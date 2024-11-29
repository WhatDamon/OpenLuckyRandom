using System;
using System.ComponentModel;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Diagnostics;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OpenLuckyRandom
{
    public partial class WndMain : Form
    {
        // ��ʼ��
        private VideoCapture capture;
        private Mat frame = new Mat();
        private CascadeClassifier faceCascade;
        private PerformanceCounter cpuCounter;
        private int frameThickness = 6;
        private string[] cascadeFiles = {
            "haarcascade_frontalface_default.xml",
            "haarcascade_frontalface_alt.xml",
            "haarcascade_frontalface_alt2.xml"
        };

        public WndMain()
        {
            InitializeComponent();
            CameraDevicesLoad();
            LoadFaceCascade(cascadeFiles[0]);

            // ��ʼ�����ܼ�����
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            // ���ֵ����
            frameThicknessNum.Value = frameThickness;
            cascadesComboBox.SelectedIndex = 0;
        }

        // ��������ͷ�豸
        private void CameraDevicesLoad()
        {
            cameraComboBox.Items.Clear();
            bool _cameraFound = false;
            foreach (var i in FindCamera.EnumDevices.Devices)
            {
                // ����豸���Ƶ������б�
                cameraComboBox.Items.Add(i);

                // ����Ƿ��ҵ��ض�����ͷ
                if (i.ToString() == "Smart Camera" || _cameraFound == false) // ϣ��һ�����������ͷ����ΪSmart Camera
                {
                    cameraComboBox.SelectedItem = i;
                    _cameraFound = true;
                }
            }
            if (cameraComboBox.Items.Count == 0)
            {
                currentStatusLabel.Text = "δ�ҵ�����ͷ";
                cameraComboBox.Enabled = false;
            }
            else
            {
                cameraComboBox.SelectedIndex = 0;  // Ĭ��ѡ���һ��
                currentStatusLabel.Text = "����";
            }
        }

        // ������������������
        private void LoadFaceCascade(string fileName)
        {
            // �ͷ�֮ǰ�� CascadeClassifier ʵ��
            if (faceCascade != null)
            {
                faceCascade.Dispose();
                faceCascade = null;
                System.GC.Collect();
            }

            string xmlPath = Path.Combine(Application.StartupPath, "cascades/", fileName);
            try
            {
                faceCascade = new CascadeClassifier(xmlPath);
                if (faceCascade.Empty())
                {
                    currentStatusLabel.Text = $"�������������� {fileName} ����ʧ��";
                }
                else
                {
                    currentStatusLabel.Text = $"�ɹ�������������������: {fileName}";
                }
            }
            catch (Exception ex)
            {
                currentStatusLabel.Text = $"������������������ʱ��������: {ex.Message}";
            }
        }

        // �����������޸�
        private void cascadesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFaceCascade(cascadeFiles[cascadesComboBox.SelectedIndex]);
        }

        // ���ˢ������ͷ��ť
        private void refreshCameraBtn_Click(object sender, EventArgs e)
        {
            CameraDevicesLoad();
        }

        private void InitializeCapture(int cameraIndex)
        {
            // �ͷžɵ�����ͷ��Դ
            if (capture != null)
            {
                capture.Release();
                capture = null;
            }

            // ��ʼ���µ�����ͷ
            capture = new VideoCapture(cameraIndex);
            if (!capture.IsOpened())
            {
                currentStatusLabel.Text = "�޷�������ͷ";
                return;
            }
            else
            {
                currentStatusLabel.Text = "����";
            }

            // ������ʱ��
            captureTimer.Start();
        }

        // ����ͷѡ�����
        private void cameraComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeCapture(cameraComboBox.SelectedIndex);
        }

        // ���Ӧ�ü�ʱ����ť
        private void applyTimerIntervalBtn_Click(object sender, EventArgs e)
        {
            captureTimer.Interval = Convert.ToInt32(timerIntervalNum.Value);
        }

        // ����߿��Ȱ�ť
        private void applyframeThicknessBtn_Click(object sender, EventArgs e)
        {
            frameThickness = Convert.ToInt32(frameThicknessNum.Value);
        }

        private void captureTimer_Tick(object sender, EventArgs e)
        {
            // ��� faceCascade �Ƿ�����ȷ����
            if (faceCascade == null || faceCascade.Empty())
            {
                currentStatusLabel.Text = "��������������δ����";
                return;
            }

            // ������ͷ��ȡһ֡ͼ��
            capture.Read(frame);
            if (frame.Empty())
            {
                currentStatusLabel.Text = "�޷���ȡ����ͷ����";
                captureTimer.Stop(); // ֹͣ��ʱ������ֹ���ڴ����CPU
                return;
            }

            using (Mat grayFrame = new Mat()) // ת��Ϊ�Ҷ�ͼ��
            {
                Cv2.CvtColor(frame, grayFrame, ColorConversionCodes.BGR2GRAY);

                // �������
                Rect[] faces = faceCascade.DetectMultiScale(grayFrame, 1.1, 10);

                // ��ԭͼ�ϻ����ο�
                foreach (Rect face in faces)
                {
                    Cv2.Rectangle(frame, face, Scalar.Red, frameThickness);
                }

                // ����״̬��ǩ
                if (faces.Length > 0)
                {
                    faceRecogStatusLabel.Text = $"��⵽ {faces.Length} ������";
                    randomBtn.Enabled = true;
                }
                else
                {
                    faceRecogStatusLabel.Text = "δʶ������";
                    randomBtn.Enabled = false;
                }
            }

            // ��Matת��ΪBitmap������ʾ��PictureBox��
            cameraCurrent.Image = frame.ToBitmap();
        }

        // ���ڹر�
        private void WndMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ֹͣ��ʱ��
            if (captureTimer != null)
            {
                captureTimer.Stop();
                captureTimer.Dispose();
            }

            // �ͷ�����ͷ��Դ
            if (capture != null)
            {
                capture.Release();
            }

            // �ͷż�����������Դ
            if (faceCascade != null)
            {
                faceCascade.Dispose();
            }
        }

        // ��������ѡ��ť
        private void randomBtn_Click(object sender, EventArgs e)
        {
            // ��ͣ��ʱ��
            captureTimer.Stop();

            // �������
            configGroupBox.Enabled = false;
            randomBtn.Enabled = false;
            backBtn.Enabled = true;

            // �������
            Mat grayFrame = new Mat();
            Cv2.CvtColor(frame, grayFrame, ColorConversionCodes.BGR2GRAY);
            Rect[] faces = faceCascade.DetectMultiScale(grayFrame, 1.1, 10);

            if (faces.Length > 0)
            {
                // ʹ��������㷨ȷ��ѡ���ĸ���
                Random rand = new Random();
                int selectedFaceIndex = rand.Next(faces.Length);
                Rect selectedFace = faces[selectedFaceIndex];

                // ǿ�����˶�
                frame.ConvertTo(frame, MatType.CV_8UC3);
                Cv2.Rectangle(frame, selectedFace, new Scalar(150, 255, 150), frameThickness + 4);
                Cv2.Rectangle(frame, selectedFace, Scalar.Green, frameThickness - 1);

                // ������ɫ��ͷ
                OpenCvSharp.Point endPoint = new OpenCvSharp.Point(selectedFace.X + selectedFace.Width / 2, selectedFace.Y - 20);
                OpenCvSharp.Point startPoint = new OpenCvSharp.Point(endPoint.X, endPoint.Y - Math.Max(selectedFace.Height / 2, 50));

                double arrowLength = 20;
                double angle = Math.PI / 6;
                OpenCvSharp.Point leftTip = new OpenCvSharp.Point(
                    (int)(endPoint.X - arrowLength * Math.Cos(angle)),
                    (int)(endPoint.Y - arrowLength * Math.Sin(angle))
                );
                OpenCvSharp.Point rightTip = new OpenCvSharp.Point(
                    (int)(endPoint.X + arrowLength * Math.Cos(angle)),
                    (int)(endPoint.Y - arrowLength * Math.Sin(angle))
                );

                Cv2.Line(frame, startPoint, endPoint, new Scalar(255, 0, 119, 215), frameThickness);
                Cv2.Line(frame, endPoint, leftTip, new Scalar(255, 0, 119, 215), frameThickness);
                Cv2.Line(frame, endPoint, rightTip, new Scalar(255, 0, 119, 215), frameThickness);

                // ��ʾ���
                cameraCurrent.Image = frame.ToBitmap();
                currentStatusLabel.Text = $"��������ֵΪ {selectedFaceIndex} ���������������ˣ�";

                // �ͷ���Դ
                GC.Collect();
            }
            else
            {
                // ���״̬�ָ�
                configGroupBox.Enabled = true;
                randomBtn.Enabled = true;
                backBtn.Enabled = false;
                currentStatusLabel.Text = "����";
            }
        }

        // ������ذ�ť
        private void backBtn_Click(object sender, EventArgs e)
        {
            // ����������ʱ��
            captureTimer.Start();

            // �������
            configGroupBox.Enabled = true;
            randomBtn.Enabled = true;
            backBtn.Enabled = false;
            currentStatusLabel.Text = "����";
        }

        // ϵͳ״̬
        private void machineStatusTimer_Tick(object sender, EventArgs e)
        {
            // ��ȡCPUʹ����
            float cpuUsage = cpuCounter.NextValue();

            // ���±�ǩ�ı�
            machineStatusLabel.Text = $"CPU: {cpuUsage:F2}%";
        }

        // ����
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskDialogPage page = new TaskDialogPage()
            {
                Text = "����һ��������ĳ�ֻ�������ʶ��������˵����\n" +
                "�汾: 1.0.0\n" +
                "�� What_Damon ���� (�ϸ�������ʱƴ�����)\n" +
                "ʹ�� Apache 2.0 ���֤��Դ\n" +
                "��Ŀ����:\n" +
                " �� OpenCV (OpenCvSharp4)\n" +
                " �� Costura.Fody\n" +
                "ע��! OpenCV ����������ʹ�õ��˲�ͬ�����֤\n" +
                "�����鿼���������⣡",
                Heading = "���� OpenLuckyRandom",
                Caption = "����",
                Icon = TaskDialogIcon.Information,
                DefaultButton = TaskDialogButton.OK,
                Buttons = { TaskDialogButton.OK }
            };

            TaskDialogButton result = TaskDialog.ShowDialog(this, page);
        }

        // �򿪿�Դ�ֿ�
        private void repoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://github.com/WhatDamon/OpenLuckyRandom");
        }
    }
}
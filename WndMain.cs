/*
 * OpenLuckyRandom by @WhatDamon
 * Licensed under Apache License 2.0
 * Copyright © 2024-present Damon Lu
 * https://github.com/WhatDamon/OpenLuckyRandom
*/

using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Reflection;

namespace OpenLuckyRandom
{
    public partial class WndMain : Form
    {
        // 初始化
        private VideoCapture capture;
        private Mat frame = new Mat();
        private CascadeClassifier faceCascade;
        private int detectionInterval = 3;
        private int lastDetectionFrameIndex = -1;
        private int frameIndex = 0;
        private int nextIndex = 0;
        private int frameThickness = 6;
        private string[] cascadeFiles = {
            "lbpcascade_frontalface.xml.xml",
            "lbpcascade_frontalface_improved.xml",
            "haarcascade_frontalface_default.xml",
            "haarcascade_frontalface_alt.xml",
            "haarcascade_frontalface_alt2.xml"
        };
        private Dictionary<int, Rect> indexedFaceRectangles = new Dictionary<int, Rect>();

        public WndMain()
        {
            InitializeComponent();
            // 组件值定义
            frameThicknessNum.Value = frameThickness;
            cascadesComboBox.SelectedIndex = 0;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            // 设置窗体标题
            this.Text = $"OpenLuckyRandom {Assembly.GetExecutingAssembly().GetName().Version} ({Misc.Runtime.GetArch()}) {(Misc.Runtime.IsDebug() ? "[Debug]" : "")}";

            // 摄像初始化
            CameraDevicesLoad();
            LoadFaceCascade(cascadeFiles[0]);
        }

        // 加载摄像头设备
        private async Task CameraDevicesLoad()
        {
            // 确保只在窗体加载完成后执行
            if (!this.IsHandleCreated)
            {
                await Task.Delay(100);
                await CameraDevicesLoad();
                return;
            }

            await Task.Run(() =>
            {
                cameraComboBox.Invoke(new Action(() => cameraComboBox.Items.Clear()));
                bool _cameraFound = false;
                foreach (var i in FindCamera.EnumDevices.Devices)
                {
                    // 添加设备名称到下拉列表
                    cameraComboBox.Invoke(new Action(() => cameraComboBox.Items.Add(i)));
                    // 检查是否找到特定摄像头
                    if (i.ToString() == "Smart_Camera" || !_cameraFound) // “Smart_Camera”是希沃一体机顶部摄像头名称
                    {
                        cameraComboBox.Invoke(new Action(() => cameraComboBox.SelectedItem = i));
                        _cameraFound = true;
                    }
                }

                if (cameraComboBox.Items.Count == 0)
                {
                    Invoke(new Action(() => currentStatusLabel.Text = "未找到摄像头"));
                    cameraComboBox.Invoke(new Action(() => cameraComboBox.Enabled = false));
                }
                else
                {
                    Invoke(new Action(() => cameraComboBox.SelectedIndex = 0));  // 默认选择第一个
                    Invoke(new Action(() => currentStatusLabel.Text = "就绪"));
                }
            });
        }

        // 加载人脸级联分类器
        private async Task LoadFaceCascade(string fileName)
        {
            // 确保只在窗体加载完成后执行
            if (!this.IsHandleCreated)
            {
                await Task.Delay(100);
                await LoadFaceCascade(fileName);
                return;
            }

            await Task.Run(() =>
            {
                // 释放之前的 CascadeClassifier 实例
                if (faceCascade != null)
                {
                    faceCascade.Dispose();
                    faceCascade = null;
                }
                string xmlPath = Path.Combine(Application.StartupPath, "cascades/", fileName);
                try
                {
                    faceCascade = new CascadeClassifier(xmlPath);
                    if (faceCascade.Empty())
                    {
                        Invoke(new Action(() => currentStatusLabel.Text = $"人脸级联分类器 {fileName} 加载失败"));
                    }
                    else
                    {
                        Invoke(new Action(() => currentStatusLabel.Text = $"成功加载人脸级联分类器: {fileName}"));
                    }
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() => currentStatusLabel.Text = $"加载人脸级联分类器时发生错误: {ex.Message}"));
                }
            });
        }

        // 级联分类器修改
        private void cascadesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFaceCascade(cascadeFiles[cascadesComboBox.SelectedIndex]);
        }

        // 点击刷新摄像头按钮
        private void refreshCameraBtn_Click(object sender, EventArgs e)
        {
            CameraDevicesLoad();
        }

        // 初始化摄像头
        private void InitializeCapture(int cameraIndex)
        {
            // 释放旧的摄像头资源
            if (capture != null)
            {
                capture.Release();
                capture = null;
            }

            // 初始化新的摄像头
            capture = new VideoCapture(cameraIndex);
            if (!capture.IsOpened())
            {
                currentStatusLabel.Text = "无法打开摄像头";
                return;
            }
            else
            {
                currentStatusLabel.Text = "就绪";
            }

            // 启动计时器
            streamTimer.Start();
        }

        // 点击切换配置面板按钮
        private void toggleConfigBtn_Click(object sender, EventArgs e)
        {
            if (configPanel.Visible)
            {
                configPanel.Visible = false;
                toggleConfigBtn.Text = "显示配置面板";
            }
            else
            {
                configPanel.Visible = true;
                toggleConfigBtn.Text = "隐藏配置面板";
            }
        }

        // 摄像头选择更改
        private void cameraComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeCapture(cameraComboBox.SelectedIndex);
        }

        // 点击应用帧率按钮
        private void applyFpsBtn_Click(object sender, EventArgs e)
        {
            streamTimer.Interval = (int)Math.Max(1, 1000 / streamFpsNum.Value);
            if (streamFpsNum.Value < faceRecognFpsNum.Value)
            {
                faceRecognFpsNum.Value = streamFpsNum.Value;
                statusLabel.Text = "人脸识别帧率不能大于视频流帧率";
            }
            detectionInterval = (int)Math.Max(1, streamFpsNum.Value / faceRecognFpsNum.Value);
        }

        // 点击边框厚度按钮
        private void applyframeThicknessBtn_Click(object sender, EventArgs e)
        {
            frameThickness = Convert.ToInt32(frameThicknessNum.Value);
        }

        // 检测人脸
        private void DetectFaces()
        {
            try
            {
                lastDetectionFrameIndex = frameIndex;

                double scale = 0.75;
                OpenCvSharp.Size newSize = new OpenCvSharp.Size(Math.Round(frame.Width * scale), Math.Round(frame.Height * scale));
                using (Mat resizedFrame = new Mat())
                {
                    Cv2.Resize(frame, resizedFrame, newSize);

                    Rect[] detectedFaces = faceCascade.DetectMultiScale(resizedFrame, scaleFactor: 1.1, minNeighbors: 5, minSize: new OpenCvSharp.Size(30, 30));

                    indexedFaceRectangles.Clear();
                    nextIndex = 0;
                    foreach (var rect in detectedFaces)
                    {
                        int x = (int)(rect.X * scale);
                        int y = (int)(rect.Y * scale);
                        int width = (int)(rect.Width * scale);
                        int height = (int)(rect.Height * scale);

                        indexedFaceRectangles[nextIndex] = new Rect(x, y, width, height);
                        nextIndex++;
                    }
                }

                faceRecogStatusLabel.Text = $"检测到 {indexedFaceRectangles.Count} 张人脸";
            }
            catch (Exception ex)
            {
                faceRecogStatusLabel.Text = $"检测人脸时发生错误: {ex.Message}";
            }
        }

        // 在 currentCamera 上绘制人脸矩形
        private void DrawFacesOnPictureBox()
        {
            try
            {
                using (Bitmap bitmap = BitmapConverter.ToBitmap(frame))
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    foreach (var kvp in indexedFaceRectangles)
                    {
                        var rect = kvp.Value;
                        int index = kvp.Key;
                        g.DrawRectangle(new Pen(Color.Red, frameThickness), rect.X, rect.Y, rect.Width, rect.Height);
                    }
                    cameraCurrent.Image?.Dispose();
                    cameraCurrent.Image = bitmap;
                }
            }
            catch (Exception ex)
            {
                currentStatusLabel.Text = $"绘制人脸矩形时发生错误: {ex.Message}";
            }
        }

        // 视频流计时器
        private void streamTimer_Tick(object sender, EventArgs e)
        {
            // 检查 faceCascade 是否已正确加载
            if (faceCascade == null || faceCascade.Empty())
            {
                currentStatusLabel.Text = "人脸级联分类器未加载";
                return;
            }

            // 从摄像头读取一帧图像
            try
            {
                if (capture.Read(frame))
                {
                    frameIndex++;
                    bool shouldDetect = (frameIndex - lastDetectionFrameIndex) >= detectionInterval;

                    if (shouldDetect)
                    {
                        DetectFaces();
                    }

                    DrawFacesOnPictureBox();
                }
            }
            catch (Exception ex)
            {
                currentStatusLabel.Text = $"发生错误: {ex.Message}";
                streamTimer.Stop(); // 停止计时器，防止爆内存或者CPU
            }
        }

        // 窗口关闭
        private void WndMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 确保计时器停止后再释放资源
            if (streamTimer != null)
            {
                streamTimer.Stop();
                streamTimer.Dispose();
            }

            // 确保在UI线程上执行
            this.Invoke((MethodInvoker)delegate {
                if (capture != null)
                {
                    capture.Release();
                }
                if (faceCascade != null)
                {
                    faceCascade.Dispose();
                }
            });
        }

        // 点击随机抽选按钮
        private void randomBtn_Click(object sender, EventArgs e)
        {
            // 暂停计时器
            streamTimer.Stop();

            // 组件控制
            configGroupBox.Enabled = false;
            randomBtn.Enabled = false;
            backBtn.Enabled = true;
            try
            {
                if (indexedFaceRectangles.Count > 0)
                {
                    // 随机选择一个索引
                    Random random = new Random();
                    int emphasizedIndex = random.Next(indexedFaceRectangles.Count);

                    // 获取对应的Rect对象
                    Rect selectedFace = indexedFaceRectangles[emphasizedIndex];

                    // 使用其他颜色（例如绿色）绘制矩形框并添加紫色箭头
                    using (Mat frameCopy = frame.Clone())
                    {
                        int frameThickness = 2;

                        // 强调幸运儿
                        Cv2.Rectangle(frameCopy, selectedFace, new Scalar(150, 255, 150), frameThickness + 4);
                        Cv2.Rectangle(frameCopy, selectedFace, Scalar.Green, frameThickness - 1);

                        // 绘制紫色箭头
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

                        Cv2.Line(frameCopy, startPoint, endPoint, new Scalar(255, 0, 119, 215), frameThickness);
                        Cv2.Line(frameCopy, endPoint, leftTip, new Scalar(255, 0, 119, 215), frameThickness);
                        Cv2.Line(frameCopy, endPoint, rightTip, new Scalar(255, 0, 119, 215), frameThickness);

                        // 将修改后的帧转换为Bitmap并在PictureBox中显示
                        using (Bitmap bitmap = BitmapConverter.ToBitmap(frameCopy))
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            cameraCurrent.Image?.Dispose(); // 确保之前的图像被释放
                            cameraCurrent.Image = bitmap;
                        }
                    }

                    currentStatusLabel.Text = $"就你啦！索引值为 {emphasizedIndex} 的脸";
                }
            }
            finally
            {
                // 组件状态恢复
                configGroupBox.Enabled = true;
                randomBtn.Enabled = true;
                backBtn.Enabled = false;
                currentStatusLabel.Text = "就绪";
            }
        }

        // 点击返回按钮
        private void backBtn_Click(object sender, EventArgs e)
        {
            // 重新启动计时器
            streamTimer.Start();

            // 组件控制
            configGroupBox.Enabled = true;
            randomBtn.Enabled = true;
            backBtn.Enabled = false;
            currentStatusLabel.Text = "就绪";
        }

        // 关于
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Misc.aboutDialogShow(this);
        }

        // 打开开源仓库
        private void repoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Misc.openRepoURL();
        }
    }
}
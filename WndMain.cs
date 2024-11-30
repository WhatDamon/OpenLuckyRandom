/*
 * OpenLuckyRandom by @WhatDamon
 * Licensed under Apache License 2.0
 * Copyright © 2024-present Damon Lu
 * https://github.com/WhatDamon/OpenLuckyRandom
*/

using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace OpenLuckyRandom
{
    public partial class WndMain : Form
    {
        // 初始化
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

            // 初始化性能计数器
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            // 组件值定义
            frameThicknessNum.Value = frameThickness;
            cascadesComboBox.SelectedIndex = 0;

            // 检查当前进程架构
            string _architecture;
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    _architecture = "x86";
                    break;
                case Architecture.X64:
                    _architecture = "x64";
                    break;
                case Architecture.Arm:
                    _architecture = "ARM32";
                    break;
                case Architecture.Arm64:
                    _architecture = "ARM64";
                    break;
                default:
                    _architecture = "Unknown";
                    break;
            }

            // 检查是否为调试版本
            bool _isDebugBuild = typeof(WndMain).Assembly.GetCustomAttributes(false)
                .OfType<DebuggableAttribute>()
                .Any(da => da.IsJITTrackingEnabled || da.IsJITOptimizerDisabled);

            // 设置窗体标题
            this.Text = $"OpenLuckyRandom ({_architecture}) {(_isDebugBuild ? "[Debug]" : "")}";
        }

        // 加载摄像头设备
        private void CameraDevicesLoad()
        {
            // 顺便释放点垃圾
            GC.Collect();

            // 清空下拉列表
            cameraComboBox.Items.Clear();
            bool _cameraFound = false;
            foreach (var i in FindCamera.EnumDevices.Devices)
            {
                // 添加设备名称到下拉列表
                cameraComboBox.Items.Add(i);

                // 检查是否找到特定摄像头
                if (i.ToString() == "Smart Camera" || _cameraFound == false) // 希沃一体机顶部摄像头名称为Smart Camera
                {
                    cameraComboBox.SelectedItem = i;
                    _cameraFound = true;
                }
            }
            if (cameraComboBox.Items.Count == 0)
            {
                currentStatusLabel.Text = "未找到摄像头";
                cameraComboBox.Enabled = false;
            }
            else
            {
                cameraComboBox.SelectedIndex = 0;  // 默认选择第一个
                currentStatusLabel.Text = "就绪";
            }
        }

        // 加载人脸级联分类器
        private void LoadFaceCascade(string fileName)
        {
            // 释放之前的 CascadeClassifier 实例
            if (faceCascade != null)
            {
                faceCascade.Dispose();
                faceCascade = null;
                GC.Collect();
            }

            string xmlPath = Path.Combine(Application.StartupPath, "cascades/", fileName);
            try
            {
                faceCascade = new CascadeClassifier(xmlPath);
                if (faceCascade.Empty())
                {
                    currentStatusLabel.Text = $"人脸级联分类器 {fileName} 加载失败";
                }
                else
                {
                    currentStatusLabel.Text = $"成功加载人脸级联分类器: {fileName}";
                }

                // 刷新显示
                this.Invalidate(true);
                this.Update();
            }
            catch (Exception ex)
            {
                currentStatusLabel.Text = $"加载人脸级联分类器时发生错误: {ex.Message}";
            }
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
            captureTimer.Start();
        }

        // 摄像头选择更改
        private void cameraComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeCapture(cameraComboBox.SelectedIndex);
        }

        // 点击应用计时器按钮
        private void applyTimerIntervalBtn_Click(object sender, EventArgs e)
        {
            captureTimer.Interval = Convert.ToInt32(timerIntervalNum.Value);
        }

        // 点击边框厚度按钮
        private void applyframeThicknessBtn_Click(object sender, EventArgs e)
        {
            frameThickness = Convert.ToInt32(frameThicknessNum.Value);
        }

        private void captureTimer_Tick(object sender, EventArgs e)
        {
            // 检查 faceCascade 是否已正确加载
            if (faceCascade == null || faceCascade.Empty())
            {
                currentStatusLabel.Text = "人脸级联分类器未加载";
                return;
            }

            // 从摄像头读取一帧图像
            capture.Read(frame);
            if (frame.Empty())
            {
                currentStatusLabel.Text = "无法读取摄像头数据";
                captureTimer.Stop(); // 停止计时器，防止爆内存或者CPU
                return;
            }

            using (Mat grayFrame = new Mat()) // 转换为灰度图像
            {
                Cv2.CvtColor(frame, grayFrame, ColorConversionCodes.BGR2GRAY);

                // 检测人脸
                Rect[] faces = faceCascade.DetectMultiScale(grayFrame, 1.1, 10);

                // 在原图上画矩形框
                foreach (Rect face in faces)
                {
                    Cv2.Rectangle(frame, face, Scalar.Red, frameThickness);
                }

                // 更新状态标签
                if (faces.Length > 0)
                {
                    faceRecogStatusLabel.Text = $"检测到 {faces.Length} 个人脸";
                    randomBtn.Enabled = true;
                }
                else
                {
                    faceRecogStatusLabel.Text = "未识别到人脸";
                    randomBtn.Enabled = false;
                }
            }

            // 将Mat转换为Bitmap，并显示在PictureBox中
            cameraCurrent.Image = frame.ToBitmap();
        }

        // 窗口关闭
        private void WndMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 停止定时器
            if (captureTimer != null)
            {
                captureTimer.Stop();
                captureTimer.Dispose();
            }

            // 释放摄像头资源
            if (capture != null)
            {
                capture.Release();
            }

            // 释放级联分类器资源
            if (faceCascade != null)
            {
                faceCascade.Dispose();
            }
        }

        // 点击随机抽选按钮
        private void randomBtn_Click(object sender, EventArgs e)
        {
            // 暂停计时器
            captureTimer.Stop();

            // 组件控制
            configGroupBox.Enabled = false;
            randomBtn.Enabled = false;
            backBtn.Enabled = true;

            // 检测人脸
            Mat grayFrame = new Mat();
            Cv2.CvtColor(frame, grayFrame, ColorConversionCodes.BGR2GRAY);
            Rect[] faces = faceCascade.DetectMultiScale(grayFrame, 1.1, 10);

            if (faces.Length > 0)
            {
                // 使用随机数算法确定选择哪个人
                Random rand = new Random();
                int selectedFaceIndex = rand.Next(faces.Length);
                Rect selectedFace = faces[selectedFaceIndex];

                // 强调幸运儿
                frame.ConvertTo(frame, MatType.CV_8UC3);
                Cv2.Rectangle(frame, selectedFace, new Scalar(150, 255, 150), frameThickness + 4);
                Cv2.Rectangle(frame, selectedFace, Scalar.Green, frameThickness - 1);

                // 绘制蓝色箭头
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

                // 显示结果
                cameraCurrent.Image = frame.ToBitmap();
                currentStatusLabel.Text = $"抽中索引值为 {selectedFaceIndex} 的脸，孩子你中了！";

                // 释放资源
                GC.Collect();
            }
            else
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
            captureTimer.Start();

            // 组件控制
            configGroupBox.Enabled = true;
            randomBtn.Enabled = true;
            backBtn.Enabled = false;
            currentStatusLabel.Text = "就绪";
        }

        // 系统状态
        private void machineStatusTimer_Tick(object sender, EventArgs e)
        {
            // 获取CPU使用率
            float cpuUsage = cpuCounter.NextValue();

            // 更新标签文本
            machineStatusLabel.Text = $"CPU: {cpuUsage:F2}%";
        }

        // 关于
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 顺便垃圾回收下
            GC.Collect();

            TaskDialogPage page = new TaskDialogPage()
            {
                Text = "这是一个启发于某沃基于人脸识别随机抽人的玩具\n" +
                "版本: 1.1.0\n" +
                "由 What_Damon 开发 (严格意义上时拼贴组合)\n" +
                "使用 Apache 2.0 许可证开源\n" +
                "项目依赖:\n" +
                " · OpenCvSharp4\n" +
                " · OpenCvSharp4.Extensions\n" +
                " · OpenCvSharp4.runtime.win\n" +
                "注意! OpenCV 的依赖可能使用到了不同的许可证\n" +
                "请酌情考虑商用问题！",
                Heading = "关于 OpenLuckyRandom",
                Caption = "关于",
                Icon = TaskDialogIcon.Information,
                DefaultButton = TaskDialogButton.OK,
                Buttons = { TaskDialogButton.OK }
            };

            TaskDialogButton result = TaskDialog.ShowDialog(this, page);
        }

        // 打开开源仓库
        private void repoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://github.com/WhatDamon/OpenLuckyRandom");
        }
    }
}
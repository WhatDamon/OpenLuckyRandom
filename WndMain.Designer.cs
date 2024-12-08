namespace OpenLuckyRandom
{
    partial class WndMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cameraCurrent = new PictureBox();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            currentStatusLabel = new ToolStripStatusLabel();
            optionsDropDownBtn = new ToolStripDropDownButton();
            repoToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            streamTimer = new System.Windows.Forms.Timer(components);
            randomBtn = new Button();
            backBtn = new Button();
            helpLabel = new Label();
            configPanel = new Panel();
            configGroupBox = new GroupBox();
            faceRecognFpsNum = new NumericUpDown();
            faceRecognFpsLabel = new Label();
            cascadesComboBox = new ComboBox();
            cascadesLabel = new Label();
            frameThicknessLabel = new Label();
            applyframeThicknessBtn = new Button();
            frameThicknessNum = new NumericUpDown();
            applyFpsBtn = new Button();
            streamFpsNum = new NumericUpDown();
            streamFpsLabel = new Label();
            refreshCameraBtn = new Button();
            chooseCameraLabel = new Label();
            cameraComboBox = new ComboBox();
            toggleConfigBtn = new Button();
            faceRecogStatusLabel = new Label();
            openLogToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)cameraCurrent).BeginInit();
            statusStrip.SuspendLayout();
            configPanel.SuspendLayout();
            configGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)faceRecognFpsNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)frameThicknessNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)streamFpsNum).BeginInit();
            SuspendLayout();
            // 
            // cameraCurrent
            // 
            cameraCurrent.BackColor = SystemColors.ActiveBorder;
            cameraCurrent.BorderStyle = BorderStyle.FixedSingle;
            cameraCurrent.Location = new Point(12, 12);
            cameraCurrent.Name = "cameraCurrent";
            cameraCurrent.Size = new Size(1394, 712);
            cameraCurrent.SizeMode = PictureBoxSizeMode.Zoom;
            cameraCurrent.TabIndex = 0;
            cameraCurrent.TabStop = false;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel, currentStatusLabel, optionsDropDownBtn });
            statusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            statusStrip.Location = new Point(0, 808);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1418, 36);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.BorderSides = ToolStripStatusLabelBorderSides.Right;
            statusLabel.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(70, 29);
            statusLabel.Text = "状态：";
            // 
            // currentStatusLabel
            // 
            currentStatusLabel.Name = "currentStatusLabel";
            currentStatusLabel.Size = new Size(46, 29);
            currentStatusLabel.Text = "就绪";
            // 
            // optionsDropDownBtn
            // 
            optionsDropDownBtn.Alignment = ToolStripItemAlignment.Right;
            optionsDropDownBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            optionsDropDownBtn.DropDownItems.AddRange(new ToolStripItem[] { openLogToolStripMenuItem, repoToolStripMenuItem, aboutToolStripMenuItem });
            optionsDropDownBtn.ImageTransparentColor = Color.Magenta;
            optionsDropDownBtn.Name = "optionsDropDownBtn";
            optionsDropDownBtn.Size = new Size(64, 33);
            optionsDropDownBtn.Text = "选项";
            // 
            // repoToolStripMenuItem
            // 
            repoToolStripMenuItem.Name = "repoToolStripMenuItem";
            repoToolStripMenuItem.Size = new Size(270, 34);
            repoToolStripMenuItem.Text = "开源仓库";
            repoToolStripMenuItem.Click += repoToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(270, 34);
            aboutToolStripMenuItem.Text = "关于";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // streamTimer
            // 
            streamTimer.Interval = 40;
            streamTimer.Tick += streamTimer_Tick;
            // 
            // randomBtn
            // 
            randomBtn.Enabled = false;
            randomBtn.Font = new Font("Microsoft YaHei UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 134);
            randomBtn.ForeColor = SystemColors.Highlight;
            randomBtn.Location = new Point(1001, 730);
            randomBtn.Name = "randomBtn";
            randomBtn.Size = new Size(405, 71);
            randomBtn.TabIndex = 4;
            randomBtn.Text = "开始抽选";
            randomBtn.UseVisualStyleBackColor = true;
            randomBtn.Click += randomBtn_Click;
            // 
            // backBtn
            // 
            backBtn.Enabled = false;
            backBtn.Font = new Font("Microsoft YaHei UI", 10F);
            backBtn.Location = new Point(916, 730);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(79, 71);
            backBtn.TabIndex = 5;
            backBtn.Text = "返回";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // helpLabel
            // 
            helpLabel.AutoSize = true;
            helpLabel.Font = new Font("Microsoft YaHei UI", 7F, FontStyle.Italic, GraphicsUnit.Point, 134);
            helpLabel.ForeColor = SystemColors.ControlDarkDark;
            helpLabel.Location = new Point(632, 746);
            helpLabel.Name = "helpLabel";
            helpLabel.Size = new Size(281, 40);
            helpLabel.TabIndex = 6;
            helpLabel.Text = "如果遇到了内容停止且按下抽选无效\r\n请点击“配置面板中”选择摄像头的“刷新”恢复\r\n";
            // 
            // configPanel
            // 
            configPanel.BorderStyle = BorderStyle.FixedSingle;
            configPanel.Controls.Add(configGroupBox);
            configPanel.Location = new Point(18, 489);
            configPanel.Name = "configPanel";
            configPanel.Size = new Size(725, 229);
            configPanel.TabIndex = 7;
            configPanel.Visible = false;
            // 
            // configGroupBox
            // 
            configGroupBox.Controls.Add(faceRecognFpsNum);
            configGroupBox.Controls.Add(faceRecognFpsLabel);
            configGroupBox.Controls.Add(cascadesComboBox);
            configGroupBox.Controls.Add(cascadesLabel);
            configGroupBox.Controls.Add(frameThicknessLabel);
            configGroupBox.Controls.Add(applyframeThicknessBtn);
            configGroupBox.Controls.Add(frameThicknessNum);
            configGroupBox.Controls.Add(applyFpsBtn);
            configGroupBox.Controls.Add(streamFpsNum);
            configGroupBox.Controls.Add(streamFpsLabel);
            configGroupBox.Controls.Add(refreshCameraBtn);
            configGroupBox.Controls.Add(chooseCameraLabel);
            configGroupBox.Controls.Add(cameraComboBox);
            configGroupBox.Location = new Point(19, 15);
            configGroupBox.Name = "configGroupBox";
            configGroupBox.Size = new Size(681, 195);
            configGroupBox.TabIndex = 2;
            configGroupBox.TabStop = false;
            configGroupBox.Text = "配置";
            // 
            // faceRecognFpsNum
            // 
            faceRecognFpsNum.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            faceRecognFpsNum.Location = new Point(172, 116);
            faceRecognFpsNum.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            faceRecognFpsNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            faceRecognFpsNum.Name = "faceRecognFpsNum";
            faceRecognFpsNum.Size = new Size(165, 30);
            faceRecognFpsNum.TabIndex = 14;
            faceRecognFpsNum.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // faceRecognFpsLabel
            // 
            faceRecognFpsLabel.AutoSize = true;
            faceRecognFpsLabel.Location = new Point(172, 89);
            faceRecognFpsLabel.Name = "faceRecognFpsLabel";
            faceRecognFpsLabel.Size = new Size(122, 24);
            faceRecognFpsLabel.TabIndex = 13;
            faceRecognFpsLabel.Text = "人脸检测帧率:";
            // 
            // cascadesComboBox
            // 
            cascadesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cascadesComboBox.FormattingEnabled = true;
            cascadesComboBox.Items.AddRange(new object[] { "LBP (默认)", "LBP Improved", "Haar Default", "Haar Alt", "Haar Alt2" });
            cascadesComboBox.Location = new Point(343, 56);
            cascadesComboBox.Name = "cascadesComboBox";
            cascadesComboBox.Size = new Size(331, 32);
            cascadesComboBox.TabIndex = 12;
            cascadesComboBox.SelectedIndexChanged += cascadesComboBox_SelectedIndexChanged;
            // 
            // cascadesLabel
            // 
            cascadesLabel.AutoSize = true;
            cascadesLabel.Location = new Point(343, 29);
            cascadesLabel.Name = "cascadesLabel";
            cascadesLabel.Size = new Size(140, 24);
            cascadesLabel.TabIndex = 11;
            cascadesLabel.Text = "选择级联分类器:";
            // 
            // frameThicknessLabel
            // 
            frameThicknessLabel.AutoSize = true;
            frameThicknessLabel.Location = new Point(343, 91);
            frameThicknessLabel.Name = "frameThicknessLabel";
            frameThicknessLabel.Size = new Size(86, 24);
            frameThicknessLabel.TabIndex = 9;
            frameThicknessLabel.Text = "边框厚度:";
            // 
            // applyframeThicknessBtn
            // 
            applyframeThicknessBtn.Location = new Point(614, 114);
            applyframeThicknessBtn.Name = "applyframeThicknessBtn";
            applyframeThicknessBtn.Size = new Size(60, 34);
            applyframeThicknessBtn.TabIndex = 8;
            applyframeThicknessBtn.Text = "应用";
            applyframeThicknessBtn.UseVisualStyleBackColor = true;
            applyframeThicknessBtn.Click += applyframeThicknessBtn_Click;
            // 
            // frameThicknessNum
            // 
            frameThicknessNum.Location = new Point(343, 117);
            frameThicknessNum.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            frameThicknessNum.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            frameThicknessNum.Name = "frameThicknessNum";
            frameThicknessNum.Size = new Size(265, 30);
            frameThicknessNum.TabIndex = 7;
            frameThicknessNum.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // applyFpsBtn
            // 
            applyFpsBtn.Location = new Point(277, 152);
            applyFpsBtn.Name = "applyFpsBtn";
            applyFpsBtn.Size = new Size(60, 34);
            applyFpsBtn.TabIndex = 5;
            applyFpsBtn.Text = "应用";
            applyFpsBtn.UseVisualStyleBackColor = true;
            applyFpsBtn.Click += applyFpsBtn_Click;
            // 
            // streamFpsNum
            // 
            streamFpsNum.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            streamFpsNum.Location = new Point(6, 116);
            streamFpsNum.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            streamFpsNum.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            streamFpsNum.Name = "streamFpsNum";
            streamFpsNum.Size = new Size(165, 30);
            streamFpsNum.TabIndex = 4;
            streamFpsNum.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // streamFpsLabel
            // 
            streamFpsLabel.AutoSize = true;
            streamFpsLabel.Location = new Point(6, 89);
            streamFpsLabel.Name = "streamFpsLabel";
            streamFpsLabel.Size = new Size(104, 24);
            streamFpsLabel.TabIndex = 3;
            streamFpsLabel.Text = "视频流帧率:";
            // 
            // refreshCameraBtn
            // 
            refreshCameraBtn.Location = new Point(277, 54);
            refreshCameraBtn.Name = "refreshCameraBtn";
            refreshCameraBtn.Size = new Size(60, 34);
            refreshCameraBtn.TabIndex = 2;
            refreshCameraBtn.Text = "刷新";
            refreshCameraBtn.UseVisualStyleBackColor = true;
            refreshCameraBtn.Click += refreshCameraBtn_Click;
            // 
            // chooseCameraLabel
            // 
            chooseCameraLabel.AutoSize = true;
            chooseCameraLabel.Location = new Point(6, 29);
            chooseCameraLabel.Name = "chooseCameraLabel";
            chooseCameraLabel.Size = new Size(104, 24);
            chooseCameraLabel.TabIndex = 1;
            chooseCameraLabel.Text = "选择摄像头:";
            // 
            // cameraComboBox
            // 
            cameraComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cameraComboBox.FormattingEnabled = true;
            cameraComboBox.Location = new Point(6, 54);
            cameraComboBox.Name = "cameraComboBox";
            cameraComboBox.Size = new Size(265, 32);
            cameraComboBox.TabIndex = 0;
            // 
            // toggleConfigBtn
            // 
            toggleConfigBtn.Location = new Point(12, 730);
            toggleConfigBtn.Name = "toggleConfigBtn";
            toggleConfigBtn.Size = new Size(103, 71);
            toggleConfigBtn.TabIndex = 9;
            toggleConfigBtn.Text = "显示配置面板";
            toggleConfigBtn.UseVisualStyleBackColor = true;
            toggleConfigBtn.Click += toggleConfigBtn_Click;
            // 
            // faceRecogStatusLabel
            // 
            faceRecogStatusLabel.AutoSize = true;
            faceRecogStatusLabel.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold);
            faceRecogStatusLabel.Location = new Point(121, 746);
            faceRecogStatusLabel.Name = "faceRecogStatusLabel";
            faceRecogStatusLabel.Size = new Size(197, 40);
            faceRecogStatusLabel.TabIndex = 10;
            faceRecogStatusLabel.Text = "未识别到人脸";
            // 
            // openLogToolStripMenuItem
            // 
            openLogToolStripMenuItem.Name = "openLogToolStripMenuItem";
            openLogToolStripMenuItem.Size = new Size(270, 34);
            openLogToolStripMenuItem.Text = "查看日志";
            openLogToolStripMenuItem.Click += openLogToolStripMenuItem_Click;
            // 
            // WndMain
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1418, 844);
            Controls.Add(configPanel);
            Controls.Add(faceRecogStatusLabel);
            Controls.Add(toggleConfigBtn);
            Controls.Add(helpLabel);
            Controls.Add(backBtn);
            Controls.Add(randomBtn);
            Controls.Add(statusStrip);
            Controls.Add(cameraCurrent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "WndMain";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OpenLuckyRandom";
            FormClosing += WndMain_FormClosing;
            ((System.ComponentModel.ISupportInitialize)cameraCurrent).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            configPanel.ResumeLayout(false);
            configGroupBox.ResumeLayout(false);
            configGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)faceRecognFpsNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)frameThicknessNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)streamFpsNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox cameraCurrent;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;
        private ToolStripStatusLabel currentStatusLabel;
        private System.Windows.Forms.Timer streamTimer;
        private ToolStripDropDownButton optionsDropDownBtn;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Button randomBtn;
        private Button backBtn;
        private Label helpLabel;
        private ToolStripMenuItem repoToolStripMenuItem;
        private Panel configPanel;
        private GroupBox configGroupBox;
        private ComboBox cascadesComboBox;
        private Label cascadesLabel;
        private Label frameThicknessLabel;
        private Button applyframeThicknessBtn;
        private NumericUpDown frameThicknessNum;
        private Button applyFpsBtn;
        private NumericUpDown streamFpsNum;
        private Label streamFpsLabel;
        private Button refreshCameraBtn;
        private Label chooseCameraLabel;
        private ComboBox cameraComboBox;
        private Button toggleConfigBtn;
        private Label faceRecogStatusLabel;
        private NumericUpDown faceRecognFpsNum;
        private Label faceRecognFpsLabel;
        private ToolStripMenuItem openLogToolStripMenuItem;
    }
}

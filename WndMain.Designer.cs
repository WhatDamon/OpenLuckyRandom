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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndMain));
            cameraCurrent = new PictureBox();
            configGroupBox = new GroupBox();
            cascadesComboBox = new ComboBox();
            cascadesLabel = new Label();
            frameThicknessWarningLabel = new Label();
            frameThicknessLabel = new Label();
            applyframeThicknessBtn = new Button();
            frameThicknessNum = new NumericUpDown();
            timerIntervalWarningLabel = new Label();
            applyTimerIntervalBtn = new Button();
            timerIntervalNum = new NumericUpDown();
            timerIntervalLabel = new Label();
            refreshCameraBtn = new Button();
            chooseCameraLabel = new Label();
            cameraComboBox = new ComboBox();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            currentStatusLabel = new ToolStripStatusLabel();
            optionsDropDownBtn = new ToolStripDropDownButton();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            machineStatusLabel = new ToolStripStatusLabel();
            captureTimer = new System.Windows.Forms.Timer(components);
            infoGroupBox = new GroupBox();
            faceRecogStatusLabel = new Label();
            machineStatusTimer = new System.Windows.Forms.Timer(components);
            randomBtn = new Button();
            backBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)cameraCurrent).BeginInit();
            configGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)frameThicknessNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)timerIntervalNum).BeginInit();
            statusStrip.SuspendLayout();
            infoGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // cameraCurrent
            // 
            cameraCurrent.BackColor = SystemColors.ActiveBorder;
            cameraCurrent.BorderStyle = BorderStyle.FixedSingle;
            cameraCurrent.Location = new Point(12, 12);
            cameraCurrent.Name = "cameraCurrent";
            cameraCurrent.Size = new Size(1394, 584);
            cameraCurrent.SizeMode = PictureBoxSizeMode.Zoom;
            cameraCurrent.TabIndex = 0;
            cameraCurrent.TabStop = false;
            // 
            // configGroupBox
            // 
            configGroupBox.Controls.Add(cascadesComboBox);
            configGroupBox.Controls.Add(cascadesLabel);
            configGroupBox.Controls.Add(frameThicknessWarningLabel);
            configGroupBox.Controls.Add(frameThicknessLabel);
            configGroupBox.Controls.Add(applyframeThicknessBtn);
            configGroupBox.Controls.Add(frameThicknessNum);
            configGroupBox.Controls.Add(timerIntervalWarningLabel);
            configGroupBox.Controls.Add(applyTimerIntervalBtn);
            configGroupBox.Controls.Add(timerIntervalNum);
            configGroupBox.Controls.Add(timerIntervalLabel);
            configGroupBox.Controls.Add(refreshCameraBtn);
            configGroupBox.Controls.Add(chooseCameraLabel);
            configGroupBox.Controls.Add(cameraComboBox);
            configGroupBox.Location = new Point(12, 602);
            configGroupBox.Name = "configGroupBox";
            configGroupBox.Size = new Size(681, 199);
            configGroupBox.TabIndex = 1;
            configGroupBox.TabStop = false;
            configGroupBox.Text = "配置";
            // 
            // cascadesComboBox
            // 
            cascadesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cascadesComboBox.FormattingEnabled = true;
            cascadesComboBox.Items.AddRange(new object[] { "Default", "Alt", "Alt2" });
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
            // frameThicknessWarningLabel
            // 
            frameThicknessWarningLabel.AutoSize = true;
            frameThicknessWarningLabel.Font = new Font("Microsoft YaHei UI", 7F, FontStyle.Italic);
            frameThicknessWarningLabel.ForeColor = Color.Red;
            frameThicknessWarningLabel.Location = new Point(343, 151);
            frameThicknessWarningLabel.Name = "frameThicknessWarningLabel";
            frameThicknessWarningLabel.Size = new Size(233, 20);
            frameThicknessWarningLabel.TabIndex = 10;
            frameThicknessWarningLabel.Text = "数值过高可能会导致脸被边框挡住！";
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
            // timerIntervalWarningLabel
            // 
            timerIntervalWarningLabel.AutoSize = true;
            timerIntervalWarningLabel.Font = new Font("Microsoft YaHei UI", 7F, FontStyle.Italic);
            timerIntervalWarningLabel.ForeColor = Color.Red;
            timerIntervalWarningLabel.Location = new Point(6, 149);
            timerIntervalWarningLabel.Name = "timerIntervalWarningLabel";
            timerIntervalWarningLabel.Size = new Size(310, 40);
            timerIntervalWarningLabel.TabIndex = 6;
            timerIntervalWarningLabel.Text = "注意, 视频刷新速度越快对设备的性能要求越高！\r\n部分设备下，过快的设置可能会导致效率降低\r\n";
            // 
            // applyTimerIntervalBtn
            // 
            applyTimerIntervalBtn.Location = new Point(277, 113);
            applyTimerIntervalBtn.Name = "applyTimerIntervalBtn";
            applyTimerIntervalBtn.Size = new Size(60, 34);
            applyTimerIntervalBtn.TabIndex = 5;
            applyTimerIntervalBtn.Text = "应用";
            applyTimerIntervalBtn.UseVisualStyleBackColor = true;
            applyTimerIntervalBtn.Click += applyTimerIntervalBtn_Click;
            // 
            // timerIntervalNum
            // 
            timerIntervalNum.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            timerIntervalNum.Location = new Point(6, 116);
            timerIntervalNum.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            timerIntervalNum.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            timerIntervalNum.Name = "timerIntervalNum";
            timerIntervalNum.Size = new Size(265, 30);
            timerIntervalNum.TabIndex = 4;
            timerIntervalNum.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // timerIntervalLabel
            // 
            timerIntervalLabel.AutoSize = true;
            timerIntervalLabel.Location = new Point(6, 89);
            timerIntervalLabel.Name = "timerIntervalLabel";
            timerIntervalLabel.Size = new Size(175, 24);
            timerIntervalLabel.TabIndex = 3;
            timerIntervalLabel.Text = "视频刷新速度 (毫秒):";
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
            cameraComboBox.SelectedIndexChanged += cameraComboBox_SelectedIndexChanged;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel, currentStatusLabel, optionsDropDownBtn, machineStatusLabel });
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
            optionsDropDownBtn.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            optionsDropDownBtn.Image = (Image)resources.GetObject("optionsDropDownBtn.Image");
            optionsDropDownBtn.ImageTransparentColor = Color.Magenta;
            optionsDropDownBtn.Name = "optionsDropDownBtn";
            optionsDropDownBtn.Size = new Size(64, 33);
            optionsDropDownBtn.Text = "选项";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(146, 34);
            aboutToolStripMenuItem.Text = "关于";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // machineStatusLabel
            // 
            machineStatusLabel.Alignment = ToolStripItemAlignment.Right;
            machineStatusLabel.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 134);
            machineStatusLabel.Name = "machineStatusLabel";
            machineStatusLabel.Size = new Size(87, 29);
            machineStatusLabel.Text = "CPU: --%";
            // 
            // captureTimer
            // 
            captureTimer.Interval = 30;
            captureTimer.Tick += captureTimer_Tick;
            // 
            // infoGroupBox
            // 
            infoGroupBox.Controls.Add(faceRecogStatusLabel);
            infoGroupBox.Location = new Point(699, 603);
            infoGroupBox.Name = "infoGroupBox";
            infoGroupBox.Size = new Size(707, 85);
            infoGroupBox.TabIndex = 3;
            infoGroupBox.TabStop = false;
            infoGroupBox.Text = "信息";
            // 
            // faceRecogStatusLabel
            // 
            faceRecogStatusLabel.AutoSize = true;
            faceRecogStatusLabel.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
            faceRecogStatusLabel.Location = new Point(6, 27);
            faceRecogStatusLabel.Name = "faceRecogStatusLabel";
            faceRecogStatusLabel.Size = new Size(197, 40);
            faceRecogStatusLabel.TabIndex = 0;
            faceRecogStatusLabel.Text = "未识别到人脸";
            // 
            // machineStatusTimer
            // 
            machineStatusTimer.Enabled = true;
            machineStatusTimer.Interval = 1000;
            machineStatusTimer.Tick += machineStatusTimer_Tick;
            // 
            // randomBtn
            // 
            randomBtn.Enabled = false;
            randomBtn.Font = new Font("Microsoft YaHei UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 134);
            randomBtn.ForeColor = SystemColors.Highlight;
            randomBtn.Location = new Point(879, 694);
            randomBtn.Name = "randomBtn";
            randomBtn.Size = new Size(527, 107);
            randomBtn.TabIndex = 4;
            randomBtn.Text = "开始抽选";
            randomBtn.UseVisualStyleBackColor = true;
            randomBtn.Click += randomBtn_Click;
            // 
            // backBtn
            // 
            backBtn.Enabled = false;
            backBtn.Location = new Point(699, 694);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(174, 107);
            backBtn.TabIndex = 5;
            backBtn.Text = "返回";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // WndMain
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1418, 844);
            Controls.Add(backBtn);
            Controls.Add(randomBtn);
            Controls.Add(infoGroupBox);
            Controls.Add(statusStrip);
            Controls.Add(configGroupBox);
            Controls.Add(cameraCurrent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "WndMain";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OpenLuckyRandom";
            FormClosing += WndMain_FormClosing;
            ((System.ComponentModel.ISupportInitialize)cameraCurrent).EndInit();
            configGroupBox.ResumeLayout(false);
            configGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)frameThicknessNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)timerIntervalNum).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            infoGroupBox.ResumeLayout(false);
            infoGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox cameraCurrent;
        private GroupBox configGroupBox;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;
        private Button refreshCameraBtn;
        private Label chooseCameraLabel;
        private ComboBox cameraComboBox;
        private ToolStripStatusLabel currentStatusLabel;
        private System.Windows.Forms.Timer captureTimer;
        private ToolStripDropDownButton optionsDropDownBtn;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Button applyTimerIntervalBtn;
        private NumericUpDown timerIntervalNum;
        private Label timerIntervalLabel;
        private GroupBox infoGroupBox;
        private Label faceRecogStatusLabel;
        private Label timerIntervalWarningLabel;
        private ToolStripStatusLabel machineStatusLabel;
        private System.Windows.Forms.Timer machineStatusTimer;
        private Button randomBtn;
        private Label frameThicknessLabel;
        private Button applyframeThicknessBtn;
        private NumericUpDown frameThicknessNum;
        private Button backBtn;
        private Label frameThicknessWarningLabel;
        private ComboBox cascadesComboBox;
        private Label cascadesLabel;
    }
}

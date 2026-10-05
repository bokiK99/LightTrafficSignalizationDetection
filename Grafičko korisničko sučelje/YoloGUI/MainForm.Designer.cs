namespace YoloGUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.rbImage = new System.Windows.Forms.RadioButton();
            this.rbVideo = new System.Windows.Forms.RadioButton();
            this.lblModel = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.lblInputPath = new System.Windows.Forms.Label();
            this.txtInputPath = new System.Windows.Forms.TextBox();
            this.btnBrowseInput = new System.Windows.Forms.Button();
            this.lblOutputName = new System.Windows.Forms.Label();
            this.txtOutputName = new System.Windows.Forms.TextBox();
            this.lblOutputDir = new System.Windows.Forms.Label();
            this.lblOutputDirValue = new System.Windows.Forms.Label();
            this.grpParams = new System.Windows.Forms.GroupBox();
            this.lblConf = new System.Windows.Forms.Label();
            this.nudConf = new System.Windows.Forms.NumericUpDown();
            this.lblIou = new System.Windows.Forms.Label();
            this.nudIou = new System.Windows.Forms.NumericUpDown();
            this.btnRun = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tabPreview = new System.Windows.Forms.TabPage();
            this.splitPreview = new System.Windows.Forms.SplitContainer();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.lblPreview = new System.Windows.Forms.Label();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.lblResultPreview = new System.Windows.Forms.Label();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.grpParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIou)).BeginInit();
            this.tabPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPreview)).BeginInit();
            this.splitPreview.Panel1.SuspendLayout();
            this.splitPreview.Panel2.SuspendLayout();
            this.splitPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.tabLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSettings);
            this.tabControl.Controls.Add(this.tabPreview);
            this.tabControl.Controls.Add(this.tabLog);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(882, 543);
            this.tabControl.TabIndex = 0;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.grpInput);
            this.tabSettings.Controls.Add(this.grpParams);
            this.tabSettings.Controls.Add(this.btnRun);
            this.tabSettings.Controls.Add(this.progressBar);
            this.tabSettings.Controls.Add(this.lblStatus);
            this.tabSettings.Location = new System.Drawing.Point(4, 29);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(8);
            this.tabSettings.Size = new System.Drawing.Size(874, 510);
            this.tabSettings.TabIndex = 0;
            this.tabSettings.Text = "  Postavke";
            // 
            // grpInput
            // 
            this.grpInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInput.Controls.Add(this.rbImage);
            this.grpInput.Controls.Add(this.rbVideo);
            this.grpInput.Controls.Add(this.lblModel);
            this.grpInput.Controls.Add(this.cmbModel);
            this.grpInput.Controls.Add(this.lblInputPath);
            this.grpInput.Controls.Add(this.txtInputPath);
            this.grpInput.Controls.Add(this.btnBrowseInput);
            this.grpInput.Controls.Add(this.lblOutputName);
            this.grpInput.Controls.Add(this.txtOutputName);
            this.grpInput.Controls.Add(this.lblOutputDir);
            this.grpInput.Controls.Add(this.lblOutputDirValue);
            this.grpInput.Location = new System.Drawing.Point(8, 8);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(856, 170);
            this.grpInput.TabIndex = 0;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Ulaz / Izlaz";
            // 
            // rbImage
            // 
            this.rbImage.Checked = true;
            this.rbImage.Location = new System.Drawing.Point(8, 22);
            this.rbImage.Name = "rbImage";
            this.rbImage.Size = new System.Drawing.Size(70, 20);
            this.rbImage.TabIndex = 0;
            this.rbImage.TabStop = true;
            this.rbImage.Text = "Slika";
            this.rbImage.CheckedChanged += new System.EventHandler(this.rbImage_CheckedChanged);
            // 
            // rbVideo
            // 
            this.rbVideo.Location = new System.Drawing.Point(84, 22);
            this.rbVideo.Name = "rbVideo";
            this.rbVideo.Size = new System.Drawing.Size(111, 20);
            this.rbVideo.TabIndex = 1;
            this.rbVideo.Text = "Videozapis";
            this.rbVideo.CheckedChanged += new System.EventHandler(this.rbVideo_CheckedChanged);
            // 
            // lblModel
            // 
            this.lblModel.Location = new System.Drawing.Point(8, 52);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(155, 20);
            this.lblModel.TabIndex = 2;
            this.lblModel.Text = "Odaberi model (.pt):";
            // 
            // cmbModel
            // 
            this.cmbModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModel.Location = new System.Drawing.Point(169, 49);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(559, 28);
            this.cmbModel.TabIndex = 3;
            this.cmbModel.SelectedIndexChanged += new System.EventHandler(this.cmbModel_SelectedIndexChanged);
            // 
            // lblInputPath
            // 
            this.lblInputPath.Location = new System.Drawing.Point(8, 86);
            this.lblInputPath.Name = "lblInputPath";
            this.lblInputPath.Size = new System.Drawing.Size(155, 20);
            this.lblInputPath.TabIndex = 4;
            this.lblInputPath.Text = "Ulazna datoteka:";
            // 
            // txtInputPath
            // 
            this.txtInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtInputPath.Location = new System.Drawing.Point(169, 83);
            this.txtInputPath.Name = "txtInputPath";
            this.txtInputPath.ReadOnly = true;
            this.txtInputPath.Size = new System.Drawing.Size(423, 27);
            this.txtInputPath.TabIndex = 5;
            this.txtInputPath.TextChanged += new System.EventHandler(this.txtInputPath_TextChanged);
            // 
            // btnBrowseInput
            // 
            this.btnBrowseInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseInput.Location = new System.Drawing.Point(598, 83);
            this.btnBrowseInput.Name = "btnBrowseInput";
            this.btnBrowseInput.Size = new System.Drawing.Size(130, 27);
            this.btnBrowseInput.TabIndex = 6;
            this.btnBrowseInput.Text = "Odaberi...";
            this.btnBrowseInput.Click += new System.EventHandler(this.btnBrowseInput_Click);
            // 
            // lblOutputName
            // 
            this.lblOutputName.Location = new System.Drawing.Point(8, 120);
            this.lblOutputName.Name = "lblOutputName";
            this.lblOutputName.Size = new System.Drawing.Size(155, 20);
            this.lblOutputName.TabIndex = 7;
            this.lblOutputName.Text = "Ime izlazne datoteke:";
            // 
            // txtOutputName
            // 
            this.txtOutputName.Location = new System.Drawing.Point(169, 117);
            this.txtOutputName.Name = "txtOutputName";
            this.txtOutputName.Size = new System.Drawing.Size(423, 27);
            this.txtOutputName.TabIndex = 8;
            this.txtOutputName.TextChanged += new System.EventHandler(this.txtOutputName_TextChanged);
            // 
            // lblOutputDir
            // 
            this.lblOutputDir.ForeColor = System.Drawing.Color.Gray;
            this.lblOutputDir.Location = new System.Drawing.Point(8, 150);
            this.lblOutputDir.Name = "lblOutputDir";
            this.lblOutputDir.Size = new System.Drawing.Size(80, 16);
            this.lblOutputDir.TabIndex = 9;
            this.lblOutputDir.Text = "Sprema se u:";
            // 
            // lblOutputDirValue
            // 
            this.lblOutputDirValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOutputDirValue.ForeColor = System.Drawing.Color.Gray;
            this.lblOutputDirValue.Location = new System.Drawing.Point(92, 150);
            this.lblOutputDirValue.Name = "lblOutputDirValue";
            this.lblOutputDirValue.Size = new System.Drawing.Size(758, 16);
            this.lblOutputDirValue.TabIndex = 10;
            // 
            // grpParams
            // 
            this.grpParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpParams.Controls.Add(this.lblConf);
            this.grpParams.Controls.Add(this.nudConf);
            this.grpParams.Controls.Add(this.lblIou);
            this.grpParams.Controls.Add(this.nudIou);
            this.grpParams.Location = new System.Drawing.Point(8, 186);
            this.grpParams.Name = "grpParams";
            this.grpParams.Size = new System.Drawing.Size(856, 58);
            this.grpParams.TabIndex = 1;
            this.grpParams.TabStop = false;
            this.grpParams.Text = "Parametri detekcije";
            // 
            // lblConf
            // 
            this.lblConf.Location = new System.Drawing.Point(8, 24);
            this.lblConf.Name = "lblConf";
            this.lblConf.Size = new System.Drawing.Size(115, 20);
            this.lblConf.TabIndex = 0;
            this.lblConf.Text = "Confidence prag:";
            // 
            // nudConf
            // 
            this.nudConf.DecimalPlaces = 2;
            this.nudConf.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudConf.Location = new System.Drawing.Point(126, 21);
            this.nudConf.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            131072});
            this.nudConf.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudConf.Name = "nudConf";
            this.nudConf.Size = new System.Drawing.Size(70, 27);
            this.nudConf.TabIndex = 1;
            this.nudConf.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // lblIou
            // 
            this.lblIou.Location = new System.Drawing.Point(220, 24);
            this.lblIou.Name = "lblIou";
            this.lblIou.Size = new System.Drawing.Size(108, 20);
            this.lblIou.TabIndex = 2;
            this.lblIou.Text = "IoU prag (NMS):";
            // 
            // nudIou
            // 
            this.nudIou.DecimalPlaces = 2;
            this.nudIou.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudIou.Location = new System.Drawing.Point(331, 21);
            this.nudIou.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            131072});
            this.nudIou.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudIou.Name = "nudIou";
            this.nudIou.Size = new System.Drawing.Size(70, 27);
            this.nudIou.TabIndex = 3;
            this.nudIou.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.Location = new System.Drawing.Point(8, 254);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(200, 38);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Pokretanje detekcije";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(220, 261);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(636, 24);
            this.progressBar.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(8, 302);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(700, 20);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Spreman.";
            // 
            // tabPreview
            // 
            this.tabPreview.Controls.Add(this.splitPreview);
            this.tabPreview.Location = new System.Drawing.Point(4, 25);
            this.tabPreview.Name = "tabPreview";
            this.tabPreview.Padding = new System.Windows.Forms.Padding(8);
            this.tabPreview.Size = new System.Drawing.Size(874, 514);
            this.tabPreview.TabIndex = 1;
            this.tabPreview.Text = "  Pregled";
            // 
            // splitPreview
            // 
            this.splitPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPreview.Location = new System.Drawing.Point(8, 8);
            this.splitPreview.Name = "splitPreview";
            // 
            // splitPreview.Panel1
            // 
            this.splitPreview.Panel1.Controls.Add(this.pictureBoxPreview);
            this.splitPreview.Panel1.Controls.Add(this.lblPreview);
            // 
            // splitPreview.Panel2
            // 
            this.splitPreview.Panel2.Controls.Add(this.pictureBoxResult);
            this.splitPreview.Panel2.Controls.Add(this.lblResultPreview);
            this.splitPreview.Size = new System.Drawing.Size(858, 498);
            this.splitPreview.SplitterDistance = 692;
            this.splitPreview.TabIndex = 0;
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPreview.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(692, 478);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.TabIndex = 0;
            this.pictureBoxPreview.TabStop = false;
            // 
            // lblPreview
            // 
            this.lblPreview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPreview.Location = new System.Drawing.Point(0, 478);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(692, 20);
            this.lblPreview.TabIndex = 1;
            this.lblPreview.Text = "Ulaz - odaberi sliku ili video";
            this.lblPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pictureBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxResult.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(162, 478);
            this.pictureBoxResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxResult.TabIndex = 0;
            this.pictureBoxResult.TabStop = false;
            // 
            // lblResultPreview
            // 
            this.lblResultPreview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblResultPreview.Location = new System.Drawing.Point(0, 478);
            this.lblResultPreview.Name = "lblResultPreview";
            this.lblResultPreview.Size = new System.Drawing.Size(162, 20);
            this.lblResultPreview.TabIndex = 1;
            this.lblResultPreview.Text = "Rezultat detekcije";
            this.lblResultPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.txtLog);
            this.tabLog.Controls.Add(this.btnClearLog);
            this.tabLog.Location = new System.Drawing.Point(4, 25);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(8);
            this.tabLog.Size = new System.Drawing.Size(874, 514);
            this.tabLog.TabIndex = 2;
            this.tabLog.Text = "  Zapisnik";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtLog.ForeColor = System.Drawing.Color.LightGreen;
            this.txtLog.Location = new System.Drawing.Point(8, 8);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(858, 470);
            this.txtLog.TabIndex = 0;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClearLog.Location = new System.Drawing.Point(8, 478);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(858, 28);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "Ocisti zapisnik";
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(882, 543);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(800, 510);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YOLO Detektor svjetlosne prometne signalizacije";
            this.tabControl.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpParams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudConf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIou)).EndInit();
            this.tabPreview.ResumeLayout(false);
            this.splitPreview.Panel1.ResumeLayout(false);
            this.splitPreview.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPreview)).EndInit();
            this.splitPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.tabLog.ResumeLayout(false);
            this.tabLog.PerformLayout();
            this.ResumeLayout(false);

        }

        // ─── Field deklaracije ─────────────────────────────────────────────────
        private System.Windows.Forms.TabControl       tabControl;
        private System.Windows.Forms.TabPage          tabSettings;
        private System.Windows.Forms.TabPage          tabPreview;
        private System.Windows.Forms.TabPage          tabLog;
        private System.Windows.Forms.GroupBox         grpInput;
        private System.Windows.Forms.GroupBox         grpParams;
        private System.Windows.Forms.RadioButton      rbImage;
        private System.Windows.Forms.RadioButton      rbVideo;
        private System.Windows.Forms.Label            lblModel;
        private System.Windows.Forms.ComboBox         cmbModel;
        private System.Windows.Forms.Label            lblInputPath;
        private System.Windows.Forms.TextBox          txtInputPath;
        private System.Windows.Forms.Button           btnBrowseInput;
        private System.Windows.Forms.Label            lblOutputName;
        private System.Windows.Forms.TextBox          txtOutputName;
        private System.Windows.Forms.Label            lblOutputDir;
        private System.Windows.Forms.Label            lblOutputDirValue;
        private System.Windows.Forms.Label            lblConf;
        private System.Windows.Forms.Label            lblIou;
        private System.Windows.Forms.NumericUpDown    nudConf;
        private System.Windows.Forms.NumericUpDown    nudIou;
        private System.Windows.Forms.Button           btnRun;
        private System.Windows.Forms.ProgressBar      progressBar;
        private System.Windows.Forms.Label            lblStatus;
        private System.Windows.Forms.SplitContainer   splitPreview;
        private System.Windows.Forms.PictureBox       pictureBoxPreview;
        private System.Windows.Forms.PictureBox       pictureBoxResult;
        private System.Windows.Forms.Label            lblPreview;
        private System.Windows.Forms.Label            lblResultPreview;
        private System.Windows.Forms.TextBox          txtLog;
        private System.Windows.Forms.Button           btnClearLog;
    }
}

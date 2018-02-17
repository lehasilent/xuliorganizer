namespace XuliOrganizzer
{
    partial class frmTimer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblHide = new System.Windows.Forms.LinkLabel();
            this.lblStandTime = new System.Windows.Forms.Label();
            this.cmnStandTime = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtH = new System.Windows.Forms.TextBox();
            this.lblHMinus = new System.Windows.Forms.Label();
            this.lblHPlus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtS = new System.Windows.Forms.TextBox();
            this.lblSMinus = new System.Windows.Forms.Label();
            this.txtM = new System.Windows.Forms.TextBox();
            this.lblSPlus = new System.Windows.Forms.Label();
            this.lblMMinus = new System.Windows.Forms.Label();
            this.lblMplus = new System.Windows.Forms.Label();
            this.lblStop = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblPause = new System.Windows.Forms.Label();
            this.lblReset = new System.Windows.Forms.Label();
            this.tmrCountdown = new System.Windows.Forms.Timer(this.components);
            this.lblSettings = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Black;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTimer.ForeColor = System.Drawing.Color.Lime;
            this.lblTimer.Location = new System.Drawing.Point(4, 21);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(318, 55);
            this.lblTimer.TabIndex = 0;
            this.lblTimer.Text = "00:00:00.000";
            // 
            // lblHide
            // 
            this.lblHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHide.Image = global::XuliOrganizzer.Properties.Resources.close24x24;
            this.lblHide.Location = new System.Drawing.Point(384, 2);
            this.lblHide.Name = "lblHide";
            this.lblHide.Size = new System.Drawing.Size(24, 24);
            this.lblHide.TabIndex = 9;
            this.lblHide.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblHide_MouseClick);
            // 
            // lblStandTime
            // 
            this.lblStandTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStandTime.Image = global::XuliOrganizzer.Properties.Resources.standpresets32x32;
            this.lblStandTime.Location = new System.Drawing.Point(23, 91);
            this.lblStandTime.Name = "lblStandTime";
            this.lblStandTime.Size = new System.Drawing.Size(32, 32);
            this.lblStandTime.TabIndex = 10;
            this.lblStandTime.Click += new System.EventHandler(this.lblStandTime_Click);
            // 
            // cmnStandTime
            // 
            this.cmnStandTime.Name = "cmnStandTime";
            this.cmnStandTime.Size = new System.Drawing.Size(61, 4);
            // 
            // txtH
            // 
            this.txtH.BackColor = System.Drawing.Color.Gray;
            this.txtH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtH.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtH.ForeColor = System.Drawing.Color.Lime;
            this.txtH.Location = new System.Drawing.Point(28, 10);
            this.txtH.MaxLength = 2;
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(22, 22);
            this.txtH.TabIndex = 12;
            this.txtH.Text = "00";
            this.txtH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtH.TextChanged += new System.EventHandler(this.AllTextChanged);
            this.txtH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyDigits);
            // 
            // lblHMinus
            // 
            this.lblHMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHMinus.Image = global::XuliOrganizzer.Properties.Resources.minus16x16;
            this.lblHMinus.Location = new System.Drawing.Point(55, 11);
            this.lblHMinus.Name = "lblHMinus";
            this.lblHMinus.Size = new System.Drawing.Size(18, 18);
            this.lblHMinus.TabIndex = 14;
            this.lblHMinus.Click += new System.EventHandler(this.lblHMinus_Click);
            // 
            // lblHPlus
            // 
            this.lblHPlus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHPlus.Image = global::XuliOrganizzer.Properties.Resources.plus16x16;
            this.lblHPlus.Location = new System.Drawing.Point(4, 11);
            this.lblHPlus.Name = "lblHPlus";
            this.lblHPlus.Size = new System.Drawing.Size(18, 18);
            this.lblHPlus.TabIndex = 15;
            this.lblHPlus.Click += new System.EventHandler(this.lblHPlus_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtS);
            this.groupBox1.Controls.Add(this.lblSMinus);
            this.groupBox1.Controls.Add(this.txtM);
            this.groupBox1.Controls.Add(this.lblSPlus);
            this.groupBox1.Controls.Add(this.lblStandTime);
            this.groupBox1.Controls.Add(this.lblMMinus);
            this.groupBox1.Controls.Add(this.lblMplus);
            this.groupBox1.Controls.Add(this.txtH);
            this.groupBox1.Controls.Add(this.lblHMinus);
            this.groupBox1.Controls.Add(this.lblHPlus);
            this.groupBox1.Location = new System.Drawing.Point(327, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(80, 126);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // txtS
            // 
            this.txtS.BackColor = System.Drawing.Color.Gray;
            this.txtS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtS.ForeColor = System.Drawing.Color.Lime;
            this.txtS.Location = new System.Drawing.Point(28, 66);
            this.txtS.MaxLength = 2;
            this.txtS.Name = "txtS";
            this.txtS.Size = new System.Drawing.Size(22, 22);
            this.txtS.TabIndex = 17;
            this.txtS.Text = "00";
            this.txtS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtS.TextChanged += new System.EventHandler(this.AllTextChanged);
            this.txtS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyDigits);
            // 
            // lblSMinus
            // 
            this.lblSMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSMinus.Image = global::XuliOrganizzer.Properties.Resources.minus16x16;
            this.lblSMinus.Location = new System.Drawing.Point(55, 67);
            this.lblSMinus.Name = "lblSMinus";
            this.lblSMinus.Size = new System.Drawing.Size(18, 18);
            this.lblSMinus.TabIndex = 18;
            this.lblSMinus.Click += new System.EventHandler(this.lblSMinus_Click);
            // 
            // txtM
            // 
            this.txtM.BackColor = System.Drawing.Color.Gray;
            this.txtM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtM.ForeColor = System.Drawing.Color.Lime;
            this.txtM.Location = new System.Drawing.Point(28, 38);
            this.txtM.MaxLength = 2;
            this.txtM.Name = "txtM";
            this.txtM.Size = new System.Drawing.Size(22, 22);
            this.txtM.TabIndex = 16;
            this.txtM.Text = "00";
            this.txtM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtM.TextChanged += new System.EventHandler(this.AllTextChanged);
            this.txtM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyDigits);
            // 
            // lblSPlus
            // 
            this.lblSPlus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSPlus.Image = global::XuliOrganizzer.Properties.Resources.plus16x16;
            this.lblSPlus.Location = new System.Drawing.Point(4, 67);
            this.lblSPlus.Name = "lblSPlus";
            this.lblSPlus.Size = new System.Drawing.Size(18, 18);
            this.lblSPlus.TabIndex = 19;
            this.lblSPlus.Click += new System.EventHandler(this.lblSPlus_Click);
            // 
            // lblMMinus
            // 
            this.lblMMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMMinus.Image = global::XuliOrganizzer.Properties.Resources.minus16x16;
            this.lblMMinus.Location = new System.Drawing.Point(55, 39);
            this.lblMMinus.Name = "lblMMinus";
            this.lblMMinus.Size = new System.Drawing.Size(18, 18);
            this.lblMMinus.TabIndex = 17;
            this.lblMMinus.Click += new System.EventHandler(this.lblMMinus_Click);
            // 
            // lblMplus
            // 
            this.lblMplus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMplus.Image = global::XuliOrganizzer.Properties.Resources.plus16x16;
            this.lblMplus.Location = new System.Drawing.Point(4, 39);
            this.lblMplus.Name = "lblMplus";
            this.lblMplus.Size = new System.Drawing.Size(18, 18);
            this.lblMplus.TabIndex = 18;
            this.lblMplus.Click += new System.EventHandler(this.lblMplus_Click);
            // 
            // lblStop
            // 
            this.lblStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStop.Image = global::XuliOrganizzer.Properties.Resources.stop64x64;
            this.lblStop.Location = new System.Drawing.Point(161, 87);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(64, 64);
            this.lblStop.TabIndex = 17;
            this.lblStop.Click += new System.EventHandler(this.lblStop_Click);
            // 
            // lblStart
            // 
            this.lblStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStart.Image = global::XuliOrganizzer.Properties.Resources.start64x64;
            this.lblStart.Location = new System.Drawing.Point(12, 88);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(64, 64);
            this.lblStart.TabIndex = 18;
            this.lblStart.Click += new System.EventHandler(this.lblStart_Click);
            // 
            // lblPause
            // 
            this.lblPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPause.Image = global::XuliOrganizzer.Properties.Resources.pause;
            this.lblPause.Location = new System.Drawing.Point(91, 86);
            this.lblPause.Name = "lblPause";
            this.lblPause.Size = new System.Drawing.Size(64, 64);
            this.lblPause.TabIndex = 19;
            this.lblPause.Click += new System.EventHandler(this.lblPause_Click);
            // 
            // lblReset
            // 
            this.lblReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblReset.Image = global::XuliOrganizzer.Properties.Resources.reset64x64;
            this.lblReset.Location = new System.Drawing.Point(234, 86);
            this.lblReset.Name = "lblReset";
            this.lblReset.Size = new System.Drawing.Size(64, 64);
            this.lblReset.TabIndex = 20;
            this.lblReset.Click += new System.EventHandler(this.lblReset_Click);
            // 
            // tmrCountdown
            // 
            this.tmrCountdown.Interval = 1;
            this.tmrCountdown.Tick += new System.EventHandler(this.tmrCountdown_Tick);
            // 
            // lblSettings
            // 
            this.lblSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSettings.Image = global::XuliOrganizzer.Properties.Resources.settings24x24;
            this.lblSettings.Location = new System.Drawing.Point(357, 2);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(24, 24);
            this.lblSettings.TabIndex = 20;
            this.lblSettings.Click += new System.EventHandler(this.lblSettings_Click);
            // 
            // frmTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(412, 157);
            this.Controls.Add(this.lblSettings);
            this.Controls.Add(this.lblReset);
            this.Controls.Add(this.lblHide);
            this.Controls.Add(this.lblPause);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStop);
            this.Controls.Add(this.lblTimer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTimer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTimer";
            this.Load += new System.EventHandler(this.frmTimer_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmTimer_MouseDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.LinkLabel lblHide;
        private System.Windows.Forms.Label lblStandTime;
        private System.Windows.Forms.ContextMenuStrip cmnStandTime;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.Label lblHMinus;
        private System.Windows.Forms.Label lblHPlus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtS;
        private System.Windows.Forms.Label lblSMinus;
        private System.Windows.Forms.TextBox txtM;
        private System.Windows.Forms.Label lblSPlus;
        private System.Windows.Forms.Label lblMMinus;
        private System.Windows.Forms.Label lblMplus;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblPause;
        private System.Windows.Forms.Label lblReset;
        private System.Windows.Forms.Timer tmrCountdown;
        private System.Windows.Forms.Label lblSettings;
    }
}
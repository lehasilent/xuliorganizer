namespace XuliOrganizzer
{
    partial class frmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.lblSP = new System.Windows.Forms.Label();
            this.txtSettingsPath = new System.Windows.Forms.TextBox();
            this.btnAutostart = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupMainBeh = new System.Windows.Forms.GroupBox();
            this.rbMainBeh1 = new System.Windows.Forms.RadioButton();
            this.rbMainBeh0 = new System.Windows.Forms.RadioButton();
            this.chkAskMainBeh = new System.Windows.Forms.CheckBox();
            this.groupNotification = new System.Windows.Forms.GroupBox();
            this.rbNotification0 = new System.Windows.Forms.RadioButton();
            this.rbNotification2 = new System.Windows.Forms.RadioButton();
            this.rbNotification1 = new System.Windows.Forms.RadioButton();
            this.chkAskExit = new System.Windows.Forms.CheckBox();
            this.groupOverdue = new System.Windows.Forms.GroupBox();
            this.chkOverdueNewTime = new System.Windows.Forms.CheckBox();
            this.chkOverdueRun = new System.Windows.Forms.CheckBox();
            this.chkOverdueNotif = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblNoRemind = new System.Windows.Forms.Label();
            this.groupMainBeh.SuspendLayout();
            this.groupNotification.SuspendLayout();
            this.groupOverdue.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSP
            // 
            this.lblSP.AutoSize = true;
            this.lblSP.Location = new System.Drawing.Point(2, 2);
            this.lblSP.Name = "lblSP";
            this.lblSP.Size = new System.Drawing.Size(173, 13);
            this.lblSP.TabIndex = 0;
            this.lblSP.Text = "Путь к файлу настроек и данных";
            // 
            // txtSettingsPath
            // 
            this.txtSettingsPath.Location = new System.Drawing.Point(-1, 16);
            this.txtSettingsPath.Name = "txtSettingsPath";
            this.txtSettingsPath.ReadOnly = true;
            this.txtSettingsPath.Size = new System.Drawing.Size(420, 20);
            this.txtSettingsPath.TabIndex = 1;
            // 
            // btnAutostart
            // 
            this.btnAutostart.Location = new System.Drawing.Point(2, 42);
            this.btnAutostart.Name = "btnAutostart";
            this.btnAutostart.Size = new System.Drawing.Size(221, 23);
            this.btnAutostart.TabIndex = 2;
            this.btnAutostart.Text = "Добавить программу в автозагрузку";
            this.btnAutostart.UseVisualStyleBackColor = true;
            this.btnAutostart.Click += new System.EventHandler(this.btnAutostart_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(344, 288);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Отмена";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupMainBeh
            // 
            this.groupMainBeh.Controls.Add(this.rbMainBeh1);
            this.groupMainBeh.Controls.Add(this.rbMainBeh0);
            this.groupMainBeh.Controls.Add(this.chkAskMainBeh);
            this.groupMainBeh.Location = new System.Drawing.Point(2, 72);
            this.groupMainBeh.Name = "groupMainBeh";
            this.groupMainBeh.Size = new System.Drawing.Size(180, 86);
            this.groupMainBeh.TabIndex = 3;
            this.groupMainBeh.TabStop = false;
            this.groupMainBeh.Text = "При закрытии главного окна";
            // 
            // rbMainBeh1
            // 
            this.rbMainBeh1.AutoSize = true;
            this.rbMainBeh1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbMainBeh1.Location = new System.Drawing.Point(6, 39);
            this.rbMainBeh1.Name = "rbMainBeh1";
            this.rbMainBeh1.Size = new System.Drawing.Size(128, 17);
            this.rbMainBeh1.TabIndex = 5;
            this.rbMainBeh1.Text = "Закрыть программу";
            this.rbMainBeh1.UseVisualStyleBackColor = true;
            this.rbMainBeh1.CheckedChanged += new System.EventHandler(this.rbMainBeh_CheckedChanged);
            // 
            // rbMainBeh0
            // 
            this.rbMainBeh0.AutoSize = true;
            this.rbMainBeh0.Checked = true;
            this.rbMainBeh0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbMainBeh0.Location = new System.Drawing.Point(6, 19);
            this.rbMainBeh0.Name = "rbMainBeh0";
            this.rbMainBeh0.Size = new System.Drawing.Size(167, 17);
            this.rbMainBeh0.TabIndex = 4;
            this.rbMainBeh0.TabStop = true;
            this.rbMainBeh0.Text = "Свернуть в системный трей";
            this.rbMainBeh0.UseVisualStyleBackColor = true;
            this.rbMainBeh0.CheckedChanged += new System.EventHandler(this.rbMainBeh_CheckedChanged);
            // 
            // chkAskMainBeh
            // 
            this.chkAskMainBeh.AutoSize = true;
            this.chkAskMainBeh.Checked = true;
            this.chkAskMainBeh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAskMainBeh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkAskMainBeh.Location = new System.Drawing.Point(6, 62);
            this.chkAskMainBeh.Name = "chkAskMainBeh";
            this.chkAskMainBeh.Size = new System.Drawing.Size(161, 17);
            this.chkAskMainBeh.TabIndex = 6;
            this.chkAskMainBeh.Text = "Спрашивать при закрытии";
            this.chkAskMainBeh.UseVisualStyleBackColor = true;
            // 
            // groupNotification
            // 
            this.groupNotification.Controls.Add(this.rbNotification0);
            this.groupNotification.Controls.Add(this.rbNotification2);
            this.groupNotification.Controls.Add(this.rbNotification1);
            this.groupNotification.Location = new System.Drawing.Point(189, 72);
            this.groupNotification.Name = "groupNotification";
            this.groupNotification.Size = new System.Drawing.Size(230, 86);
            this.groupNotification.TabIndex = 7;
            this.groupNotification.TabStop = false;
            this.groupNotification.Text = "Оповещение о напоминании";
            // 
            // rbNotification0
            // 
            this.rbNotification0.AutoSize = true;
            this.rbNotification0.Checked = true;
            this.rbNotification0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbNotification0.Location = new System.Drawing.Point(5, 20);
            this.rbNotification0.Name = "rbNotification0";
            this.rbNotification0.Size = new System.Drawing.Size(193, 17);
            this.rbNotification0.TabIndex = 8;
            this.rbNotification0.TabStop = true;
            this.rbNotification0.Text = "Окно и всплывающая подсказка";
            this.rbNotification0.UseVisualStyleBackColor = true;
            this.rbNotification0.CheckedChanged += new System.EventHandler(this.rbNotification_CheckedChanged);
            // 
            // rbNotification2
            // 
            this.rbNotification2.AutoSize = true;
            this.rbNotification2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbNotification2.Location = new System.Drawing.Point(6, 63);
            this.rbNotification2.Name = "rbNotification2";
            this.rbNotification2.Size = new System.Drawing.Size(156, 17);
            this.rbNotification2.TabIndex = 10;
            this.rbNotification2.Text = "Всплывающая подсказка";
            this.rbNotification2.UseVisualStyleBackColor = true;
            this.rbNotification2.CheckedChanged += new System.EventHandler(this.rbNotification_CheckedChanged);
            // 
            // rbNotification1
            // 
            this.rbNotification1.AutoSize = true;
            this.rbNotification1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbNotification1.Location = new System.Drawing.Point(6, 42);
            this.rbNotification1.Name = "rbNotification1";
            this.rbNotification1.Size = new System.Drawing.Size(117, 17);
            this.rbNotification1.TabIndex = 9;
            this.rbNotification1.Text = "В отдельном окне";
            this.rbNotification1.UseVisualStyleBackColor = true;
            this.rbNotification1.CheckedChanged += new System.EventHandler(this.rbNotification_CheckedChanged);
            // 
            // chkAskExit
            // 
            this.chkAskExit.AutoSize = true;
            this.chkAskExit.Checked = true;
            this.chkAskExit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAskExit.Location = new System.Drawing.Point(2, 265);
            this.chkAskExit.Name = "chkAskExit";
            this.chkAskExit.Size = new System.Drawing.Size(308, 17);
            this.chkAskExit.TabIndex = 14;
            this.chkAskExit.Text = "Спрашивать подтверждение при выходе из программы";
            this.chkAskExit.UseVisualStyleBackColor = true;
            // 
            // groupOverdue
            // 
            this.groupOverdue.Controls.Add(this.chkOverdueNewTime);
            this.groupOverdue.Controls.Add(this.chkOverdueRun);
            this.groupOverdue.Controls.Add(this.chkOverdueNotif);
            this.groupOverdue.Location = new System.Drawing.Point(189, 164);
            this.groupOverdue.Name = "groupOverdue";
            this.groupOverdue.Size = new System.Drawing.Size(230, 91);
            this.groupOverdue.TabIndex = 11;
            this.groupOverdue.TabStop = false;
            this.groupOverdue.Text = "Просроченные задания";
            // 
            // chkOverdueNewTime
            // 
            this.chkOverdueNewTime.AutoSize = true;
            this.chkOverdueNewTime.Location = new System.Drawing.Point(6, 66);
            this.chkOverdueNewTime.Name = "chkOverdueNewTime";
            this.chkOverdueNewTime.Size = new System.Drawing.Size(219, 17);
            this.chkOverdueNewTime.TabIndex = 2;
            this.chkOverdueNewTime.Text = "Установить новое время выполнения";
            this.chkOverdueNewTime.UseVisualStyleBackColor = true;
            // 
            // chkOverdueRun
            // 
            this.chkOverdueRun.AutoSize = true;
            this.chkOverdueRun.Location = new System.Drawing.Point(6, 43);
            this.chkOverdueRun.Name = "chkOverdueRun";
            this.chkOverdueRun.Size = new System.Drawing.Size(147, 17);
            this.chkOverdueRun.TabIndex = 1;
            this.chkOverdueRun.Text = "Выполнить немедленно";
            this.chkOverdueRun.UseVisualStyleBackColor = true;
            // 
            // chkOverdueNotif
            // 
            this.chkOverdueNotif.AutoSize = true;
            this.chkOverdueNotif.Location = new System.Drawing.Point(7, 20);
            this.chkOverdueNotif.Name = "chkOverdueNotif";
            this.chkOverdueNotif.Size = new System.Drawing.Size(86, 17);
            this.chkOverdueNotif.TabIndex = 0;
            this.chkOverdueNotif.Text = "Оповестить";
            this.chkOverdueNotif.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(2, 288);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblNoRemind
            // 
            this.lblNoRemind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNoRemind.ForeColor = System.Drawing.Color.Red;
            this.lblNoRemind.Location = new System.Drawing.Point(-1, 167);
            this.lblNoRemind.Name = "lblNoRemind";
            this.lblNoRemind.Size = new System.Drawing.Size(184, 60);
            this.lblNoRemind.TabIndex = 17;
            this.lblNoRemind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 313);
            this.Controls.Add(this.lblNoRemind);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupOverdue);
            this.Controls.Add(this.chkAskExit);
            this.Controls.Add(this.groupNotification);
            this.Controls.Add(this.groupMainBeh);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAutostart);
            this.Controls.Add(this.txtSettingsPath);
            this.Controls.Add(this.lblSP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Опции";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.groupMainBeh.ResumeLayout(false);
            this.groupMainBeh.PerformLayout();
            this.groupNotification.ResumeLayout(false);
            this.groupNotification.PerformLayout();
            this.groupOverdue.ResumeLayout(false);
            this.groupOverdue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSP;
        private System.Windows.Forms.TextBox txtSettingsPath;
        private System.Windows.Forms.Button btnAutostart;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupMainBeh;
        private System.Windows.Forms.RadioButton rbMainBeh1;
        private System.Windows.Forms.RadioButton rbMainBeh0;
        private System.Windows.Forms.CheckBox chkAskMainBeh;
        private System.Windows.Forms.GroupBox groupNotification;
        private System.Windows.Forms.RadioButton rbNotification0;
        private System.Windows.Forms.RadioButton rbNotification2;
        private System.Windows.Forms.RadioButton rbNotification1;
        private System.Windows.Forms.CheckBox chkAskExit;
        private System.Windows.Forms.GroupBox groupOverdue;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblNoRemind;
        private System.Windows.Forms.CheckBox chkOverdueNewTime;
        private System.Windows.Forms.CheckBox chkOverdueRun;
        private System.Windows.Forms.CheckBox chkOverdueNotif;
    }
}
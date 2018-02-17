namespace XuliOrganizzer
{
    partial class frmTimerSettings
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
            this.chkBaloon = new System.Windows.Forms.CheckBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.chkTopMost = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSound2 = new System.Windows.Forms.RadioButton();
            this.lblOpenSound = new System.Windows.Forms.Label();
            this.lblPlaySound = new System.Windows.Forms.Label();
            this.rbSound1 = new System.Windows.Forms.RadioButton();
            this.rbSound0 = new System.Windows.Forms.RadioButton();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.lblOK = new System.Windows.Forms.Label();
            this.lblCancel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkBaloon
            // 
            this.chkBaloon.AutoSize = true;
            this.chkBaloon.Location = new System.Drawing.Point(2, 5);
            this.chkBaloon.Name = "chkBaloon";
            this.chkBaloon.Size = new System.Drawing.Size(163, 17);
            this.chkBaloon.TabIndex = 0;
            this.chkBaloon.Text = "Всплывающее сообщение:";
            this.chkBaloon.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.ForeColor = System.Drawing.Color.Black;
            this.txtMessage.Location = new System.Drawing.Point(2, 28);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(407, 74);
            this.txtMessage.TabIndex = 1;
            // 
            // chkTopMost
            // 
            this.chkTopMost.AutoSize = true;
            this.chkTopMost.Location = new System.Drawing.Point(2, 108);
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.Size = new System.Drawing.Size(156, 17);
            this.chkTopMost.TabIndex = 2;
            this.chkTopMost.Text = "Таймер поверх всех окон";
            this.chkTopMost.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSound2);
            this.groupBox1.Controls.Add(this.lblOpenSound);
            this.groupBox1.Controls.Add(this.lblPlaySound);
            this.groupBox1.Controls.Add(this.rbSound1);
            this.groupBox1.Controls.Add(this.rbSound0);
            this.groupBox1.Location = new System.Drawing.Point(2, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 53);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Звук";
            // 
            // rbSound2
            // 
            this.rbSound2.AutoSize = true;
            this.rbSound2.Location = new System.Drawing.Point(306, 20);
            this.rbSound2.Name = "rbSound2";
            this.rbSound2.Size = new System.Drawing.Size(80, 17);
            this.rbSound2.TabIndex = 13;
            this.rbSound2.Text = "Отключить";
            this.rbSound2.UseVisualStyleBackColor = true;
            this.rbSound2.CheckedChanged += new System.EventHandler(this.SoundChecked);
            // 
            // lblOpenSound
            // 
            this.lblOpenSound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOpenSound.Image = global::XuliOrganizzer.Properties.Resources.opensoundfile;
            this.lblOpenSound.Location = new System.Drawing.Point(228, 13);
            this.lblOpenSound.Name = "lblOpenSound";
            this.lblOpenSound.Size = new System.Drawing.Size(32, 32);
            this.lblOpenSound.TabIndex = 12;
            this.lblOpenSound.Click += new System.EventHandler(this.lblOpenSound_Click);
            // 
            // lblPlaySound
            // 
            this.lblPlaySound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPlaySound.Image = global::XuliOrganizzer.Properties.Resources.sound32x32;
            this.lblPlaySound.Location = new System.Drawing.Point(268, 14);
            this.lblPlaySound.Name = "lblPlaySound";
            this.lblPlaySound.Size = new System.Drawing.Size(32, 32);
            this.lblPlaySound.TabIndex = 11;
            this.lblPlaySound.Click += new System.EventHandler(this.lblPlaySound_Click);
            // 
            // rbSound1
            // 
            this.rbSound1.AutoSize = true;
            this.rbSound1.Location = new System.Drawing.Point(104, 20);
            this.rbSound1.Name = "rbSound1";
            this.rbSound1.Size = new System.Drawing.Size(122, 17);
            this.rbSound1.TabIndex = 1;
            this.rbSound1.Text = "Пользовательский";
            this.rbSound1.UseVisualStyleBackColor = true;
            this.rbSound1.CheckedChanged += new System.EventHandler(this.SoundChecked);
            // 
            // rbSound0
            // 
            this.rbSound0.AutoSize = true;
            this.rbSound0.Checked = true;
            this.rbSound0.Location = new System.Drawing.Point(11, 20);
            this.rbSound0.Name = "rbSound0";
            this.rbSound0.Size = new System.Drawing.Size(87, 17);
            this.rbSound0.TabIndex = 0;
            this.rbSound0.TabStop = true;
            this.rbSound0.Text = "Встроенный";
            this.rbSound0.UseVisualStyleBackColor = true;
            this.rbSound0.CheckedChanged += new System.EventHandler(this.SoundChecked);
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "Wave file|*.wav";
            // 
            // lblOK
            // 
            this.lblOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOK.Image = global::XuliOrganizzer.Properties.Resources.ok32x32;
            this.lblOK.Location = new System.Drawing.Point(4, 189);
            this.lblOK.Name = "lblOK";
            this.lblOK.Size = new System.Drawing.Size(32, 32);
            this.lblOK.TabIndex = 12;
            this.lblOK.Click += new System.EventHandler(this.lblOK_Click);
            // 
            // lblCancel
            // 
            this.lblCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCancel.Image = global::XuliOrganizzer.Properties.Resources.close32x321;
            this.lblCancel.Location = new System.Drawing.Point(377, 189);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(32, 32);
            this.lblCancel.TabIndex = 13;
            this.lblCancel.Click += new System.EventHandler(this.lblCancel_Click);
            // 
            // frmTimerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(412, 226);
            this.Controls.Add(this.lblCancel);
            this.Controls.Add(this.lblOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkTopMost);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.chkBaloon);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTimerSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmTimerSettings";
            this.Load += new System.EventHandler(this.frmTimerSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkBaloon;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.CheckBox chkTopMost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSound1;
        private System.Windows.Forms.RadioButton rbSound0;
        private System.Windows.Forms.Label lblPlaySound;
        private System.Windows.Forms.RadioButton rbSound2;
        private System.Windows.Forms.Label lblOpenSound;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.Label lblOK;
        private System.Windows.Forms.Label lblCancel;
    }
}
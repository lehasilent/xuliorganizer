namespace XuliOrganizzer
{
    partial class frmMessage
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
            this.lblTime = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.groupRemindType = new System.Windows.Forms.GroupBox();
            this.lblErr = new System.Windows.Forms.Label();
            this.rbRemindType1 = new System.Windows.Forms.RadioButton();
            this.rbRemindType0 = new System.Windows.Forms.RadioButton();
            this.txtRemind = new System.Windows.Forms.TextBox();
            this.btnAddTime = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.ttButtons = new System.Windows.Forms.ToolTip(this.components);
            this.lblHeader = new System.Windows.Forms.Label();
            this.groupRemindType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.ForeColor = System.Drawing.Color.Lime;
            this.lblTime.Location = new System.Drawing.Point(173, 37);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(150, 55);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "00.00";
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.Black;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtMessage.ForeColor = System.Drawing.Color.Lime;
            this.txtMessage.Location = new System.Drawing.Point(12, 95);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(616, 297);
            this.txtMessage.TabIndex = 666;
            this.txtMessage.Text = "Test Text";
            this.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupRemindType
            // 
            this.groupRemindType.Controls.Add(this.lblErr);
            this.groupRemindType.Controls.Add(this.rbRemindType1);
            this.groupRemindType.Controls.Add(this.rbRemindType0);
            this.groupRemindType.Controls.Add(this.txtRemind);
            this.groupRemindType.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupRemindType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupRemindType.Location = new System.Drawing.Point(151, 398);
            this.groupRemindType.Name = "groupRemindType";
            this.groupRemindType.Size = new System.Drawing.Size(245, 66);
            this.groupRemindType.TabIndex = 2;
            this.groupRemindType.TabStop = false;
            this.groupRemindType.Text = "Напоминать через каждые";
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.ForeColor = System.Drawing.Color.Red;
            this.lblErr.Location = new System.Drawing.Point(6, 48);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(25, 13);
            this.lblErr.TabIndex = 667;
            this.lblErr.Text = "      ";
            // 
            // rbRemindType1
            // 
            this.rbRemindType1.AutoSize = true;
            this.rbRemindType1.Location = new System.Drawing.Point(185, 22);
            this.rbRemindType1.Name = "rbRemindType1";
            this.rbRemindType1.Size = new System.Drawing.Size(54, 17);
            this.rbRemindType1.TabIndex = 13;
            this.rbRemindType1.TabStop = true;
            this.rbRemindType1.Text = "часов";
            this.rbRemindType1.UseVisualStyleBackColor = true;
            this.rbRemindType1.CheckedChanged += new System.EventHandler(this.RemindType_CheckedChanged);
            // 
            // rbRemindType0
            // 
            this.rbRemindType0.AutoSize = true;
            this.rbRemindType0.Checked = true;
            this.rbRemindType0.Location = new System.Drawing.Point(124, 22);
            this.rbRemindType0.Name = "rbRemindType0";
            this.rbRemindType0.Size = new System.Drawing.Size(55, 17);
            this.rbRemindType0.TabIndex = 12;
            this.rbRemindType0.TabStop = true;
            this.rbRemindType0.Text = "минут";
            this.rbRemindType0.UseVisualStyleBackColor = true;
            this.rbRemindType0.CheckedChanged += new System.EventHandler(this.RemindType_CheckedChanged);
            // 
            // txtRemind
            // 
            this.txtRemind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtRemind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtRemind.Location = new System.Drawing.Point(6, 19);
            this.txtRemind.MaxLength = 10;
            this.txtRemind.Name = "txtRemind";
            this.txtRemind.Size = new System.Drawing.Size(112, 20);
            this.txtRemind.TabIndex = 3;
            this.txtRemind.Text = "0";
            this.txtRemind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemind_KeyPress);
            // 
            // btnAddTime
            // 
            this.btnAddTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddTime.Image = global::XuliOrganizzer.Properties.Resources.AddTime64x64;
            this.btnAddTime.Location = new System.Drawing.Point(3, 407);
            this.btnAddTime.Name = "btnAddTime";
            this.btnAddTime.Size = new System.Drawing.Size(64, 64);
            this.btnAddTime.TabIndex = 21;
            this.btnAddTime.UseVisualStyleBackColor = true;
            this.btnAddTime.Click += new System.EventHandler(this.btnAddTime_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnComplete.Image = global::XuliOrganizzer.Properties.Resources.complete64x64;
            this.btnComplete.Location = new System.Drawing.Point(564, 407);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(64, 64);
            this.btnComplete.TabIndex = 22;
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // tmrTime
            // 
            this.tmrTime.Interval = 500;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.BackColor = System.Drawing.Color.Yellow;
            this.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHeader.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(33, 26);
            this.lblHeader.TabIndex = 667;
            this.lblHeader.Text = "***";
            // 
            // frmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(640, 478);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnAddTime);
            this.Controls.Add(this.groupRemindType);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblTime);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "This is message";
            this.Load += new System.EventHandler(this.frmMessage_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMessage_FormClosing);
            this.groupRemindType.ResumeLayout(false);
            this.groupRemindType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.GroupBox groupRemindType;
        private System.Windows.Forms.RadioButton rbRemindType1;
        private System.Windows.Forms.RadioButton rbRemindType0;
        private System.Windows.Forms.TextBox txtRemind;
        private System.Windows.Forms.Button btnAddTime;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.ToolTip ttButtons;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.Label lblHeader;
    }
}
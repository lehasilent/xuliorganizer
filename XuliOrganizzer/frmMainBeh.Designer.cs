﻿namespace XuliOrganizzer
{
    partial class frmMainBeh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainBeh));
            this.lblText = new System.Windows.Forms.Label();
            this.chkStopQuestion = new System.Windows.Forms.CheckBox();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbMainBeh0 = new System.Windows.Forms.RadioButton();
            this.rbMainBeh1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblText.Location = new System.Drawing.Point(91, 7);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(215, 42);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "Укажите действие при закрытии окна";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkStopQuestion
            // 
            this.chkStopQuestion.AutoSize = true;
            this.chkStopQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkStopQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkStopQuestion.Location = new System.Drawing.Point(82, 94);
            this.chkStopQuestion.Name = "chkStopQuestion";
            this.chkStopQuestion.Size = new System.Drawing.Size(221, 17);
            this.chkStopQuestion.TabIndex = 3;
            this.chkStopQuestion.Text = "Больше не задавать этот вопрос";
            this.chkStopQuestion.UseVisualStyleBackColor = true;
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(3, 117);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 4;
            this.btnYes.Text = "Да";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(247, 117);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 5;
            this.btnNo.Text = "Нет";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::XuliOrganizzer.Properties.Resources.question1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // rbMainBeh0
            // 
            this.rbMainBeh0.AutoSize = true;
            this.rbMainBeh0.Checked = true;
            this.rbMainBeh0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbMainBeh0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.rbMainBeh0.Location = new System.Drawing.Point(117, 53);
            this.rbMainBeh0.Name = "rbMainBeh0";
            this.rbMainBeh0.Size = new System.Drawing.Size(191, 17);
            this.rbMainBeh0.TabIndex = 6;
            this.rbMainBeh0.TabStop = true;
            this.rbMainBeh0.Text = "Свернуть в системный трей";
            this.rbMainBeh0.UseVisualStyleBackColor = true;
            this.rbMainBeh0.CheckedChanged += new System.EventHandler(this.rbMainBeh_CheckedChanged);
            // 
            // rbMainBeh1
            // 
            this.rbMainBeh1.AutoSize = true;
            this.rbMainBeh1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbMainBeh1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.rbMainBeh1.Location = new System.Drawing.Point(117, 73);
            this.rbMainBeh1.Name = "rbMainBeh1";
            this.rbMainBeh1.Size = new System.Drawing.Size(144, 17);
            this.rbMainBeh1.TabIndex = 7;
            this.rbMainBeh1.Text = "Закрыть программу";
            this.rbMainBeh1.UseVisualStyleBackColor = true;
            this.rbMainBeh1.CheckedChanged += new System.EventHandler(this.rbMainBeh_CheckedChanged);
            // 
            // frmMainBeh
            // 
            this.AcceptButton = this.btnYes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 144);
            this.Controls.Add(this.rbMainBeh1);
            this.Controls.Add(this.rbMainBeh0);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.chkStopQuestion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMainBeh";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Действие при закрытии главного окна";
            this.Load += new System.EventHandler(this.frmMainBeh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkStopQuestion;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.RadioButton rbMainBeh0;
        private System.Windows.Forms.RadioButton rbMainBeh1;
    }
}
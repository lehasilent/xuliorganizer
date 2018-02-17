namespace XuliOrganizzer
{
    partial class frmAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCaption = new System.Windows.Forms.RichTextBox();
            this.txtNote = new System.Windows.Forms.RichTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblInsert = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Заголовок:";
            // 
            // txtCaption
            // 
            this.txtCaption.Location = new System.Drawing.Point(65, 3);
            this.txtCaption.Multiline = false;
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtCaption.Size = new System.Drawing.Size(510, 21);
            this.txtCaption.TabIndex = 1;
            this.txtCaption.Text = "";
            this.txtCaption.Enter += new System.EventHandler(this.txtCaption_Enter);
            this.txtCaption.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCaption_KeyUp);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(5, 30);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(570, 360);
            this.txtNote.TabIndex = 2;
            this.txtNote.Text = "";
            this.txtNote.Enter += new System.EventHandler(this.txtNote_Enter);
            this.txtNote.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNote_KeyUp);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(5, 397);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(500, 397);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "О&тмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblInsert
            // 
            this.lblInsert.AutoSize = true;
            this.lblInsert.Location = new System.Drawing.Point(255, 393);
            this.lblInsert.Name = "lblInsert";
            this.lblInsert.Size = new System.Drawing.Size(30, 13);
            this.lblInsert.TabIndex = 5;
            this.lblInsert.Text = "ЗАМ";
            // 
            // frmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 421);
            this.Controls.Add(this.lblInsert);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.txtCaption);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить";
            this.Load += new System.EventHandler(this.frmAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtCaption;
        private System.Windows.Forms.RichTextBox txtNote;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblInsert;
    }
}
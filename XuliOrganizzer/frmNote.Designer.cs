namespace XuliOrganizzer
{
    partial class frmNote
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
            this.lblOnTop = new System.Windows.Forms.Label();
            this.lblFormReset = new System.Windows.Forms.Label();
            this.lblPrev = new System.Windows.Forms.Label();
            this.lblNext = new System.Windows.Forms.Label();
            this.lblDelete = new System.Windows.Forms.Label();
            this.lblSave = new System.Windows.Forms.Label();
            this.lblShowpanel = new System.Windows.Forms.Label();
            this.lblWordwarp = new System.Windows.Forms.Label();
            this.lblFont = new System.Windows.Forms.Label();
            this.lblNew = new System.Windows.Forms.Label();
            this.tpnlControl = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCenterButtons = new System.Windows.Forms.Panel();
            this.lblShowall = new System.Windows.Forms.Label();
            this.dlgFont = new System.Windows.Forms.FontDialog();
            this.lblRecInfo = new System.Windows.Forms.Label();
            this.ttControls = new System.Windows.Forms.ToolTip(this.components);
            this.lblClose = new System.Windows.Forms.Label();
            this.txtCaption = new System.Windows.Forms.RichTextBox();
            this.cmnText = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnTextCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnTextCut = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnTextPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnTextDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnTextSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNote = new System.Windows.Forms.RichTextBox();
            this.pnlNote = new System.Windows.Forms.Panel();
            this.pnlCaption = new System.Windows.Forms.Panel();
            this.lblInsertIndicator = new System.Windows.Forms.Label();
            this.tpnlControl.SuspendLayout();
            this.pnlCenterButtons.SuspendLayout();
            this.cmnText.SuspendLayout();
            this.pnlNote.SuspendLayout();
            this.pnlCaption.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOnTop
            // 
            this.lblOnTop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOnTop.Image = global::XuliOrganizzer.Properties.Resources.knopka24x24;
            this.lblOnTop.Location = new System.Drawing.Point(42, 73);
            this.lblOnTop.Name = "lblOnTop";
            this.lblOnTop.Size = new System.Drawing.Size(24, 24);
            this.lblOnTop.TabIndex = 21;
            this.lblOnTop.Click += new System.EventHandler(this.lblOnTop_Click);
            // 
            // lblFormReset
            // 
            this.lblFormReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFormReset.Image = global::XuliOrganizzer.Properties.Resources.reset24x24;
            this.lblFormReset.Location = new System.Drawing.Point(72, 73);
            this.lblFormReset.Name = "lblFormReset";
            this.lblFormReset.Size = new System.Drawing.Size(24, 24);
            this.lblFormReset.TabIndex = 22;
            this.lblFormReset.Click += new System.EventHandler(this.lblFormReset_Click);
            // 
            // lblPrev
            // 
            this.lblPrev.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPrev.Image = global::XuliOrganizzer.Properties.Resources.left24x24;
            this.lblPrev.Location = new System.Drawing.Point(3, 4);
            this.lblPrev.Name = "lblPrev";
            this.lblPrev.Size = new System.Drawing.Size(24, 24);
            this.lblPrev.TabIndex = 23;
            this.lblPrev.Click += new System.EventHandler(this.lblPrev_Click);
            // 
            // lblNext
            // 
            this.lblNext.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNext.Image = global::XuliOrganizzer.Properties.Resources.right24x24;
            this.lblNext.Location = new System.Drawing.Point(263, 4);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(24, 24);
            this.lblNext.TabIndex = 24;
            this.lblNext.Click += new System.EventHandler(this.lblNext_Click);
            // 
            // lblDelete
            // 
            this.lblDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDelete.Image = global::XuliOrganizzer.Properties.Resources.Trash;
            this.lblDelete.Location = new System.Drawing.Point(154, 1);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(24, 24);
            this.lblDelete.TabIndex = 25;
            this.lblDelete.Click += new System.EventHandler(this.lblDelete_Click);
            // 
            // lblSave
            // 
            this.lblSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSave.Image = global::XuliOrganizzer.Properties.Resources.save24x241;
            this.lblSave.Location = new System.Drawing.Point(11, 1);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(24, 24);
            this.lblSave.TabIndex = 26;
            this.lblSave.Click += new System.EventHandler(this.lblSave_Click);
            // 
            // lblShowpanel
            // 
            this.lblShowpanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblShowpanel.Image = global::XuliOrganizzer.Properties.Resources.showpanel24x24;
            this.lblShowpanel.Location = new System.Drawing.Point(102, 73);
            this.lblShowpanel.Name = "lblShowpanel";
            this.lblShowpanel.Size = new System.Drawing.Size(24, 24);
            this.lblShowpanel.TabIndex = 27;
            this.lblShowpanel.Click += new System.EventHandler(this.lblShowpanel_Click);
            // 
            // lblWordwarp
            // 
            this.lblWordwarp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblWordwarp.Image = global::XuliOrganizzer.Properties.Resources.wordwarp_on24x24;
            this.lblWordwarp.Location = new System.Drawing.Point(98, 1);
            this.lblWordwarp.Name = "lblWordwarp";
            this.lblWordwarp.Size = new System.Drawing.Size(24, 24);
            this.lblWordwarp.TabIndex = 28;
            this.lblWordwarp.Click += new System.EventHandler(this.lblWordwarp_Click);
            // 
            // lblFont
            // 
            this.lblFont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFont.Image = global::XuliOrganizzer.Properties.Resources.font24x24;
            this.lblFont.Location = new System.Drawing.Point(70, 1);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(24, 24);
            this.lblFont.TabIndex = 29;
            this.lblFont.Click += new System.EventHandler(this.lblFont_Click);
            // 
            // lblNew
            // 
            this.lblNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNew.Image = global::XuliOrganizzer.Properties.Resources.newfile24x24;
            this.lblNew.Location = new System.Drawing.Point(41, 1);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(24, 24);
            this.lblNew.TabIndex = 30;
            this.lblNew.Click += new System.EventHandler(this.lblNew_Click);
            // 
            // tpnlControl
            // 
            this.tpnlControl.ColumnCount = 3;
            this.tpnlControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tpnlControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tpnlControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tpnlControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpnlControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpnlControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpnlControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpnlControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpnlControl.Controls.Add(this.pnlCenterButtons, 1, 0);
            this.tpnlControl.Controls.Add(this.lblNext, 2, 0);
            this.tpnlControl.Controls.Add(this.lblPrev, 0, 0);
            this.tpnlControl.Location = new System.Drawing.Point(0, 12);
            this.tpnlControl.Name = "tpnlControl";
            this.tpnlControl.RowCount = 1;
            this.tpnlControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlControl.Size = new System.Drawing.Size(290, 32);
            this.tpnlControl.TabIndex = 32;
            // 
            // pnlCenterButtons
            // 
            this.pnlCenterButtons.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlCenterButtons.Controls.Add(this.lblShowall);
            this.pnlCenterButtons.Controls.Add(this.lblDelete);
            this.pnlCenterButtons.Controls.Add(this.lblSave);
            this.pnlCenterButtons.Controls.Add(this.lblNew);
            this.pnlCenterButtons.Controls.Add(this.lblWordwarp);
            this.pnlCenterButtons.Controls.Add(this.lblFont);
            this.pnlCenterButtons.Location = new System.Drawing.Point(51, 3);
            this.pnlCenterButtons.Name = "pnlCenterButtons";
            this.pnlCenterButtons.Size = new System.Drawing.Size(187, 26);
            this.pnlCenterButtons.TabIndex = 34;
            // 
            // lblShowall
            // 
            this.lblShowall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblShowall.Image = global::XuliOrganizzer.Properties.Resources.showallrec24x24;
            this.lblShowall.Location = new System.Drawing.Point(128, 1);
            this.lblShowall.Name = "lblShowall";
            this.lblShowall.Size = new System.Drawing.Size(24, 24);
            this.lblShowall.TabIndex = 34;
            this.lblShowall.Click += new System.EventHandler(this.lblShowall_Click);
            // 
            // dlgFont
            // 
            this.dlgFont.ShowColor = true;
            // 
            // lblRecInfo
            // 
            this.lblRecInfo.AutoSize = true;
            this.lblRecInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblRecInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRecInfo.ForeColor = System.Drawing.Color.Yellow;
            this.lblRecInfo.Location = new System.Drawing.Point(229, 83);
            this.lblRecInfo.Name = "lblRecInfo";
            this.lblRecInfo.Size = new System.Drawing.Size(38, 24);
            this.lblRecInfo.TabIndex = 33;
            this.lblRecInfo.Text = "0/0";
            // 
            // lblClose
            // 
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Image = global::XuliOrganizzer.Properties.Resources.close24x24;
            this.lblClose.Location = new System.Drawing.Point(12, 73);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(24, 24);
            this.lblClose.TabIndex = 34;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // txtCaption
            // 
            this.txtCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCaption.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCaption.ContextMenuStrip = this.cmnText;
            this.txtCaption.DetectUrls = false;
            this.txtCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCaption.Location = new System.Drawing.Point(0, 0);
            this.txtCaption.Multiline = false;
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtCaption.ShortcutsEnabled = false;
            this.txtCaption.Size = new System.Drawing.Size(270, 21);
            this.txtCaption.TabIndex = 35;
            this.txtCaption.Text = "";
            this.txtCaption.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtCaption.Leave += new System.EventHandler(this.TextBox_Leave);
            this.txtCaption.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyUp);
            // 
            // cmnText
            // 
            this.cmnText.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnTextCopy,
            this.cmnTextCut,
            this.cmnTextPaste,
            this.cmnTextDelete,
            this.toolStripSeparator1,
            this.cmnTextSelectAll});
            this.cmnText.Name = "cmnText";
            this.cmnText.Size = new System.Drawing.Size(157, 120);
            // 
            // cmnTextCopy
            // 
            this.cmnTextCopy.Name = "cmnTextCopy";
            this.cmnTextCopy.Size = new System.Drawing.Size(156, 22);
            this.cmnTextCopy.Text = "Скопировать";
            this.cmnTextCopy.Click += new System.EventHandler(this.cmnTextCopy_Click);
            // 
            // cmnTextCut
            // 
            this.cmnTextCut.Name = "cmnTextCut";
            this.cmnTextCut.Size = new System.Drawing.Size(156, 22);
            this.cmnTextCut.Text = "Вырезать";
            this.cmnTextCut.Click += new System.EventHandler(this.cmnTextCut_Click);
            // 
            // cmnTextPaste
            // 
            this.cmnTextPaste.Name = "cmnTextPaste";
            this.cmnTextPaste.Size = new System.Drawing.Size(156, 22);
            this.cmnTextPaste.Text = "Вставить";
            this.cmnTextPaste.Click += new System.EventHandler(this.cmnTextPaste_Click);
            // 
            // cmnTextDelete
            // 
            this.cmnTextDelete.Name = "cmnTextDelete";
            this.cmnTextDelete.Size = new System.Drawing.Size(156, 22);
            this.cmnTextDelete.Text = "Удалить";
            this.cmnTextDelete.Click += new System.EventHandler(this.cmnTextDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // cmnTextSelectAll
            // 
            this.cmnTextSelectAll.Name = "cmnTextSelectAll";
            this.cmnTextSelectAll.Size = new System.Drawing.Size(156, 22);
            this.cmnTextSelectAll.Text = "Выделить все";
            this.cmnTextSelectAll.Click += new System.EventHandler(this.cmnTextSelectAll_Click);
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNote.ContextMenuStrip = this.cmnText;
            this.txtNote.DetectUrls = false;
            this.txtNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNote.Location = new System.Drawing.Point(0, 0);
            this.txtNote.Name = "txtNote";
            this.txtNote.ShortcutsEnabled = false;
            this.txtNote.Size = new System.Drawing.Size(221, 95);
            this.txtNote.TabIndex = 36;
            this.txtNote.Text = "";
            this.txtNote.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtNote.Leave += new System.EventHandler(this.TextBox_Leave);
            this.txtNote.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyUp);
            // 
            // pnlNote
            // 
            this.pnlNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNote.Controls.Add(this.txtNote);
            this.pnlNote.Location = new System.Drawing.Point(6, 126);
            this.pnlNote.Name = "pnlNote";
            this.pnlNote.Size = new System.Drawing.Size(223, 97);
            this.pnlNote.TabIndex = 37;
            // 
            // pnlCaption
            // 
            this.pnlCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCaption.Controls.Add(this.txtCaption);
            this.pnlCaption.Location = new System.Drawing.Point(7, 229);
            this.pnlCaption.Name = "pnlCaption";
            this.pnlCaption.Size = new System.Drawing.Size(272, 23);
            this.pnlCaption.TabIndex = 38;
            // 
            // lblInsertIndicator
            // 
            this.lblInsertIndicator.AutoSize = true;
            this.lblInsertIndicator.Location = new System.Drawing.Point(5, 256);
            this.lblInsertIndicator.Name = "lblInsertIndicator";
            this.lblInsertIndicator.Size = new System.Drawing.Size(16, 13);
            this.lblInsertIndicator.TabIndex = 39;
            this.lblInsertIndicator.Text = "   ";
            // 
            // frmNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(296, 278);
            this.Controls.Add(this.lblInsertIndicator);
            this.Controls.Add(this.pnlNote);
            this.Controls.Add(this.pnlCaption);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblRecInfo);
            this.Controls.Add(this.tpnlControl);
            this.Controls.Add(this.lblShowpanel);
            this.Controls.Add(this.lblFormReset);
            this.Controls.Add(this.lblOnTop);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmNote";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmNote_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNote_FormClosing);
            this.Resize += new System.EventHandler(this.frmNote_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNote_KeyDown);
            this.tpnlControl.ResumeLayout(false);
            this.pnlCenterButtons.ResumeLayout(false);
            this.cmnText.ResumeLayout(false);
            this.pnlNote.ResumeLayout(false);
            this.pnlCaption.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOnTop;
        private System.Windows.Forms.Label lblFormReset;
        private System.Windows.Forms.Label lblPrev;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.Label lblShowpanel;
        private System.Windows.Forms.Label lblWordwarp;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.TableLayoutPanel tpnlControl;
        private System.Windows.Forms.FontDialog dlgFont;
        private System.Windows.Forms.Label lblRecInfo;
        private System.Windows.Forms.Panel pnlCenterButtons;
        private System.Windows.Forms.Label lblShowall;
        private System.Windows.Forms.ToolTip ttControls;
        private System.Windows.Forms.Label lblClose;
        //private XuliOrganizzer.myRichTextBox txtCaption;
        //private XuliOrganizzer.myRichTextBox txtNote;
        private System.Windows.Forms.RichTextBox txtCaption;
        private System.Windows.Forms.RichTextBox txtNote;
        private System.Windows.Forms.Panel pnlNote;
        private System.Windows.Forms.Panel pnlCaption;
        private System.Windows.Forms.Label lblInsertIndicator;
        private System.Windows.Forms.ContextMenuStrip cmnText;
        private System.Windows.Forms.ToolStripMenuItem cmnTextCopy;
        private System.Windows.Forms.ToolStripMenuItem cmnTextCut;
        private System.Windows.Forms.ToolStripMenuItem cmnTextDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmnTextSelectAll;
        private System.Windows.Forms.ToolStripMenuItem cmnTextPaste;
    }
}
namespace XuliOrganizzer
{
    partial class frmAllNotes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAllNotes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsOneNote = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuToolsTrash = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuToolsRestoreWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditFind = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrash = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrashNormalRecords = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTrashRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrashRestoreAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTrashDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrashClean = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFieldNameDSBL = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindDown = new System.Windows.Forms.ToolStripMenuItem();
            this.mtxtFind = new System.Windows.Forms.ToolStripTextBox();
            this.mnuFindDSBL = new System.Windows.Forms.ToolStripMenuItem();
            this.grdMain = new System.Windows.Forms.DataGridView();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.mnuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTools,
            this.mnuEdit,
            this.mnuTrash,
            this.mnuFieldNameDSBL,
            this.mnuFindUp,
            this.mnuFindDown,
            this.mtxtFind,
            this.mnuFindDSBL});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(593, 25);
            this.mnuMain.TabIndex = 2;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsOneNote,
            this.toolStripSeparator4,
            this.mnuToolsTrash,
            this.mnuToolsSave,
            this.mnuToolsSaveAll,
            this.toolStripSeparator2,
            this.mnuToolsRestoreWindow,
            this.mnuToolsExit});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(87, 21);
            this.mnuTools.Text = "&Инструменты";
            // 
            // mnuToolsOneNote
            // 
            this.mnuToolsOneNote.Name = "mnuToolsOneNote";
            this.mnuToolsOneNote.Size = new System.Drawing.Size(254, 22);
            this.mnuToolsOneNote.Text = "&Режим одной заметки";
            this.mnuToolsOneNote.Click += new System.EventHandler(this.mnuToolsOneNote_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(251, 6);
            // 
            // mnuToolsTrash
            // 
            this.mnuToolsTrash.Name = "mnuToolsTrash";
            this.mnuToolsTrash.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.mnuToolsTrash.Size = new System.Drawing.Size(254, 22);
            this.mnuToolsTrash.Text = "&Корзина";
            this.mnuToolsTrash.Click += new System.EventHandler(this.mnuToolsTrash_Click);
            // 
            // mnuToolsSave
            // 
            this.mnuToolsSave.Name = "mnuToolsSave";
            this.mnuToolsSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuToolsSave.Size = new System.Drawing.Size(254, 22);
            this.mnuToolsSave.Text = "С&охранить в файл...";
            this.mnuToolsSave.Click += new System.EventHandler(this.mnuToolsSave_Click);
            // 
            // mnuToolsSaveAll
            // 
            this.mnuToolsSaveAll.Name = "mnuToolsSaveAll";
            this.mnuToolsSaveAll.Size = new System.Drawing.Size(254, 22);
            this.mnuToolsSaveAll.Text = "Со&хранить все заметки в файл...";
            this.mnuToolsSaveAll.Click += new System.EventHandler(this.mnuToolsSaveAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(251, 6);
            // 
            // mnuToolsRestoreWindow
            // 
            this.mnuToolsRestoreWindow.Name = "mnuToolsRestoreWindow";
            this.mnuToolsRestoreWindow.Size = new System.Drawing.Size(254, 22);
            this.mnuToolsRestoreWindow.Text = "&Восстановить окно";
            this.mnuToolsRestoreWindow.Click += new System.EventHandler(this.mnuToolsRestoreWindow_Click);
            // 
            // mnuToolsExit
            // 
            this.mnuToolsExit.Name = "mnuToolsExit";
            this.mnuToolsExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.mnuToolsExit.Size = new System.Drawing.Size(254, 22);
            this.mnuToolsExit.Text = "&Закрыть";
            this.mnuToolsExit.Click += new System.EventHandler(this.mnuToolsExit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditCopy,
            this.toolStripSeparator1,
            this.mnuEditAdd,
            this.mnuEditEdit,
            this.mnuEditFind,
            this.mnuEditDelete,
            this.toolStripSeparator3,
            this.mnuEditDeleteAll});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(98, 21);
            this.mnuEdit.Text = "&Редактировать";
            // 
            // mnuEditCopy
            // 
            this.mnuEditCopy.Name = "mnuEditCopy";
            this.mnuEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuEditCopy.Size = new System.Drawing.Size(214, 22);
            this.mnuEditCopy.Text = "&Копировать";
            this.mnuEditCopy.Click += new System.EventHandler(this.mnuEditCopy_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // mnuEditAdd
            // 
            this.mnuEditAdd.Name = "mnuEditAdd";
            this.mnuEditAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
            this.mnuEditAdd.Size = new System.Drawing.Size(214, 22);
            this.mnuEditAdd.Text = "&Добавить...";
            this.mnuEditAdd.Click += new System.EventHandler(this.mnuEditAdd_Click);
            // 
            // mnuEditEdit
            // 
            this.mnuEditEdit.Name = "mnuEditEdit";
            this.mnuEditEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuEditEdit.Size = new System.Drawing.Size(214, 22);
            this.mnuEditEdit.Text = "&Редактировать...";
            this.mnuEditEdit.Click += new System.EventHandler(this.mnuEditEdit_Click);
            // 
            // mnuEditFind
            // 
            this.mnuEditFind.Name = "mnuEditFind";
            this.mnuEditFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuEditFind.Size = new System.Drawing.Size(214, 22);
            this.mnuEditFind.Text = "&Найти...";
            this.mnuEditFind.Click += new System.EventHandler(this.mnuEditFind_Click);
            // 
            // mnuEditDelete
            // 
            this.mnuEditDelete.Name = "mnuEditDelete";
            this.mnuEditDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.mnuEditDelete.Size = new System.Drawing.Size(214, 22);
            this.mnuEditDelete.Text = "&Удалить...";
            this.mnuEditDelete.Click += new System.EventHandler(this.mnuEditDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(211, 6);
            // 
            // mnuEditDeleteAll
            // 
            this.mnuEditDeleteAll.Name = "mnuEditDeleteAll";
            this.mnuEditDeleteAll.Size = new System.Drawing.Size(214, 22);
            this.mnuEditDeleteAll.Text = "Удалить все...";
            this.mnuEditDeleteAll.Click += new System.EventHandler(this.mnuEditDeleteAll_Click);
            // 
            // mnuTrash
            // 
            this.mnuTrash.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTrashNormalRecords,
            this.toolStripSeparator5,
            this.mnuTrashRestore,
            this.mnuTrashRestoreAll,
            this.toolStripSeparator6,
            this.mnuTrashDelete,
            this.mnuTrashClean});
            this.mnuTrash.Name = "mnuTrash";
            this.mnuTrash.Size = new System.Drawing.Size(61, 21);
            this.mnuTrash.Text = "&Корзина";
            // 
            // mnuTrashNormalRecords
            // 
            this.mnuTrashNormalRecords.Name = "mnuTrashNormalRecords";
            this.mnuTrashNormalRecords.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.mnuTrashNormalRecords.Size = new System.Drawing.Size(280, 22);
            this.mnuTrashNormalRecords.Text = "Вернуться к просмотру записей";
            this.mnuTrashNormalRecords.Click += new System.EventHandler(this.mnuTrashNormalRecords_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(277, 6);
            // 
            // mnuTrashRestore
            // 
            this.mnuTrashRestore.Name = "mnuTrashRestore";
            this.mnuTrashRestore.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.mnuTrashRestore.Size = new System.Drawing.Size(280, 22);
            this.mnuTrashRestore.Text = "&Восстановить";
            this.mnuTrashRestore.Click += new System.EventHandler(this.mnuTrashRestore_Click);
            // 
            // mnuTrashRestoreAll
            // 
            this.mnuTrashRestoreAll.Name = "mnuTrashRestoreAll";
            this.mnuTrashRestoreAll.Size = new System.Drawing.Size(280, 22);
            this.mnuTrashRestoreAll.Text = "Восстановить все...";
            this.mnuTrashRestoreAll.Click += new System.EventHandler(this.mnuTrashRestoreAll_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(277, 6);
            // 
            // mnuTrashDelete
            // 
            this.mnuTrashDelete.Name = "mnuTrashDelete";
            this.mnuTrashDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            this.mnuTrashDelete.Size = new System.Drawing.Size(280, 22);
            this.mnuTrashDelete.Text = "&Удалить...";
            this.mnuTrashDelete.Click += new System.EventHandler(this.mnuTrashDelete_Click);
            // 
            // mnuTrashClean
            // 
            this.mnuTrashClean.Name = "mnuTrashClean";
            this.mnuTrashClean.Size = new System.Drawing.Size(280, 22);
            this.mnuTrashClean.Text = "&Очистить...";
            this.mnuTrashClean.Click += new System.EventHandler(this.mnuTrashClean_Click);
            // 
            // mnuFieldNameDSBL
            // 
            this.mnuFieldNameDSBL.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuFieldNameDSBL.Enabled = false;
            this.mnuFieldNameDSBL.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuFieldNameDSBL.Name = "mnuFieldNameDSBL";
            this.mnuFieldNameDSBL.Size = new System.Drawing.Size(12, 21);
            this.mnuFieldNameDSBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mnuFindUp
            // 
            this.mnuFindUp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuFindUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuFindUp.Image = ((System.Drawing.Image)(resources.GetObject("mnuFindUp.Image")));
            this.mnuFindUp.Name = "mnuFindUp";
            this.mnuFindUp.Size = new System.Drawing.Size(28, 21);
            this.mnuFindUp.Text = "Up";
            this.mnuFindUp.Click += new System.EventHandler(this.mnuFindUp_Click);
            // 
            // mnuFindDown
            // 
            this.mnuFindDown.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuFindDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuFindDown.Image = ((System.Drawing.Image)(resources.GetObject("mnuFindDown.Image")));
            this.mnuFindDown.Name = "mnuFindDown";
            this.mnuFindDown.Size = new System.Drawing.Size(28, 21);
            this.mnuFindDown.Text = "Down";
            this.mnuFindDown.Click += new System.EventHandler(this.mnuFindDown_Click);
            // 
            // mtxtFind
            // 
            this.mtxtFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mtxtFind.Name = "mtxtFind";
            this.mtxtFind.Size = new System.Drawing.Size(100, 21);
            this.mtxtFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtFind_KeyUp);
            this.mtxtFind.TextChanged += new System.EventHandler(this.mtxtFind_TextChanged);
            // 
            // mnuFindDSBL
            // 
            this.mnuFindDSBL.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuFindDSBL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuFindDSBL.Enabled = false;
            this.mnuFindDSBL.Name = "mnuFindDSBL";
            this.mnuFindDSBL.Size = new System.Drawing.Size(43, 21);
            this.mnuFindDSBL.Text = "Find:";
            this.mnuFindDSBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdMain
            // 
            this.grdMain.AllowUserToAddRows = false;
            this.grdMain.AllowUserToDeleteRows = false;
            this.grdMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdMain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMain.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMain.Location = new System.Drawing.Point(0, 25);
            this.grdMain.MultiSelect = false;
            this.grdMain.Name = "grdMain";
            this.grdMain.ReadOnly = true;
            this.grdMain.Size = new System.Drawing.Size(593, 321);
            this.grdMain.TabIndex = 3;
            this.grdMain.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMain_CellDoubleClick);
            this.grdMain.SelectionChanged += new System.EventHandler(this.grdMain_SelectionChanged);
            // 
            // dlgSaveFile
            // 
            this.dlgSaveFile.Filter = "Текстовые файлы (*.txt)|*.txt";
            // 
            // frmAllNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 346);
            this.Controls.Add(this.grdMain);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAllNotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Все заметки";
            this.Load += new System.EventHandler(this.frmAllNotes_Load);
            this.Shown += new System.EventHandler(this.frmAllNotes_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAllNotes_FormClosing);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuEditCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuEditAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuEditEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuEditDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsOneNote;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsTrash;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsExit;
        private System.Windows.Forms.ToolStripMenuItem mnuTrash;
        private System.Windows.Forms.ToolStripMenuItem mnuTrashRestore;
        private System.Windows.Forms.ToolStripMenuItem mnuFieldNameDSBL;
        private System.Windows.Forms.ToolStripMenuItem mnuFindUp;
        private System.Windows.Forms.ToolStripMenuItem mnuFindDown;
        private System.Windows.Forms.ToolStripTextBox mtxtFind;
        private System.Windows.Forms.ToolStripMenuItem mnuFindDSBL;
        private System.Windows.Forms.DataGridView grdMain;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsSave;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsSaveAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuTrashDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsRestoreWindow;
        private System.Windows.Forms.ToolStripMenuItem mnuTrashClean;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuEditDeleteAll;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private System.Windows.Forms.ToolStripMenuItem mnuTrashNormalRecords;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mnuTrashRestoreAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuEditFind;
    }
}
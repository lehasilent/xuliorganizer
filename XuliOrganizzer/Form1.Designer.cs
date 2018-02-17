namespace XuliOrganizzer
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.niMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmnMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnMainTasks = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnMainNote = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnMainAllNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnMainTimer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnMainExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileTimer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileNote = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileAllNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileRestoreWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileCopyConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileHide = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditFind = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditDouble = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditViewLog = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditClearLog = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditClearLogAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditActivate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFieldNameDSBL = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindDown = new System.Windows.Forms.ToolStripMenuItem();
            this.mtxtFind = new System.Windows.Forms.ToolStripTextBox();
            this.mnuFindDSBL = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTasks = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTasksStartAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTasksStopAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTasksRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.grdMain = new System.Windows.Forms.DataGridView();
            this.cmnGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnGridActivate = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnGridDouble = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnGridClearLogAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnGridEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnGridDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.statMessages = new System.Windows.Forms.StatusStrip();
            this.statlblMessages = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnMain.SuspendLayout();
            this.mnuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            this.cmnGrid.SuspendLayout();
            this.statMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // niMain
            // 
            this.niMain.ContextMenuStrip = this.cmnMain;
            this.niMain.Text = "XuliOrganizzer";
            this.niMain.Visible = true;
            this.niMain.DoubleClick += new System.EventHandler(this.niMain_DoubleClick);
            // 
            // cmnMain
            // 
            this.cmnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnMainTasks,
            this.cmnMainNote,
            this.cmnMainAllNotes,
            this.cmnMainTimer,
            this.toolStripSeparator1,
            this.cmnMainExit});
            this.cmnMain.Name = "cmnMain";
            this.cmnMain.Size = new System.Drawing.Size(234, 120);
            // 
            // cmnMainTasks
            // 
            this.cmnMainTasks.Name = "cmnMainTasks";
            this.cmnMainTasks.Size = new System.Drawing.Size(233, 22);
            this.cmnMainTasks.Text = "Задачи...";
            this.cmnMainTasks.Click += new System.EventHandler(this.cmnMainTasks_Click);
            // 
            // cmnMainNote
            // 
            this.cmnMainNote.Name = "cmnMainNote";
            this.cmnMainNote.Size = new System.Drawing.Size(233, 22);
            this.cmnMainNote.Text = "Заметка...";
            this.cmnMainNote.Click += new System.EventHandler(this.cmnMainNote_Click);
            // 
            // cmnMainAllNotes
            // 
            this.cmnMainAllNotes.Name = "cmnMainAllNotes";
            this.cmnMainAllNotes.Size = new System.Drawing.Size(233, 22);
            this.cmnMainAllNotes.Text = "Все заметки...";
            this.cmnMainAllNotes.Click += new System.EventHandler(this.cmnMainAllNotes_Click);
            // 
            // cmnMainTimer
            // 
            this.cmnMainTimer.Name = "cmnMainTimer";
            this.cmnMainTimer.Size = new System.Drawing.Size(233, 22);
            this.cmnMainTimer.Text = "Таймер обратного отсчета...";
            this.cmnMainTimer.Click += new System.EventHandler(this.cmnMainTimer_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(230, 6);
            // 
            // cmnMainExit
            // 
            this.cmnMainExit.Name = "cmnMainExit";
            this.cmnMainExit.Size = new System.Drawing.Size(233, 22);
            this.cmnMainExit.Text = "Выход";
            this.cmnMainExit.Click += new System.EventHandler(this.cmnMainExit_Click);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuFieldNameDSBL,
            this.mnuFindUp,
            this.mnuFindDown,
            this.mtxtFind,
            this.mnuFindDSBL,
            this.mnuTasks,
            this.toolStripMenuItem1,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(632, 25);
            this.mnuMain.TabIndex = 3;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileTimer,
            this.mnuFileNote,
            this.mnuFileAllNotes,
            this.toolStripSeparator2,
            this.mnuFileOptions,
            this.mnuFileRestoreWindow,
            this.mnuFileCopyConfig,
            this.toolStripSeparator4,
            this.mnuFileHide,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(45, 21);
            this.mnuFile.Text = "&Файл";
            // 
            // mnuFileTimer
            // 
            this.mnuFileTimer.Name = "mnuFileTimer";
            this.mnuFileTimer.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.mnuFileTimer.Size = new System.Drawing.Size(219, 22);
            this.mnuFileTimer.Text = "&Таймер...";
            this.mnuFileTimer.Click += new System.EventHandler(this.mnuFileTimer_Click);
            // 
            // mnuFileNote
            // 
            this.mnuFileNote.Name = "mnuFileNote";
            this.mnuFileNote.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.mnuFileNote.Size = new System.Drawing.Size(219, 22);
            this.mnuFileNote.Text = "З&аметка...";
            this.mnuFileNote.Click += new System.EventHandler(this.mnuFileNote_Click);
            // 
            // mnuFileAllNotes
            // 
            this.mnuFileAllNotes.Name = "mnuFileAllNotes";
            this.mnuFileAllNotes.Size = new System.Drawing.Size(219, 22);
            this.mnuFileAllNotes.Text = "Вс&е заметки...";
            this.mnuFileAllNotes.Click += new System.EventHandler(this.mnuFileAllNotes_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(216, 6);
            // 
            // mnuFileOptions
            // 
            this.mnuFileOptions.Name = "mnuFileOptions";
            this.mnuFileOptions.Size = new System.Drawing.Size(219, 22);
            this.mnuFileOptions.Text = "&Опции...";
            this.mnuFileOptions.Click += new System.EventHandler(this.mnuFileOptions_Click);
            // 
            // mnuFileRestoreWindow
            // 
            this.mnuFileRestoreWindow.Name = "mnuFileRestoreWindow";
            this.mnuFileRestoreWindow.Size = new System.Drawing.Size(219, 22);
            this.mnuFileRestoreWindow.Text = "&Восстановить окно";
            this.mnuFileRestoreWindow.Click += new System.EventHandler(this.mnuFileRestoreWindow_Click);
            // 
            // mnuFileCopyConfig
            // 
            this.mnuFileCopyConfig.Name = "mnuFileCopyConfig";
            this.mnuFileCopyConfig.Size = new System.Drawing.Size(219, 22);
            this.mnuFileCopyConfig.Text = "С&копировать БД в файл...";
            this.mnuFileCopyConfig.Click += new System.EventHandler(this.mnuFileCopyConfig_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(216, 6);
            // 
            // mnuFileHide
            // 
            this.mnuFileHide.Name = "mnuFileHide";
            this.mnuFileHide.Size = new System.Drawing.Size(219, 22);
            this.mnuFileHide.Text = "Скр&ыть";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(219, 22);
            this.mnuFileExit.Text = "Вы&ход";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditFind,
            this.toolStripSeparator3,
            this.mnuEditAdd,
            this.mnuEditEdit,
            this.mnuEditDelete,
            this.mnuEditDouble,
            this.toolStripSeparator5,
            this.mnuEditViewLog,
            this.mnuEditClearLog,
            this.mnuEditClearLogAll,
            this.toolStripSeparator6,
            this.mnuEditActivate});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(98, 21);
            this.mnuEdit.Text = "&Редактировать";
            // 
            // mnuEditFind
            // 
            this.mnuEditFind.Name = "mnuEditFind";
            this.mnuEditFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuEditFind.Size = new System.Drawing.Size(214, 22);
            this.mnuEditFind.Text = "&Найти...";
            this.mnuEditFind.Click += new System.EventHandler(this.mnuEditFind_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(211, 6);
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
            // mnuEditDelete
            // 
            this.mnuEditDelete.Name = "mnuEditDelete";
            this.mnuEditDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.mnuEditDelete.Size = new System.Drawing.Size(214, 22);
            this.mnuEditDelete.Text = "&Удалить...";
            this.mnuEditDelete.Click += new System.EventHandler(this.mnuEditDelete_Click);
            // 
            // mnuEditDouble
            // 
            this.mnuEditDouble.Name = "mnuEditDouble";
            this.mnuEditDouble.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnuEditDouble.Size = new System.Drawing.Size(214, 22);
            this.mnuEditDouble.Text = "Дублировать";
            this.mnuEditDouble.Click += new System.EventHandler(this.mnuEditDouble_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(211, 6);
            // 
            // mnuEditViewLog
            // 
            this.mnuEditViewLog.Name = "mnuEditViewLog";
            this.mnuEditViewLog.Size = new System.Drawing.Size(214, 22);
            this.mnuEditViewLog.Text = "Смотреть протокол";
            this.mnuEditViewLog.Click += new System.EventHandler(this.mnuEditViewLog_Click);
            // 
            // mnuEditClearLog
            // 
            this.mnuEditClearLog.Name = "mnuEditClearLog";
            this.mnuEditClearLog.Size = new System.Drawing.Size(214, 22);
            this.mnuEditClearLog.Text = "Очистить протокол";
            this.mnuEditClearLog.Click += new System.EventHandler(this.mnuEditClearLog_Click);
            // 
            // mnuEditClearLogAll
            // 
            this.mnuEditClearLogAll.Name = "mnuEditClearLogAll";
            this.mnuEditClearLogAll.Size = new System.Drawing.Size(214, 22);
            this.mnuEditClearLogAll.Text = "Очистить все протоколы";
            this.mnuEditClearLogAll.Click += new System.EventHandler(this.mnuEditClearLogAll_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(211, 6);
            // 
            // mnuEditActivate
            // 
            this.mnuEditActivate.Name = "mnuEditActivate";
            this.mnuEditActivate.Size = new System.Drawing.Size(214, 22);
            this.mnuEditActivate.Text = "Деактивировать";
            this.mnuEditActivate.Click += new System.EventHandler(this.mnuEditActivate_Click);
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
            // mnuTasks
            // 
            this.mnuTasks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTasksStartAll,
            this.mnuTasksStopAll,
            this.mnuTasksRestart});
            this.mnuTasks.Name = "mnuTasks";
            this.mnuTasks.Size = new System.Drawing.Size(56, 21);
            this.mnuTasks.Text = "&Задачи";
            // 
            // mnuTasksStartAll
            // 
            this.mnuTasksStartAll.Name = "mnuTasksStartAll";
            this.mnuTasksStartAll.Size = new System.Drawing.Size(179, 22);
            this.mnuTasksStartAll.Text = "З&апуск всех задач";
            this.mnuTasksStartAll.Click += new System.EventHandler(this.mnuTasksStartAll_Click);
            // 
            // mnuTasksStopAll
            // 
            this.mnuTasksStopAll.Name = "mnuTasksStopAll";
            this.mnuTasksStopAll.Size = new System.Drawing.Size(179, 22);
            this.mnuTasksStopAll.Text = "&Остановить все";
            this.mnuTasksStopAll.Click += new System.EventHandler(this.mnuTasksStopAll_Click);
            // 
            // mnuTasksRestart
            // 
            this.mnuTasksRestart.Name = "mnuTasksRestart";
            this.mnuTasksRestart.Size = new System.Drawing.Size(179, 22);
            this.mnuTasksRestart.Text = "Пере&запуск";
            this.mnuTasksRestart.Click += new System.EventHandler(this.mnuTasksRestart_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 21);
            // 
            // dlgSave
            // 
            this.dlgSave.Filter = "Файлы XML (*.xml)|*.xml";
            // 
            // grdMain
            // 
            this.grdMain.AllowUserToAddRows = false;
            this.grdMain.AllowUserToDeleteRows = false;
            this.grdMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdMain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMain.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdMain.Location = new System.Drawing.Point(0, 25);
            this.grdMain.MultiSelect = false;
            this.grdMain.Name = "grdMain";
            this.grdMain.ReadOnly = true;
            this.grdMain.Size = new System.Drawing.Size(632, 402);
            this.grdMain.TabIndex = 4;
            this.grdMain.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdMain_CellMouseClick);
            this.grdMain.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMain_CellDoubleClick);
            this.grdMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdMain_MouseClick);
            this.grdMain.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.grdMain_RowPrePaint);
            this.grdMain.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdMain_CellFormatting);
            this.grdMain.SelectionChanged += new System.EventHandler(this.grdMain_SelectionChanged);
            // 
            // cmnGrid
            // 
            this.cmnGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnGridActivate,
            this.cmnGridDouble,
            this.toolStripSeparator8,
            this.cmnGridClearLogAll,
            this.toolStripSeparator7,
            this.cmnGridEdit,
            this.cmnGridDelete});
            this.cmnGrid.Name = "cmnGrid";
            this.cmnGrid.Size = new System.Drawing.Size(186, 126);
            // 
            // cmnGridActivate
            // 
            this.cmnGridActivate.Name = "cmnGridActivate";
            this.cmnGridActivate.Size = new System.Drawing.Size(185, 22);
            this.cmnGridActivate.Text = "Активировать";
            this.cmnGridActivate.Click += new System.EventHandler(this.cmnGridMenuItem_Click);
            // 
            // cmnGridDouble
            // 
            this.cmnGridDouble.Name = "cmnGridDouble";
            this.cmnGridDouble.Size = new System.Drawing.Size(185, 22);
            this.cmnGridDouble.Text = "Дублировать";
            this.cmnGridDouble.Click += new System.EventHandler(this.cmnGridMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(182, 6);
            // 
            // cmnGridClearLogAll
            // 
            this.cmnGridClearLogAll.Name = "cmnGridClearLogAll";
            this.cmnGridClearLogAll.Size = new System.Drawing.Size(185, 22);
            this.cmnGridClearLogAll.Text = "Очистить протокол";
            this.cmnGridClearLogAll.Click += new System.EventHandler(this.cmnGridMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(182, 6);
            // 
            // cmnGridEdit
            // 
            this.cmnGridEdit.Name = "cmnGridEdit";
            this.cmnGridEdit.Size = new System.Drawing.Size(185, 22);
            this.cmnGridEdit.Text = "Редактировать";
            this.cmnGridEdit.Click += new System.EventHandler(this.cmnGridMenuItem_Click);
            // 
            // cmnGridDelete
            // 
            this.cmnGridDelete.Name = "cmnGridDelete";
            this.cmnGridDelete.Size = new System.Drawing.Size(185, 22);
            this.cmnGridDelete.Text = "Удалить";
            this.cmnGridDelete.Click += new System.EventHandler(this.cmnGridMenuItem_Click);
            // 
            // statMessages
            // 
            this.statMessages.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statMessages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statlblMessages});
            this.statMessages.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statMessages.Location = new System.Drawing.Point(0, 409);
            this.statMessages.Name = "statMessages";
            this.statMessages.Size = new System.Drawing.Size(632, 18);
            this.statMessages.TabIndex = 6;
            // 
            // statlblMessages
            // 
            this.statlblMessages.Name = "statlblMessages";
            this.statlblMessages.Size = new System.Drawing.Size(43, 13);
            this.statlblMessages.Text = "Готово";
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(59, 21);
            this.mnuHelp.Text = "&Помощь";
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(161, 22);
            this.mnuHelpAbout.Text = "&О программе...";
            this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 427);
            this.Controls.Add(this.statMessages);
            this.Controls.Add(this.grdMain);
            this.Controls.Add(this.mnuMain);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Задачи и настройки";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.cmnMain.ResumeLayout(false);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.cmnGrid.ResumeLayout(false);
            this.statMessages.ResumeLayout(false);
            this.statMessages.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon niMain;
        private System.Windows.Forms.ContextMenuStrip cmnMain;
        private System.Windows.Forms.ToolStripMenuItem cmnMainTimer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmnMainExit;
        private System.Windows.Forms.ToolStripMenuItem cmnMainNote;
        private System.Windows.Forms.ToolStripMenuItem cmnMainAllNotes;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuFileTimer;
        private System.Windows.Forms.ToolStripMenuItem mnuFileNote;
        private System.Windows.Forms.ToolStripMenuItem mnuFileAllNotes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuFileRestoreWindow;
        private System.Windows.Forms.ToolStripMenuItem mnuFileHide;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuEditAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuEditEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuEditFind;
        private System.Windows.Forms.ToolStripMenuItem mnuEditDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuFieldNameDSBL;
        private System.Windows.Forms.ToolStripMenuItem mnuFindUp;
        private System.Windows.Forms.ToolStripMenuItem mnuFindDown;
        private System.Windows.Forms.ToolStripTextBox mtxtFind;
        private System.Windows.Forms.ToolStripMenuItem mnuFindDSBL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuFileCopyConfig;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem cmnMainTasks;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.DataGridView grdMain;
        private System.Windows.Forms.ToolStripMenuItem mnuEditDouble;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mnuEditViewLog;
        private System.Windows.Forms.ToolStripMenuItem mnuEditClearLog;
        private System.Windows.Forms.ToolStripMenuItem mnuEditClearLogAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuEditActivate;
        private System.Windows.Forms.ContextMenuStrip cmnGrid;
        private System.Windows.Forms.ToolStripMenuItem cmnGridActivate;
        private System.Windows.Forms.ToolStripMenuItem cmnGridDouble;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem cmnGridClearLogAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem cmnGridDelete;
        private System.Windows.Forms.ToolStripMenuItem cmnGridEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuTasks;
        private System.Windows.Forms.ToolStripMenuItem mnuTasksStartAll;
        private System.Windows.Forms.ToolStripMenuItem mnuTasksStopAll;
        private System.Windows.Forms.ToolStripMenuItem mnuTasksRestart;
        private System.Windows.Forms.StatusStrip statMessages;
        private System.Windows.Forms.ToolStripStatusLabel statlblMessages;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
    }
}


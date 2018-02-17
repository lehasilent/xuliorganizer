using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Media;

namespace XuliOrganizzer
{
    public partial class frmMain : Form
    {
        frmTimer fTimer = null;
        frmNote fNote = null;

        DataRow[] FindRows = null;
        int CurFind = 0;
        bool FindMode = false;

        int rbcRow = 0;
        int rbcCol = 0;
        int rbcRowPre = 0;
        int rbcColPre = 0;
        Point ptMenu = new Point(0, 0);
        bool ExitFromMenu = false;

        cTaskWorker Worker = new cTaskWorker();
        
        ArrayList LockedRecIDs = new ArrayList();        
        public delegate void LockRecord(int recID);
        public event LockRecord OnLockRecord;
        public delegate void UnlockRecord(int recID);
        public event UnlockRecord OnUnlockRecord;

        Color OverdueColor = Color.Salmon;        
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void LockUnlock(bool Lck, int RecID)
        {
            if (Lck) //заблокировать запись
            {                
                LockedRecIDs.Add(RecID);
                if (OnLockRecord != null) OnLockRecord(RecID);
            }
            else
            {                
                LockedRecIDs.Remove(RecID);
                if (OnLockRecord != null) OnUnlockRecord(RecID);
            }
        }

        string klc(string InS)
        {
            string[] buf = InS.Split('/');

            for (int i = 0; i < buf.Length; i++)
            {
                if (buf[i].Length == 2)
                {
                    if (buf[i][0] == '0') buf[i] = Convert.ToString(buf[i][1]);
                }
            }
            return string.Join("/", buf);
        }

        void showworkererror(WorkerErrorLevel wol, string oktext)
        {
            switch (wol)
            {
                case WorkerErrorLevel.Error:
                    {
                        statlblMessages.ForeColor = Color.Red;
                        statlblMessages.Text = Worker.TaskErrMessage;
                        CommonFunctions.ErrMessage(Worker.TaskErrMessage);
                    }; break;
                case WorkerErrorLevel.Warning:
                    {
                        statlblMessages.ForeColor = Color.Crimson;
                        statlblMessages.Text = Worker.TaskErrMessage;
                    }; break;
                default:
                    {
                        statlblMessages.ForeColor = Color.Black;
                        statlblMessages.Text = oktext;
                    }; break;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {   
         
            niMain.Icon = XuliOrganizzer.Properties.Resources.Clock1;
            CommonFunctions.globalNI = niMain;

            if (File.Exists(cConfig.ConfigPath + cConfig.ConfigFileName))
            {
                if (!cConfig.LoadConfig())
                {
                    CommonFunctions.ErrMessage(cConfig.ConfigErrMessage);
                }
            }

            //загрузка данных
            grdMain.DataSource = cConfig.dsConfig.Tables["Tasks"].DefaultView;

            //поиск по умолчанию скрыт
            mnuFieldNameDSBL.Visible = false;
            mnuFindDown.Visible = false;
            mnuFindDSBL.Visible = false;
            mnuFindUp.Visible = false;
            mtxtFind.Visible = false;

            
            //загрузка и установка параметров окна
            bool Maximized = false;
            try
            {
                Maximized = Convert.ToBoolean(cConfig.GetParameter("Main.Maximized", "false"));
            }
            catch { Maximized = false; }

            if (Maximized) 
            { 
                this.WindowState = FormWindowState.Maximized; 
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                try
                {
                    this.Width = Convert.ToInt32(cConfig.GetParameter("Main.Width", "640"));
                    this.Height = Convert.ToInt32(cConfig.GetParameter("Main.Height", "453"));
                }
                catch
                {
                    this.Width = 640;
                    this.Height = 453;
                }
            }
            
            
            //запуск задач
            int wn = Convert.ToInt32(cConfig.GetParameter("Global.Notification", "0"));
            Worker.WorkerNotification = (NotificationType)wn;
            Worker.OnAutoRefreshError += new cTaskWorker.AutoRefreshError(Worker_OnAutoRefreshError);
            Worker.OnAutorefreshComplete += new cTaskWorker.AutoRefreshComplete(Worker_OnAutorefreshComplete);
            Worker.OnOverdueTaskDetected += new cTaskWorker.OverdueTaskDetected(Worker_OnOverdueTaskDetected);
            Worker.OnStartRunTask += new cTaskWorker.StartRunTask(Worker_OnStartRunTask);
            Worker.OnStopTask += new cTaskWorker.StopTask(Worker_OnStopTask);
            Worker.OnCompleteTask += new cTaskWorker.CompleteTask(Worker_OnCompleteTask);
            Worker.fMain = this;
            mnuTasksStartAll_Click(null, null);
        }

        void Worker_OnCompleteTask(cTask task)
        {
            LockUnlock(false, task.ID);
        }

        void Worker_OnStopTask(cTask task)
        {
            LockUnlock(false, task.ID);
        }

        void Worker_OnStartRunTask(cTask task)
        {
            LockUnlock(true, task.ID);
        }

        void Worker_OnOverdueTaskDetected(object sender)
        {            
            
            string correctMsg = "Для просроченных задач установлено новое время"+ 
                " выполнения. Однократно выполняемые задачи деактивированы";
            string runMsg="Выполнение просроченных задач завершено";

            if (Convert.ToBoolean(cConfig.GetParameter("Global.OverdueNotify","true")))
            {
                    niMain.ShowBalloonTip(5000, "Просроченные задания",
                        "Обнаружены просроченные задания", ToolTipIcon.Warning);
            }

            if (Convert.ToBoolean(cConfig.GetParameter("Global.OverdueRun", "false")))
            {
                WorkerErrorLevel wol = Worker.RunOverdueTasks();
                showworkererror(wol, runMsg);
            }

            if (Convert.ToBoolean(cConfig.GetParameter("Global.OverdueNewTime", "false")))
            {
                WorkerErrorLevel wol = Worker.CorrectOverdueTime(DateTime.Now);
                showworkererror(wol, correctMsg);
                
                if (wol == WorkerErrorLevel.OK)
                {
                    niMain.ShowBalloonTip(5000, "Просроченные задания",
                        correctMsg, ToolTipIcon.Info);
                }
            }

        }

        void Worker_OnAutorefreshComplete(object sender)
        {
            this.Invoke((MethodInvoker)delegate 
            {
                statlblMessages.ForeColor = Color.Black;
                statlblMessages.Text = "Автообновление задач завершено."+
                    "Задач "+Worker.LoadedTasksCount();
            });
        }

        void Worker_OnAutoRefreshError(object sender)
        {
            cTaskWorker w = (cTaskWorker)sender;
            CommonFunctions.ErrMessage(w.TaskErrMessage);
            WorkerErrorLevel wol=w.StopAutoRefresh();
            if (wol != WorkerErrorLevel.OK)
            {
                CommonFunctions.ErrMessage(w.TaskErrMessage);
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            this.Hide();            
            //настройка вида DataGridView
            for (int i = 0; i < grdMain.Columns.Count; i++)
            {
                grdMain.Columns[i].Visible = false;                
            }

            grdMain.Columns["Name"].Visible = true;
            grdMain.Columns["Name"].HeaderText = "Задача";
            grdMain.Columns["StartDateTime"].Visible = true;
            grdMain.Columns["StartDateTime"].HeaderText = "Дата";
            grdMain.Columns["NextDateTime"].Visible = true;
            grdMain.Columns["NextDateTime"].HeaderText = "Следующая дата";
            grdMain.Columns["TimeType"].Visible = true;
            grdMain.Columns["TimeType"].HeaderText = "Выполнение";
            grdMain.Columns["ActionType"].Visible = true;
            grdMain.Columns["ActionType"].HeaderText = "Действие";
            grdMain.Columns["ProgramPath"].Visible = true;
            grdMain.Columns["ProgramPath"].HeaderText = "Программа";
            grdMain.Columns["MessageText"].Visible = true;
            grdMain.Columns["MessageText"].HeaderText = "Сообщение";
            grdMain.Columns["LastRun"].Visible = true;
            grdMain.Columns["LastRun"].HeaderText = "Последнее выполнение";

            grdMain.CurrentCell = grdMain.FirstDisplayedCell;
            grdMain_SelectionChanged(null, null);
        }
        
        private void frmMain_Resize(object sender, EventArgs e)
        {
            grdMain.Height = this.Height - statMessages.Height;
        }        

        private void cmnMainTimer_Click(object sender, EventArgs e)
        {
            if (fTimer == null)
            {
                fTimer = new frmTimer();                
                fTimer.Show();
            }

            
            fTimer.TopMost = true;
            if (!fTimer.Visible) fTimer.Visible = true;

            if (!Convert.ToBoolean(cConfig.GetParameter("TopMost", "false")))
            {
                Thread.Sleep(250);
                fTimer.TopMost = false;
            }
        }

        private void cmnMainExit_Click(object sender, EventArgs e)
        {
            bool askexit = Convert.ToBoolean(cConfig.GetParameter("Global.AskExit","true"));
            if (askexit)
            {
                frmExit fExit = new frmExit();
                DialogResult Ask = fExit.ShowDialog();
                if (Ask == DialogResult.No) return;
            }
            ExitFromMenu = true;
            Application.Exit();
            //this.Close();            
        }

        private void cmnMainNote_Click(object sender, EventArgs e)
        {
            if (fNote == null)
            {
                fNote = new frmNote();
                fNote.Disposed += new EventHandler(fNote_Disposed);
            }

            fNote.Show();

            fNote.TopMost = true;
            if (!fNote.Visible) fNote.Visible = true;

            if (!Convert.ToBoolean(cConfig.GetParameter("Note.TopMost", "false")))
            {
                Thread.Sleep(250);
                fNote.TopMost = false;
            }
        }

        void fNote_Disposed(object sender, EventArgs e)
        {
            fNote = null;
        }

        private void cmnMainAllNotes_Click(object sender, EventArgs e)
        {
            frmAllNotes fAllNotes = new frmAllNotes();
            string  tTop = cConfig.GetParameter("AllNotes.Top", string.Empty);
            string  tLeft = cConfig.GetParameter("AllNotes.Left", string.Empty);
            if (tTop == string.Empty || tLeft == string.Empty)
            {
                fAllNotes.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                fAllNotes.StartPosition = FormStartPosition.Manual;
            }
            fAllNotes.Show();
        }

        private void cmnMainTasks_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ExitFromMenu) //пользователь закрыл форму крестиком, а не вышел из меню
            {
                if (Convert.ToBoolean(cConfig.GetParameter("Global.AskMainBehavior", "true")))
                {
                    //спросить о поведении формы
                    frmMainBeh fMainBeh = new frmMainBeh();
                    DialogResult Ask = fMainBeh.ShowDialog();
                    if (Ask == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                
                //проверить что делать
                FormBehavior MainBehavior = (FormBehavior)Convert.ToInt32(
                    cConfig.GetParameter("Global.MainBehavior", "0"));

                if (MainBehavior == FormBehavior.Hide) //скрыть форму
                {
                    this.Hide();
                    e.Cancel = true;
                }
            }
            
            bool Maximized = false;
            //если форма минимизирована перед закрытием
            //не сохранять параметры окна
            if (this.WindowState == FormWindowState.Minimized) return;
            
            if (this.WindowState == FormWindowState.Maximized) Maximized = true;

            cConfig.SetParameter("Main.Maximized", Maximized.ToString());            
            cConfig.SetParameter("Main.Width", this.Width.ToString());
            cConfig.SetParameter("Main.Height", this.Height.ToString());
            
            //закрытие не отменено - останавливаем задачи
            if (!e.Cancel)
            {
                WorkerErrorLevel wol = Worker.StopAutoRefresh();                
                if (wol != WorkerErrorLevel.OK)
                {
                    CommonFunctions.ErrMessage(Worker.TaskErrMessage);
                }
                //LockedRecIDs.Clear();
                //LockedRecIDs = null;
            }

            if (!cConfig.SaveConfig())
            {
                CommonFunctions.ErrMessage(cConfig.ConfigErrMessage);
            }
        }

        private void mnuFileRestoreWindow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Width = 640;
            this.Height = 453;
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
                (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
            
            cConfig.SetParameter("Main.Maximized", false.ToString());
            cConfig.SetParameter("Main.Width", this.Width.ToString());
            cConfig.SetParameter("Main.Height", this.Height.ToString());
            cConfig.SaveConfig();
        }

        private void mnuFileTimer_Click(object sender, EventArgs e)
        {
            this.Hide();
            cmnMainTimer_Click(null, null);
        }

        private void mnuFileNote_Click(object sender, EventArgs e)
        {
            this.Hide();
            cmnMainNote_Click(null, null);
        }

        private void mnuFileAllNotes_Click(object sender, EventArgs e)
        {
            this.Hide();
            cmnMainAllNotes_Click(null, null);
        }

        private void mnuFileOptions_Click(object sender, EventArgs e)
        {
            frmOptions fOptions = new frmOptions();
            fOptions.ShowDialog();

            if (fOptions.bSuccess)
            {
                if (fOptions.NotificationChanged)
                {
                    WorkerErrorLevel wol = Worker.StopAutoRefresh();
                    showworkererror(wol, "Задачи остановлены");
                    mnuTasksStartAll.Enabled = true;
                    mnuTasksStopAll.Enabled = false;
                    mnuTasksRestart.Enabled = false;
                    if (!Worker.TasksLoaded()) mnuTasksStartAll_Click(null, null);
                }
                cConfig.SaveConfig();
            }
        }

        private void mnuFileCopyConfig_Click(object sender, EventArgs e)
        {
            dlgSave.FileName = "";
            DialogResult Ans = dlgSave.ShowDialog();
            if (Ans == DialogResult.Cancel) return;

            if (!cConfig.SaveConfig())
            {
                CommonFunctions.ErrMessage(cConfig.ConfigErrMessage);
                return;
            }

            try
            {
                File.Copy(cConfig.ConfigPath + cConfig.ConfigFileName,
                    dlgSave.FileName);
            }
            catch (Exception ex)
            {
                CommonFunctions.ErrMessage(ex.Message);
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            cmnMainExit_Click(null, null);
        }

        private void mnuEditAdd_Click(object sender, EventArgs e)
        {
            //показали форму для добавления
            frmAddTask fAddTask = new frmAddTask();
            fAddTask.ShowDialog();

            if (fAddTask.bSuccess) //добавление удачно
            {
                FindRows = null; //обнуляем поиск

                //попытка запуска новой задачи                
                
                //вытаскиваем ID последней записи
                int RecID = (int)cConfig.dsConfig.Tables["Tasks"].
                    Rows[cConfig.dsConfig.Tables["Tasks"].Rows.Count - 1]["ID"];

                //Пробуем загрузить
                WorkerErrorLevel wol = Worker.AddTask(RecID);

                showworkererror(wol,"Задача сохранена и запущена на выполнение.");
                
            }
        }

        private void mnuEditEdit_Click(object sender, EventArgs e)
        {
            if (grdMain.CurrentRow == null) return;
            
            //Подготовка данных для редактирования
            int RecID = (int)grdMain.CurrentRow.Cells["ID"].Value;
            cTask Task = null;

            //проверка, не заблокирована ли запись
            if (LockedRecIDs.Contains(RecID))
            {
                CommonFunctions.InfoMessage("Запись заблокирована, так как данное задание выполняется",
                    "Запись заблокирована");
                return;
            }

            try
            {
                Task = new cTask(cConfig.dsConfig, "Tasks", RecID);
            }
            catch (Exception ex)
            {
                CommonFunctions.ErrMessage(ex.Message);
                statlblMessages.ForeColor = Color.Red;
                statlblMessages.Text = "ОШИБКА: " + ex.Message;
                return;
            }

            //форма редактирования
            frmAddTask fAddTask = new frmAddTask();
            fAddTask.fMain = this;
            fAddTask.Task = Task;
            fAddTask.bEdit = true;
            fAddTask.ShowDialog();
            OnLockRecord = null;
            OnUnlockRecord = null;

            if (fAddTask.bSuccess)
            {
                FindRows = null; //обнуление поиска
                
                //отредактированное задание должно быть в очереди на выполнение
                if (Worker.RunningInCurrentPeriod(RecID))
                {
                    Worker.RemoveTask(RecID,false); //удаляем                        
                    WorkerErrorLevel wol = Worker.AddTask(RecID); //перезапускаем
                    showworkererror(wol,"Задача сохранена и запущена на выполнение.");
                }
                
            }
        }

        private void grdMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mnuEditEdit_Click(null, null);
        }

        private void mnuEditDelete_Click(object sender, EventArgs e)
        {
            if (grdMain.CurrentRow == null) return;
            int RecID = (int)grdMain.CurrentRow.Cells["ID"].Value;

            //проверка, не заблокирована ли запись
            if (LockedRecIDs.Contains(RecID))
            {
                CommonFunctions.InfoMessage("Запись заблокирована, так как данное задание выполняется",
                    "Запись заблокирована");
                return;
            }

            DataRow dr = cConfig.dsConfig.Tables["Tasks"].Rows.Find(RecID);

            DialogResult Ans = MessageBox.Show("Окончательно удалить задачу " +
                dr["Name"].ToString() + "?\r\nОтменить будет невозможно!",
                "Удаление задачи", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (Ans == DialogResult.No) return;            
            
            //удаление задачи
            cConfig.dsConfig.Tables["Tasks"].Rows.Remove(dr);
            //выгружаем из списка запущенных, если есть
            WorkerErrorLevel wol = Worker.RemoveTask(RecID, false);
            showworkererror(wol, "Задача удалена");
            if (!cConfig.SaveConfig())
            {
                CommonFunctions.ErrMessage(cConfig.ConfigErrMessage);
            }
            FindRows = null;

        }

        private void grdMain_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (grdMain.Rows.Count < 1) return;
            //if (grdMain.Rows[e.RowIndex].DefaultCellStyle.BackColor == OverdueColor) return;

            bool overdue = (bool)grdMain.Rows[e.RowIndex].Cells["Overdue"].Value;
            bool active = (bool)grdMain.Rows[e.RowIndex].Cells["Active"].Value;

            if (!active)
            {
                grdMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
                return;
            }

            if (overdue)
            {
                grdMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = OverdueColor;
                return;
            }            
            
            if ((!overdue)&&(active))
            {
                grdMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            

        }

        private void grdMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grdMain.Columns[e.ColumnIndex].Name == "TimeType")
            {
                switch ((TimeType)grdMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    case TimeType.One: e.Value = "Единоразово"; break;
                    case TimeType.EveryDay: e.Value = "Ежедневно"; break;
                    case TimeType.EveryWeek: e.Value = "Еженедельно"; break;
                    case TimeType.EveryMonth: e.Value = "Ежемесячно"; break;
                    case TimeType.EveryYear: e.Value = "Ежегодно"; break;
                    case TimeType.EveryNDays: e.Value = "Каждые "+
                        cConfig.dsConfig.Tables["Tasks"].Rows[e.RowIndex]["N"].ToString()+
                        " дней"; break;
                }
                
                return;
            }

            if (grdMain.Columns[e.ColumnIndex].Name == "StartDateTime"||
                grdMain.Columns[e.ColumnIndex].Name == "NextDateTime"||
                grdMain.Columns[e.ColumnIndex].Name == "LastRun")
            {
                string tmp = (string)grdMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                e.Value = cTask.FormatDateString(tmp, "YYYY.MM.DD HH:mm");

                return;
            }

            if (grdMain.Columns[e.ColumnIndex].Name == "ActionType")
            {
                switch ((ActionType)grdMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    case ActionType.Message: e.Value = "Сообщение"; break;
                    case ActionType.Run: e.Value = "Выполнить программу"; break;
                    case ActionType.Both: e.Value = "Программа и сообщение"; break;
                }

                return;
            }

        }

        private void grdMain_SelectionChanged(object sender, EventArgs e)
        {
            int maxlen = 15;
            if (grdMain.CurrentCell == null) return;

            if ((grdMain.Columns[grdMain.CurrentCell.ColumnIndex].Name == "Name") ||
                (grdMain.Columns[grdMain.CurrentCell.ColumnIndex].Name == "ProgramPath") ||
                (grdMain.Columns[grdMain.CurrentCell.ColumnIndex].Name == "MessageText") ||
                (grdMain.Columns[grdMain.CurrentCell.ColumnIndex].Name == "StartDateTime")||
                (grdMain.Columns[grdMain.CurrentCell.ColumnIndex].Name == "NextDateTime")||
                (grdMain.Columns[grdMain.CurrentCell.ColumnIndex].Name == "LastRun"))
            {
                mnuFindDown.Enabled = true;
                mnuFindUp.Enabled = true;
                mtxtFind.Enabled = true;                

                mnuFieldNameDSBL.Text =
                CommonFunctions.AddToSize(
                    "[" + cConfig.dsConfig.Tables["Tasks"].
                    Columns[grdMain.CurrentCell.ColumnIndex].ColumnName + "]",
                    ' ', maxlen, true);
            }
            else
            {
                mnuFindDown.Enabled = false;
                mnuFindUp.Enabled = false;
                mtxtFind.Enabled = false;
                mnuFieldNameDSBL.Text =
                CommonFunctions.AddToSize(
                    "[" + "---" + "]",
                    ' ', maxlen, true);
            }

            //изменение меню в зависимости от того, активирована задача, или нет.
            bool actval = (bool)grdMain.Rows[grdMain.CurrentCellAddress.Y].
                Cells["Active"].Value;

            if (actval)
            {
                mnuEditActivate.Text = "Деактивировать";
                cmnGridActivate.Text = "Деактивировать";
            }
            else
            {
                mnuEditActivate.Text = "Активировать";
                cmnGridActivate.Text = "Активировать";
            }
        }

        private void mtxtFind_TextChanged(object sender, EventArgs e)
        {
            if (grdMain.Rows.Count < 1) return;

            int curcell = grdMain.CurrentCell.OwningColumn.Index;

            if (mtxtFind.TextBox.Text == "")
            {
                grdMain.CurrentCell = grdMain.Rows[0].Cells[curcell];
                return;
            }

            string fnd = mtxtFind.TextBox.Text;
            if ((grdMain.Columns[grdMain.CurrentCell.ColumnIndex].Name == "StartDateTime") ||
                (grdMain.Columns[grdMain.CurrentCell.ColumnIndex].Name == "NextDateTime"))
            {
                fnd = fnd.Replace(' ', '/').Replace('.', '/').Replace(':', '/');
                fnd = klc(fnd);
            }
            fnd = CommonFunctions.EscapeLikeValue(fnd);

            string col = cConfig.dsConfig.Tables["Tasks"].
                Columns[grdMain.CurrentCell.ColumnIndex].ColumnName;
            string sort = cConfig.dsConfig.Tables["Tasks"].DefaultView.Sort;
            if (sort == "") sort = "ID DESC";

            FindRows = cConfig.dsConfig.Tables["Tasks"].Select("["+col+"]" + " LIKE '%" + fnd + "%'", sort);

            if (FindRows.Length == 0) return; //nothing found

            CurFind = 0;
            int currow = -1;
            foreach (DataGridViewRow dgvr in grdMain.Rows)
            {
                currow++;
                if (dgvr.Cells[0].Value.ToString() == FindRows[CurFind]["ID"].ToString())
                {
                    grdMain.CurrentCell = grdMain.Rows[currow].Cells[curcell];
                }
            }

        }

        private void mnuFindDown_Click(object sender, EventArgs e)
        {
            if (FindRows == null) return;
            if (FindRows.Length == 0) return;
            int curcell = grdMain.CurrentCell.OwningColumn.Index;
            int currow = -1;
            CurFind++;
            if (CurFind >= FindRows.Length) CurFind = 0;

            foreach (DataGridViewRow dgvr in grdMain.Rows)
            {
                currow++;
                if (dgvr.Cells[0].Value.ToString() == FindRows[CurFind]["ID"].ToString())
                {
                    grdMain.CurrentCell = grdMain.Rows[currow].Cells[curcell];
                }
            }
        }

        private void mnuFindUp_Click(object sender, EventArgs e)
        {
            if (FindRows == null) return;
            if (FindRows.Length == 0) return;
            int curcell = grdMain.CurrentCell.OwningColumn.Index;
            int currow = -1;
            CurFind--;
            if (CurFind < 0) CurFind = FindRows.Length - 1;

            foreach (DataGridViewRow dgvr in grdMain.Rows)
            {
                currow++;
                if (dgvr.Cells[0].Value.ToString() == FindRows[CurFind]["ID"].ToString())
                {
                    grdMain.CurrentCell = grdMain.Rows[currow].Cells[curcell];
                }
            }

        }

        private void mnuEditFind_Click(object sender, EventArgs e)
        {
            FindMode = !FindMode;

            if (FindMode)
            {
                mnuFieldNameDSBL.Visible = true;
                mnuFindDown.Visible = true;
                mnuFindDSBL.Visible = true;
                mnuFindUp.Visible = true;
                mtxtFind.Visible = true;
                mnuEditFind.Text = "Скр&ыть поиск";
            }
            else
            {
                mnuFieldNameDSBL.Visible = false;
                mnuFindDown.Visible = false;
                mnuFindDSBL.Visible = false;
                mnuFindUp.Visible = false;
                mtxtFind.Visible = false;
                mnuEditFind.Text = "&Найти...";
            }
        }
        
        private void mnuEditDouble_Click(object sender, EventArgs e)
        {
            if (grdMain.CurrentRow == null) return;
            int RecID = (int)grdMain.CurrentRow.Cells["ID"].Value;
            DataRow dr = cConfig.dsConfig.Tables["Tasks"].Rows.Find(RecID);
            DataRow newRow = cConfig.dsConfig.Tables["Tasks"].NewRow();

            for (int i = 1; i < dr.ItemArray.Length; i++)
            {
                newRow[i] = dr[i];
            }
            
            cConfig.dsConfig.Tables["Tasks"].Rows.Add(newRow);
            grdMain.CurrentCell = 
                grdMain.Rows[grdMain.Rows.Count - 1].Cells[grdMain.CurrentCellAddress.X];

            mnuEditEdit_Click(null, null);
            cConfig.SaveConfig();
            
        }

        private void mnuEditViewLog_Click(object sender, EventArgs e)
        {
            if (grdMain.CurrentRow == null) return;
            int RecID = (int)grdMain.CurrentRow.Cells["ID"].Value;

            cTask tmptsk = new cTask(cConfig.dsConfig, "Tasks", RecID);
            frmLogView fLogView = new frmLogView();

            fLogView.NoClear = LockedRecIDs.Contains(RecID);
            fLogView.log = tmptsk.Log;
            fLogView.ShowDialog();
            if (fLogView.bClear)
            {
                tmptsk.ClearLog();
                tmptsk.ToDataSet(cConfig.dsConfig, "Tasks");
                cConfig.SaveConfig();
            }
        }

        private void mnuEditClearLog_Click(object sender, EventArgs e)
        {            
            if (grdMain.CurrentRow == null) return;
            int RecID = (int)grdMain.CurrentRow.Cells["ID"].Value;
            //проверка, не заблокирована ли запись
            if (LockedRecIDs.Contains(RecID))
            {
                CommonFunctions.InfoMessage("Запись заблокирована, так как данное задание выполняется",
                    "Запись заблокирована");
                return;
            }
            DialogResult Ask = MessageBox.Show("Очистить протокол?", "Очистка протокола",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Ask == DialogResult.No) return;

            
            cTask tmptsk = new cTask(cConfig.dsConfig, "Tasks", RecID);
            tmptsk.ClearLog();
            tmptsk.ToDataSet(cConfig.dsConfig, "Tasks");
            cConfig.SaveConfig();
            Worker.ClearTaskLog(RecID);
        }

        private void mnuEditClearLogAll_Click(object sender, EventArgs e)
        {
            //проверка, не заблокировано ли что-нибудь
            if (LockedRecIDs.Count >0)
            {
                CommonFunctions.InfoMessage("Невозможно очистить протоколы.",
                    "Выполняется задание");
                return;
            }


            DialogResult Ask = MessageBox.Show("Очистить все протоколы?", "Очистка протоколов",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Ask == DialogResult.No) return;

            if (cConfig.dsConfig.Tables["Tasks"].Rows.Count == 0) return;

            for (int i = 0; i < cConfig.dsConfig.Tables["Tasks"].Rows.Count; i++)
            {
                cConfig.dsConfig.Tables["Tasks"].Rows[i]["Log"] = string.Empty;
                int RecID = (int)cConfig.dsConfig.Tables["Tasks"].Rows[i]["ID"];
                Worker.ClearTaskLog(RecID);
            }

            cConfig.SaveConfig();
        }

        private void mnuEditActivate_Click(object sender, EventArgs e)
        {
            if (grdMain.CurrentRow == null) return;
            int RecID = (int)grdMain.CurrentRow.Cells["ID"].Value;
            //проверка, не заблокирована ли запись
            if (LockedRecIDs.Contains(RecID))
            {
                CommonFunctions.InfoMessage("Запись заблокирована, так как данное задание выполняется",
                    "Запись заблокирована");
                return;
            }
            

            DataRow dr = cConfig.dsConfig.Tables["Tasks"].Rows.Find(RecID);
            bool Active = (bool)dr["Active"];
            bool stopped = false;
            
            grdMain_SelectionChanged(null, null);

            //есть  ли задача в списке на выполнение
            if (Worker.IsTaskExist(RecID))
            {
                //есть, значит активна, надо остановить и удалить из списка
                WorkerErrorLevel wol = Worker.RemoveTask(RecID, false);
                showworkererror(wol, "Задача остановлена");
                if (wol != WorkerErrorLevel.OK) return;
                Active = false;
                stopped = true;
            }
            else //в списке нет
            {
                //меняем активность на противоположную
                Active = !Active;
            }
            
            //сохранение в БД
            dr["Active"] = Active;
            bool scfg = cConfig.SaveConfig();
            if (!scfg)
            {
                CommonFunctions.ErrMessage(cConfig.ConfigErrMessage);
                return;
            }

            if (Active) //если была активирована
            {
                if (Worker.RunningInCurrentPeriod(RecID)) //должна ли выполняться
                {
                    //надо добавить в список и запустить
                    WorkerErrorLevel wol = Worker.AddTask(RecID);
                    showworkererror(wol, "Задача активирована и запущена");
                }
                else
                {
                    statlblMessages.ForeColor = Color.Black;
                    statlblMessages.Text = "Задача активирована.";
                }
            }
            else
            {
                if (stopped)
                {
                    statlblMessages.ForeColor = Color.Black;
                    statlblMessages.Text = "Задача остановлена и деактивирована.";
                }
                else
                {
                    statlblMessages.ForeColor = Color.Black;
                    statlblMessages.Text = "Задача деактивирована.";
                }
            }
        }
        
        private void grdMain_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rbcColPre = grdMain.CurrentCellAddress.X;
                rbcRowPre = grdMain.CurrentCellAddress.Y;

                rbcRow = e.RowIndex;
                rbcCol = e.ColumnIndex;

                //изменение меню в зависимости от того, активирована задача, или нет.
                bool actval = (bool)grdMain.Rows[rbcRow].
                    Cells["Active"].Value;

                if (actval)
                {                    
                    cmnGridActivate.Text = "Деактивировать";
                }
                else
                {                    
                    cmnGridActivate.Text = "Активировать";
                }

                cmnGrid.Show(ptMenu);
            }
        }
        
        private void grdMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ptMenu = grdMain.PointToScreen(e.Location);
            }
        }

        private void cmnGridMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;

            grdMain.CurrentCell = grdMain.Rows[rbcRow].Cells[rbcCol];
            switch (mnu.Name)
            {
                case "cmnGridActivate": { mnuEditActivate_Click(null, null); }; break;
                case "cmnGridDouble": { mnuEditDouble_Click(null, null); }; break;
                case "cmnGridClearLogAll": { mnuEditClearLogAll_Click(null, null); }; break;
                case "cmnGridEdit": { mnuEditEdit_Click(null, null); }; break;
                case "cmnGridDelete": { mnuEditDelete_Click(null, null); }; break;
            }
            grdMain.CurrentCell = grdMain.Rows[rbcRowPre].Cells[rbcColPre];
        }

        private void mnuTasksStartAll_Click(object sender, EventArgs e)
        {
            WorkerErrorLevel wol = Worker.StartAutoRefresh();
            if (wol != WorkerErrorLevel.OK)
            {
                CommonFunctions.ErrMessage(Worker.TaskErrMessage);
                statlblMessages.ForeColor = Color.Red;
                statlblMessages.Text = Worker.TaskErrMessage;
            }
            else
            {
                if (Worker.TaskErrMessage == string.Empty)
                {
                    statlblMessages.ForeColor = Color.Black;
                    statlblMessages.Text = "Задачи запущены. " +
                        "Задач " + Worker.LoadedTasksCount();
                }
                else
                {
                    statlblMessages.ForeColor = Color.Crimson;
                    statlblMessages.Text = Worker.TaskErrMessage;                    
                }

                mnuTasksStartAll.Enabled = false;
                mnuTasksStopAll.Enabled = true;
                mnuTasksRestart.Enabled = true;
            }
        }

        private void mnuTasksStopAll_Click(object sender, EventArgs e)
        {
            if (Worker.TasksLoaded())
            {
                DialogResult Ask = MessageBox.Show("Имеются загруженные задачи. Остановить все?",
                    "Остановка задач", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Ask == DialogResult.No) return;
            }
            
            WorkerErrorLevel wol = Worker.StopAutoRefresh();
            showworkererror(wol, "Задачи остановлены");
            mnuTasksStartAll.Enabled = true;
            mnuTasksStopAll.Enabled = false;
            mnuTasksRestart.Enabled = false;
        }

        private void mnuTasksRestart_Click(object sender, EventArgs e)
        {
            mnuTasksStopAll_Click(null, null);
            if (!Worker.TasksLoaded()) mnuTasksStartAll_Click(null, null);
        }
        

        private void niMain_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            frmAbout fAbout = new frmAbout();
            fAbout.ShowDialog();
        }

        
        

        
        
    }
}

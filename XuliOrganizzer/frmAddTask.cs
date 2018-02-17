using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace XuliOrganizzer
{
    public partial class frmAddTask : Form
    {
        public frmAddTask()
        {
            InitializeComponent();
        }

        public bool bSuccess = false;
        public bool bEdit = false;
        public cTask Task = null;
        public frmMain fMain = null;

        private RemindType TaskRemindType = RemindType.Minuts;
        private ActionType TaskActionType = ActionType.Message;
        private SoundType TaskSoundType = SoundType.Internal;
        private TimeType TaskTimeType = TimeType.One;
        private string SoundFile = "";        
        private Dictionary<string,bool> ControlState = new Dictionary<string,bool>();

        private void FillMounthCmb(int Mounth,int Year, ComboBox cmb)
        {
            int N = DateTime.DaysInMonth(Year, Mounth);
            cmb.Items.Clear();
            for (int i = 1; i <= N; i++)
            {
                cmb.Items.Add(i.ToString());
            }
        }

        private void CheckRadioButton(string rbName, GroupBox grb)
        {
            foreach (Control ctrl in grb.Controls)
            {
                if (ctrl.Name == rbName)
                {
                    RadioButton rb = (RadioButton)ctrl;
                    rb.Checked = true;
                    break;
                }
            }
        }

        private void frmAddTask_Load(object sender, EventArgs e)
        {            
            //общая настройка контролов при загрузке формы
            dtStartDateTime.Value = DateTime.Now;
            dtNextDateTime.Value = dtNextDateTime.MinDate;
            dtNextDateTime.Enabled = false;
            
            //Установка дня недели в текущий в Еженедельно
            cmbWeekDay.Text = CommonFunctions.GetDayName(DateTime.Now.DayOfWeek);
            //установка месяца в Ежегодно 
            cmbMonth.Text = CommonFunctions.GetMonthName(DateTime.Now.Month);
            //добавление дней в месячные ComboBox            
            FillMounthCmb(DateTime.Now.Month, DateTime.Now.Year,cmbMonthDay);
            cmbMonthDay.Text = DateTime.Now.Day.ToString();
            FillMounthCmb(CommonFunctions.GetMonthNumber(cmbMonth.Text), 
                DateTime.Now.Year,cmbYearDay);
            cmbYearDay.Text = DateTime.Now.Day.ToString();

            //отключение контролов
            cmbMonthDay.Enabled = false;
            cmbYearDay.Enabled = false;
            txtN.Enabled = false;
            cmbMonth.Enabled = false;
            cmbWeekDay.Enabled = false;
            btnOpenSoundFile.Enabled = false;
            btnSelect.Enabled = false;
            txtProgramPath.Enabled = false;
            txtProgramParams.Enabled = false;
            chkProgramHide.Enabled = false;
            btnLog.Visible = false;
            btnClearLog.Visible = false;

            if (bEdit) //редактирование
            {

                this.Text = "Изменение задачи";
                btnLog.Visible = true;
                btnClearLog.Visible = true;

                //установка значений контролов
                chkActive.Checked = Task.Active;
                txtMessage.Text = Task.MessageText;
                txtN.Text = Task.N.ToString();
                txtProgramParams.Text =  Task.ProgramParameters; 
                txtProgramPath.Text = Task.ProgramPath;
                txtRemind.Text = Task.Remind.ToString();
                SoundFile = Task.SoundPath;
                dtStartDateTime.Value  =  Task.GetStartDateTime();
                dtNextDateTime.Value  =  Task.GetNextDateTime();
                TaskActionType = Task.TaskActionType;
                txtName.Text = Task.TaskName;
                TaskRemindType = Task.TaskRemindType;
                TaskSoundType = Task.TaskSoundType;
                TaskTimeType = Task.TaskTimeType;

                //установка radiobutton'ов

                int tmp = (int)TaskActionType;
                string tmpname = "rbActionType" + tmp.ToString();
                CheckRadioButton(tmpname,groupActionType);

                tmp = (int)TaskRemindType;
                tmpname = "rbRemindType" + tmp.ToString();
                CheckRadioButton(tmpname,groupRemindType);

                tmp = (int)TaskSoundType;
                tmpname = "rbSoundType" + tmp.ToString();
                CheckRadioButton(tmpname,groupSoundType);

                tmp = (int)TaskTimeType;
                tmpname = "rbTimeType" + tmp.ToString();
                CheckRadioButton(tmpname,groupTimeType);                
                
                //подключение событий для контроля за состоянием задания
                fMain.OnLockRecord += new frmMain.LockRecord(fMain_OnLockRecord);
                fMain.OnUnlockRecord += new frmMain.UnlockRecord(fMain_OnUnlockRecord);                
            }
            else //новая задача
            {
                this.Text = "Добавить задачу";                
            }
        }

        void fMain_OnUnlockRecord(int recID)
        {
            if (recID == Task.ID)
            {
                //После выполнения могут обновиться
                //только дата следующего выполнения 
                //и фактическая дата выполнения
                //надо обновить в объекте, чтоб не потерялись 
                //при сохранении
                Task.FromDataSet(cConfig.dsConfig, "Tasks", Task.ID);
                fMain.Invoke((MethodInvoker)delegate
                {                    
                    this.Text = "Изменение задачи";
                    foreach (Control c in this.Controls)
                    {
                       c.Enabled = ControlState[c.Name];
                    }                    
                });
            }
        }

        void fMain_OnLockRecord(int recID)
        {
            //задача сработала во время редактирования
            if (recID == Task.ID)
            {                                
                fMain.Invoke((MethodInvoker)delegate
                {
                    //CommonFunctions.InfoMessage("Редактирование заблокировано, поскольку задача "
                    //+ "выполняется в данный момент", "Редактирование заблокировано");

                    ControlState.Clear();
                    this.Text="Изменение задачи [ЗАБЛОКИРОВАНО]";
                    foreach (Control c in this.Controls)
                    {
                        ControlState.Add(c.Name,c.Enabled);
                        c.Enabled = false;
                    }
                    btnCancel.Enabled=true;
                });
            }
        }

        private void TimeType_Changed(object sender, EventArgs e)
        {
            RadioButton chk = (RadioButton)sender;
            int v = Convert.ToInt32(chk.Name.Substring(chk.Name.Length - 1));
            TaskTimeType = (TimeType)v;

            switch (TaskTimeType)
            {
                case TimeType.One:
                    {
                        cmbMonthDay.Enabled = false;
                        cmbYearDay.Enabled = false;
                        txtN.Enabled = false;
                        cmbMonth.Enabled = false;
                        cmbWeekDay.Enabled = false;

                    }; break;
                case TimeType.EveryDay:
                    {
                        cmbMonthDay.Enabled = false;
                        cmbYearDay.Enabled = false;
                        txtN.Enabled = false;
                        cmbMonth.Enabled = false;
                        cmbWeekDay.Enabled = false;

                    }; break;
                case TimeType.EveryWeek:
                    {
                        cmbMonthDay.Enabled = false;
                        cmbYearDay.Enabled = false;
                        txtN.Enabled = false;
                        cmbMonth.Enabled = false;
                        cmbWeekDay.Enabled = true;

                    }; break;
                case TimeType.EveryMonth:
                    {
                        cmbMonthDay.Enabled = true;
                        cmbYearDay.Enabled = false;
                        txtN.Enabled = false;
                        cmbMonth.Enabled = false;
                        cmbWeekDay.Enabled = false;

                    }; break;
                case TimeType.EveryYear:
                    {
                        cmbMonthDay.Enabled = false;
                        cmbYearDay.Enabled = true;
                        txtN.Enabled = false;
                        cmbMonth.Enabled = true;
                        cmbWeekDay.Enabled = false;

                    }; break;
                case TimeType.EveryNDays:
                    {
                        cmbMonthDay.Enabled = false;
                        cmbYearDay.Enabled = false;
                        txtN.Enabled = true;
                        cmbMonth.Enabled = false;
                        cmbWeekDay.Enabled = false;

                    }; break;                
            }
        }

        private void ActionType_Changed(object sender, EventArgs e)
        {
            RadioButton chk = (RadioButton)sender;
            int v = Convert.ToInt32(chk.Name.Substring(chk.Name.Length - 1));
            TaskActionType = (ActionType)v;

            switch (TaskActionType)
            {
                case ActionType.Message:
                    {
                        groupRemindType.Enabled = true;
                        txtMessage.Enabled = true;
                        txtProgramPath.Enabled = false;
                        txtProgramParams.Enabled = false;
                        chkProgramHide.Enabled = false;
                        btnSelect.Enabled = false;
                    }; break;
                case ActionType.Run:
                    {
                        txtMessage.Enabled = false;
                        txtProgramPath.Enabled = true;
                        txtProgramParams.Enabled = true;
                        chkProgramHide.Enabled = true;
                        btnSelect.Enabled = true;
                        groupRemindType.Enabled = false;
                    }; break;
                case ActionType.Both:
                    {
                        txtMessage.Enabled = true;
                        txtProgramPath.Enabled = true;
                        txtProgramParams.Enabled = true;
                        chkProgramHide.Enabled = true;
                        btnSelect.Enabled = true;
                        groupRemindType.Enabled = false;
                    }; break;
            }
        }

        private void SoundType_Changed(object sender, EventArgs e)
        {
            RadioButton chk = (RadioButton)sender;
            int v = Convert.ToInt32(chk.Name.Substring(chk.Name.Length - 1));
            TaskSoundType = (SoundType)v;

            switch (TaskSoundType)
            {
                case SoundType.NoSound:
                    {
                        btnOpenSoundFile.Enabled = false;
                        btnPlaySound.Enabled = false;

                    }; break;
                
                case SoundType.Internal:
                    {
                        btnOpenSoundFile.Enabled = false;
                        btnPlaySound.Enabled = true;

                    }; break;
                
                case SoundType.User:
                    {
                        btnOpenSoundFile.Enabled = true;
                        btnPlaySound.Enabled = true;

                    }; break;
            }

            if (TaskSoundType == SoundType.User)
            {
                btnOpenSoundFile.Enabled = true;
                btnPlaySound.Enabled = true;
            }
            else
            {
                
            }
        }

        private void RemindType_Changed(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int v = Convert.ToInt32(rb.Name.Substring(rb.Name.Length - 1));
            TaskRemindType = (RemindType)v;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bSuccess = false;
            this.Close();
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //заполнение дня в соответствии с месяцем
            int mth = CommonFunctions.GetMonthNumber(cmbMonth.Text);
            int yr = dtStartDateTime.Value.Year;
            FillMounthCmb(mth,yr,cmbYearDay);

            int dm = DateTime.DaysInMonth(yr, mth);

            int curday = 1;
            try //ошибка бывает при первом заполнении формы
            {
                curday = Convert.ToInt32(cmbYearDay.Text);
            }
            catch
            {
                curday = 1;
            }

            if (dm < curday) cmbYearDay.Text = dm.ToString();
            if (curday < 1) cmbYearDay.Text = "1";

            //смена основной даты при изменении Combobox
            dtStartDateTime.Value = new DateTime(dtStartDateTime.Value.Year,
                CommonFunctions.GetMonthNumber(cmbMonth.Text), dtStartDateTime.Value.Day,
                dtStartDateTime.Value.Hour, dtStartDateTime.Value.Minute,
                dtStartDateTime.Value.Second);
        }        

        private void txtOnlyDigits(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void cmbMonthDay_Leave(object sender, EventArgs e)
        {
            //проверка, не ввел ли пользователь 32 число :)

            int mth = dtStartDateTime.Value.Month;
            int yr = dtStartDateTime.Value.Year;
            int dm = DateTime.DaysInMonth(yr, mth);
            int curday = Convert.ToInt32(cmbMonthDay.Text);
            int cdm = -1;
            if (curday > dm) { cdm = curday; curday = dm; }
            if (curday < 1) { cdm = curday; curday = 1; }

            cmbMonthDay.Text = curday.ToString();
            if (cdm > -1)
            {
                lblFormMsg.Text = cdm.ToString() + " нет в этом месяце. Присвоено "+cmbMonthDay.Text;
                lblFormMsg.ForeColor = Color.Red;
            }
        }
        
        private void cmbYearDay_Leave(object sender, EventArgs e)
        {
            int mth = CommonFunctions.GetMonthNumber(cmbMonth.Text);
            int yr = dtStartDateTime.Value.Year;
            int dm = DateTime.DaysInMonth(yr, mth);
            int curday = Convert.ToInt32(cmbYearDay.Text);
            int cdm = -1;
            if (curday > dm) { cdm = curday; curday = dm; }
            if (curday < 1) { cdm = curday; curday = 1; }

            cmbYearDay.Text = curday.ToString();
            if (cdm > -1)
            {
                lblFormMsg.Text = cdm.ToString() + " нет в этом месяце. Присвоено " + cmbYearDay.Text;
                lblFormMsg.ForeColor = Color.Red;
            }
        }

        private void btnPlaySound_Click(object sender, EventArgs e)
        {
            if (TaskSoundType == SoundType.Internal)
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources.alarm);
                sp.Load();
                sp.Play();
            }

            if (TaskSoundType == SoundType.User)
            {
                if (SoundFile == "")
                {
                    lblFormMsg.ForeColor = Color.Red;
                    lblFormMsg.Text = "Файл не указан!";
                    return;
                }

                try
                {
                    SoundPlayer sp = new SoundPlayer(SoundFile);
                    sp.Load();
                    sp.Play();
                }
                catch (Exception ex)
                {
                    CommonFunctions.ErrMessage (ex.Message);
                }                    
            }
        }

        private void btnOpenSoundFile_Click(object sender, EventArgs e)
        {
            frmSoundFile fSoundFile = new frmSoundFile();
            fSoundFile.FileName = SoundFile;
            fSoundFile.ShowDialog();
            if (fSoundFile.bSuccess)
            {
                SoundFile = fSoundFile.FileName;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            dlgOpen.Filter = "Исполняемые файлы (*exe,*.com,*.bat,*.scr)|" +
                "*exe;*.com;*.bat;*.scr|" + "Все файлы|*.*";
            dlgOpen.FileName = "";
            DialogResult Ans = dlgOpen.ShowDialog();
            if (Ans == DialogResult.Cancel) return;

            txtProgramPath.Text = dlgOpen.FileName;
        }

        private void dtStartDateTime_ValueChanged(object sender, EventArgs e)
        {
            if (!bEdit)
            { 
                dtNextDateTime.Value = dtStartDateTime.Value; 
            }

            cmbWeekDay.Text = CommonFunctions.GetDayName(dtStartDateTime.Value.DayOfWeek);            
            FillMounthCmb(DateTime.Now.Month, DateTime.Now.Year, cmbMonthDay);
            cmbMonthDay.Text = dtStartDateTime.Value.Day.ToString();            
            cmbMonth.Text = CommonFunctions.GetMonthName(dtStartDateTime.Value.Month);
            cmbYearDay.Text = dtStartDateTime.Value.Day.ToString();

        }

        private void cmbWeekDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtStartDateTime.Value = cTask.DateNextDayOfWeek(dtStartDateTime.Value,
                CommonFunctions.GetDayOfWeek(cmbWeekDay.Text), false);
        }

        private void cmbMonthDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtStartDateTime.Value = new DateTime(dtStartDateTime.Value.Year,
                dtStartDateTime.Value.Month, Convert.ToInt32(cmbMonthDay.Text),
                dtStartDateTime.Value.Hour, dtStartDateTime.Value.Minute,
                dtStartDateTime.Value.Second);
        }

        private void cmbYearDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtStartDateTime.Value = new DateTime(dtStartDateTime.Value.Year,
                dtStartDateTime.Value.Month, Convert.ToInt32(cmbYearDay.Text),
                dtStartDateTime.Value.Hour, dtStartDateTime.Value.Minute,
                dtStartDateTime.Value.Second);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((TaskActionType == ActionType.Message) || (TaskActionType == ActionType.Both))
            {
                if (txtMessage.Text.Trim() == string.Empty)
                {
                    DialogResult Ans = MessageBox.Show("Сообщение пустое. Продолжить?",
                        "Пустое сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (Ans == DialogResult.No) return;
                }
            }
            
            if (bEdit)
            {
                if (dtStartDateTime.Value != Task.GetStartDateTime())
                {
                    if ((TaskTimeType != TimeType.One) && (TaskTimeType != TimeType.EveryDay)
                        && (TaskTimeType != TimeType.EveryNDays))
                    {
                        DialogResult Ans = MessageBox.Show("Дата (время) были изменены." +
                        "При сохранении изменится дата (время) первого и следующих запусков. " +
                        "Изменить дату (время)?",
                            "Изменение даты", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (Ans == DialogResult.No)
                        {
                            dtStartDateTime.Value = Task.GetStartDateTime();
                            return;
                        }                       

                    }

                    Task.StartDateTime = cTask.DateTimeToString(dtStartDateTime.Value);
                    Task.ResetNextTime();
                    Task.ClearLastRun();
                }
            }
            else
            {
                try
                {
                    Task = new cTask(txtName.Text.Trim(), dtStartDateTime.Value, false);
                }
                catch (Exception ex)
                {
                    lblFormMsg.ForeColor = Color.Red;
                    lblFormMsg.Text = ex.Message;
                    return;
                }
            }

            //установка свойств объекта
            Task.Active = chkActive.Checked;
            Task.MessageText = txtMessage.Text.Trim();
            Task.N = Convert.ToInt32(txtN.Text);
            Task.ProgramParameters = txtProgramParams.Text.Trim();
            Task.ProgramPath = txtProgramPath.Text.Trim();
            Task.ProgramHide = chkProgramHide.Checked;
            Task.Remind = Convert.ToInt32(txtRemind.Text);
            Task.SoundPath = SoundFile;            
            Task.TaskActionType = TaskActionType;
            Task.TaskName = txtName.Text.Trim();
            Task.TaskRemindType = TaskRemindType;
            Task.TaskSoundType = TaskSoundType;
            Task.TaskTimeType = TaskTimeType;

            //внутренняя проверка объекта
            try
            {
                Task.CheckTask();
            }
            catch (Exception ex)
            {
                lblFormMsg.ForeColor = Color.Red;
                lblFormMsg.Text = ex.Message;
                return;
            }
            
            //Запись в БД
            try
            {
                Task.ToDataSet(cConfig.dsConfig, "Tasks");
            }
            catch (Exception ex)
            {
                lblFormMsg.ForeColor = Color.Red;
                lblFormMsg.Text = ex.Message;
                return;
            }
            
            //сохранение
            if (!cConfig.SaveConfig())
            {
                lblFormMsg.ForeColor = Color.Red;
                lblFormMsg.Text = cConfig.ConfigErrMessage;
                return;
            }



            bSuccess = true;
            this.Close();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            frmLogView fLogView = new frmLogView();
            fLogView.log = Task.Log;
            fLogView.ShowDialog();
            if (fLogView.bClear) Task.ClearLog();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            DialogResult Ask = MessageBox.Show("Очистить протокол?", "Очистка протокола",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Ask == DialogResult.No) return;

            Task.ClearLog();
        }
        
    }
}

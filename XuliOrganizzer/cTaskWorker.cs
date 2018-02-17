using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Data;
using System.Media;

namespace XuliOrganizzer
{
    public enum WorkerErrorLevel
    {
        OK = 0,
        Warning =1,
        Error = 2
    }
    public enum NotificationType
    {
        Both = 0,
        Window = 1,
        Baloon = 2
    }
    public enum OverdueTaskReaction
    {
        Notification = 0,
        RunAndNotification = 1
    }
    public class cTaskWorker
    {        
        public delegate void AutoRefreshError(object sender);
        public event AutoRefreshError OnAutoRefreshError;
        public delegate void AutoRefreshComplete(object sender);
        public event AutoRefreshComplete OnAutorefreshComplete;
        public delegate void OverdueTaskDetected(object sender);
        public event OverdueTaskDetected OnOverdueTaskDetected;

        public delegate void StartRunTask(cTask task);
        public event StartRunTask OnStartRunTask;
        public delegate void CompleteTask(cTask task);
        public event CompleteTask OnCompleteTask;
        public delegate void StopTask(cTask task);
        public event StopTask OnStopTask;


        public ArrayList OverdueTaskIDs = new ArrayList();
        
        public string TaskErrMessage { get; private set; }
        public NotificationType WorkerNotification { get; set; }
        public frmMain fMain { get; set; }

        private Dictionary<int, cTask> CurrentTasks = new Dictionary<int,cTask>();
        private Dictionary<int, frmMessage> MessageForms = new Dictionary<int, frmMessage>();
        private Timer WorkerTimer = null;
        private string CurrentDate = "";        

        public cTaskWorker()
        {
            TaskErrMessage = string.Empty;
        }
        
        
        //загрузка заданий на текущий день
        private WorkerErrorLevel LoadTasks()
        {
            //задачи уже есть
            if (CurrentTasks.Count>0)
            {
                TaskErrMessage ="Задачи уже загружены";
                return WorkerErrorLevel.Error;
            }

            //получение текущего дня и перевод строки в формат БД
            DateTime curday = DateTime.Now;
            string findstr = cTask.DateTimeToString(curday);
            string[] buf = findstr.Split('/');
            findstr = buf[0] + "/" + buf[1] + "/" + buf[2];

            //Поиск данных
            DataRow[] drtasks = cConfig.dsConfig.Tables["Tasks"].
                Select("[NextDateTime]" + " LIKE '%" + findstr + "%'", "NextDateTime DESC");

            if (drtasks.Length == 0)
            {
                TaskErrMessage = "Нет запланированных задач";
                return WorkerErrorLevel.Warning;
            }

            //Загрузка объектов в ArrayList
            foreach (DataRow dr in drtasks)
            {
                int RecID = (int)dr["ID"];
                bool Active = (bool)dr["Active"];
                string currun = (string)dr["NextDateTime"];
                string lastrun = (string)dr["LastRun"];
                if ((Active) && (!OverdueRecord(curday,RecID)) && (currun!=lastrun))
                {
                    CurrentTasks.Add(RecID,new cTask(cConfig.dsConfig, "Tasks", RecID));
                }
            }

            if (CurrentTasks.Count == 0)
            {
                TaskErrMessage = 
                    "Задачи на текущий день есть, но не загружены т.к. просрочены, неактивны или"+ 
                " уже выполнены.";
                return WorkerErrorLevel.Warning;
            }
            return WorkerErrorLevel.OK;
        }

        //загрузка и запуск заданий на текущий день
        public WorkerErrorLevel StartTasks()
        {            
            WorkerErrorLevel wol = LoadTasks();
            if (wol != WorkerErrorLevel.OK) return wol;

            foreach (cTask tsk in CurrentTasks.Values)
            {                
                //запуск задач                
                tsk.onCompleteTask += new cTask.CompleteTask(cTaskWorker_onCompleteTask);
                tsk.onSendMessage += new cTask.SendTaskMessage(cTaskWorker_onSendMessage);
                tsk.onStartRunningTask += new cTask.StartRunnigTask(tsk_onStartRunningTask);
                tsk.onTaskStop += new cTask.TaskStop(tsk_onTaskStop);

                //если только всплывающие сообщения
                if (WorkerNotification == NotificationType.Baloon)
                {
                    tsk.NoRemind = true; //отключить постоянные напоминания
                }
                else
                {
                    tsk.NoRemind = false;
                }

                try
                {
                    tsk.StartWatch();
                    MessageForms.Add(tsk.ID, null);
                }
                catch (Exception ex)
                {
                    TaskErrMessage = ex.Message;
                    return WorkerErrorLevel.Error;
                }
            }
         
            return WorkerErrorLevel.OK;
        }

        private string GetCurrentDate()
        {
            return DateTime.Now.Year.ToString() + "/" +
                DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
        }
        private string GetDate(DateTime date)
        {
            return date.Year.ToString() + "/" +
                date.Month.ToString() + "/" + date.Day.ToString();
        }

        #region workerevents
        void tsk_onTaskStop(object sender)
        {
            if (OnStopTask != null) OnStopTask((cTask)sender);
        }

        void tsk_onStartRunningTask(object sender)
        {
            if (!((cTask)sender).Overdue)
            {
                if (OnStartRunTask != null) OnStartRunTask((cTask)sender);
            }
        }

        
        void cTaskWorker_onCompleteTask(object sender)
        {
            //задача завершена - сохраняем состояние
            ((cTask)sender).ToDataSet(cConfig.dsConfig, "Tasks");
            if (OnCompleteTask != null) OnCompleteTask((cTask)sender);
        }
       
        
        void cTaskWorker_onSendMessage(object sender, bool NoAddTime)
        {
            cTask tsk = (cTask)sender;

            switch (tsk.TaskSoundType)
            {
                case SoundType.Internal:
                    {
                        SoundPlayer sp = new SoundPlayer(Properties.Resources.alarm);
                        sp.Load();
                        sp.Play();

                    }; break;
                case SoundType.User:
                    {
                        try
                        {
                            SoundPlayer sp = new SoundPlayer(tsk.SoundPath);
                            sp.Load();
                            sp.Play();
                        }
                        catch
                        {
                            SystemSounds.Hand.Play();
                        }
                    }; break;
            }

            //показываем всплывающую подсказку
            if ((WorkerNotification == NotificationType.Baloon) ||
                (WorkerNotification == NotificationType.Both))
            {
                fMain.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    CommonFunctions.globalNI.ShowBalloonTip(5000, tsk.TaskName,
                    tsk.MessageText+" ", 
                    System.Windows.Forms.ToolTipIcon.Info);
                });
            }
            
            //показываем окно с оповещением
            if ((WorkerNotification == NotificationType.Window)||
                (WorkerNotification == NotificationType.Both))
            {
                if (tsk.Overdue)
                {
                    fMain.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        CommonFunctions.InfoMessage(tsk.MessageText, 
                            tsk.TaskName + ": " + tsk.LastRun);
                    });
                    return;
                }
                if (MessageForms[tsk.ID] == null) //формы сообщения нет
                {
                    fMain.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        MessageForms[tsk.ID] = new frmMessage();
                        MessageForms[tsk.ID].Task = tsk;
                        MessageForms[tsk.ID].NoAddTime = NoAddTime;
                        MessageForms[tsk.ID].TopMost = true; //поверх всех окон                        
                        MessageForms[tsk.ID].Show();
                    });
                }
                else 
                {
                    //форма для этой задачи есть, сообщение выслано повторно (Remind)
                    //а пользователь не реагирует
                    fMain.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        MessageForms[tsk.ID].TopMost = true; //Форма поверх всех окон, в форме это отключается.
                        MessageForms[tsk.ID].Task = tsk;
                        MessageForms[tsk.ID].Show();                        
                        
                    });                    
                    
                }
            }
        }
        

        void WorkerTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string date = GetCurrentDate();

            if (CurrentDate != date) //наступил следующий день, обновляем список задач
            {
                WorkerTimer.Stop(); //остановка таймера, чтоб событие не вызвалось
                WorkerErrorLevel wol = RefreshTasks();
                if (wol == WorkerErrorLevel.Error)
                {
                    if (OnAutoRefreshError!=null) OnAutoRefreshError(this);
                    return;
                }

                CurrentDate = date;
                WorkerTimer.Start();
                if (OnAutorefreshComplete != null) OnAutorefreshComplete(this);
            }
        }
        #endregion
        

        public WorkerErrorLevel StopTasks()
        {
            foreach (cTask tsk in CurrentTasks.Values)
            {
                tsk.StopTask(); //останавливаем задачу

                try
                {
                    tsk.ToDataSet(cConfig.dsConfig, "Tasks"); //сохраняем состояние в DataSet
                }
                catch (Exception ex)
                {
                    TaskErrMessage = ex.Message;
                    return WorkerErrorLevel.Error;
                }
            }

            //удаление всех созданных форм
            foreach (frmMessage f in MessageForms.Values)
            {
                if (f != null)
                {
                    fMain.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        try
                        {
                            f.Dispose();
                        }
                        catch { }
                    });
                }
            }

            CurrentTasks.Clear();
            MessageForms.Clear();

            return WorkerErrorLevel.OK;
        }

        public WorkerErrorLevel RefreshTasks()
        {
            WorkerErrorLevel wol = StopTasks();
            if (wol != WorkerErrorLevel.OK) return wol;
            return StartTasks();
        }

        //запуск всех задач и автообновление списка из БД
        public WorkerErrorLevel StartAutoRefresh()
        {
            GetOverdueInDB(DateTime.Now);
            //запуск задач
            WorkerErrorLevel wol = StartTasks();
            if (wol == WorkerErrorLevel.Error) return wol;

            //получение текущего дня
            CurrentDate = GetCurrentDate();
            
            //запуск таймера
            if (WorkerTimer == null) WorkerTimer = new Timer();
            WorkerTimer.AutoReset = true;
            WorkerTimer.Interval = 10000;
            WorkerTimer.Elapsed += new ElapsedEventHandler(WorkerTimer_Elapsed);
            WorkerTimer.Start();

            return WorkerErrorLevel.OK;
        }

        public WorkerErrorLevel StopAutoRefresh()
        {
            WorkerErrorLevel wol = StopTasks();
            if (wol != WorkerErrorLevel.OK) return wol;
            if (WorkerTimer != null)
            {
                WorkerTimer.Stop();
                WorkerTimer.Elapsed -= WorkerTimer_Elapsed;
                WorkerTimer.Dispose();
                WorkerTimer = null;
            }

            return WorkerErrorLevel.OK;
        }

        public bool TasksLoaded()
        {
            return (CurrentTasks.Count > 0);
        }
        public int LoadedTasksCount()
        {
            return CurrentTasks.Count;
        }


        #region onetaskopers
        //------------опрации с отдельными задачами-------------------------

        
        public bool IsTaskExist(int tskID)
        {
            return CurrentTasks.ContainsKey(tskID);
        }

        
        public bool RunningInCurrentPeriod(int tskID)
        {
            cTask tmpTsk = null;
            try
            {
                tmpTsk = new cTask(cConfig.dsConfig,"Tasks",tskID);
            }
            catch (Exception ex)
            {
                TaskErrMessage = ex.Message;
                return false;
            }            

            string date = GetDate(tmpTsk.GetNextDateTime());

            if (CurrentDate==date) return true;

            return false;
        }
        
        public bool RunningInCurrentPeriod(cTask  tsk)
        {                                                

            string date = GetDate(tsk.GetNextDateTime());

            if (CurrentDate == date) return true;

            return false;
        }
        public void ClearTaskLog(int tskID)
        {
            if (IsTaskExist(tskID))
            {
                CurrentTasks[tskID].ClearLog();
            }
        }
        
        //остановка и удаление отдельной задачи из списка запущенных
        public WorkerErrorLevel RemoveTask (int tskID, bool Save)
        {
            if (!CurrentTasks.ContainsKey(tskID)) 
            {
                TaskErrMessage = "Не найдено";
                return WorkerErrorLevel.Warning;
            }

            CurrentTasks[tskID].StopTask();

            if (Save)
            {
                //сохраняем состояние в DataSet
                try
                {
                    CurrentTasks[tskID].ToDataSet(cConfig.dsConfig, "Tasks");
                }
                catch (Exception ex)
                {
                    TaskErrMessage = ex.Message;
                    return WorkerErrorLevel.Error;
                }
            }

            //если есть форма сообщения, удаляем.
            if (MessageForms[tskID]!=null)
            {
                    fMain.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        try
                        {
                            MessageForms[tskID].Dispose();
                        }
                        catch { }
                    });                
            }

            CurrentTasks.Remove(tskID);
            MessageForms.Remove(tskID);
            return WorkerErrorLevel.OK;
        }

        //добавляет к списку и запускает задачу
        public WorkerErrorLevel AddTask(int tskID)
        {
            if (IsTaskExist(tskID))
            {
                TaskErrMessage = "Задача уже существует";
                return WorkerErrorLevel.Error;
            }

            DataRow dr = cConfig.dsConfig.Tables["Tasks"].Rows.Find(tskID);

            if (dr == null)
            {
                TaskErrMessage = "Задача не найдена в базе данных";
                return WorkerErrorLevel.Error;
            }

            if (!((bool)dr["Active"]))
            {
                TaskErrMessage = "Задача неактивна";
                return WorkerErrorLevel.Warning;
            }

            if (!RunningInCurrentPeriod(tskID))
            {
                TaskErrMessage = "Задача будет загружена позже";
                return WorkerErrorLevel.Warning;
            }
            string currun = (string)dr["NextDateTime"];
            string lastrun = (string)dr["LastRun"];
            if (currun == lastrun)
            {
                TaskErrMessage = "Задача уже выполнялась";
                return WorkerErrorLevel.Warning;
            }
            
            
            try
            {
                CurrentTasks.Add(tskID, new cTask(cConfig.dsConfig, "Tasks", tskID));
                CurrentTasks[tskID].CheckTask();
                CurrentTasks[tskID].onCompleteTask+=new cTask.CompleteTask(cTaskWorker_onCompleteTask);
                CurrentTasks[tskID].onSendMessage += new cTask.SendTaskMessage(cTaskWorker_onSendMessage);
                CurrentTasks[tskID].onStartRunningTask += new cTask.StartRunnigTask(tsk_onStartRunningTask);
                CurrentTasks[tskID].onTaskStop += new cTask.TaskStop(tsk_onTaskStop);
                if (WorkerNotification == NotificationType.Baloon)
                {
                    CurrentTasks[tskID].NoRemind = true;
                }
                else
                {
                    CurrentTasks[tskID].NoRemind = false;
                }
                MessageForms.Add(tskID, null);
                if (CurrentTasks[tskID].TaskOverdue(DateTime.Now))
                {
                    OverdueTaskIDs.Add(tskID);
                    if (OnOverdueTaskDetected != null)
                    {
                        OnOverdueTaskDetected(this);
                    }
                }

                CurrentTasks[tskID].StartWatch();                
            }
            catch (Exception ex)
            {
                TaskErrMessage = ex.Message;
                return WorkerErrorLevel.Error;
            }

            return WorkerErrorLevel.OK;
        }
        #endregion

        //работа с просрочкой

        private void GetOverdueInDB(DateTime curDateTime)
        {
            OverdueTaskIDs.Clear();

            foreach (DataRow dr in cConfig.dsConfig.Tables["Tasks"].Rows)
            {
                string sNext = (string)dr["NextDateTime"];
                DateTime dtNext = cTask.InternalStringToDT(sNext);

                curDateTime = new DateTime(curDateTime.Year, curDateTime.Month,
                    curDateTime.Day, curDateTime.Hour, curDateTime.Minute, 0);

                string LastRun = (string)dr["LastRun"];
                int ID = (int)dr["ID"];
                TimeType TaskTimeType = (TimeType)dr["TimeType"];

                bool Active = (bool)dr["Active"];

                if (!Active) continue;

                if (LastRun == string.Empty) //задача не разу не выполнялась
                {
                    //сравниваем дату следующего выполнения с заданной
                    //заданная больше - задание просрочено
                    if (curDateTime > dtNext)
                    {
                        OverdueTaskIDs.Add(ID);
                        dr["Overdue"] = true;
                    }
                }
                else //задание выполнялось
                {
                    //задание одноразовое и выполнялось
                    //не просрочено
                    if (TaskTimeType == TimeType.One) continue;

                    //сравниваем дату следующего выполнения с заданной
                    //заданная больше - задание просрочено
                    if (curDateTime > dtNext)
                    {
                        OverdueTaskIDs.Add(ID);
                        dr["Overdue"] = true;
                    }
                }
            }

            if (OverdueTaskIDs.Count > 0)
            {
                if (OnOverdueTaskDetected != null)
                {
                    OnOverdueTaskDetected(this);
                }
            }
        }

        private bool OverdueRecord(DateTime curDateTime, int recID)
        {
            cTask tmpTsk = null;

            try
            {
                tmpTsk = new cTask(cConfig.dsConfig, "Tasks", recID);
            }
            catch
            {
                return false;
            }

            return tmpTsk.TaskOverdue(curDateTime);
        }        
        
        public WorkerErrorLevel RunOverdueTasks()
        {
            cTask tmpTsk = null;
            foreach (int otID in OverdueTaskIDs)
            {
                try
                {
                    tmpTsk = new cTask(cConfig.dsConfig, "Tasks", otID);                    
                }
                catch (Exception ex)
                {
                    TaskErrMessage = ex.Message;
                    return WorkerErrorLevel.Error;
                }
                
                tmpTsk.onSendMessage += cTaskWorker_onSendMessage;
                tmpTsk.NoRemind = true;                                
                tmpTsk.RunTask();
                tmpTsk.onSendMessage -= cTaskWorker_onSendMessage;
                tmpTsk = null;
            }
            return WorkerErrorLevel.OK;
        }

        public WorkerErrorLevel CorrectOverdueTime(DateTime startDT)
        {
            cTask tmpTsk = null;
            foreach (int otID in OverdueTaskIDs)
            {
                try
                {
                    tmpTsk = new cTask(cConfig.dsConfig, "Tasks", otID);
                }
                catch (Exception ex)
                {
                    TaskErrMessage = ex.Message;
                    return WorkerErrorLevel.Error;
                }

                tmpTsk.CorrectOverdueTime(startDT, true);
                tmpTsk.ToDataSet(cConfig.dsConfig, "Tasks");
                tmpTsk = null;
            }
            return WorkerErrorLevel.OK;
        }
    }
}

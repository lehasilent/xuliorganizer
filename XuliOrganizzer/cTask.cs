using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Timers;
using System.Diagnostics;

namespace XuliOrganizzer
{
    #region enums
    public enum TimeType
    {
        One = 0,
        EveryDay = 1,
        EveryWeek = 2,
        EveryMonth = 3,
        EveryYear = 4,
        EveryNDays = 5,
        EveryNHours = 6,
        EveryNMinutes = 7
    }

    public enum ActionType
    {
        Message = 0,
        Run = 1,
        Both = 2
    }

    public enum SoundType
    {
        NoSound = 0,
        Internal = 1,
        User = 2,
    }

    public enum RemindType
    {
        Minuts = 0,
        Hours = 1
    }
    #endregion
    public class cTask
    {
        public delegate void SendTaskMessage(object sender, bool NoAddTime);
        public event SendTaskMessage onSendMessage;
        public delegate void CompleteTask(object sender);
        public event CompleteTask onCompleteTask;
        public delegate void StartRunnigTask(object sender);
        public event StartRunnigTask onStartRunningTask;
        public delegate void TaskStop(object sender);
        public event TaskStop onTaskStop;

        private DateTime dtStartDateTime = new DateTime();
        private DateTime dtNextDateTime = new DateTime();
        private DateTime dtOld = new DateTime();
        private int remindOld = 0;
        private bool LoadedFormDS = false;
        private bool isComplete = false;
        private bool isFirstRun = true;
        private Timer TaskIntTimer = null;

        #region properties
        public int ID { get; private set; } //ID для БД (может придется переделать)
        public string TaskName { get; set; }
        public string StartDateTime //строка формата YYYY/MM/DD/HH/mm
        {
            get
            {
                return DateTimeToString(dtStartDateTime);    
            }
            set
            {
                dtStartDateTime = InternalStringToDT(value);
            }
        }
        public string NextDateTime
        {
            get
            {
                return DateTimeToString(dtNextDateTime);
            }
            private set
            {
                dtNextDateTime = InternalStringToDT(value);
            }
        }
        public TimeType TaskTimeType { get; set; }
        public ActionType TaskActionType { get; set; }
        public string MessageText { get; set; }
        public string ProgramPath { get; set; }
        public string ProgramParameters { get; set; }
        public bool ProgramHide { get; set; }
        public SoundType TaskSoundType { get; set; }
        public string SoundPath { get; set; }
        public RemindType TaskRemindType { get; set; }
        public int Remind { get; set; }        
        public bool Active { get; set; }
        public string Log { get; private set; }
        public int N { get; set; }
        public string LastRun { get; private set; }
        public bool Overdue { get; private set; }

        public bool NoRemind { get; set; }
        #endregion

        #region staticfunc
        public static int DaysToDayOfWeek(DayOfWeek Current, DayOfWeek Next, bool NextWeek)
        {
            //сколько дней до ближайшего дня недели от указанного 
            int c = Convert.ToInt32(Current);
            int n = Convert.ToInt32(Next);
            int res = 0;

            //воскресенье 7 день, понедельник - 1
            if (c == 0) c = 7;
            if (n == 0) n = 7;

            if (c == n) //дни недели одинаковые
            {
                if (NextWeek) return 7; else return 0;
            }

            //следующий день недели меньше текущего 
            //(напр Чт и ск. дней до ближайшего Вт)
            if (n < c) res = (7 - c) + n;

            //следующий день недели больше текущего 
            //(напр Чт и ск. дней до ближайшей Сб)
            if (n > c) res = n - c;

            return res;
        }
        

        public static DateTime DateNextDayOfWeek(DateTime Current, DayOfWeek Next, bool NextWeek)
        {
            int days = DaysToDayOfWeek(Current.DayOfWeek, Next, NextWeek);

            return Current.AddDays(days);
        }

        public static string DateTimeToString(DateTime dt)
        {
            string sbuf = dt.Year.ToString() + "/" +
                    dt.Month.ToString() + "/" +
                    dt.Day.ToString() + "/" +
                    dt.Hour.ToString() + "/" +
                    dt.Minute.ToString();
            return sbuf;
        }
        private static string AddToSize(string Str, char AddChr, int Size, bool Right)
        {
            if (Str.Length >= Size) return Str;

            if (Right)
            {
                Str = Str.PadRight(Size, AddChr);
            }
            else
            {
                Str = Str.PadLeft(Size, AddChr);
            }

            return Str;
        }
        public static string FormatDateString(string sDate, string sFormat)
        {
            if (sDate == null) return string.Empty;
            string[] sbuf = sDate.Split('/');
            if (sbuf.Length != 5) return sDate;

            string OutStr = sFormat;

            OutStr = OutStr.Replace("YYYY", sbuf[0]); //год
            OutStr = OutStr.Replace("MM", AddToSize(sbuf[1],'0',2,false)); //месяц
            OutStr = OutStr.Replace("DD", AddToSize(sbuf[2], '0', 2, false));//день
            OutStr = OutStr.Replace("HH", AddToSize(sbuf[3], '0', 2, false));//часы
            OutStr = OutStr.Replace("mm", AddToSize(sbuf[4], '0', 2, false));//минуты

            return OutStr;
        }
        public  static DateTime InternalStringToDT(string sDateTime)
        {
            string[] sbuf = sDateTime.Split('/');
            int[] ibuf = new int[sbuf.Length];
            int i = 0;
            try
            {
                foreach (string s in sbuf)
                {
                    ibuf[i] = Convert.ToInt32(sbuf[i]);
                    i++;
                }

                DateTime dt = new DateTime(ibuf[0], ibuf[1], ibuf[2], ibuf[3], ibuf[4], 0);
                return dt;
            }
            catch (Exception ex)
            {
                ArgumentException aex = new ArgumentException(ex.Message, ex);
                throw aex;
            }
        }
        #endregion

        public cTask(string sTaskName, string  dStartDateTime, bool CalcNextDT)
        {
            DefaultValues();
            TaskName = sTaskName;
            if (TaskName.Trim() == string.Empty)
            {
                Exception ex = new Exception("TaskName is empty!");
                throw ex;
            }
            StartDateTime = dStartDateTime;
            if (CalcNextDT)
            {
                dtNextDateTime = CalcNextDate();
            }
            else
            {
                dtNextDateTime = dtStartDateTime;
            }

        }

        public cTask(string sTaskName, DateTime dStartDateTime, bool CalcNextDT)
        {
            DefaultValues();
            TaskName = sTaskName;
            if (TaskName.Trim() == string.Empty)
            {
                Exception ex = new Exception("TaskName is empty!");
                throw ex;
            }
            dtStartDateTime = dStartDateTime;
            if (CalcNextDT)
            {
                dtNextDateTime = CalcNextDate();
            }
            else
            {
                dtNextDateTime = dtStartDateTime;
            }
        }

        public cTask(DataSet DS, string TableName, int RecID)
        {
            DefaultValues();
            FromDataSet(DS, TableName, RecID);
            CheckTask();
        }

        private void DefaultValues()
        {
            ID = 0;
            TaskName = string.Empty;
            //StartDateTime = string.Empty;
            //NextDateTime = string.Empty;        
            TaskTimeType = TimeType.One;
            TaskActionType = ActionType.Message;
            MessageText = string.Empty;
            ProgramPath = string.Empty;
            ProgramParameters = string.Empty;
            ProgramHide = false;
            TaskSoundType = SoundType.Internal;
            SoundPath = string.Empty;
            TaskRemindType = RemindType.Minuts;
            Remind = 0;
            Active = true;
            Log = string.Empty;
            N = 0;
            LastRun = string.Empty;
            Overdue = false;

            NoRemind = false;
        }
        

        private DateTime CalcNextDate()
        {
            DateTime ndt = dtNextDateTime;
            if (ndt == (new DateTime(1, 1, 1)))
            {
                ndt = dtStartDateTime;
            }

            switch (TaskTimeType)
            {
                case TimeType.One:
                    {
                        return ndt;
                    };
                case TimeType.EveryDay:
                    {
                        ndt = ndt.AddDays(1);

                    }; break;
                case TimeType.EveryMonth:
                    {
                        ndt = ndt.AddMonths(1);

                    }; break;                    
                case TimeType.EveryWeek:
                    {
                        ndt = ndt.AddDays(7);
                    }; break;                    
                case TimeType.EveryYear:
                    {
                        ndt = ndt.AddYears(1);
                    }; break;                    
                case TimeType.EveryNDays:
                    {
                        ndt = ndt.AddDays(N);
                    }; break;                    
            }

            return ndt;
            
        }

        public DateTime NextDateInfo()
        {
            return CalcNextDate();
        }
        public void CalcNextDateTime()
        {
            dtNextDateTime = CalcNextDate();
        }
        public DateTime GetStartDateTime()
        {
            return dtStartDateTime;
        }
        public DateTime GetNextDateTime()
        {
            return dtNextDateTime;
        }

        public void ToDataSet(DataSet DS, string TableName)
        {
            TaskOverdue(DateTime.Now);
            if (!LoadedFormDS) //добавить новую запись в таблицу
            {
                try
                {
                    DataRow dr = DS.Tables[TableName].NewRow();

                    dr["Name"] = TaskName;
                    dr["StartDateTime"] = StartDateTime;
                    dr["NextDateTime"] = NextDateTime;
                    dr["TimeType"] = TaskTimeType;
                    dr["ActionType"] = TaskActionType;
                    dr["MessageText"] = MessageText;
                    dr["ProgramPath"] = ProgramPath;
                    dr["ProgramParameters"] = ProgramParameters;
                    dr["ProgramHide"] = ProgramHide;
                    dr["SoundType"] = TaskSoundType;
                    dr["SoundPath"] = SoundPath;
                    dr["RemindType"] = TaskRemindType;
                    dr["Remind"] = Remind;
                    dr["Active"] = Active;
                    dr["Log"] = Log;
                    dr["N"] = N;
                    dr["LastRun"] = LastRun;
                    dr["Overdue"] = Overdue;

                    DS.Tables[TableName].Rows.Add(dr);
                }
                catch (Exception ex)
                {
                    Exception gex = new Exception(ex.Message, ex);
                    throw gex;
                }
            }
            else //редактирование существующей записи
            {
                try
                {
                    DataRow dr = DS.Tables[TableName].Rows.Find(ID);

                    dr["Name"] = TaskName;
                    dr["StartDateTime"] = StartDateTime;
                    dr["NextDateTime"] = NextDateTime;
                    dr["TimeType"] = TaskTimeType;
                    dr["ActionType"] = TaskActionType;
                    dr["MessageText"] = MessageText;
                    dr["ProgramPath"] = ProgramPath;
                    dr["ProgramParameters"] = ProgramParameters;
                    dr["ProgramHide"] = ProgramHide;
                    dr["SoundType"] = TaskSoundType;
                    dr["SoundPath"] = SoundPath;
                    dr["RemindType"] = TaskRemindType;
                    dr["Remind"] = Remind;
                    dr["Active"] = Active;
                    dr["Log"] = Log;
                    dr["N"] = N;
                    dr["LastRun"] = LastRun;
                    dr["Overdue"] = Overdue;
                    
                }
                catch (Exception ex)
                {
                    Exception gex = new Exception(ex.Message, ex);
                    throw gex;
                }
            }
        }

        public void FromDataSet(DataSet DS, string TableName, int RecID)
        {
            try
            {
                ID = RecID;

                DataRow dr = DS.Tables[TableName].Rows.Find(ID);
                                 
                 TaskName = dr["Name"].ToString() ;
                 StartDateTime = dr["StartDateTime"].ToString();
                 NextDateTime = dr["NextDateTime"].ToString(); 
                 TaskTimeType = (TimeType)dr["TimeType"];
                 TaskActionType = (ActionType)dr["ActionType"] ;
                 MessageText = dr["MessageText"].ToString();
                 ProgramPath = dr["ProgramPath"].ToString();
                 ProgramHide = (bool)dr["ProgramHide"];
                 ProgramParameters = dr["ProgramParameters"].ToString();
                 TaskSoundType = (SoundType)dr["SoundType"];
                 SoundPath = dr["SoundPath"].ToString();
                 TaskRemindType = (RemindType)dr["RemindType"];
                 Remind = (int)dr["Remind"];
                 Active = (bool)dr["Active"];
                 Log = dr["Log"].ToString();
                 N = (int)dr["N"];
                 LastRun = dr["LastRun"].ToString();
                 Overdue = Convert.ToBoolean(dr["Overdue"]);

                 LoadedFormDS = true;
            }
            catch (Exception ex)
            {
                Exception gex = new Exception(ex.Message, ex);
                throw gex;
            }            
        }

        public void CheckTask()
        {
            Exception CheckException = null;
            if (TaskName == string.Empty)
            {
                CheckException = new Exception("Task name empty");
                throw CheckException;                
            }

            if ((TaskActionType == ActionType.Run) || (TaskActionType == ActionType.Both))
            {
                if (ProgramPath == string.Empty)
                {
                    CheckException = new Exception("Program path empty");
                    throw CheckException;                
                }
            }

            if ((TaskSoundType == SoundType.User) && (SoundPath == string.Empty))
            {
                CheckException = new Exception("Sound path empty");
                throw CheckException;                
            }
        }

        public void ResetNextTime()
        {
            dtNextDateTime = dtStartDateTime;
        }

        private void AddLog(string LogMessage)
        {
            DateTime dtlog = DateTime.Now;
            string strdtlog = FormatDateString(DateTimeToString(dtlog), "YYYY.MM.DD HH:mm");
            Log =  Log+ TaskName+" "+strdtlog + ": "+LogMessage+"\r\n";
        }
        public void ClearLog()
        {
            Log = string.Empty;
        }
        
        public void StartWatch()
        {
            CheckTask();
            TaskIntTimer = new Timer();
            TaskIntTimer.Elapsed += new ElapsedEventHandler(TaskIntTimer_Elapsed);
            TaskIntTimer.Interval = 100;
            TaskIntTimer.AutoReset = true;
            TaskIntTimer.Start();
        }
        
        void TaskIntTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            
            DateTime cdt = DateTime.Now;
            string strcdt = DateTimeToString(cdt);
            if (strcdt == NextDateTime)
            {                
                //останавливаем таймер
                StopWatch();
                //выполняем задачу
                RunTask();                                     
            }
            
        }
        public void StopWatch()
        {
            if (TaskIntTimer == null) return;
            TaskIntTimer.Stop();
            TaskIntTimer.Elapsed -= TaskIntTimer_Elapsed;
            TaskIntTimer.Dispose();
            
        }

        private void ExcecuteProgram()
        {
            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = ProgramPath;
            startInfo.Arguments = ProgramParameters;
            if (ProgramHide)
            {
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            }
            
            p.StartInfo = startInfo;
            
            AddLog("Запуск " + ProgramPath + " " + ProgramParameters +
                " (" + startInfo.WindowStyle.ToString() + ")");

            try
            {
                bool r = p.Start();
                if (r) AddLog("OK"); else AddLog("Ошибка программы");
            }
            catch (Exception ex)
            {
                AddLog("Ошибка " + ex.Message);
            }            
        }
        
        private void SendMess(bool NoAddTime)
        {
            if (onSendMessage != null) onSendMessage(this,NoAddTime);
            AddLog("Сообщение " + MessageText);
            if (!NoAddTime)
            {
                //если установлено постоянное напоминание через определенное время
                if (Remind != 0)
                {
                    AddTime(Remind, TaskRemindType);
                }
            }
        }

        public void AddTime(int Add, RemindType rt)
        {
            Remind = Add;
            dtNextDateTime = DateTime.Now;
            if (rt == RemindType.Minuts)
            {
                dtNextDateTime = dtNextDateTime.AddMinutes(Remind);
            }
            else
            {
                dtNextDateTime = dtNextDateTime.AddHours(Remind);
            }
            StartWatch();
        }        
        public void TaskComplete()
        {
            //восстанавливаем время следующего выполнения и напоминания
            dtNextDateTime = dtOld;
            Remind = remindOld;
            //расчитываем новое время следующего выполнения
            dtNextDateTime = CalcNextDate();
            //Отмечаем в Log
            AddLog("Выполнено.");
            //генерируем событие и устанавливаем флаг
            isComplete = true;
            StopWatch(); //остановка таймера
            if (onCompleteTask != null) onCompleteTask(this);
        }
        
        public void StopTask()
        {
            //задача уже завершена
            if (isComplete) return;

            StopWatch(); //остановка таймера
            
            //отписываем всех от событий
            onCompleteTask = null;
            onSendMessage = null;

            //остановили задачу до выполнения
            if (dtNextDateTime > DateTime.Now)
            {
                AddLog("Остановлено до выполнения");
            }
            else //это задача остановленная во время или после выполнения
            {
                //не завершенная с помощью Complete()

                //восстанавливаем время следующего выполнения и напоминания
                dtNextDateTime = dtOld;
                Remind = remindOld;
                //расчитываем новое время следующего выполнения
                dtNextDateTime = CalcNextDate();

                AddLog("Остановлено во время или после выполнения");
            }

            if (onTaskStop != null) onTaskStop(this);
        }
        
        public void ClearLastRun()
        {
            LastRun = string.Empty;
        }

        //определение просрочки задачи
        public bool TaskOverdue(DateTime date)
        {            
            date = new DateTime(date.Year, date.Month, date.Day, date.Hour,
                date.Minute, 0);

            if (LastRun == string.Empty) //задача не разу не выполнялась
            {
                //сравниваем дату следующего выполнения с заданной
                //заданная больше - задание просрочено
                if (date > dtNextDateTime)
                {
                    Overdue = true;
                    return Overdue;
                }
            }
            else //задание выполнялось
            {
                //задание одноразовое и выполнялось
                //не просрочено
                if (TaskTimeType == TimeType.One)
                {
                    Overdue = false;
                    return Overdue;
                }

                //сравниваем дату следующего выполнения с заданной
                //заданная больше - задание просрочено
                if (date > dtNextDateTime)
                {
                    Overdue = true;
                    return Overdue;
                }
            }

            Overdue = false;
            return Overdue;
        }

        public void CorrectOverdueTime(DateTime startDT, bool DeactivateOneTasks)
        {
            if (TaskOverdue(startDT))
            {
                if (TaskTimeType == TimeType.One)
                {
                    if (DeactivateOneTasks)
                    {
                        Active = false;
                    }
                    return;
                }

                while (TaskOverdue(startDT))
                {
                    CalcNextDateTime();
                }
            }
        }

        //выполнение задачи
        public void RunTask()
        {
            if (onStartRunningTask != null) onStartRunningTask(this);
            //отдаем фактическое время выполнения
            LastRun = DateTimeToString(DateTime.Now);
            //Сохранение времени запуска
            //понадобится если пользователь добавит время
            if (isFirstRun)
            {
                dtOld = dtNextDateTime;                
                remindOld = Remind;
                isFirstRun = false;
            }

            switch (TaskActionType)
            {                
                case ActionType.Message:
                    {
                        SendMess(NoRemind);

                    }; break;
                case ActionType.Run:
                    {
                        ExcecuteProgram();
                        TaskComplete();

                    }; break;
                case ActionType.Both:
                    {
                        ExcecuteProgram();
                        SendMess(true);
                        TaskComplete();
                        
                    }; break;
            }
        }
    }    
}

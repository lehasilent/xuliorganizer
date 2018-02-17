using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XuliOrganizzer
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
        }

        private FormBehavior MainBehavior = FormBehavior.Hide;
        private NotificationType Notification = NotificationType.Both;        
        private NotificationType oldNotification = NotificationType.Both;
        public bool NotificationChanged = false;
        public bool bSuccess = false;

        private void AutostartInfo()
        {
            if (cConfig.CheckAutostart())
            {
                btnAutostart.Text = "Удалить программу из автозагрузки";
            }
            else
            {
                btnAutostart.Text = "Добавить программу в автозагрузку";
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

        private void frmOptions_Load(object sender, EventArgs e)
        {
            AutostartInfo();
            txtSettingsPath.Text = cConfig.ConfigPath + cConfig.ConfigFileName;

            //установка чекбоксов
            chkAskExit.Checked=Convert.ToBoolean(
                cConfig.GetParameter("Global.AskExit","true"));
            chkAskMainBeh.Checked = Convert.ToBoolean(
                cConfig.GetParameter("Global.AskMainBehavior","true"));
            chkOverdueNotif.Checked = Convert.ToBoolean(
                cConfig.GetParameter("Global.OverdueNotify", "true"));
            chkOverdueNewTime.Checked = Convert.ToBoolean(
                cConfig.GetParameter("Global.OverdueNewTime", "false"));
            chkOverdueRun.Checked = Convert.ToBoolean(
                cConfig.GetParameter("Global.OverdueRun","false"));
            
            //загрузка остальных параметров
            MainBehavior = (FormBehavior) Convert.ToInt32(
                cConfig.GetParameter("Global.MainBehavior","0"));
            Notification  = (NotificationType)Convert.ToInt32(
                cConfig.GetParameter("Global.Notification","0"));
            oldNotification = Notification;

            //установка Radiobutton'ов
            int tmpNum = (int)MainBehavior;
            string tmpName = "rbMainBeh" + tmpNum.ToString();
            CheckRadioButton(tmpName, groupMainBeh);
            tmpNum = (int)Notification;
            tmpName = "rbNotification" + tmpNum.ToString();
            CheckRadioButton(tmpName, groupNotification);
        }

        private void btnAutostart_Click(object sender, EventArgs e)
        {
            bool res = cConfig.SwitchAutostart();
            if (!res)
            {
                CommonFunctions.ErrMessage("Неудача при изменении автозагрузки! Возможно нужно запустить программу с правами администратора!");
            }
            else
            {
                MessageBox.Show("Успешно изменена автозагрузка!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            AutostartInfo();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            bSuccess = false;
            this.Close();
        }
        

        private void rbMainBeh_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int v = Convert.ToInt32(rb.Name.Substring(rb.Name.Length - 1));
            MainBehavior = (FormBehavior)v;
        }

        private void rbNotification_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int v = Convert.ToInt32(rb.Name.Substring(rb.Name.Length - 1));
            Notification = (NotificationType)v;

            if (Notification == NotificationType.Baloon)
            {
                lblNoRemind.Text = "Возможность повторных напоминаний будет отключена";
            }
            else
            {
                lblNoRemind.Text = "";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            cConfig.SetParameter("Global.AskExit", 
                chkAskExit.Checked.ToString());
            cConfig.SetParameter("Global.AskMainBehavior", 
                chkAskMainBeh.Checked.ToString());
            cConfig.SetParameter("Global.OverdueNotify",
                chkOverdueNotif.Checked.ToString());
            cConfig.SetParameter("Global.OverdueNewTime",
                chkOverdueNewTime.Checked.ToString());
            cConfig.SetParameter("Global.OverdueRun",
                chkOverdueRun.Checked.ToString());

            cConfig.SetParameter("Global.MainBehavior", 
                ((int)MainBehavior).ToString());
            cConfig.SetParameter("Global.Notification", 
                ((int)Notification).ToString());

            if (Notification != oldNotification)
            {
                NotificationChanged = true;
            }
            else
            {
                NotificationChanged = false;
            }

            bSuccess = true;
            this.Close();
        }
    }
}

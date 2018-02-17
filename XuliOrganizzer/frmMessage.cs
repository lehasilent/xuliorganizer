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
    public partial class frmMessage : Form
    {
        public frmMessage()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;            
        }
        public cTask Task = null;
        public bool NoAddTime = false;
        private int TickCtr = 0;
        private RemindType TaskRemindType = RemindType.Minuts;        
        private const int cCaption = 26;   // Caption bar height;        

        protected override void OnPaint(PaintEventArgs e)
        {            
            Rectangle rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.Yellow, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                pos = this.PointToClient(pos);
                m.Result = (IntPtr)2;  // HTCAPTION
                return;                
            }
            base.WndProc(ref m);
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

        private void frmMessage_Load(object sender, EventArgs e)
        {
            ttButtons.SetToolTip(btnAddTime, "Напомнить позже");
            ttButtons.SetToolTip(btnComplete, "Готово");
            
            lblHeader.Text = this.Text = Task.TaskName + " :" + cTask.FormatDateString(Task.LastRun, "DD.MM.YYYY HH.mm");
            
            lblTime.Text = CommonFunctions.AddToSize(DateTime.Now.Hour.ToString(), '0', 2, false) +
                ":" + CommonFunctions.AddToSize(DateTime.Now.Minute.ToString(), '0', 2, false)+
                ":" + CommonFunctions.AddToSize(DateTime.Now.Second.ToString(), '0', 2, false);
            lblTime.Left = ClientSize.Width / 2 - lblTime.Width / 2;
            groupRemindType.Left = ClientSize.Width / 2 - groupRemindType.Width / 2;

            txtRemind.Text = Task.Remind.ToString();
            txtMessage.Text = Task.MessageText;
            TaskRemindType = Task.TaskRemindType;
            int tmp = (int)TaskRemindType;
            string tmpname = "rbRemindType" + tmp.ToString();
            CheckRadioButton(tmpname, groupRemindType);

            if (NoAddTime)
            {
                groupRemindType.Enabled = false;
                btnAddTime.Enabled = false;
            }

            tmrTime.Start();
        }

        string sep = ":";
        private void tmrTime_Tick(object sender, EventArgs e)
        {
            TickCtr++;
            
            if (sep == ":") sep = " "; else sep = ":";

            lblTime.Text = CommonFunctions.AddToSize(DateTime.Now.Hour.ToString(), '0', 2, false) +
                sep +CommonFunctions.AddToSize(DateTime.Now.Minute.ToString(), '0', 2, false)+
                sep +CommonFunctions.AddToSize(DateTime.Now.Second.ToString(), '0', 2, false);

            if (this.TopMost) this.TopMost = false;
            
        }

        private void txtRemind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
        
        private void RemindType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int v = Convert.ToInt32(rb.Name.Substring(rb.Name.Length - 1));
            TaskRemindType = (RemindType)v;
        }

        private void btnAddTime_Click(object sender, EventArgs e)
        {
            if (txtRemind.Text == string.Empty)
            {
                lblErr.Text = "Добавляемое время не указано!";
                return;
            }
            
            int remind = Convert.ToInt32(txtRemind.Text);
            if (remind == 0)
            {
                lblErr.Text = "Добавляемое время должно быть больше 0!";
                return;
            }
            Task.AddTime(remind, TaskRemindType);
            this.Hide();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            Task.TaskComplete();
            this.Hide();
        }
                
        /*private void frmMessage_MouseMove(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }*/

        private void frmMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrTime.Stop();
        }

    }
}

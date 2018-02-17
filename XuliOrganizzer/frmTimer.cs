using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace XuliOrganizzer
{
    public partial class frmTimer : Form
    {                
        private int[] StandTimeMin = new int[] { 1, 2, 5, 10, 15, 20, 30, 35, 60,120 };

        private int curH = 0;
        private int curM = 0;
        private int curS = 0;
        private int curMS = 0;

        private int oldH = 0;
        private int oldM = 0;
        private int oldS = 0;

        private int AllSec = 0;

        private bool Pause = false;

        private PrivateFontCollection myFonts = new PrivateFontCollection();
        
        public frmTimer()
        {
            InitializeComponent();
        }
        private void SetTime(int H, int M, int S, bool SetText)
        {
            curS = S % 60;
            curM = (M + S / 60) % 60;
            curH = M / 60 + H;

            lblTimer.Text = curH.ToString().PadLeft(2, '0') + ":"
                + curM.ToString().PadLeft(2, '0') + ":"
                + curS.ToString().PadLeft(2, '0') + "."
                + curMS.ToString().PadLeft(3, '0');

            if (SetText)
            {
                txtH.Text = curH.ToString().PadLeft(2, '0');
                txtM.Text = curM.ToString().PadLeft(2, '0');
                txtS.Text = curS.ToString().PadLeft(2, '0');
            }
        }

        private void frmTimer_Load(object sender, EventArgs e)
        {
            curH = Convert.ToInt32(cConfig.GetParameter("H", "0"));
            curM = Convert.ToInt32(cConfig.GetParameter("M", "0"));
            curS = Convert.ToInt32(cConfig.GetParameter("S", "0"));

            SetTime(curH, curM, curS,true);
            
            lblPause.Enabled = false;

            //создаем контекстное меню с заранее заданными временными интервалами
            int i = 0;
            cmnStandTime.Items.Clear();
            foreach (int t in StandTimeMin)
            {
                ToolStripMenuItem cmnStandTimeMenuItem = new ToolStripMenuItem();
                cmnStandTimeMenuItem.Name = "cmnStandTimeMenuItem" + i.ToString();
                cmnStandTimeMenuItem.Text = "Таймер на " + t.ToString() + " минут(ы)";
                cmnStandTimeMenuItem.Click += new EventHandler(cmnStandTimeMenuItem_Click);
                cmnStandTime.Items.Add(cmnStandTimeMenuItem);
                i++;
            }

            //выгрузка шрифта из ресурсов во временный файл
            string fontfile = CommonFunctions.TempFileWrite(Properties.Resources.lcdnova);
            if (fontfile != string.Empty)
            {
                myFonts.AddFontFile(fontfile);
                lblTimer.Font = new Font(myFonts.Families[0], 40);
                txtS.Font = new Font(myFonts.Families[0], 15);
                txtM.Font = new Font(myFonts.Families[0], 15);
                txtH.Font = new Font(myFonts.Families[0], 15);
            }
            
        }

        void cmnStandTimeMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsi = (ToolStripMenuItem)sender;
            int i = Convert.ToInt32(tsi.Name.Substring("cmnStandTimeMenuItem".Length));
            SetTime(StandTimeMin[i] / 60, StandTimeMin[i] % 60, 0,true);
        }        

        private void frmTimer_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);         
        }
        

        private void lblHide_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }

        private void lblStandTime_Click(object sender, EventArgs e)
        {
            cmnStandTime.Show(lblStandTime, 0, lblStandTime.Height);
        }

        
        private void txtOnlyDigits(object sender, KeyPressEventArgs e)
        {
            //ввод только цифр
            //MessageBox.Show(txtS.SelectionStart.ToString());
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }

            //режим замены
            TextBox txt = (TextBox)sender;
            int ss = txt.SelectionStart;
            if (ss<txt.Text.Length) txt.Text = txt.Text.Remove(ss, 1);
            txt.SelectionStart = ss;
            
            //старт таймера по Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                lblStart_Click(null, null);
            }
        }

        
        private void lblSPlus_Click(object sender, EventArgs e)
        {
            int curS = Convert.ToInt32(txtS.Text.Trim());            
            curS++;

            SetTime(curH, curM, curS, true);
        }

        private void lblMplus_Click(object sender, EventArgs e)
        {
            int curM = Convert.ToInt32(txtM.Text.Trim());
            curM++;

            SetTime(curH, curM, curS, true);
        }

        private void lblHPlus_Click(object sender, EventArgs e)
        {
            int curH = Convert.ToInt32(txtH.Text.Trim());
            if (curH < 99) curH++;

            SetTime(curH, curM, curS, true);
        }

        
        private void AllTextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (txt.Text.Trim() == "")
            {
                txt.Text = "00";
            }

            curS = Convert.ToInt32(txtS.Text);
            curM = Convert.ToInt32(txtM.Text);
            curH = Convert.ToInt32(txtH.Text);

            if (CommonFunctions.GetSecounds(curH,curM,curS) >= 359999)
            {
                curS = 59;
                curM = 59;
                curH = 99;

            }
            
            SetTime(curH, curM, curS, false);            
        }

        private void lblHMinus_Click(object sender, EventArgs e)
        {
            int curH = Convert.ToInt32(txtH.Text.Trim());
            if (curH > 0) curH--;

            SetTime(curH, curM, curS, true);
        }

        private void lblMMinus_Click(object sender, EventArgs e)
        {
            int curM = Convert.ToInt32(txtM.Text.Trim());
            if (curM > 0) curM--;

            SetTime(curH, curM, curS, true);
        }

        private void lblSMinus_Click(object sender, EventArgs e)
        {
            int curS = Convert.ToInt32(txtS.Text.Trim());
            if (curS > 0) curS--;

            SetTime(curH, curM, curS, true);
        }

        private void lblReset_Click(object sender, EventArgs e)
        {
            lblStop_Click(null, null);
            SetTime(0, 0, 0, true);
            cConfig.SetParameter("H", "0");
            cConfig.SetParameter("M", "0");
            cConfig.SetParameter("S", "0");
            cConfig.SaveConfig();

        }

        private void lblStart_Click(object sender, EventArgs e)
        {
            AllSec = CommonFunctions.GetSecounds(curH, curM, curS);
            if (AllSec == 0) return;

            txtH.Enabled = false; lblHMinus.Enabled = false; lblHPlus.Enabled = false;
            txtM.Enabled = false; lblMMinus.Enabled = false; lblMplus.Enabled = false;
            txtS.Enabled = false; lblSMinus.Enabled = false; lblSPlus.Enabled = false;
            lblStandTime.Enabled = false;

            lblPause.Enabled = true;

            oldH = curH; oldM = curM; oldS = curS;
            cConfig.SetParameter("H", oldH.ToString());
            cConfig.SetParameter("M", oldM.ToString());
            cConfig.SetParameter("S", oldS.ToString());
            cConfig.SaveConfig();

            tmrCountdown.Enabled = true;
            tmrCountdown.Interval = 50;
            tmrCountdown.Start();
        }

        int niicon = 0;
        private void tmrCountdown_Tick(object sender, EventArgs e)
        {
            if (curMS == 0)
            {
                curMS = 1000;
                AllSec--;
            }
            curMS = curMS - tmrCountdown.Interval;

            if (AllSec == 0)
            {
                TimeAlarm();
                lblStop_Click(null, null);
            }
            else
            {
                SetTime(0, 0, AllSec, false);
                
                if (niicon > 3) niicon = 0;
                CommonFunctions.globalNI.Icon = CommonFunctions.niIcons16[niicon];
                niicon++;
            }            
        }

        private void lblStop_Click(object sender, EventArgs e)
        {
            tmrCountdown.Stop();
            tmrCountdown.Enabled = false;
            lblPause.Enabled = false;

            txtH.Enabled = true; lblHMinus.Enabled = true ; lblHPlus.Enabled = true;
            txtM.Enabled = true; lblMMinus.Enabled = true; lblMplus.Enabled = true;
            txtS.Enabled = true; lblSMinus.Enabled = true; lblSPlus.Enabled = true;
            lblStandTime.Enabled = true;

            curH = oldH; curM = oldM; curS = oldS; curMS = 0;

            SetTime(curH, curM, curS,false);

            CommonFunctions.globalNI.Icon = CommonFunctions.niIcons16[0];

        }

        private void lblPause_Click(object sender, EventArgs e)
        {
            if (Pause)
            {
                tmrCountdown.Start();
            }
            else
            {
                tmrCountdown.Stop();
            }

            Pause = !Pause;
        }

        private void TimeAlarm()
        {
            if (Convert.ToBoolean(cConfig.GetParameter("Baloon", "false")))
            {
                CommonFunctions.globalNI.ShowBalloonTip(5000, "Сработал таймер",
                    cConfig.GetParameter("Message", ""), ToolTipIcon.None);
            }

            int soundtype = Convert.ToInt32(cConfig.GetParameter("SoundType", "0"));

            switch (soundtype)
            {
                case 0: //встроенный звук
                    {
                        SoundPlayer sp = new SoundPlayer(Properties.Resources.alarm);
                        sp.Load();
                        sp.Play();

                    }; break;
                case 1: //пользовательский файл
                    {

                        string soundfile = cConfig.GetParameter("SoundFile", "");

                        try
                        {
                            SoundPlayer sp = new SoundPlayer(soundfile);
                            sp.Load();
                            sp.Play();
                        }
                        catch (Exception ex)
                        {
                            CommonFunctions.ErrMessage (ex.Message);
                        }
                    }; break;
            }
        }

        private void lblSettings_Click(object sender, EventArgs e)
        {
            frmTimerSettings fTimerSettings = new frmTimerSettings();
            this.TopMost=false;
            fTimerSettings.ShowDialog();
            this.TopMost=Convert.ToBoolean(cConfig.GetParameter("TopMost", "false"));
        }
        
        
        

       
        
    }
}

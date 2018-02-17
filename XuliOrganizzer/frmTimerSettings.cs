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
    public partial class frmTimerSettings : Form
    {
        private string SoundFile = "";
        private int SoundType = 0;
        public frmTimerSettings()
        {
            InitializeComponent();
        }
        

        private void lblCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTimerSettings_Load(object sender, EventArgs e)
        {
            chkBaloon.Checked = Convert.ToBoolean(cConfig.GetParameter("Baloon", "false"));
            txtMessage.Text = cConfig.GetParameter("Message", "");
            chkTopMost.Checked = Convert.ToBoolean(cConfig.GetParameter("TopMost", "false"));

            switch (cConfig.GetParameter("SoundType", "false"))
            {
                case "0": rbSound0.Checked = true; break;
                case "1": rbSound1.Checked = true; break;
                case "2": rbSound2.Checked = true; break;
            }

            SoundFile = cConfig.GetParameter("SoundFile", "");
        }

        private void lblOK_Click(object sender, EventArgs e)
        {
            cConfig.SetParameter("Baloon", chkBaloon.Checked.ToString());
            cConfig.SetParameter("Message", txtMessage.Text);
            cConfig.SetParameter("TopMost", chkTopMost.Checked.ToString());
            cConfig.SetParameter("SoundType", SoundType.ToString());
            cConfig.SetParameter("SoundFile", SoundFile);

            if (!cConfig.SaveConfig())
            {
                MessageBox.Show(cConfig.ConfigErrMessage, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.Close();
        }

        private void SoundChecked(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            SoundType = Convert.ToInt32(rb.Name.Substring(rb.Name.Length - 1));
        }

        private void lblOpenSound_Click(object sender, EventArgs e)
        {
            dlgOpen.FileName = "";
            DialogResult Ans =  dlgOpen.ShowDialog();
            if (Ans == DialogResult.Cancel) return;
            SoundFile = dlgOpen.FileName;
        }

        private void lblPlaySound_Click(object sender, EventArgs e)
        {
            if (SoundFile == "") return;

            try
            {
                SoundPlayer sp = new SoundPlayer(SoundFile);
                sp.Load();
                sp.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}

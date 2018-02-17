using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XuliOrganizzer
{
    public partial class frmMainBeh : Form
    {
        public frmMainBeh()
        {
            InitializeComponent();
        }

        FormBehavior MainBehavior = FormBehavior.Hide;
        private void btnYes_Click(object sender, EventArgs e)
        {
            cConfig.SetParameter("Global.AskMainBehavior", (!chkStopQuestion.Checked).ToString());
            cConfig.SetParameter("Global.MainBehavior", ((int)MainBehavior).ToString());
            this.DialogResult = DialogResult.Yes;
            this.Close();            
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void frmMainBeh_Load(object sender, EventArgs e)
        {
            MainBehavior=(FormBehavior)Convert.ToInt32(cConfig.GetParameter("Global.MainBehavior", "0"));

            if (MainBehavior == FormBehavior.Hide) rbMainBeh0.Checked = true;
            else rbMainBeh1.Checked = true;
        }

        private void rbMainBeh_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int tmp = Convert.ToInt32(rb.Name.Substring(rb.Name.Length - 1));
            MainBehavior = (FormBehavior)tmp;
        }
        
        
    }
}

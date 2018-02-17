using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XuliOrganizzer
{
    public partial class frmExit : Form
    {
        public frmExit()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            cConfig.SetParameter("Global.AskExit",(!chkStopQuestion.Checked).ToString());
            this.DialogResult = DialogResult.Yes;
            this.Close();            
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void frmExit_Load(object sender, EventArgs e)
        {

        }

        
    }
}

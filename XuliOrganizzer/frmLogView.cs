using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XuliOrganizzer
{
    public partial class frmLogView : Form
    {
        public string log = "";
        public bool bClear = false;
        public bool NoClear = false;
        public frmLogView()
        {
            InitializeComponent();
        }

        private void frmLogView_Load(object sender, EventArgs e)
        {
            txtLog.Text = log;
            if (NoClear) btnClear.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult Ask = MessageBox.Show("Очистить протокол?","Очистка протокола",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (Ask == DialogResult.No) return;
            
            bClear = true;
            this.Close();
        }
    }
}

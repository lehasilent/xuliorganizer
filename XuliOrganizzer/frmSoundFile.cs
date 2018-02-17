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
    public partial class frmSoundFile : Form
    {
        public frmSoundFile()
        {
            InitializeComponent();
        }

        public string FileName = "";
        public bool bSuccess = false;

        private void frmSoundFile_Load(object sender, EventArgs e)
        {
            txtFileName.Text = FileName;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dlgOpen.FileName = "";
            DialogResult Ans = dlgOpen.ShowDialog();
            if (Ans == DialogResult.Cancel) return;
            FileName = dlgOpen.FileName;
            txtFileName.Text = FileName;
        }

        private void btnPlaySound_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer sp = new SoundPlayer(FileName);
                sp.Load();
                sp.Play();
            }
            catch (Exception ex)
            {
                CommonFunctions.ErrMessage(ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (FileName == "")
            {
                CommonFunctions.ErrMessage("Не выбран файл!");
                return;
            }
            bSuccess = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bSuccess = false;
            this.Close();
        }
    }
}

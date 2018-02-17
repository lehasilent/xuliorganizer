using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XuliOrganizzer
{
    public partial class frmAdd : Form
    {
        public frmAdd()
        {
            InitializeComponent();
        }

        public bool bSuccess = false;
        public bool bEdit = false;
        public string stCaption = "";
        public string stNote = "";

        private bool InsNote = false;
        private bool InsCaption = false;

        private void frmAdd_Load(object sender, EventArgs e)
        {
            lblInsert.Text = "";

            if (bEdit)
            {
                txtCaption.Text = stCaption;
                txtNote.Text = stNote;
            }
        }

        private void InsShow(bool InsMode)
        {
            if (InsMode)
            {
                lblInsert.Text = "ЗАМ";
            }
            else
            {
                lblInsert.Text = "";
            }
        }

        private void txtNote_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Insert)
            {
                InsNote = !InsNote;
                InsShow(InsNote);
            }
        }

        private void txtCaption_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Insert)
            {
                InsCaption = !InsCaption;
                InsShow(InsCaption);
            }
        }

        private void txtNote_Enter(object sender, EventArgs e)
        {
            InsShow(InsNote);
        }

        private void txtCaption_Enter(object sender, EventArgs e)
        {
            InsShow(InsCaption);
        }
        

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((txtNote.Text == "") && (txtCaption.Text == ""))
            {
                DialogResult Ans = MessageBox.Show("Сохранить пустую запись?", "Вопрос",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Ans == DialogResult.No) return;
            }

            stCaption = txtCaption.Text;
            stNote = txtNote.Text;
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace XuliOrganizzer
{
    public partial class frmAllNotes : Form
    {        
        public frmAllNotes()
        {
            InitializeComponent();
        }

        bool RestoreWindow = false;
        bool TrashView = false;
        bool FindMode = false;
        DataRow[] FindRows = null;
        int CurFind = 0;
        string CurTable = "Notes";

        private DataRow CurRec(string TableName)
        {
            if (grdMain.CurrentRow == null) return null;
            int RecID = (int)grdMain.CurrentRow.Cells[0].Value;
            
            return cConfig.dsConfig.Tables[TableName].Rows.Find(RecID);
        }
        
        private DataRow CurRec(string TableName, int idx)
        {
            if (cConfig.dsConfig.Tables[TableName].Rows.Count == 0) return null;            

            return cConfig.dsConfig.Tables[TableName].Rows[idx];
        }

        private void frmAllNotes_Load(object sender, EventArgs e)
        {
            mnuTrash.Visible = false;

            mnuFieldNameDSBL.Visible = false;
            mnuFindDown.Visible = false;
            mnuFindDSBL.Visible = false;
            mnuFindUp.Visible = false;
            mtxtFind.Visible = false;

            bool Maximized = false;
            try
            {
                Maximized = Convert.ToBoolean(cConfig.GetParameter("AllNotes.Maximized", "false"));
            }
            catch { Maximized = false; }
            
            if (Maximized) { this.WindowState = FormWindowState.Maximized; return; }
            else { this.WindowState = FormWindowState.Normal; }
            
            string tTop = cConfig.GetParameter("AllNotes.Top", string.Empty);
            string tLeft = cConfig.GetParameter("AllNotes.Left", string.Empty);

            try
            {
                this.Width = Convert.ToInt32(cConfig.GetParameter("AllNotes.Width", "601"));
                this.Height = Convert.ToInt32(cConfig.GetParameter("AllNotes.Height", "373"));
            }
            catch
            {
                this.Width = 601;
                this.Height = 373;
            }

            if (tTop !=string.Empty && tLeft != string.Empty)
            {
                try
                {
                    this.Top = Convert.ToInt32(tTop);
                    this.Left = Convert.ToInt32(tLeft);
                }
                catch
                {
                    this.Top = 0; this.Left = 0;
                }
                
            }            
        }

        private void frmAllNotes_Shown(object sender, EventArgs e)
        {
            grdMain.DataSource = cConfig.dsConfig.Tables["Notes"].DefaultView;
            grdMain.Columns[0].Visible = false;
            grdMain.Columns[1].HeaderCell.Value = "Заголовок";
            grdMain.Columns[2].HeaderCell.Value = "Текст";
            grdMain.CurrentCell = grdMain.FirstDisplayedCell;
            grdMain_SelectionChanged(null, null);
        }

        private void frmAllNotes_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (RestoreWindow) return;
            
            if (this.WindowState == FormWindowState.Minimized) return;
            
            bool Maximized = false;            
            
            if (this.WindowState == FormWindowState.Maximized)
            {
                Maximized = true;
                cConfig.SetParameter("AllNotes.Maximized", Maximized.ToString());
                cConfig.SetParameter("AllNotes.Top", string.Empty);
                cConfig.SetParameter("AllNotes.Left", string.Empty);
                cConfig.SetParameter("AllNotes.Width", "601");
                cConfig.SetParameter("AllNotes.Height", "373");
            }
            else
            {
                cConfig.SetParameter("AllNotes.Maximized", Maximized.ToString());
                cConfig.SetParameter("AllNotes.Top", this.Top.ToString());
                cConfig.SetParameter("AllNotes.Left", this.Left.ToString());
                cConfig.SetParameter("AllNotes.Width", this.Width.ToString());
                cConfig.SetParameter("AllNotes.Height", this.Height.ToString());

            }
            
            cConfig.SaveConfig();
        }

        private void mnuToolsExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void mnuToolsRestoreWindow_Click(object sender, EventArgs e)
        {
            RestoreWindow = true;
            cConfig.SetParameter("AllNotes.Maximized", "false");
            cConfig.SetParameter("AllNotes.Top", string.Empty);
            cConfig.SetParameter("AllNotes.Left", string.Empty);
            cConfig.SetParameter("AllNotes.Width", "601");
            cConfig.SetParameter("AllNotes.Height", "373");

            if (!cConfig.SaveConfig())
            {
                CommonFunctions.ErrMessage(cConfig.ConfigErrMessage);
            }
            else
            {
                MessageBox.Show("Параметры окна по умолчанию восстановлены \r\n" +
                    "Откройте окно вновь.", "Готово", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                
                this.Close();
            }
            
        }

        private void mnuToolsOneNote_Click(object sender, EventArgs e)
        {
            frmNote fNote = new frmNote();
            fNote.Show();
            this.Close();
        }

        private void mnuToolsSaveAll_Click(object sender, EventArgs e)
        {

            dlgSaveFile.FileName = "";
            DialogResult Ans = dlgSaveFile.ShowDialog();
            if (Ans == DialogResult.Cancel) return;

            if (cConfig.dsConfig.Tables["Notes"].Rows.Count == 0) return;

            string buf = "";
            foreach (DataRow dr in cConfig.dsConfig.Tables["Notes"].Rows)
            {
                buf = buf + dr["Caption"] + "\r\n\r\n" + 
                    CommonFunctions.AtCRLF((string)dr["Text"]) +
                    "\r\n--------------------\r\n";
            }

            try
            {
                File.WriteAllText(dlgSaveFile.FileName, buf, Encoding.GetEncoding(1251));
            }
            catch (Exception ex)
            {
                CommonFunctions.ErrMessage(ex.Message);
            }
        }

        private void mnuToolsSave_Click(object sender, EventArgs e)
        {
            DataRow dr = CurRec("Notes");
            if (dr == null) return;

            dlgSaveFile.FileName = "";
            DialogResult Ans = dlgSaveFile.ShowDialog();
            if (Ans == DialogResult.Cancel) return;

            string buf = dr["Caption"] + "\r\n\r\n" + 
                CommonFunctions.AtCRLF((string)dr["Text"]);

            try
            {
                File.WriteAllText(dlgSaveFile.FileName, buf, Encoding.GetEncoding(1251));
            }
            catch (Exception ex)
            {
                CommonFunctions.ErrMessage(ex.Message);
            }
        }

        private void mnuToolsTrash_Click(object sender, EventArgs e)
        {
            mnuEdit.Visible = false;
            mnuTools.Visible = false;
            mnuTrash.Visible = true;
            TrashView = true;
            CurTable = "TrashNotes";

            grdMain.DataSource = cConfig.dsConfig.Tables["TrashNotes"].DefaultView;
            grdMain.Columns[0].Visible = false;
            grdMain.Columns[1].HeaderCell.Value = "Заголовок";
            grdMain.Columns[2].HeaderCell.Value = "Текст";                    
        }

        private void mnuEditCopy_Click(object sender, EventArgs e)
        {
            if (grdMain.CurrentCell == null) return;

            Clipboard.SetText(grdMain.CurrentCell.Value.ToString());
        }

        private void mnuEditAdd_Click(object sender, EventArgs e)
        {
            frmAdd fAdd = new frmAdd();
            fAdd.ShowDialog();

            if (fAdd.bSuccess)
            {
                cConfig.dsConfig.Tables["Notes"].Rows.Add(null,
                    fAdd.stCaption, fAdd.stNote);
            }

            if (!cConfig.SaveConfig())
            {
                CommonFunctions.ErrMessage(cConfig.ConfigErrMessage);
            }

            FindRows = null;
        }

        private void mnuEditEdit_Click(object sender, EventArgs e)
        {
            DataRow dr = CurRec("Notes");
            if (dr == null) return;

            frmAdd fAdd = new frmAdd();
            fAdd.stNote = dr["Text"].ToString();
            fAdd.stCaption = dr["Caption"].ToString();
            fAdd.bEdit = true;
            fAdd.ShowDialog();

            if (fAdd.bSuccess)
            {
                dr["Text"] = fAdd.stNote;
                dr["Caption"] = fAdd.stCaption;
            }

            if (!cConfig.SaveConfig())
            {
                CommonFunctions.ErrMessage(cConfig.ConfigErrMessage);
            }

            FindRows = null;
        }

        private void mnuEditDelete_Click(object sender, EventArgs e)
        {
            //поиск
            DataRow dr = CurRec("Notes");
            if (dr == null) return;

            DialogResult Ans = MessageBox.Show("Удалить запись " + dr["Caption"].ToString() + "?",
                "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Ans == DialogResult.No) return;

            //копирование в корзину
            cConfig.dsConfig.Tables["TrashNotes"].Rows.Add(null,
                dr["Caption"].ToString(), dr["Text"].ToString());

            //удаление
            cConfig.dsConfig.Tables["Notes"].Rows.Remove(dr);

            if (!cConfig.SaveConfig())
            {
                CommonFunctions.ErrMessage(cConfig.ConfigErrMessage);
            }

            FindRows = null;

        }

        private void mnuEditDeleteAll_Click(object sender, EventArgs e)
        {

            if (cConfig.dsConfig.Tables["Notes"].Rows.Count == 0) return;

            DialogResult Ans = MessageBox.Show("Действительно удалить все записи?",
                "Массовое удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (Ans == DialogResult.No) return;

            while (cConfig.dsConfig.Tables["Notes"].Rows.Count>0)
            {
                DataRow dr = CurRec("Notes", 0);
                
                //копирование в корзину
                cConfig.dsConfig.Tables["TrashNotes"].Rows.Add(null,
                    dr["Caption"].ToString(), dr["Text"].ToString());

                //удаление
                cConfig.dsConfig.Tables["Notes"].Rows.Remove(dr);
            }

            if (!cConfig.SaveConfig())
            {
                CommonFunctions.ErrMessage(cConfig.ConfigErrMessage);
            }
            FindRows = null;
        }

        private void mnuTrashNormalRecords_Click(object sender, EventArgs e)
        {
            mnuEdit.Visible = true;
            mnuTools.Visible = true;
            mnuTrash.Visible = false;
            TrashView = false;
            CurTable = "Notes";

            grdMain.DataSource = cConfig.dsConfig.Tables["Notes"].DefaultView;
            grdMain.Columns[0].Visible = false;
            grdMain.Columns[1].HeaderCell.Value = "Заголовок";
            grdMain.Columns[2].HeaderCell.Value = "Текст";
        }

        private void mnuTrashRestore_Click(object sender, EventArgs e)
        {            
            //выбор записи в корзине
            DataRow dr = CurRec("TrashNotes");
            if (dr == null) return;

            //восстановление
            cConfig.dsConfig.Tables["Notes"].Rows.Add(null,
                dr["Caption"].ToString(), dr["Text"].ToString());

            //удаление из корзины
            cConfig.dsConfig.Tables["TrashNotes"].Rows.Remove(dr);

            if (!cConfig.SaveConfig())
            {
                CommonFunctions.ErrMessage(cConfig.ConfigErrMessage);
            }
        }

        private void mnuTrashRestoreAll_Click(object sender, EventArgs e)
        {
            if (cConfig.dsConfig.Tables["TrashNotes"].Rows.Count == 0) return;

            DialogResult Ans = MessageBox.Show("Восстановить все записи?",
                "Массовое восстановление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Ans == DialogResult.No) return;

            while (cConfig.dsConfig.Tables["TrashNotes"].Rows.Count > 0)
            {
                DataRow dr = CurRec("TrashNotes", 0);

                //восстановление
                cConfig.dsConfig.Tables["Notes"].Rows.Add(null,
                    dr["Caption"].ToString(), dr["Text"].ToString());

                //удаление из корзины
                cConfig.dsConfig.Tables["TrashNotes"].Rows.Remove(dr);
            }

            if (!cConfig.SaveConfig())
            {
                CommonFunctions.ErrMessage(cConfig.ConfigErrMessage);
            }


        }

        private void mnuTrashDelete_Click(object sender, EventArgs e)
        {
            //выбор записи в корзине
            DataRow dr = CurRec("TrashNotes");
            if (dr == null) return;
            
            DialogResult Ans = MessageBox.Show("Окончательно удалить запись "+
                dr["Caption"].ToString()+"?\r\nОтменить будет невозможно!",
                "Окончательное удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (Ans == DialogResult.No) return;
            
            //удаление из корзины
            cConfig.dsConfig.Tables["TrashNotes"].Rows.Remove(dr);

            if (!cConfig.SaveConfig())
            {
                CommonFunctions.ErrMessage(cConfig.ConfigErrMessage);
            }
        }

        private void mnuTrashClean_Click(object sender, EventArgs e)
        {
            if (cConfig.dsConfig.Tables["TrashNotes"].Rows.Count == 0) return;

            DialogResult Ans = MessageBox.Show("Очистить корзину?\r\n ОТМЕНИТЬ БУДЕТ НЕВОЗМОЖНО!",
                "ОЧИСТКА КОРЗИНЫ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (Ans == DialogResult.No) return;

            while (cConfig.dsConfig.Tables["TrashNotes"].Rows.Count > 0)
            {
                DataRow dr = CurRec("TrashNotes", 0);
                
                //удаление из корзины
                cConfig.dsConfig.Tables["TrashNotes"].Rows.Remove(dr);
            }

            if (!cConfig.SaveConfig())
            {
                CommonFunctions.ErrMessage(cConfig.ConfigErrMessage);
            }
        }

        private void grdMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TrashView)
            {
                mnuTrashRestore_Click(null, null);
            }
            else
            {
                mnuEditEdit_Click(null, null);
            }
        }

        private void grdMain_SelectionChanged(object sender, EventArgs e)
        {
            if (grdMain.CurrentCell == null) return;

            mnuFieldNameDSBL.Text =
                CommonFunctions.AddToSize(
                    "[" + grdMain.Columns[grdMain.CurrentCell.ColumnIndex].HeaderText + "]",
                    ' ', 11, true);
                        
        }

        private void mtxtFind_TextChanged(object sender, EventArgs e)
        {
            if (grdMain.Rows.Count < 1) return;

            int curcell = grdMain.CurrentCell.OwningColumn.Index;

            if (mtxtFind.TextBox.Text == "")
            {
                grdMain.CurrentCell = grdMain.Rows[0].Cells[curcell];
                return;
            }

            string fnd = CommonFunctions.EscapeLikeValue(mtxtFind.TextBox.Text);
            string col = cConfig.dsConfig.Tables[CurTable].
                Columns[grdMain.CurrentCell.ColumnIndex].ColumnName;
            string sort = cConfig.dsConfig.Tables[CurTable].DefaultView.Sort;
            if (sort == "") sort = "ID DESC";
            
            FindRows = cConfig.dsConfig.Tables[CurTable].Select(col + " LIKE '%" + fnd + "%'",sort);

            if (FindRows.Length == 0) return; //nothing found

            CurFind = 0;
            int currow = -1;
            foreach (DataGridViewRow dgvr in grdMain.Rows)
            {
                currow++;
                if (dgvr.Cells[0].Value.ToString() == FindRows[CurFind]["ID"].ToString())
                {
                    grdMain.CurrentCell = grdMain.Rows[currow].Cells[curcell];
                }
            }

        }

        private void mtxtFind_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                grdMain.Select();
            }
        }

        private void mnuEditFind_Click(object sender, EventArgs e)
        {
            FindMode = !FindMode;

            if (FindMode)
            {
                mnuFieldNameDSBL.Visible = true;
                mnuFindDown.Visible = true;
                mnuFindDSBL.Visible = true;
                mnuFindUp.Visible = true;
                mtxtFind.Visible = true;
                mnuEditFind.Text = "Скр&ыть поиск";
            }
            else
            {
                mnuFieldNameDSBL.Visible = false;
                mnuFindDown.Visible = false;
                mnuFindDSBL.Visible = false;
                mnuFindUp.Visible = false;
                mtxtFind.Visible = false;
                mnuEditFind.Text = "&Найти...";
            }
        }

        private void mnuFindDown_Click(object sender, EventArgs e)
        {
            if (FindRows == null) return;
            if (FindRows.Length == 0) return;
            int curcell = grdMain.CurrentCell.OwningColumn.Index;
            int currow = -1;
            CurFind++;
            if (CurFind >= FindRows.Length) CurFind = 0;

            foreach (DataGridViewRow dgvr in grdMain.Rows)
            {
                currow++;
                if (dgvr.Cells[0].Value.ToString() == FindRows[CurFind]["ID"].ToString())
                {
                    grdMain.CurrentCell = grdMain.Rows[currow].Cells[curcell];
                }
            }


        }

        private void mnuFindUp_Click(object sender, EventArgs e)
        {
            if (FindRows == null) return;
            if (FindRows.Length == 0) return;
            int curcell = grdMain.CurrentCell.OwningColumn.Index;
            int currow = -1;
            CurFind--;
            if (CurFind < 0) CurFind = FindRows.Length - 1;

            foreach (DataGridViewRow dgvr in grdMain.Rows)
            {
                currow++;
                if (dgvr.Cells[0].Value.ToString() == FindRows[CurFind]["ID"].ToString())
                {
                    grdMain.CurrentCell = grdMain.Rows[currow].Cells[curcell];
                }
            }

        }        
    }
}

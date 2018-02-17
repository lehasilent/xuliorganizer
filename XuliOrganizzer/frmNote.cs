using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace XuliOrganizzer
{
    public partial class frmNote : Form
    {
        public frmNote()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }


        bool InsertModeNote = false;
        bool InsertModeCaption = false;
        //Счетчики и переменные для записей Notes
        private int CurRow = 0;
        private int RowsCount = 0;
        
        private bool isEdit = false;
        private int recID = 0;
        //....

        private const int cGrip = 16;      // Grip size
        private const int cCaption = 24;   // Caption bar height;
        private Color caplColor = Color.DarkBlue;

        //копирование текста из RichTextBox
        //с возможностью скопировать весь текст
        //если ничего не выделено
        private void TextCopy(RichTextBox rtb)
        {
            Clipboard.Clear();
            if (rtb.SelectionLength == 0) //ничего не выделено, копируем все
            {
                Clipboard.SetText(CommonFunctions.AtCRLF(rtb.Text));
            }
            else //копируем выделенное
            {
                Clipboard.SetText(CommonFunctions.AtCRLF(rtb.SelectedText));
            }

        }
        //вставка текста в RichTextBox со сбросом оформления
        private void TextPaste(RichTextBox rtb)
        {
            string NormalText = Clipboard.GetText();
            rtb.SelectedText = NormalText;
        }
        private void SetButtonsPic()
        {
            //поверх всех окон
            if (this.TopMost)
                lblOnTop.Image = Properties.Resources.knopka2_24x24;
            else
                lblOnTop.Image = Properties.Resources.knopka24x24;

            //перенос по словам
            if (txtNote.WordWrap)
                lblWordwarp.Image = Properties.Resources.wordwarp_on24x24;
            else
                lblWordwarp.Image = Properties.Resources.wordwarp_off24x24;

            //скрыть/показать панель
            if (pnlCenterButtons.Visible)
                lblShowpanel.Image = Properties.Resources.showpanel24x24;
            else
                lblShowpanel.Image = Properties.Resources.showpanel_off24x24;        
        }

        //дополнительные функции для работы с данными
        private void CountersUpdate()
        {
            int i = CurRow + 1;
            RowsCount = cConfig.dsConfig.Tables["Notes"].Rows.Count;
            lblRecInfo.Text = i.ToString() + "/" + RowsCount.ToString();
        }

        private void NewRec(bool End)
        {
            
            if (End) CurRow = RowsCount;
            else CurRow = -1;
            
            isEdit = false;
            txtCaption.Text = "";
            txtNote.Text = "";

            CountersUpdate();
            
        }

        private void ShowCurRec()
        {
            if (CurRow < 0) return;

            recID = (int)cConfig.dsConfig.Tables["Notes"].
                Rows[CurRow]["ID"];
            txtCaption.Text = cConfig.dsConfig.Tables["Notes"].
                Rows[CurRow]["Caption"].ToString();
            txtNote.Text = cConfig.dsConfig.Tables["Notes"].
                Rows[CurRow]["Text"].ToString();

            isEdit = true;
        }


        
        //............................................

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void frmNote_Load(object sender, EventArgs e)
        {
            

            ttControls.SetToolTip(lblClose, "Закрыть [ALT+F4]");
            ttControls.SetToolTip(lblDelete, "Удалить [CTRL+D]");
            ttControls.SetToolTip(lblFont, "Шрифт и цвет текста [ALT+F]");
            ttControls.SetToolTip(lblFormReset, "Восстановить значения по умолчанию");
            ttControls.SetToolTip(lblNew, "Новая заметка [CTRL+N]");
            ttControls.SetToolTip(lblNext, "Следующая заметка [CTRL+Стрелка вправо]");
            ttControls.SetToolTip(lblOnTop, "Поверх всех окон");
            ttControls.SetToolTip(lblPrev, "Предыдущая заметка [CTRL+Стрелка влево]");
            ttControls.SetToolTip(lblRecInfo, "Текущая запись/Количество записей");
            ttControls.SetToolTip(lblSave, "Сохранить [CTRL+S]");
            ttControls.SetToolTip(lblShowall, "Показать все записи [ALT+A]");
            ttControls.SetToolTip(lblShowpanel, "Показать/скрыть элементы управления");
            ttControls.SetToolTip(lblWordwarp, "Перенос по словам");

            this.Top = Convert.ToInt32(cConfig.GetParameter("Note.Top","0"));
            this.Left = Convert.ToInt32(cConfig.GetParameter("Note.Left", "0"));
            this.Width = Convert.ToInt32(cConfig.GetParameter("Note.Width", "292"));
            this.Height = Convert.ToInt32(cConfig.GetParameter("Note.Height", "237"));
            
            txtNote.Font = cConfig.GetFont("Note.Font");
            txtCaption.Font = cConfig.GetFont("Note.Font");

            txtNote.ForeColor = Color.FromArgb(Convert.ToInt32(cConfig.GetParameter("Note.TextColor","0")));
            txtCaption.ForeColor = Color.FromArgb(Convert.ToInt32(cConfig.GetParameter("Note.TextColor", "0")));

            txtNote.WordWrap = Convert.ToBoolean(cConfig.GetParameter("Note.WordWrap", "true"));
            pnlCenterButtons.Visible = Convert.ToBoolean(cConfig.GetParameter("Note.ShowPanel", "true"));

            SetButtonsPic();

            //загружаем последнюю отредактированную запись 
            CountersUpdate();
            if (RowsCount == 0) //ничего нет
            {
                NewRec(true);
            }
            else
            {
                string lri = cConfig.GetParameter("Note.LastRecID");
                if (lri == null) //ошибка получения параметра
                {
                    NewRec(true);
                }
                else
                {
                    DataRow dr = cConfig.dsConfig.Tables["Notes"].Rows.
                        Find(Convert.ToInt32(lri));
                    if (dr == null) //нет записи с таким ID
                    {
                        NewRec(true);
                    }
                    else //нашли
                    {
                        recID = Convert.ToInt32(lri);
                        CurRow = cConfig.dsConfig.Tables["Notes"].Rows.IndexOf(dr);
                        ShowCurRec(); //загружаем
                        CountersUpdate();
                    }
                }
            }
        }

        private void frmNote_Resize(object sender, EventArgs e)
        {
            int MinWidth = 0; //расчитывается ниже
            int MinHeight = 113;
            
            //кнопки в заголовке окна
            lblClose.Location = new Point(this.Width-lblClose.Width, 0);
            lblClose.BackColor = caplColor;
            lblOnTop.Location = new Point(lblClose.Location.X - lblClose.Width, 0);
            lblOnTop.BackColor = caplColor;
            lblFormReset.Location = new Point(lblOnTop.Location.X - lblOnTop.Width, 0);
            lblFormReset.BackColor = caplColor;
            lblShowpanel.Location = new Point(lblFormReset.Location.X - lblFormReset.Width, 0);
            lblShowpanel.BackColor = caplColor;


            //Кнопки управления 
            tpnlControl.Location = new Point(0, cCaption + 1);
            tpnlControl.Width = this.Width;
            tpnlControl.Height = 32;
            //tpnlControl.Visible = false;

            //панель с полем заголовка записи
            pnlCaption.Location = new Point(0, cCaption + tpnlControl.Height + 1);
            pnlCaption.Width = this.Width;
            pnlCaption.Height = 20;
            
            //панель с полем записи
            pnlNote.Location = new Point(0, cCaption +
                pnlCaption.Height + tpnlControl.Height);
            pnlNote.Width = this.Width;
            pnlNote.Height = this.Height - (cCaption + 
                pnlCaption.Height+tpnlControl.Height) - cGrip;

            //label-индикатор INSERT
            lblInsertIndicator.Location = new Point(0,
                cCaption + pnlCaption.Height + tpnlControl.Height+pnlNote.Height+1);
            
            //label со счетчиком записи
            lblRecInfo.Location = new Point(5, 0);
            lblRecInfo.BackColor = caplColor;

            //Ограничение resize по ширине
            MinWidth = lblRecInfo.Width + 24 * 4 + 25;
            if (this.Width<MinWidth) this.Width=MinWidth;
            //по высоте            
            if (this.Height < MinHeight) this.Height = MinHeight;            
        }
        
        private void frmNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            //сохраняем все что было не сохранено из заметок
            lblSave_Click(null, null); 
            
            //сохраняем в конфиг ID последней записи (добавленной или редактируемой)
            cConfig.SetParameter("Note.LastRecID", recID.ToString());
            
            //все остальные опции
            cConfig.SetParameter("Note.Top", this.Top.ToString());
            cConfig.SetParameter("Note.Left", this.Left.ToString());
            cConfig.SetParameter("Note.Width", this.Width.ToString());
            cConfig.SetParameter("Note.Height", this.Height.ToString());
            
            cConfig.SetFont("Note.Font", txtNote.Font);
            cConfig.SetParameter("Note.TextColor", txtNote.ForeColor.ToArgb().ToString());            
            
            cConfig.SaveConfig();
            
                        
        }
 
        private void lblOnTop_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;            
            cConfig.SetParameter("Note.TopMost", this.TopMost.ToString());
            SetButtonsPic();
            cConfig.SaveConfig();
        }

        private void lblFormReset_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.Top = 0;
            this.Left = 0;
            this.Width = 292;
            this.Height = 237;

            txtCaption.ForeColor = Color.FromArgb(0);
            txtNote.ForeColor = Color.FromArgb(0);
            txtCaption.Font = cConfig.RestoreDefaultFont();
            txtNote.Font = cConfig.RestoreDefaultFont();
            txtNote.WordWrap = true;
            pnlCenterButtons.Visible = true;

            cConfig.SetParameter("Note.TopMost", this.TopMost.ToString());
            cConfig.SetParameter("Note.Top", this.Top.ToString());
            cConfig.SetParameter("Note.Left", this.Left.ToString());
            cConfig.SetParameter("Note.Width", this.Width.ToString());
            cConfig.SetParameter("Note.Height", this.Height.ToString());
            cConfig.SetParameter("Note.TextColor", txtNote.ForeColor.ToArgb().ToString());
            cConfig.SetFont("Note.Font", txtNote.Font);
            cConfig.SetParameter("Note.WordWrap", txtNote.WordWrap.ToString());
            cConfig.SetParameter("Note.ShowPanel", pnlCenterButtons.Visible.ToString());
            
            cConfig.SaveConfig();
            SetButtonsPic();            
        }

        private void lblFont_Click(object sender, EventArgs e)
        {
            dlgFont.Font = txtNote.Font;
            dlgFont.Color = txtNote.ForeColor;

            DialogResult Ans = dlgFont.ShowDialog();
            if (Ans == DialogResult.Cancel) return;

            txtCaption.Font = dlgFont.Font;
            txtCaption.ForeColor = dlgFont.Color;
            txtNote.Font = dlgFont.Font;
            txtNote.ForeColor = dlgFont.Color;                        
        }
        
        private void lblWordwarp_Click(object sender, EventArgs e)
        {
            txtNote.WordWrap = !txtNote.WordWrap;
            cConfig.SetParameter("Note.WordWrap", txtNote.WordWrap.ToString());
            SetButtonsPic();
            cConfig.SaveConfig();
        }

        
        
        private void lblNew_Click(object sender, EventArgs e)
        {
            lblSave_Click(null, null);
            NewRec(true);
        }

        private void lblSave_Click(object sender, EventArgs e)
        {            
            if (isEdit) //редактирование существующей записи
            {
                if ((txtCaption.Text == "") && (txtNote.Text == ""))
                {
                    DialogResult Ask = MessageBox.Show("Сохранить пустую запись?",
                        "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Ask == DialogResult.No) return;
                }
                DataRow dr = cConfig.dsConfig.Tables["Notes"].Rows.Find(recID);
                int idx = cConfig.dsConfig.Tables["Notes"].Rows.IndexOf(dr);

                try
                {
                    cConfig.dsConfig.Tables["Notes"].Rows[idx]["Caption"] = txtCaption.Text;
                    cConfig.dsConfig.Tables["Notes"].Rows[idx]["Text"] = txtNote.Text;
                }
                catch (Exception ex)
                {
                    CommonFunctions.ErrMessage(ex.Message);
                    return;
                }
            }
            else //новая запись
            {
                if ((txtCaption.Text == "") && (txtNote.Text == "")) return;

                try
                {
                    //создаем новую запись
                    DataRow dr = cConfig.dsConfig.Tables["Notes"].NewRow();
                    dr["Caption"] = txtCaption.Text;
                    dr["Text"] = txtNote.Text;                        
                    
                    if (CurRow < 0)
                    {
                        //вставляем новую запись вперед
                        cConfig.dsConfig.Tables["Notes"].Rows.InsertAt(dr,0);
                    }
                    else
                    {
                        //добавляем в конец
                        cConfig.dsConfig.Tables["Notes"].Rows.Add(dr);
                    }

                    //ее индекс и ID будет текущим
                    CurRow = cConfig.dsConfig.Tables["Notes"].Rows.IndexOf(dr);
                    recID = (int)dr["ID"];
                }
                catch (Exception ex)
                {
                    CommonFunctions.ErrMessage(ex.Message);
                    return;
                }

                if (!cConfig.SaveConfig())
                {
                    CommonFunctions.ErrMessage(cConfig.ConfigErrMessage);
                    return;
                }
            }
            
            isEdit = true;            
            CountersUpdate();
        }
        
        private void lblNext_Click(object sender, EventArgs e)
        {            
            lblSave_Click(null, null); //сохраняем старую запись
            
            CurRow++;

            //Если новая запись была сохранена - отобразится 
            //добавление еще одной новой, если нет - первая
            if (CurRow > RowsCount) CurRow = 0;  

            if (CurRow == RowsCount)
            {
                NewRec(true);
            }
            else
            {
                ShowCurRec();            
            }
                                                
            CountersUpdate();
        }        

        private void lblPrev_Click(object sender, EventArgs e)
        {
            if (RowsCount == 0) return; //иначе создастся коллизия и посыплется счетчик
            int OldCount = RowsCount;
            lblSave_Click(null, null);//сохраняем старую запись

            CurRow--;

            if (CurRow == -1)
            {
                NewRec(false);
            }
            else
            {
                
                //if (CurRow == -2) CurRow = RowsCount-1;

                if (CurRow == -2)
                {
                    if (RowsCount > OldCount) //добавили новую запись и нажали lblPrev
                    {
                        //чтоб снова отобразилось добавление новой записи                        
                        CurRow = - 1;
                        NewRec(false);
                        return;
                    }
                    else CurRow  =  RowsCount - 1;                    
                }

                ShowCurRec();
            }
            
            CountersUpdate();
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)sender;

            tb.BackColor = Color.FromArgb(255, 255, 255, 128);

            switch (tb.Name)
            {
                case "txtNote":
                    {                        
                        InsertModeShow(InsertModeNote);
                    }; break;
                case "txtCaption":
                    {                        
                        InsertModeShow(InsertModeCaption);
                    }; break;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)sender;

            tb.BackColor = Color.FromArgb(255, 255, 255, 192);

            switch (tb.Name)
            {
                case "txtNote":
                    {
                        InsertModeShow(InsertModeNote);
                    }; break;
                case "txtCaption":
                    {
                        InsertModeShow(InsertModeCaption);
                    }; break;
            }
        }
        
        private void lblShowpanel_Click(object sender, EventArgs e)
        {
            pnlCenterButtons.Visible  = !pnlCenterButtons.Visible;
            cConfig.SetParameter("Note.ShowPanel", pnlCenterButtons.Visible.ToString());
            SetButtonsPic();
            cConfig.SaveConfig();
        }

        private void lblDelete_Click(object sender, EventArgs e)
        {
            DialogResult Ans = MessageBox.Show("Удалить запись?", "Удаление",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Ans == DialogResult.No) return;

            if ((CurRow > -1)&&(CurRow<RowsCount)) //запись сохраненная
            {
                //удаление
                try
                {
                    //поиск записи
                    DataRow dr = cConfig.dsConfig.Tables["Notes"].Rows.Find(recID);
                    //копирование заметки в "корзину"
                    cConfig.dsConfig.Tables["TrashNotes"].Rows.Add(
                        null, dr["Caption"], dr["Text"]);                    
                    //удаление
                    cConfig.dsConfig.Tables["Notes"].Rows.Remove(dr);
                }
                catch (Exception ex)
                {
                    CommonFunctions.ErrMessage(ex.Message);
                    return;
                }
                
                //сохраняем файл
                if (!cConfig.SaveConfig()) 
                {
                    CommonFunctions.ErrMessage(cConfig.ConfigErrMessage);
                    return;
                }

                //очищаем текстовые поля
                txtCaption.Text = ""; txtNote.Text = "";

                CountersUpdate(); //обновляем счетчики

                //Показываем  
                if (CurRow == RowsCount) //если записей нет пустую
                {
                    NewRec(true);
                }
                else //следующую запись если записи есть
                {
                    ShowCurRec();
                }
                
            }
            else //это была новая запись
            {
                //очищаем текстовые поля
                txtCaption.Text = ""; txtNote.Text = "";

            }
                                    
        }
        

        private void frmNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.D: lblDelete_Click(null, null); break;
                    case Keys.N: lblNew_Click(null, null); break;
                    case Keys.S: lblSave_Click(null, null); break;
                    case Keys.A: break;
                    case Keys.Right: lblNext_Click(null, null); break;
                    case Keys.Left: lblPrev_Click(null, null); break;
                }
            }
            if (e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.A: lblShowall_Click(null, null); break;
                    case Keys.F: lblFont_Click(null, null); break;
                }
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblShowall_Click(object sender, EventArgs e)
        {
            frmAllNotes fAllNotes = new frmAllNotes();
            fAllNotes.Show();
            this.Close();
        }

        private void InsertModeShow(bool InsertMode)
        {
            if (InsertMode)
            {
                lblInsertIndicator.Text = "ЗАМ";
            }
            else
            {
                lblInsertIndicator.Text = "";
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            RichTextBox rtb = (RichTextBox)sender;

            //проверка на режим замены символов
            if (e.KeyData == Keys.Insert)
            {
                switch (rtb.Name)
                {
                    case "txtNote":
                        {
                            InsertModeNote = !InsertModeNote;
                            InsertModeShow(InsertModeNote);
                        }; break;
                    case "txtCaption":
                        {
                            InsertModeCaption = !InsertModeCaption;
                            InsertModeShow(InsertModeNote);
                        }; break;
                }
            }

            //своя обработка горячих клавиш
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Z:
                        {
                            rtb.Undo();
                        }; break;
                    case Keys.Y:
                        {
                            rtb.Redo();
                        }; break;
                    case Keys.C:
                        {
                            TextCopy(rtb);
                        }; break;
                    case Keys.V:
                        {
                            TextPaste(rtb);
                        }; break;
                    case Keys.X:
                        {
                            rtb.Cut();
                        }; break;
                    case Keys.A:
                        {
                            rtb.SelectAll();
                        }; break;
                }
            }

            if (e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        {
                            rtb.Cut();
                        }; break;
                    case Keys.Insert:
                        {
                            TextPaste(rtb);
                        }; break;
                }
            }
        }

        private void cmnTextSelectAll_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)cmnText.SourceControl;

            rtb.SelectAll();
        }

        private void cmnTextDelete_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)cmnText.SourceControl;

            if (rtb.SelectionLength == 0) return;
            rtb.SelectedText = string.Empty;
        }

        private void cmnTextCut_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)cmnText.SourceControl;

            rtb.Cut();
        }

        private void cmnTextCopy_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)cmnText.SourceControl;
            TextCopy(rtb);
        }

        private void cmnTextPaste_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)cmnText.SourceControl;            
            if (Clipboard.ContainsText())
            {
                rtb.Paste();                             
            }
        }
                
        
    }
}

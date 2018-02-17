using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics;

namespace XuliOrganizzer
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        ArrayList aboutStrings = new ArrayList();
        ArrayList aboutFonts = new ArrayList();

        ArrayList bugStrings = new ArrayList();
        ArrayList bugFonts = new ArrayList();        
        string WildsoftSl = "Make code, not war! C# like you.";
        
        Font fnt, WildsoftSlFnt;
        Graphics graph;
        Single teky,starty,endy,centery;
        Single x;
        SizeF pixlen;
        Bitmap view;
        int space_coef = 15;
        int scene_number = 0;
        int i = 0;
        float stringsHeight = 0;
        private void SetStrings()
        {
            //шрифты для текста
            Font Group = new Font ("Arial", 9, FontStyle.Bold, GraphicsUnit.Point);
            Font Names = new Font("Microsoft Sans Serif", 8, FontStyle.Regular, GraphicsUnit.Point);
            //строки для первой сцены
            aboutStrings.Add("XuliOrganizzer"); aboutFonts.Add(Group);
            aboutStrings.Add("v 0.0.1"); aboutFonts.Add(Group);
            aboutStrings.Add("Распространяется бесплатно"); aboutFonts.Add(Names);
            aboutStrings.Add("                      "); aboutFonts.Add(Names);
            aboutStrings.Add("Developers"); aboutFonts.Add(Group);
            aboutStrings.Add("[Wildsoft], [Chaos Software]"); aboutFonts.Add(Group);
            aboutStrings.Add("                      "); aboutFonts.Add(Names);
            aboutStrings.Add("Idea"); aboutFonts.Add(Group);
            aboutStrings.Add("NKT"); aboutFonts.Add(Names);
            aboutStrings.Add("Code"); aboutFonts.Add(Group);
            aboutStrings.Add("Leha Silent"); aboutFonts.Add(Names);
            aboutStrings.Add("PunkArr[]"); aboutFonts.Add(Names);
            aboutStrings.Add("NKT"); aboutFonts.Add(Names);            
            aboutStrings.Add("Interface Design"); aboutFonts.Add(Group);
            aboutStrings.Add("Leha Silent"); aboutFonts.Add(Names);
            aboutStrings.Add("Chaos. Cry. Destruction."); aboutFonts.Add(Group);
            aboutStrings.Add("PunkArr[]"); aboutFonts.Add(Names);
            aboutStrings.Add("Testing"); aboutFonts.Add(Group);
            aboutStrings.Add("Leha Silent"); aboutFonts.Add(Names);
            aboutStrings.Add("NKT"); aboutFonts.Add(Names);
            aboutStrings.Add("PunkArr[]"); aboutFonts.Add(Names);
            aboutStrings.Add("Beer"); aboutFonts.Add(Group);
            aboutStrings.Add("NKT"); aboutFonts.Add(Names);
            aboutStrings.Add("Lina K."); aboutFonts.Add(Names);
            //строки для второй сцены
            bugStrings.Add("Об ошибках и предложениях"); bugFonts.Add (Names);
            bugStrings.Add("пишите в блог"); bugFonts.Add (Names);
            bugStrings.Add("#http://tolik-punkoff.com"); bugFonts.Add(Names);
            bugStrings.Add("#http://lj.rossia.org/users/hex_laden"); bugFonts.Add(Names);
            //высота строк в пикселях для второй сцены
            for (int i = 0; i < bugStrings.Count; i++)
            {
                stringsHeight += graph.MeasureString(Convert.ToString(bugStrings[i]), (Font)bugFonts[i]).Height;
            }
            stringsHeight += space_coef * bugStrings.Count;
            centery = Convert.ToInt32((pctMessages.Height - stringsHeight) / 2);
            //фонты для слоганов            
            WildsoftSlFnt = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Point);
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            
            view = new Bitmap(318, 319);
            graph = Graphics.FromImage((Image)view);
            pctMessages.Image = ((Image)view);

            this.BackColor = Color.Black; //- это чорный фон
            this.ForeColor = Color.Green; //- это зеленый цвет
            lblCopyright.Height = this.Height;            
            SetStrings();
            starty = teky = pctMessages.Height;
            endy = pctMessages.Location.Y ;                                                                         
            tmrDraw.Interval = 20;
            tmrDraw.Start();
            i = 0;            
        }

        private void tmrDraw_Tick(object sender, EventArgs e)
        {
            switch (scene_number)
            {
                case 0:
                    {
                        graph.Clear(this.BackColor);
                        for (i = 0; i < aboutStrings.Count; i++)
                        {
                            fnt = (Font)aboutFonts[i];
                            pixlen = graph.MeasureString(Convert.ToString(aboutStrings[i]), fnt);
                            x = Convert.ToInt32((this.Width - pixlen.Width) / 2);
                            graph.DrawString(Convert.ToString(aboutStrings[i]), fnt, Brushes.Lime, x, teky + i * space_coef);
                        }
                        pctMessages.Image = (Image)view;
                        if (teky <= (endy - 25 * aboutStrings.Count))
                        {
                            teky = starty;
                            scene_number = 1;
                             
                        }
                        else
                        {
                            teky -= 1;
                        }
                        break;
                    }
                case 1:
                    {
                        graph.Clear(this.BackColor);
                        for (i = 0; i < bugStrings.Count; i++)
                        {
                            fnt = (Font)bugFonts[i];
                            if ((Convert.ToString(bugStrings[i]).Substring(0,1))=="#")
                            {
                                pixlen = graph.MeasureString(Convert.ToString(bugStrings[i]).Substring(1), fnt);
                                x = Convert.ToInt32((this.Width - pixlen.Width) / 2);
                                graph.DrawString(Convert.ToString(bugStrings[i]).Substring(1), fnt, Brushes.SkyBlue, x, teky + i * space_coef);
                            }
                            else 
                            {
                            pixlen = graph.MeasureString(Convert.ToString(bugStrings[i]), fnt);
                            x = Convert.ToInt32((this.Width - pixlen.Width) / 2);
                            graph.DrawString(Convert.ToString(bugStrings[i]), fnt, Brushes.Lime, x, teky + i * space_coef);
                            }
                        }
                        pctMessages.Image = (Image)view;
                        if (teky <= (endy - 55 * bugStrings.Count))
                        {
                            teky = starty;
                            scene_number = 2;
                        }
                        else
                        {
                            if (teky == centery)
                            {
                                tmrDraw.Stop();
                                tmrPause.Interval = 3000; //пауза в 3 секунды
                                tmrPause.Start();
                            }
                            teky -= 1;
                        }
                        break;
                    }
                case 2:
                    {
                        graph.Clear(this.BackColor);                        
                        pixlen = graph.MeasureString(WildsoftSl, WildsoftSlFnt);
                        x = Convert.ToInt32((this.Width - pixlen.Width) / 2);
                        graph.DrawString(WildsoftSl, WildsoftSlFnt, Brushes.Yellow, x, teky+40);
                        pctMessages.Image = (Image)view;
                        if (teky <= (endy - 175))
                        {
                            teky = starty;
                            scene_number = 0;
                        }
                        else
                        {
                            if (teky == centery)
                            {
                                tmrDraw.Stop();
                                tmrPause.Interval = 10000; //пауза в 10 секунд
                                tmrPause.Start();
                            }
                            teky -= 1;
                        }
                        break;
                    }
            }
    }

        private void tmrPause_Tick(object sender, EventArgs e)
        {
            tmrPause.Stop();
            tmrDraw.Start();
        }

        

        private void pctLogo_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://tolik-punkoff.com");
            }
            catch (Exception ex)
            {
                CommonFunctions.ErrMessage(ex.Message);
            }
        }
    }
}
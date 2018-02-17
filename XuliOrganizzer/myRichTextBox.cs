using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace XuliOrganizzer
{
    public partial class myRichTextBox : RichTextBox 
    {
        public myRichTextBox()
        {
            InitializeComponent();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }

        public void SendKey(KeyEventArgs e)
        {
            OnGotFocus(e);
            OnKeyUp(e);
        }
        /*public void SendKey(KeyPressEventArgs e)
        {
            OnKeyPress(e);
        }*/
    }
}

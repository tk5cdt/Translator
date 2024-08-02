
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace TranslatorLibrary
{
    public class HintRichTextbox : KryptonRichTextBox
    {
        string hintText = "Enter text here...";
        public string HintText
        {
            get { return hintText; }
            set { hintText = value; this.Invalidate(); }
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xF) //WM_PAINT
            {
                if (string.IsNullOrEmpty(this.Text) && !this.Focused && !string.IsNullOrEmpty(this.hintText))
                {
                    using (var g = this.CreateGraphics())
                    {
                        TextRenderer.DrawText(g, hintText, this.Font, this.ClientRectangle, SystemColors.GrayText, this.BackColor, TextFormatFlags.Top | TextFormatFlags.Left);
                    }
                }
            }
        }
    }
}

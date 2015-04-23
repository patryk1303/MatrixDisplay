using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixDisplay
{
    public class MatrixDisplay : UserControl
    {
        private Color OnColor;
        [Category("Colors")]
        public Color DotEnabledColor
        {
            get { return OnColor; }
            set { OnColor = value; }
        }
        private Color OffColor;
        [Category("Colors")]
        public Color DotDisabledColor
        {
            get { return OffColor; }
            set { OffColor = value; }
        }

        private int DotSize;
        [Category("Appearance")]
        public int DotRadius
        {
            get { return DotSize; }
            set { DotSize = value; }
        }

        public MatrixDisplay() 
        {
            ForeColor = Color.Black;
            DotDisabledColor = Color.Gray;
            DotEnabledColor = Color.Orange;
            Width = 300;
            Height = 48;
            DotRadius = 16;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int l = ClientRectangle.Left;
            int t = ClientRectangle.Top;
            int h = ClientRectangle.Height;
            int w = ClientRectangle.Width;

            int dotsOnWidth = Width / (DotRadius * 2);
            int dotsOnHeight = Height / (DotRadius * 2);

            Pen pen = new System.Drawing.Pen(DotDisabledColor,2);
            SolidBrush brush = new SolidBrush(DotDisabledColor);
            
            for(int i=0;i<dotsOnWidth;++i)
            {
                for(int j=0;j<dotsOnHeight;++j)
                {
                    e.Graphics.FillEllipse(brush, i * DotRadius + DotRadius * 2, j * DotRadius + DotRadius * 2, DotRadius * 2, DotRadius * 2);
                }
            }
        }
    }
}

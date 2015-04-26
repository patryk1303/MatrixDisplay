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
            set
            {
                if (value <= 0)
                    DotSize = 1;
                else
                    DotSize = value;
            }
        }

        private string _Text = "E";
        [Category("Colors")]
        public string MatrixText
        {
            get { return _Text; }
            set { _Text = value; }
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

            //int dotsOnWidth = Width / (DotRadius * 2) - DotRadius;
            int dotsOnWidth = MatrixText.Length * 7;
            //int dotsOnHeight = Height / (DotRadius * 2);
            int dotsOnHeight = 7;

            Pen pen = new System.Drawing.Pen(DotDisabledColor,2);
            SolidBrush brush = new SolidBrush(DotDisabledColor);

            //Console.WriteLine("dotsOnWidth: {0}, dotsOnHeight: {1}", dotsOnWidth, dotsOnHeight);

            for(int i=0;i<dotsOnWidth;++i)
            {
                byte charIndex = charToIndex(MatrixText[i/7]);
                for (int j = 0; j < dotsOnHeight; ++j)
                {
                    var x = i * (DotRadius * 2) + DotRadius * 2;
                    var y = j * (DotRadius*2) + DotRadius*2;

                    if (charIndex < 128)
                    {
                        if (Letters.SLetters[charIndex, j, i % 7] == 0)
                            brush.Color = DotDisabledColor;
                        else if (Letters.SLetters[charIndex, j, i % 7] == 1)
                            brush.Color = DotEnabledColor;
                    }
                    else
                    {

                    }

                    //Console.WriteLine("char: {0}, code: {1}, index: {2}", _c, (byte)_c, charToIndex(_c));

                    //Console.WriteLine("x: {0}, y: {1}", x, y);
                    e.Graphics.FillEllipse(brush, x, y, DotRadius * 2, DotRadius * 2);
                }
            }
        }

        private byte charToIndex(char _c)
        {
            byte code = (byte)_c;

            //Capital letter
            if (code >= 65 && code <= 90)
                return (byte)(code - 65);
            //Small letter
            else if (code >= 97 && code <= 122)
                return (byte)(code - 97);
            //SPACE
            else if (code == 32)
                return 255;

            return 0;
        }
    }
}

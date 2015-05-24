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
        [Category("Dots")]
        [Description("Dot color when it's enabled")]
        public Color DotEnabledColor
        {
            get { return OnColor; }
            set { OnColor = value; }
        }
        private Color OffColor;
        [Category("Dots")]
        [Description("Dot color when it's disabled")]
        public Color DotDisabledColor
        {
            get { return OffColor; }
            set { OffColor = value; }
        }

        private int DotSize;
        [Category("Dots")]
        [Description("Dot radius")]
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
        [Category("Dots")]
        [Description("Text to displat in matrix")]
        public string MatrixText
        {
            get { return _Text; }
            set { _Text = value; }
        }

        private ScrollDirection Direction = ScrollDirection.NONE;
        [Category("Dots")]
        [Description("Dots scroll direction")]
        public ScrollDirection ScrollDirection_
        {
            get { return Direction; }
            set { Direction = value; }
        }

        private int _MaxChars = 7;
        [Category("Dots")]
        [Description("Maximum amount of chart to be displayed")]
        public int MaxChars
        {
            get { return _MaxChars; }
            set
            {
                if (value <= 0)
                    _MaxChars = 1;
                else
                    _MaxChars = value;
            }
        }

        /**
         * MatrixDisplay contructor
         * 
         */
        public MatrixDisplay()
        {
            ForeColor = Color.Black;
            DotDisabledColor = Color.Gray;
            DotEnabledColor = Color.Orange;
            Width = 300;
            Height = 48;
            DotRadius = 16;
        }

        /**
         * paints matrix
         */ 
        protected override void OnPaint(PaintEventArgs e)
        {
            int l = ClientRectangle.Left;
            int t = ClientRectangle.Top;
            int h = ClientRectangle.Height;
            int w = ClientRectangle.Width;

            //int dotsOnWidth = MatrixText.Length * 7;
            int dotsOnWidth = _MaxChars * 7;
            int dotsOnHeight = 7;

            Pen pen = new System.Drawing.Pen(DotDisabledColor,2);
            SolidBrush brush = new SolidBrush(DotDisabledColor);

            //fill to spaces
            if (MatrixText.Length < _MaxChars)
            {
                MatrixText = MatrixText.PadRight(_MaxChars);
            }

            for(int i=0;i<dotsOnWidth;++i)
            {
                byte charIndex = charToIndex(MatrixText[i/7]);
                for (int j = 0; j < dotsOnHeight; ++j)
                {
                    var x = i * (DotRadius * 2) + DotRadius * 2;
                    var y = j * (DotRadius * 2) + DotRadius * 2;

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
                    e.Graphics.FillEllipse(brush, x, y, DotRadius * 2, DotRadius * 2);
                }
            }

            if (Direction != ScrollDirection.NONE)
            {
                Invalidate();
            }
        }

        /**
         * Return the <b>Letters.SLetters</b> char index
         * @param _c char to get index
         * 
         * @return char index if it's in supported range, if not - 0
         */
        private byte charToIndex(char _c)
        {
            byte code = (byte)_c;

            //Capital letter
            if (code >= 65 && code <= 90)
                return (byte)(code - 65);
            //Small letter
            else if (code >= 97 && code <= 122)
                return (byte)(code - 97);
            //Numbers 0-9
            else if (code >= 48 && code <= 57)
                return (byte)(code - 22);
            //SPACE
            else if (code == 32)
                return 255;

            return 0;
        }

        public enum ScrollDirection
        {
            NONE,
            LEFT,
            RIGHT
        }
    }
}

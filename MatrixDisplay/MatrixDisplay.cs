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
            set 
            {
                OnColor = value;
                Invalidate();
            }
        }
        private Color OffColor;
        [Category("Dots")]
        [Description("Dot color when it's disabled")]
        public Color DotDisabledColor
        {
            get { return OffColor; }
            set
            {
                OffColor = value;
                Invalidate();
            }
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
                Invalidate();
            }
        }

        private string _Text = "E";
        [Category("Dots")]
        [Description("Text to displat in matrix")]
        public string MatrixText
        {
            get { return _Text; }
            set
            {
                _Text = value;
                Invalidate();
            }
        }

        private ScrollDirection Direction = ScrollDirection.NONE;
        [Category("Dots")]
        [Description("Dots scroll direction")]
        public ScrollDirection ScrollDirection_
        {
            get { return Direction; }
            set
            {
                if (value == ScrollDirection.NONE)
                    Pivot = 0;
                Direction = value;
                Invalidate();
            }
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
                Invalidate();
            }
        }

        private DotShape _Shape = DotShape.CIRCLE;
        [Category("Dots")]
        [Description("Dot shape")]
        public DotShape _DotShape
        {
            get { return _Shape; }
            set
            {
                _Shape = value;
                Invalidate();
            }
        }

        private byte[,] OldMatrix;
        private byte[,] NewMatrix;
        private int Pivot;

        /// <summary>
        /// Contructor
        /// </summary>
        public MatrixDisplay()
        {
            ForeColor = Color.Black;
            DotDisabledColor = Color.Gray;
            DotEnabledColor = Color.Orange;
            Width = 300;
            Height = 48;
            DotRadius = 16;
            NewMatrix = InitMatrix(_MaxChars * 7, 7);
            OldMatrix = InitMatrix(_MaxChars * 7, 7);
            Pivot = 0;
        }

        /// <summary>
        /// paints matrix
        /// </summary>
        /// <param name="e">arguments</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            int l = ClientRectangle.Left;
            int t = ClientRectangle.Top;
            int h = ClientRectangle.Height;
            int w = ClientRectangle.Width;

            //int dotsOnWidth = MatrixText.Length * 7;
            int dotsOnWidth = _MaxChars * 7;
            int dotsOnHeight = 7;

            Pen pen = new System.Drawing.Pen(DotDisabledColor, 2);
            SolidBrush brush = new SolidBrush(DotDisabledColor);

            //fill to spaces
            if (MatrixText.Length < _MaxChars)
            {
                MatrixText = MatrixText.PadRight(_MaxChars);
            }

            for (int i = 0; i < dotsOnWidth; ++i)
            {
                byte charIndex = charToIndex(MatrixText[i / 7]);
                for (int j = 0; j < dotsOnHeight; ++j)
                {
                    int x = i * (DotRadius * 2) + DotRadius * 2;
                    int y = j * (DotRadius * 2) + DotRadius * 2;
                    byte _char = 2;

                    if (charIndex < 128)
                    {
                        _char = Letters.SLetters[charIndex, Math.Abs((j + Pivot) % 7), i % 7];
                        //_char = Letters.SLetters[charIndex, j, Math.Abs((i + Pivot) % 7) % 7];
                        if (_char == 0)
                            brush.Color = DotDisabledColor;
                        else if (_char == 1)
                            brush.Color = DotEnabledColor;
                    }
                    NewMatrix[i, j] = _char;
                    if (NewMatrix[i, j] != OldMatrix[i, j])
                    switch (_Shape)
                    {
                        case DotShape.CIRCLE:
                            e.Graphics.FillEllipse(brush, x, y, DotRadius * 2, DotRadius * 2);
                            break;
                        case DotShape.SQUARE:
                            e.Graphics.FillRectangle(brush, x - DotRadius, y - DotRadius, DotRadius * 2, DotRadius * 2);
                            break;
                    }
                    OldMatrix[i, j] = _char;
                }
            }

            if (Direction != ScrollDirection.NONE)
            {
                Invalidate();
            }
            switch (Direction)
            {
                case ScrollDirection.DOWN: Pivot--;
                    if (Pivot < -7) Pivot = 0;
                    Invalidate();
                    break;
                case ScrollDirection.UP: Pivot++;
                    if (Pivot > 7) Pivot = 0;
                    Invalidate();
                    break;
            }
        }

        /// <summary>
        /// Returns the <b>Letters.SLetters</b> char index
        /// </summary>
        /// <param name="_c"> char to get index</param>
        /// <returns>char index if it's in supported range, if not - 0</returns>
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

        /// <summary>
        /// Matrix scroll direction
        /// </summary>
        public enum ScrollDirection
        {
            NONE,
            DOWN,
            UP
        }

        /// <summary>
        /// Matrix dot shape
        /// </summary>
        public enum DotShape
        {
            CIRCLE,
            SQUARE
        }

        /// <summary>
        /// Fills Matrix with zeroes
        /// </summary>
        /// <param name="_width">Matrix width</param>
        /// <param name="_height">Matrix height</param>
        private byte[,] InitMatrix(int _width, int _height)
        {
            var Matrix = new byte[_width, _height];
            for (int i = 0; i < _width; ++i)
                for (int j = 0; j < _height; ++j)
                    Matrix[i, j] = 0;
            return Matrix;
        }
    }
}

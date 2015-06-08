using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixTestWidnowApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            matrixDisplay1.MatrixText = textBox1.Text;
            matrixDisplay1.Invalidate();
        }

        private void onColorBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                matrixDisplay1.DotEnabledColor = colorDialog1.Color;
                matrixDisplay1.Invalidate();
            }
        }

        private void offColorBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                matrixDisplay1.DotDisabledColor = colorDialog1.Color;
                matrixDisplay1.Invalidate();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            matrixDisplay1.DotRadius = (int)numericUpDown1.Value;
            matrixDisplay1.Invalidate();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (scrollDirection.SelectedIndex)
            {
                case 0: matrixDisplay1.ScrollDirection_ = MatrixDisplay.MatrixDisplay.ScrollDirection.NONE;
                    break;
                case 1: matrixDisplay1.ScrollDirection_ = MatrixDisplay.MatrixDisplay.ScrollDirection.DOWN;
                    break;
                case 2: matrixDisplay1.ScrollDirection_ = MatrixDisplay.MatrixDisplay.ScrollDirection.UP;
                    break;
            }
            matrixDisplay1.Invalidate();
        }

        private void numericMaxChars_ValueChanged(object sender, EventArgs e)
        {
            matrixDisplay1.MaxChars = (int)numericMaxChars.Value;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    matrixDisplay1._DotShape = MatrixDisplay.MatrixDisplay.DotShape.CIRCLE;
                    break;
                case 1:
                    matrixDisplay1._DotShape = MatrixDisplay.MatrixDisplay.DotShape.SQUARE;
                    break;
            }
            matrixDisplay1.Invalidate();
        }
    }
}

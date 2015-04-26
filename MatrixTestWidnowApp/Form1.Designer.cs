﻿namespace MatrixTestWidnowApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.onColorBtn = new System.Windows.Forms.Button();
            this.offColorBtn = new System.Windows.Forms.Button();
            this.matrixDisplay1 = new MatrixDisplay.MatrixDisplay();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(806, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.matrixDisplay1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 303);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.onColorBtn);
            this.flowLayoutPanel1.Controls.Add(this.offColorBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 246);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(806, 54);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // onColorBtn
            // 
            this.onColorBtn.FlatAppearance.BorderSize = 2;
            this.onColorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.onColorBtn.Location = new System.Drawing.Point(3, 3);
            this.onColorBtn.Name = "onColorBtn";
            this.onColorBtn.Size = new System.Drawing.Size(83, 42);
            this.onColorBtn.TabIndex = 2;
            this.onColorBtn.Text = "Kolor włączonych";
            this.onColorBtn.UseVisualStyleBackColor = true;
            this.onColorBtn.Click += new System.EventHandler(this.onColorBtn_Click);
            // 
            // offColorBtn
            // 
            this.offColorBtn.FlatAppearance.BorderSize = 2;
            this.offColorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.offColorBtn.Location = new System.Drawing.Point(92, 3);
            this.offColorBtn.Name = "offColorBtn";
            this.offColorBtn.Size = new System.Drawing.Size(83, 42);
            this.offColorBtn.TabIndex = 3;
            this.offColorBtn.Text = "Kolor wyłączonych";
            this.offColorBtn.UseVisualStyleBackColor = true;
            this.offColorBtn.Click += new System.EventHandler(this.offColorBtn_Click);
            // 
            // matrixDisplay1
            // 
            this.matrixDisplay1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.matrixDisplay1.DotDisabledColor = System.Drawing.Color.Maroon;
            this.matrixDisplay1.DotEnabledColor = System.Drawing.Color.Orange;
            this.matrixDisplay1.DotRadius = 5;
            this.matrixDisplay1.ForeColor = System.Drawing.Color.Black;
            this.matrixDisplay1.Location = new System.Drawing.Point(3, 33);
            this.matrixDisplay1.MatrixText = "EAC";
            this.matrixDisplay1.Name = "matrixDisplay1";
            this.matrixDisplay1.Size = new System.Drawing.Size(806, 207);
            this.matrixDisplay1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 303);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button onColorBtn;
        private System.Windows.Forms.Button offColorBtn;
        private MatrixDisplay.MatrixDisplay matrixDisplay1;
    }
}


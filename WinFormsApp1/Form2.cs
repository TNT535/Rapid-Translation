using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        int mode = 0;
        public Form2()
        {
            InitializeComponent();
            this.textBox1.Text = OCR.ImageToText(Form1.capture).Replace("\n", System.Environment.NewLine);
            this.pictureBox1.Image = Form1.capture;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    this.textBox1.Text = OCR.ImageToText(Form1.capture, 1).Replace("\n", System.Environment.NewLine);
        //    this.pictureBox1.Image = Form1.capture;
        //    this.Refresh();
        //}

        private void button1_Click_1(object sender, EventArgs e)
        {
            mode++;
            this.textBox1.Text = OCR.ImageToText(Form1.capture, mode).Replace("\n", System.Environment.NewLine);
            this.pictureBox1.Image = Form1.capture;
            this.Refresh();

        }
    }
}

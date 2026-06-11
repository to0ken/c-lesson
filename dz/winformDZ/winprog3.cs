using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private bool isAlive = true;

        public Form1()
        {
            InitializeComponent();
            progressBar1.Maximum = 100; progressBar1.Value = 80; // Еда
            progressBar2.Maximum = 100; progressBar2.Value = 80; // Вода
            progressBar3.Maximum = 100; progressBar3.Value = 80; // Счастье
            timer1.Interval = 1000; 
            timer1.Start();

        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void progressBar1_Click(object sender, EventArgs e) { }
        private void progressBar3_Click(object sender, EventArgs e) { }
        private void progressBar2_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!isAlive) return;
            progressBar1.Value = Math.Min(100, progressBar1.Value + 10);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isAlive) return;

            progressBar1.Value = Math.Max(0, progressBar1.Value - 2);
            progressBar2.Value = Math.Max(0, progressBar2.Value - 3);
            progressBar3.Value = Math.Max(0, progressBar3.Value - 2);

            if (progressBar1.Value == 0 || progressBar2.Value == 0 || progressBar3.Value == 0)
            {
                isAlive = false;
                timer1.Stop();


                string reason = "";
                if (progressBar1.Value == 0) reason += "Еда ";
                if (progressBar2.Value == 0) reason += "Вода ";
                if (progressBar3.Value == 0) reason += "Счастье ";
                MessageBox.Show("ТЫ УБИЙЦА");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!isAlive) return;
            progressBar3.Value = Math.Min(100, progressBar3.Value + 7);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isAlive) return;
            progressBar2.Value = Math.Min(100, progressBar2.Value + 5);
        }
    }
}

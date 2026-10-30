
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int start = int.Parse(textBox1.Text);
            int end = int.Parse(textBox2.Text);
  

            label1.Text = $"Диапазон: от {start} до {end}";

            Thread thread = new Thread(() =>
            {
                for (int i = start; i <= end; i++)
                {
                    Console.WriteLine($"Поток: {Thread.CurrentThread.ManagedThreadId}, число: {i}");
                }
            });




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

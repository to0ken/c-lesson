using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    // 1.Создать программу, которая  меняет цвет labla каждую секунду. Цветов 10.
    public partial class Form1 : Form
    {
        int colorr = 0;
        private Color[] colors = {
            Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple,
            Color.Black, Color.Magenta, Color.Yellow, Color.Pink, Color.Lime
        };
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e) { }
        

        private void label1_Click(object sender, EventArgs e) { }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.ForeColor = colors[colorr];
            colorr++;
            if (colorr == 10)
                colorr = 0;
        }
    }
}

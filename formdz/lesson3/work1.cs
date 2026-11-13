using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ConsoleApp1
{

    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        private static extern bool Beep(uint frequency, uint duration);

        [DllImport("user32.dll")]
        private static extern bool MessageBeep(uint uType);

        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Beep(400, 500);
            Thread.Sleep(1000);
            Beep(1000, 300);
            Thread.Sleep(1000);
            MessageBeep(0xFFFFFFFF);
        }
    }
}

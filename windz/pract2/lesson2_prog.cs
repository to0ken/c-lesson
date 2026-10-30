
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1: Form
    {
        int[] numbers = new int[1000];
        int max, min;
        double avg;

        public Form1()
        {
            InitializeComponent();
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
                numbers[i] = random.Next(0, 1001);

            
            button1.Text = "Максимум";
            button2.Text = "Минимум";
            button3.Text = "Среднее";
            label1.Text = "Нажмите кнопку для вычисления";
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Thread t = new Thread(FindMax);
            t.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Thread t = new Thread(FindMin);
            t.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            Thread t = new Thread(FindAvg);
            t.Start();
        }

        void FindMax()
        {
            int localMax = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
                if (numbers[i] > localMax) localMax = numbers[i];


            this.Invoke((MethodInvoker)delegate {
                label1.Text = $"Максимум: {localMax} (Поток ID: {Thread.CurrentThread.ManagedThreadId})";
            });
        }

        void FindMin()
        {
            int localMin = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
                if (numbers[i] < localMin) localMin = numbers[i];

            this.Invoke((MethodInvoker)delegate {
                label1.Text = $"Минимум: {localMin} (Поток ID: {Thread.CurrentThread.ManagedThreadId})";
            });
        }
        void FindAvg()
        {
            long sum = 0;
            for (int i = 0; i < numbers.Length; i++)
                sum += numbers[i];

            double localAvg = (double)sum / numbers.Length;

            this.Invoke((MethodInvoker)delegate {
                label1.Text = $"Среднее: {localAvg:F2} (Поток ID: {Thread.CurrentThread.ManagedThreadId})";
            });
        }

    }
}

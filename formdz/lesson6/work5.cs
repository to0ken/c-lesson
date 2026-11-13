using System;
using System.Threading;
using System.Windows.Forms;

namespace MultiThreadApp
{
    public partial class Form1 : Form
    {

        Thread primeThread, fibThread;
        bool isPrimeRunning;
        boll isPrimePaused;
        bool isFibRunning;
        bool isFibPaused;

        public Form1()
        {
            InitializeComponent();
        }


        private void btnPrimeStart_Click(object sender, EventArgs e)
        {

            if (primeThread != null && primeThread.IsAlive)
            {
                isPrimeRunning = false;
                primeThread.Join(200); 
            }
            lstPrimes.Items.Clear();
            

            isPrimeRunning = true;
            isPrimePaused = false;
            primeThread = new Thread(GeneratePrimes);
            primeThread.IsBackground = true;
            primeThread.Start();
        }


        private void btnFibStart_Click(object sender, EventArgs e)
        {
            if (fibThread != null && fibThread.IsAlive)
            {
                isFibRunning = false;
                fibThread.Join(200);
            }
            lstFib.Items.Clear();
            
            isFibRunning = true;
            isFibPaused = false;
            fibThread = new Thread(GenerateFibonacci);
            fibThread.IsBackground = true;
            fibThread.Start();
        }

        private void GenerateFibonacci()
        {
            long a = 0, b = 1;
            

            while (isFibRunning)
            {
                // Задание 4: Пауза
                if (isFibPaused)
                {
                    Thread.Sleep(50);
                    continue; 
                }

                lstFib.Invoke((MethodInvoker)(() => lstFib.Items.Add(a)));
                
                long next = a + b;
                a = b;
                b = next;


                if (b < 0) 
                {
                    isFibRunning = false;
                    break; 
                } 
                
                Thread.Sleep(10); 
            }
        }

        private void btnFibPause_Click(object sender, EventArgs e) => isFibPaused = true;
        private void btnFibResume_Click(object sender, EventArgs e) => isFibPaused = false;

        private void btnFibStop_Click(object sender, EventArgs e)
        {
            isFibRunning = false;
            isFibPaused = false;
            if (fibThread != null && fibThread.IsAlive) fibThread.Join(200);
        }
    }
}

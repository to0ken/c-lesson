namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        private bool isFinished = false;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 100;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int step1 = rnd.Next(1, 6);
            progressBar1.Value += step1;
            if (progressBar1.Value > 100) progressBar1.Value = 100;
            if (progressBar1.Value == 100) { Winner(1); return; }

            int step2 = rnd.Next(1, 6);
            progressBar2.Value += step2;
            if (progressBar2.Value > 100) progressBar1.Value = 100;
            if (progressBar2.Value == 100) { Winner(2); return; }

            int step3 = rnd.Next(1, 6);
            progressBar3.Value += step3;
            if (progressBar3.Value > 100) progressBar1.Value = 100;
            if (progressBar3.Value == 100) { Winner(3); return; }

            int step4 = rnd.Next(1, 6);
            progressBar4.Value += step4;
            if (progressBar4.Value > 100) progressBar1.Value = 100;
            if (progressBar4.Value == 100) { Winner(4); return; }

            /*if (progressBar5.Value < progressBar5.Maximum)
            {
                progressBar5.Value += 1;
            }
            else
            {
                timer1.Stop(); 
                
            }*/

        }
        private void Winner(int number)
        {
            isFinished = true;
            timer1.Stop();
        }

        private void progressBar1_Click(object sender, EventArgs e) { }
        private void progressBar2_Click(object sender, EventArgs e) { }
        private void progressBar3_Click(object sender, EventArgs e) { }
        private void progressBar4_Click(object sender, EventArgs e) { }
        private void progressBar5_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            progressBar4.Value = 0;
            progressBar5.Value = 0;

            isFinished = false; 
            timer1.Start();

        }
        
    }
}

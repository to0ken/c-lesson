namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Random rand = new Random();
        bool PlayerTurn = true;
        private bool gameOver = false;
        public Form1()
        {
            InitializeComponent();
            progressBar1.Maximum = 100;
            progressBar1.Value = 100;

            progressBar2.Maximum = 100;
            progressBar2.Value = 100;
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e) { }


        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
 

        private void pictureBox2_Click(object sender, EventArgs e) { }



        private void progressBar2_Click(object sender, EventArgs e) { }
        private void progressBar1_Click(object sender, EventArgs e) { }
 

        private void ударить_CheckedChanged(object sender, EventArgs e) { }
        private void исцелить_CheckedChanged(object sender, EventArgs e) { }
        private void ульта_CheckedChanged(object sender, EventArgs e) { }
        

        private void сделать_Click(object sender, EventArgs e)
        {
            if (gameOver || !PlayerTurn) return;

            int power = 0;
            string logMessage = "";

            if (ударить.Checked)
            {
                power = rand.Next(1, 11); 
                progressBar2.Value = Math.Max(0, progressBar2.Value - power);
                logMessage = $"атака: -{power} HP";
            }
            else if (исцелить.Checked)
            {
                power = rand.Next(5, 11); 
                progressBar1.Value = Math.Min(100, progressBar1.Value + power);
                logMessage = $"исцеление: +{power} HP";
            }
            else if (ульта.Checked)
            {
                power = rand.Next(20, 41); 
                progressBar2.Value = Math.Max(0, progressBar2.Value - power);
                logMessage = $"УльтааааААаа: -{power} HP";

                PlayerTurn = false;
            }
            else
            {
                return;
            }


            if (CheckEndGame()) return;
            
            PlayerTurn = false;
            EnemyTurn();
            if (CheckEndGame()) return;
            PlayerTurn = true;
        }
        private bool CheckEndGame()
        {
            if (progressBar2.Value <= 0)
            {
             
                gameOver = true;
                return true;
            }
            if (progressBar1.Value <= 0)
            {
               
                gameOver = true;
                return true;
            }
            return false;
        }

        private void EnemyTurn()
        {
            int chance = rand.Next(1, 101); 
            int power = 0;

            if (chance <= 60)
            {
                power = rand.Next(1, 11);
                progressBar1.Value = Math.Max(0, progressBar1.Value - power);
                
            }
            else if (chance <= 85)
            {
                power = rand.Next(20, 41);
                progressBar1.Value = Math.Max(0, progressBar1.Value - power);
            }
               
            else 
            {
                power = rand.Next(5, 11);
                progressBar2.Value = Math.Min(100, progressBar2.Value + power);
                
            }

        }


        }
}

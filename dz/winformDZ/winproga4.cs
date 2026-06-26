namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
    // 1. Создать игру 21 с кнопками добавить карту и проверить кто выйграл. img не надо 
        int score1 = 0;
        int score2 = 0;
        bool play1 = false;
        bool play2 = false;
        private Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            UpdateLabels();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (play1) return;
            score1 += rand.Next(1, 11);
            UpdateLabels();
            CheckWin();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            play1 = true;
            button1.Enabled = false;
            button2.Enabled = false;
            CheckWin();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (play2) return;
            score2 += rand.Next(1, 11);
            UpdateLabels();
            CheckWin();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            play2 = true;
            button3.Enabled = false;
            button4.Enabled = false;
            CheckWin();
        }
        private void UpdateLabels()
        {
            label1.Text = $"Игрок 2: {score1}";
            label2.Text = $"Игрок 1: {score2}";
        }

        private void CheckWin()
        {
            
            if (score1 > 21 && !play1)
            {
                
                play1 = true;
                button1.Enabled = button2.Enabled = false;
            }

            
            if (score2 > 21 && !play2)
            {
         
                play2 = true;
                button3.Enabled = button4.Enabled = false;
            }

            
            if (score1 == 21 && !play1)
            {
                MessageBox.Show("Игрок 1 выиграл!", "Победа!");
                
                return;
            }

            
            if (score2 == 21 && !play2)
            {
                MessageBox.Show("Игрок 2 выиграл!", "Победа!");
               
                return;
            }
            if (play1 && play2)
            {
                if (score1 > score2 && score1 <= 21)
                    MessageBox.Show(" Игрок 1 выиграл!!!", "Конец игры");
                else if (score2 > score1 && score2 <= 21)
                    MessageBox.Show("Игрок 2 выиграл!!!", "Конец игры");
                else if (score1 == score2)
                    MessageBox.Show("Ничья!", "Конец игры");
                else
                    MessageBox.Show("Оба перебрали", "Конец игры");

                
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

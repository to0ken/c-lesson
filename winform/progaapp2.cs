namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        private Random rand = new Random();
        string[] letterPool = { "A", "B", "C", "D", "E", "X", "Y", "Z", "Q", "W" };
        string[] letterSemfol = { "%","!","@","&",")" };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e)
        {
            string result = textBox1.Text;

            if (checkBox1.Checked)
            {
                result += rand.Next(0, 1000).ToString();
            }

            if (checkBox2.Checked)
            {
                string randomLetter = letterPool[rand.Next(letterPool.Length)];
                result += randomLetter;
            }
            if (checkBox3.Checked)
            {
                string randomSemwol = letterSemfol[rand.Next(letterSemfol.Length)];
                result += randomSemwol;
            }
            textBox1.Text = result;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox3_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox2_CheckedChanged(object sender, EventArgs e) { }

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
  // 1. Создать листбокс, кнопку добавление, удаление. Но при удалении происходит запрет на повторное вписывание того что удалили
    public partial class Form1 : Form
    {
        private List<string> bannedWords = new List<string>();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        

        private void button2_Click(object sender, EventArgs e)
        {
            string word = "привет";
            if (!bannedWords.Contains(word) && !listBox1.Items.Contains(word))
            {
                listBox1.Items.Add(word);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string word = listBox1.SelectedItem.ToString();
                listBox1.Items.Remove(word);
                bannedWords.Add(word);
            }
        }
    }
}

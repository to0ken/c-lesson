namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        // 1.Cоздать и заполнить ListView, по нажатию кнопки строка переходит в 3 lable и удаляется в ListView.
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (listView1.Columns.Count == 0)
            {
                listView1.Columns.Add("Товар", 150);   
                listView1.Columns.Add("Цвет", 120);
                listView1.Columns.Add("Цена", 100);
            }

            
            AddRow("Яблоко", "Красное", "120 руб");
            AddRow("Банан", "Жёлтый", "80 руб");
            AddRow("Груша", "Зелёная", "150 руб");
            AddRow("Апельсин", "Оранжевый", "90 руб");

        }

        private void AddRow(string col1, string col2, string col3)
        {
            
            ListViewItem item = new ListViewItem(col1);

            item.SubItems.Add(col2);
            item.SubItems.Add(col3);

            
            listView1.Items.Add(item);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите строку!", MessageBoxButtons.OK, );
                return;
            }

            ListViewItem item = listView1.SelectedItems[0];

            label1.Text = item.SubItems.Count > 0 ? item.SubItems[0].Text : "";
            label2.Text = item.SubItems.Count > 1 ? item.SubItems[1].Text : "";
            label3.Text = item.SubItems.Count > 2 ? item.SubItems[2].Text : "";

            listView1.Items.Remove(item);
        }
    }
}

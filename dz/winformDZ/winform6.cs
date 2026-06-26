namespace WinFormsApp8
{
  // 1. Изменять размер фотографии в picturebox с помощью trackBar.
    public partial class Form1 : Form
    {
        int origW;
        int origH;

        public Form1()
        {
            InitializeComponent();

            if (pictureBox1.Image != null)
            {
                origW = pictureBox1.Image.Width;
                origH = pictureBox1.Image.Height;
            }

            
            trackBar1.Minimum = 10;   
            trackBar1.Maximum = 200;  
            trackBar1.Value = 100;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double k = trackBar1.Value / 100.0;

         
            pictureBox1.Width = (int)(origW * k);
            pictureBox1.Height = (int)(origH * k);
        }
    }

}

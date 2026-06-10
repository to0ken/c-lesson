namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // AnchorStyles.Bottom - прилипгуть к стенке 

            hScrollBar1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            
            vScrollBar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;

            
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            
            this.ClientSizeChanged += Form1_SizeChanged;

            UpdateScrollLimits();
            hScrollBar1.Value = 0;
            vScrollBar1.Value = 0;

        }
        private void UpdateScrollLimits()
        {
            
            int maxX = Math.Max(0, this.ClientSize.Width - pictureBox1.Width);
            int maxY = Math.Max(0, this.ClientSize.Height - pictureBox1.Height);

            hScrollBar1.Minimum = 0; vScrollBar1.Minimum = 0;
            hScrollBar1.Maximum = maxX; vScrollBar1.Maximum = maxY;

            
            if (pictureBox1.Left > maxX) pictureBox1.Left = maxX;
            if (pictureBox1.Top > maxY) pictureBox1.Top = maxY;

            
            hScrollBar1.Value = pictureBox1.Left;
            vScrollBar1.Value = pictureBox1.Top;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            UpdateScrollLimits();
        }

        private void Form1_Load(object sender, EventArgs e) { }
        

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
            
        {
            
            pictureBox1.Left = hScrollBar1.Value;

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            
            pictureBox1.Top = vScrollBar1.Value;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

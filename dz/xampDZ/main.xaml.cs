using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(LoginBox.Text) &&
                !string.IsNullOrWhiteSpace(PassBox.Password))
            {
                LoginPanel.Visibility = Visibility.Collapsed; 
                PhotoPanel.Visibility = Visibility.Visible;   
                
            }
            
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            PhotoPanel.Visibility = Visibility.Collapsed;
            LoginPanel.Visibility = Visibility.Visible;
            PassBox.Clear();
        }


    }
}

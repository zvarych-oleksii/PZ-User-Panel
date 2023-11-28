using System.Windows;

namespace WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // Perform basic validation (replace this with your authentication logic)
            if (username == "admin" && password == "password")
            {
                txtResult.Text = "Login successful!";
            }
            else
            {
                txtResult.Text = "Invalid username or password. Try again.";
            }
        }
    }
}
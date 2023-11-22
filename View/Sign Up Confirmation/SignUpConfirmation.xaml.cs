using System.Windows.Controls;

namespace LIS1.View
{
    public partial class SignUpConfirmation : UserControl
    {
        public SignUpConfirmation()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }
        private void ReturnToLogin_Click(object sender, RoutedEventArgs e)
        {
            var loginView = new LoginView();
            loginView.Show();

            Close();
        }
    }
}
using LibrarySystem.Services;
using LibrarySystem.ViewModels.Pages;
using LibrarySystem.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibrarySystem.Views.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        public void loginForm_SignUpRequested()
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(new SignupForm());
        }

        public void signUpForm_BackToLogin()
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(new LoginForm());
        }

        private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

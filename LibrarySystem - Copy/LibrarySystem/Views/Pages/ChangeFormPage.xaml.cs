using LibrarySystem.ViewModels.Pages;
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
    /// Interaction logic for ChangeFormPage.xaml
    /// </summary>
    public partial class ChangeFormPage : Page
    {
        private readonly LoginViewModel _viewModel;
        public ChangeFormPage()
        {
            InitializeComponent();
            _viewModel = new LoginViewModel();
            DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(_viewModel.UserPass.Password!=null)
            {
                txtNewPassword.Text = _viewModel.UserPass.Password;
            }
        }
    }
}

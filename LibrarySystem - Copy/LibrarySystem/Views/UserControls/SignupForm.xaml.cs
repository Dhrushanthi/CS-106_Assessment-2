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

namespace LibrarySystem.Views.UserControls
{
    /// <summary>
    /// Interaction logic for SignupForm.xaml
    /// </summary>
    public partial class SignupForm : UserControl
    {
        public event EventHandler BackToLogin;
        public SignupForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BackToLogin?.Invoke(this, EventArgs.Empty);
        }
    }
}

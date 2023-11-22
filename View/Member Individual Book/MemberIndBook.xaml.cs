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


namespace LIS1.View
{
    public partial class MemberIndBook : UserControl
    {
        public MemberIndBook()
        {
            InitializeComponent();
        }
    private void DatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            f (DatePicker.SelectedDate.HasValue && DatePicker.SelectedDate > DateTime.Now)
            {
                // Set button content to "Prebook"
                bookButton.Content = "Prebook";
            }
            else
            {
                // Set button content to "Book"
                bookButton.Content = "Book";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}


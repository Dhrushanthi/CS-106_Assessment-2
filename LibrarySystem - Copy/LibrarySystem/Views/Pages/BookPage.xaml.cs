using LibrarySystem.Model;
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
    /// Interaction logic for BookPage.xaml
    /// </summary>
    public partial class BookPage : Page
    {
        private readonly BookPageVM _viewModel;
        public BookPage()
        {
            InitializeComponent();
        }
        public BookPage(int BookID, user userLogin)
        {
            InitializeComponent();
            _viewModel = new BookPageVM(BookID, userLogin);
            DataContext = _viewModel;
            BookAvailbilty.Text = _viewModel.SelectedBook.Availbility.ToString();
            BookAuthor.Text = _viewModel.SelectedBook.Author;
            BookYear.Text= _viewModel.SelectedBook.Year.ToString();
            BookTitle.Text = _viewModel.SelectedBook.Title;
            BookDescription.Text = _viewModel.SelectedBook.Description;
            if (_viewModel.NoHistory==true&&_viewModel.UserLogin.Type=="U")
            {
                Booking.Visibility = Visibility.Visible;
                Returning.Visibility = Visibility.Collapsed;
                Canceling.Visibility = Visibility.Collapsed;
            }
            else if(_viewModel.HaveBooked==true && _viewModel.UserLogin.Type == "U")
            {
                Returning.Visibility = Visibility.Visible;
                Booking.Visibility = Visibility.Collapsed;
                Canceling.Visibility = Visibility.Collapsed;
            }
            else if (_viewModel.HavePrebook==true && _viewModel.UserLogin.Type == "U")
            {
                Canceling.Visibility = Visibility.Visible;
                Booking.Visibility = Visibility.Collapsed;
                Returning.Visibility = Visibility.Collapsed;
            }
            else if (_viewModel.UserLogin.Type=="A")
            {
                Modify.Visibility = Visibility.Visible;
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SwitchToMainPage(_viewModel.UserLogin);
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if(ModifyButton.IsChecked==true &&_viewModel.SelectedBook.Status=="A")
            {
                BookExist.Visibility = Visibility.Visible;
                BookAvailbilityBox.Visibility = Visibility.Visible;
                Edit.Visibility = Visibility.Visible;
                Edit1.Visibility = Visibility.Visible;
            }
            else if (ModifyButton.IsChecked == true && _viewModel.SelectedBook.Status == "D")
            {
                BookNotExist.Visibility = Visibility.Visible;
                BookAvailbilityBox.Visibility = Visibility.Visible;
                Edit.Visibility = Visibility.Visible;
                Edit1.Visibility = Visibility.Visible;
            }
            else if (ModifyButton.IsChecked == false && _viewModel.SelectedBook.Status == "A")
            {
                BookExist.Visibility = Visibility.Collapsed;
                BookAvailbilityBox.Visibility = Visibility.Collapsed;
                Edit.Visibility = Visibility.Collapsed;
                Edit1.Visibility = Visibility.Collapsed;
            }
            else if (ModifyButton.IsChecked == false && _viewModel.SelectedBook.Status == "D")
            {
                BookNotExist.Visibility = Visibility.Collapsed;
                BookAvailbilityBox.Visibility = Visibility.Collapsed;
                Edit.Visibility = Visibility.Collapsed;
                Edit1.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _viewModel.SwitchToProfilePage(_viewModel.UserLogin);
        }
    }
}

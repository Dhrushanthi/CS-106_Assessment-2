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
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private book selectedBook;
        private user selectedUser;
        private readonly ProfilePageVM _viewModel;
        public ProfilePage(user userlogin)
        {
            InitializeComponent();
            _viewModel = new ProfilePageVM(userlogin);
            DataContext = _viewModel;
            if(_viewModel.UserLogin.Type=="A")
            {
                AdminNav.Visibility = Visibility.Visible;
                UserNav.Visibility = Visibility.Collapsed;
                UserSelection.ItemsSource = _viewModel.UsersList;
                ViewUsersDisplay.Visibility = Visibility.Visible;
            }
            else if(_viewModel.UserLogin.Type == "U")
            {
                if (_viewModel.UserLogin.Gender == "F")
                {
                    ugender.Text = "Female";
                }
                else
                {
                    ugender.Text = "Male";
                }
                UserNav.Visibility = Visibility.Visible;
                AdminNav.Visibility = Visibility.Collapsed;
                ViewProfileDisplay.Visibility = Visibility.Visible;
            }
        }

        private void BorrowSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedBook = new book();
            selectedBook = e.AddedItems[0] as book;
            _viewModel.SwitchToBookPage(selectedBook.ID, _viewModel.UserLogin);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewProfileDisplay.Visibility = Visibility.Collapsed;
            PrebookDisplay.Visibility = Visibility.Collapsed;
            ReturnDisplay.Visibility = Visibility.Collapsed;
            BorrowDisplay.Visibility = Visibility.Visible;
            _viewModel.BorrowedDisplay();
            if(_viewModel.Borrow==true)
            {
                BorrowSelection.ItemsSource = _viewModel.BookDisplay;
                BorrowNull.Visibility = Visibility.Collapsed;
                BorrowSelection.Visibility = Visibility.Visible;
            }
            else
            {
                BorrowSelection.Visibility = Visibility.Collapsed;
                BorrowNull.Visibility = Visibility.Visible;
            }
        }

        private void ReturnSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedBook = new book();
            selectedBook = e.AddedItems[0] as book;
            _viewModel.SwitchToBookPage(selectedBook.ID, _viewModel.UserLogin);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ViewProfileDisplay.Visibility = Visibility.Collapsed;
            PrebookDisplay.Visibility = Visibility.Collapsed;
            BorrowDisplay.Visibility = Visibility.Collapsed;
            ReturnDisplay.Visibility = Visibility.Visible;
            _viewModel.ReturnDisplay();
            if (_viewModel.Return == true)
            {
                ReturnSelection.ItemsSource = _viewModel.BookDisplay;
                ReturnNull.Visibility = Visibility.Collapsed;
                ReturnSelection.Visibility = Visibility.Visible;
            }
            else
            {
                ReturnSelection.Visibility = Visibility.Collapsed;
                ReturnNull.Visibility = Visibility.Visible;
            }
        }

        private void PrebookSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedBook = new book();
            selectedBook = e.AddedItems[0] as book;
            _viewModel.SwitchToBookPage(selectedBook.ID, _viewModel.UserLogin);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ViewProfileDisplay.Visibility = Visibility.Collapsed;
            ReturnDisplay.Visibility = Visibility.Collapsed;
            BorrowDisplay.Visibility = Visibility.Collapsed;
            PrebookDisplay.Visibility = Visibility.Visible;
            _viewModel.PrebookDisplay();
            if (_viewModel.Prebook == true)
            {
                PrebookSelection.ItemsSource = _viewModel.BookDisplay;
                PrebookNull.Visibility = Visibility.Collapsed;
                PrebookSelection.Visibility = Visibility.Visible;
            }
            else
            {
                PrebookSelection.Visibility = Visibility.Collapsed;
                PrebookNull.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (_viewModel.UserLogin.Gender == "F")
            {
                ugender.Text = "Female";
            }
            else
            {
                ugender.Text = "Male";
            }
            ReturnDisplay.Visibility = Visibility.Collapsed;
            BorrowDisplay.Visibility = Visibility.Collapsed;
            PrebookDisplay.Visibility = Visibility.Collapsed;
            ViewProfileDisplay.Visibility = Visibility.Visible;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            UserSelection.ItemsSource = _viewModel.UsersList;
            UserProfileDisplay.Visibility = Visibility.Collapsed;
            ViewBooksDisplay.Visibility = Visibility.Collapsed;
            ViewUsersDisplay.Visibility = Visibility.Visible;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            BookSelection.ItemsSource = _viewModel.BooksList;
            UserProfileDisplay.Visibility = Visibility.Collapsed;
            ViewUsersDisplay.Visibility = Visibility.Collapsed;
            ViewBooksDisplay.Visibility = Visibility.Visible;
        }

        private void UserSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedUser = new user();
            selectedUser = e.AddedItems[0] as user;
            name.Text = selectedUser.Name;
            id.Text = selectedUser.ID.ToString();
            join.Text = selectedUser.JoinDate.ToString();
            if(selectedUser.Gender=="F")
            {
                gender.Text = "Female";
            }
            else
            {
                gender.Text = "Male";
            }
            dob.Text = selectedUser.DateOfBirth.ToString();
            ViewUsersDisplay.Visibility = Visibility.Collapsed;
            ViewBooksDisplay.Visibility = Visibility.Collapsed;
            UserProfileDisplay.Visibility = Visibility.Visible;
        }

        private void BookSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedBook = new book();
            selectedBook = e.AddedItems[0] as book;
            _viewModel.SwitchToBookPage(selectedBook.ID, _viewModel.UserLogin);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            _viewModel.SwitchToMainPage(_viewModel.UserLogin);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            _viewModel.SwitchToMainPage(_viewModel.UserLogin);
        }
    }
}

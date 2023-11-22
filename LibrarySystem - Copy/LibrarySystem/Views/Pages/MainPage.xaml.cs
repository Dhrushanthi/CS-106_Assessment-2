using LibrarySystem.Model;
using LibrarySystem.Services;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private book selectedBook;
        private readonly MainPageVM _viewModel;
        public MainPage()
        {
            InitializeComponent();
        }
        public MainPage(user UserLogin )
        {
            InitializeComponent();
            _viewModel = new MainPageVM(UserLogin);
            DataContext = _viewModel;
            Book.ItemsSource = _viewModel.BookDisplayS;
            BookR.ItemsSource = _viewModel.BookDisplayR;
            if (_viewModel.UserLogin.Type == "A")
            {
                Modify.Visibility = Visibility.Visible;
            }
            else
            {
                Modify.Visibility = Visibility.Collapsed;
            }
        }
        private void Modify_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Book.ItemsSource = _viewModel.BookDisplayS;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Book.ItemsSource = _viewModel.BookDisplayF;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Book.ItemsSource = _viewModel.BookDisplayD;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Book.ItemsSource = _viewModel.BookList;
        }
        private void BookR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedBook = new book();
            selectedBook = e.AddedItems[0] as book;
            _viewModel.SelectedBook = selectedBook;
            if (Modify.IsChecked==true)
            {
                ChangeGenre.Visibility = Visibility.Visible;
                title.Text = _viewModel.SelectedBook.Title;
                return;
            }
            else
            {
                _viewModel.SwitchToBookPage(_viewModel.SelectedBook.ID,_viewModel.UserLogin);
            }
        }

        private void Book_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedBook = new book();
            selectedBook = e.AddedItems[0] as book;
            _viewModel.SelectedBook = selectedBook;
            if (Modify.IsChecked == true)
            {
                ChangeGenre.Visibility = Visibility.Visible;
                title.Text = _viewModel.SelectedBook.Title;
                return;
            }
            else
            {
                _viewModel.SwitchToBookPage(_viewModel.SelectedBook.ID, _viewModel.UserLogin);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ChangeGenre.Visibility = Visibility.Collapsed;
            _viewModel.SwitchToMainPage(_viewModel.UserLogin);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            _viewModel.MoveCategories("S");
            _viewModel.SwitchToMainPage(_viewModel.UserLogin);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            _viewModel.MoveCategories("F");
            _viewModel.SwitchToMainPage(_viewModel.UserLogin);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            _viewModel.MoveCategories("D");
            _viewModel.SwitchToMainPage(_viewModel.UserLogin);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            _viewModel.SwitchToProfilePage(_viewModel.UserLogin);
        }
    }
}

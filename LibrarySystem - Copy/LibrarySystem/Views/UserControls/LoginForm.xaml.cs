﻿using LibrarySystem.ViewModels.Pages;
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
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : UserControl
    {
        public event EventHandler SignUpRequested;
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpRequested?.Invoke(this, EventArgs.Empty);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

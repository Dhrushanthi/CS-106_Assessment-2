using System;
using System.Windows;
using System.Windows.Controls;

namespace LIS1.View.Sign_Up
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            btnClose_Click();
        }

        private void ShowCalendar_Click(object sender, RoutedEventArgs e)
        {
       
            calendarPopup.IsOpen = true;
        }

        private void ShowGenderOptions_Click(object sender, RoutedEventArgs e)
        {
          
            genderOptionsPopup.IsOpen = true;
        }

        private void GenderOption_Click(object sender, RoutedEventArgs e)
        {
           
            Button button = sender as Button;
            if (button != null)
            {
                string selectedGender = button.Content.ToString();
                
            }

           
            genderOptionsPopup.IsOpen = false;
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
           
            string name = Name.Text;
            string email = Email.Text;
            
        }

        private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
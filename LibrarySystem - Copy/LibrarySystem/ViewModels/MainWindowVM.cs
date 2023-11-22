using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using LibrarySystem.Views.Pages;

namespace LibrarySystem.ViewModels
{
    class MainWindowVM : ViewModelBaseClass
    {
        public MainWindowVM()
        {
            CurrentDisplayPage = new LoginPage();
        }

        private Page _currentDisplayPage;
        public Page CurrentDisplayPage
        {
            get
            {
                return _currentDisplayPage;
            }

            set
            {
                _currentDisplayPage = value;
                OnPropertyChanged("CurrentDisplayPage");
            }
        }
    }
}

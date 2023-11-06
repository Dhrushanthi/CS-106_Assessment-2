using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibrarySystem.ViewModels
{
    class MainWindow : ViewModelBaseClass
    {
        public MainWindow()
        {
            //Very first default page when the app load
            //CurrentDisplayPage = new WelcomePage();
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

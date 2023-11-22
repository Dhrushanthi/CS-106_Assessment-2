using LibrarySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Model
{
    public class BookRecord:ViewModelBaseClass
    {
        private string _author;
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
                OnPropertyChanged("Author");
            }
        }
        private int _availbility;
        public int Availbility
        {
            get
            {
                return _availbility;
            }
            set
            {
                _availbility = value;
                OnPropertyChanged("Availbility");
            }
        }
        private int _year;
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
                OnPropertyChanged("Year");
            }
        }
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("Title");
            }
        }
    }
}

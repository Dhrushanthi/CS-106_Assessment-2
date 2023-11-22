using LibrarySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Model
{
    public class BorrowedRecord: ViewModelBaseClass
    {
        private DateTime _borrow;
        public DateTime Borrow
        {
            get
            {
                return _borrow;
            }
            set
            {
                _borrow = value;
                OnPropertyChanged("Borrow");
            }
        }
    }
}

using LibrarySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Model
{
    public class UserRecord:ViewModelBaseClass
    {
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        private string _gender;
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                OnPropertyChanged("Gender");
            }
        }
        private DateTime _dateofbirth;
        public DateTime DateOfBirth
        {
            get
            {
                return _dateofbirth;
            }
            set
            {
                _dateofbirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }
        private DateTime _joindate;
        public DateTime JoinDate
        {
            get
            {
                return _dateofbirth;
            }
            set
            {
                _dateofbirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }
    }
}

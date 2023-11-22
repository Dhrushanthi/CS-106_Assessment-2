using LibrarySystem.Model;
using LibrarySystem.DataAccess;
using LibrarySystem.Services;
using LibrarySystem.Views.UserControls;
using LibrarySystem.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Windows.Controls;

namespace LibrarySystem.ViewModels.Pages
{
    public class LoginViewModel : ViewModelBaseClass
    {
        private ICommand _login;
        private ICommand _signUp;
        private ICommand _forgetPassword;
        private ICommand _logOut;
        private ICommand _close;
        private UsersRepository _usersRepository { get; set; }
        public user UserLogin;
        public user UserPass;
        public ICommand Login
        {
            get
            {
                if (_login == null)
                    _login = new RelayCommand(param => LoginValidation(), null);

                return _login;
            }
        }
        public ICommand SignUp
        {
            get
            {
                if (_signUp == null)
                    _signUp = new RelayCommand(param => SignUpAccount(), null);
                return _signUp;
            }
        }
        public ICommand ForgetPassword
        {
            get
            {
                if (_forgetPassword == null)
                    _forgetPassword = new RelayCommand(param => ChangePassword(), null);
                return _forgetPassword;
            }
        }
        public ICommand LogOut
        {
            get
            {
                if (_logOut == null)
                    _logOut = new RelayCommand(param => ClearUser(), null);
                return _logOut;
            }
        }
        public ICommand Close
        {
            get
            {
                if (_close == null)
                    _close = new RelayCommand(param => Switch(), null);
                return _close;
            }
        }
        public void Switch()
        {
            
        }
        public UserRecord UserFormRecord {
            get; set;
        }
        public void LoginValidation()
        {
            string email = "Temp";
            string password = "Temp";
            if(UserFormRecord.Email!=null&&UserFormRecord.Password!=null)
            {
                email = UserFormRecord.Email;
                password = UserFormRecord.Password;
                var userFind = _usersRepository.Login(email, password);
                if (userFind != null)
                {
                    UserLogin = userFind;
                }
                else
                {
                    UserFormRecord.Email =null;
                    UserFormRecord.Password =null;
                    MessageBox.Show("Login failed!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please fill login!");
                    return;
            }
            ClickEventDefinition(new MainPage(UserLogin));
        }
        public void SignUpAccount()
        {
            bool CreateAccount = true;
            string email="Temp";
            string password = "Temp";
            string name = "Temp";
            string type = "U";
            string gender = "F";
            DateTime DOB =DateTime.Today;
            DateTime join = DateTime.Today;
            if (UserFormRecord.Email!= null)
            {
                email = UserFormRecord.Email;
                if (EmailValidation(email) == false)
                {
                    MessageBox.Show("Email is Invalid!");
                    UserFormRecord.Email = null;
                    CreateAccount = false;
                    return;
                }
            }
            else
            {
                MessageBox.Show("Email is Empty!");
                return;
            }
            if(UserFormRecord.Password!=null)
            {
                password = UserFormRecord.Password;
                if (PasswordValidation(password) == false)
                {
                    MessageBox.Show("Password must be 8 characters!(Min 1 number, and no special characters)");
                    UserFormRecord.Password = null;
                    CreateAccount = false;
                    return;
                }
            }
            else
            {
                MessageBox.Show("Password is Empty!");
                return;
            }
            if(UserFormRecord.Name!=null)
            {
                name = UserFormRecord.Name;
            }
            else
            {
                MessageBox.Show("Name is Empty!");
                return;
            }
            if (UserFormRecord.Gender != null)
            {
                gender = UserFormRecord.Gender;
            }
            else
            {
                MessageBox.Show("Gender is Empty!");
                return;
            }
            if (UserFormRecord.DateOfBirth != null)
            {
                DOB = UserFormRecord.DateOfBirth;
            }
            else
            {
                MessageBox.Show("Date of birth is Empty!");
                return;
            }
            if (CreateAccount == true)
            {
                var account = new user
                {
                    Email = email,
                    Password = password,
                    Name = name,
                    Type = type,
                    Gender = gender,
                    DateOfBirth = DOB,
                    JoinDate = join
                };
                _usersRepository.AddUser(account);
            }
            MessageBox.Show("Account is created!");
            SwitchToLoginForm();
        }
        public void ChangePassword()
        {
            string email = "Temp";
            string name = "Temp";
            string password = "temp";
            if (UserFormRecord.Email!=null&&UserFormRecord.Name!=null)
            {
                email = UserFormRecord.Email;
                name = UserFormRecord.Name;
                var userFind = _usersRepository.Get(email);
                if (userFind != null)
                {
                    if (userFind.Name == name)
                    {
                        UserPass.Password = userFind.Password;
                        if (UserFormRecord.Password!=null)
                        {
                            password = UserFormRecord.Password;
                            if (PasswordValidation(password) == false)
                            {
                                MessageBox.Show("Password must be 8 characters!(Min 1 number, and no special characters)");
                                //Password=null;
                                return;
                            }
                            else
                            {
                                userFind.Password = password;
                                _usersRepository.UpdateUser(userFind);
                                MessageBox.Show("Password succesfully changed!");
                                SwitchToLoginForm();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Account is Valid! Please insert password!");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Name doesn't match!");
                        UserFormRecord.Name = null;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Email is not existed!");
                    UserFormRecord.Email = null;
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please fill the name and email!");
                return;
            }
        }
        public void ClearUser()
        {
            UserLogin = new user();
            SwitchToLoginForm();
        }
        static bool EmailValidation(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            return Regex.IsMatch(email, emailPattern);
        }
        static bool PasswordValidation(string password)
        {
            string passwordPattern = @"^(?=.*\d)[A-Za-z\d]{8,}$";
            return Regex.IsMatch(password, passwordPattern);
        }
        public void SwitchToLoginForm()
        {
            ClickEventDefinition(new LoginPage());
        }
        public void SwitchToSignUpForm()
        {
            ClickEventDefinition(new SignUpPage());
        }
        private void SwitchToChangeForm()
        {
            ClickEventDefinition(new ChangeFormPage());
        }
        public void SwitchToMainPage(user user)
        {
            ClickEventDefinition(new MainPage(user));
        }
        public void SwitchToBookPage(int id, user login)
        {
            ClickEventDefinition(new BookPage(id,login));
        }
        public void SwitchToProfilePage(user login)
        {
            ClickEventDefinition(new ProfilePage(login));
        }
        public LoginViewModel()
        {

            UserFormRecord = new UserRecord();
            _usersRepository = new UsersRepository();
            UserLogin = new user();
            UserPass = new user();
            SwitchToLoginFormCommand = new RelayCommand(param => SwitchToLoginForm());
            SwitchToSignUpFormCommand = new RelayCommand(param => SwitchToSignUpForm());
            SwitchToChangeFormCommand = new RelayCommand(param => SwitchToChangeForm());
        }
        public ICommand SwitchToLoginFormCommand { get; set; }
        public ICommand SwitchToSignUpFormCommand { get; set; }
        public ICommand SwitchToChangeFormCommand { get; set; }
        private void ClickEventDefinition(Page destinationPage)
        {
            MainWindowVM mainVM = (MainWindowVM)Application.Current.MainWindow.DataContext;
            mainVM.CurrentDisplayPage = destinationPage;
        }

    }
}

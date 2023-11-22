using LibrarySystem.DataAccess;
using LibrarySystem.Model;
using LibrarySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibrarySystem.ViewModels.Pages
{
    public class BookPageVM : LoginViewModel
    {
        public user UserLogin;
        public book SelectedBook;
        public List<borrowed> UserBooks;
        public borrowed UserBook;
        public BorrowedRecord BookForm
        {
            get;set;
        }
        public BookRecord ChangedForm
        {
            get;set;
        }
        private BooksRepository _booksRepository;
        private BorrowedRepository _borrowedRepository;
        public bool NoHistory=false;
        public bool HavePrebook=false;
        public bool HaveBooked=false;
        private ICommand _booking;
        private ICommand _canceling;
        private ICommand _returning;
        private ICommand _saveUpdate;
        private ICommand _deleteBook;
        private ICommand _addBook;
        public ICommand SaveUpdate
        {
            get
            {
                if (_saveUpdate == null)
                    _saveUpdate = new RelayCommand(param => BookChanged(), null);
                return _saveUpdate;
            }
        }
        public ICommand DeleteBook
        {
            get
            {
                if (_deleteBook == null)
                    _deleteBook = new RelayCommand(param => BookDelete(), null);
                return _deleteBook;
            }
        }
        public ICommand AddBook
        {
            get
            {
                if (_addBook == null)
                    _addBook = new RelayCommand(param => BookAdd(), null);
                return _addBook;
            }
        }
        public ICommand Booking
        {
            get
            {
                if (_booking == null)
                    _booking = new RelayCommand(param => MakeABooking(), null);
                return _booking;
            }
        }
        public ICommand Canceling
        {
            get
            {
                if (_canceling == null)
                    _canceling = new RelayCommand(param => CancelABooking(), null);
                return _canceling;
            }
        }
        public ICommand Returning
        {
            get
            {
                if (_returning == null)
                    _returning = new RelayCommand(param => ReturningABooking(), null);
                return _returning;
            }
        }
        public void MakeABooking()
        {
            DateTime bookdate = DateTime.Today;
            DateTime returndate = bookdate.AddDays(+3);
            string status = "B";
            if(BookForm.Borrow<bookdate)
            {
                MessageBox.Show("Please select proper date!");
                return;
            }
            else if(BookForm.Borrow>bookdate)
            {
                bookdate = BookForm.Borrow;
                returndate= bookdate.AddDays(+3);
                status = "P";
            }
            var booking = new borrowed();
            booking.BookID = SelectedBook.ID;
            booking.UserID = UserLogin.ID;
            booking.Borrow = bookdate;
            booking.Return = returndate;
            booking.Status = status;
            var bookupdate = SelectedBook;
            bookupdate.Availbility -= 1;
            _booksRepository.UpdateBooks(bookupdate);
            if(status=="B"&& SelectedBook.Availbility>0)
            {
                MessageBox.Show("Booking have been made! Your book returning date is "+returndate);
                _borrowedRepository.AddBorrowed(booking);
                SwitchToBookPage(SelectedBook.ID, UserLogin);
            }
            else if(status == "B"&&SelectedBook.Availbility<=0)
            {
                MessageBox.Show("Pre- Booking have been made! Waiting for book availbility!");
                booking.Status = "P";
                _borrowedRepository.AddBorrowed(booking);
                SwitchToBookPage(SelectedBook.ID, UserLogin);
            }
            else if(status=="P")
            {
                MessageBox.Show("Pre-booking have been made! Don't forget to take the book!");
                _borrowedRepository.AddBorrowed(booking);
                SwitchToBookPage(SelectedBook.ID, UserLogin);
            }
        }
        public void CancelABooking()
        {
            string status = "C";
            UserBook.Status = status;
            _borrowedRepository.UpdateBorrowed(UserBook);
            var bookupdate = SelectedBook;
            bookupdate.Availbility += 1;
            _booksRepository.UpdateBooks(bookupdate);
            MessageBox.Show("Pre-Booking of " + SelectedBook.Title + " is canceled!");
            SwitchToBookPage(SelectedBook.ID, UserLogin);
        }
        public void ReturningABooking()
        {
            string status = "R";
            UserBook.Status = status;
            _borrowedRepository.UpdateBorrowed(UserBook);
            var bookupdate = SelectedBook;
            bookupdate.Availbility += 1;
            _booksRepository.UpdateBooks(bookupdate);
            MessageBox.Show(SelectedBook.Title+" is returned!");
            SwitchToBookPage(SelectedBook.ID, UserLogin);
        }
        public void BookChanged()
        {
            SelectedBook.Title = ChangedForm.Title;
            SelectedBook.Author = ChangedForm.Author;
            SelectedBook.Availbility = ChangedForm.Availbility;
            SelectedBook.Year =  ChangedForm.Year;
            SelectedBook.Description = ChangedForm.Description;
            _booksRepository.UpdateBooks(SelectedBook);
            SwitchToBookPage(SelectedBook.ID, UserLogin);
        }
        public void BookDelete()
        {
            SelectedBook.Status = "D";
            _booksRepository.UpdateBooks(SelectedBook);
            MessageBox.Show(SelectedBook.Title+(" have been deleted from book display!"));
            SwitchToBookPage(SelectedBook.ID, UserLogin);
        }
        public void BookAdd()
        {
            SelectedBook.Status = "A";
            _booksRepository.UpdateBooks(SelectedBook);
            MessageBox.Show(SelectedBook.Title + (" have been added to book display!"));
            SwitchToBookPage(SelectedBook.ID, UserLogin);
        }
        public void UserBookSort()
        {
            if(UserLogin.Type=="A")
            {
                return;
            }
            else
            {
                UserBooks = _borrowedRepository.BookPageBorrow(SelectedBook.ID, UserLogin.ID);
                UserBook = UserBooks.FirstOrDefault(a => a.Status == "P" || a.Status == "B");
            }
            if(UserBook!=null)
            {
                if (UserBook.Status == "P")
                {
                    HavePrebook = true;
                }
                else if (UserBook.Status == "B")
                {
                    HaveBooked = true;
                }
            }
            else
            {
                NoHistory = true;
            }
        }
        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                if (_imagePath != value)
                {
                    _imagePath = value;
                    OnPropertyChanged(nameof(ImagePath));
                }
            }
        }
        public BookPageVM(int bookid,user userlogin)
        {
            _booksRepository = new BooksRepository();
            _borrowedRepository = new BorrowedRepository();
            BookForm = new BorrowedRecord();
            ChangedForm = new BookRecord();
            UserLogin = userlogin;
            SelectedBook = _booksRepository.Select(bookid);
            ImagePath = SelectedBook.Image;
            ChangedForm.Title = SelectedBook.Title;
            ChangedForm.Author = SelectedBook.Author;
            ChangedForm.Description = SelectedBook.Description;
            ChangedForm.Year = (int)SelectedBook.Year;
            ChangedForm.Availbility = (int)SelectedBook.Availbility;
            UserBookSort();
        }
    }
}

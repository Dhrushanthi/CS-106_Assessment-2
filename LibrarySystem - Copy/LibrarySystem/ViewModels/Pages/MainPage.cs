using LibrarySystem.Model;
using LibrarySystem.DataAccess;
using LibrarySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Text.RegularExpressions;

namespace LibrarySystem.ViewModels.Pages
{
    public class MainPageVM:LoginViewModel
    {
        public user UserLogin;
        public book SelectedBook;
        public BookRecord _bookRecord;
        public List<book> BookList { get; set; }
        public List<book> BookDisplayF{ get; set;}
        public List<book> BookDisplayS { get; set; }
        public List<book> BookDisplayD { get; set; }
        public List<book> BookDisplayR { get; set; }
        public List<borrowed> UserBooks { get; set; }
        public List<borrowed> UserBorrowed { get; set; }
        public List<borrowed> UserPrebook { get; set; }
        public List<borrowed> UserReturn { get; set; }
        private BooksRepository _bookRepository;
        public BorrowedRepository _borrowedRepository;
        private bool Late()
        {
            return UserBooks.Any(book => book.Return < DateTime.Now&& book.Status=="B");
        }
        private void BookFilter()
        {
            _bookRepository = new BooksRepository();
            if(BookList!=null)
            {
                return;
            }
            else
            {
                BookList = _bookRepository.GetAll();
                BookDisplayF = BookList.Where(book => book.Genre == "F" && book.Status == "A").ToList();
                BookDisplayS = BookList.Where(book => book.Genre == "S" && book.Status == "A").ToList();
                BookDisplayD = BookList.Where(book => book.Genre == "D" && book.Status == "A").ToList();
                BookDisplayR = BookList.Where(book =>(book.ID == 1 && book.Status == "A") || (book.ID == 7 && book.Status == "A") || (book.ID == 9 && book.Status == "A") || (book.ID == 11 && book.Status == "A") || (book.ID == 12 && book.Status == "A") || (book.ID == 13 && book.Status == "A") || (book.ID == 17 && book.Status == "A") || (book.ID == 23 && book.Status == "A") || (book.ID == 25 && book.Status == "A") || (book.ID == 26 && book.Status == "A") ).ToList();
            }
        }
        public void UserBookFilter()
        {
            _borrowedRepository = new BorrowedRepository();
            if (UserLogin.Type == "A")
            {
                return;
            }
            if(UserBooks==null)
            {
                UserBooks = new List<borrowed>();
            }
            else
            {
                UserBooks.Clear();
            }
            UserBorrowed = new List<borrowed>();
            UserPrebook = new List<borrowed>();
            UserReturn = new List<borrowed>();
            UserBooks = _borrowedRepository.GetAll(UserLogin.ID);
            if (Late() == true)
            {
                MessageBox.Show("Please check borrowed book to return!");
            }
            int bookcount = UserBooks.Count(borrowed => borrowed.Status == "B");
            if (bookcount >0)
            {
                if (bookcount == 1)
                {
                    MessageBox.Show(bookcount + " book is borrowed! Don't forget to check the return date!");
                }
                else
                {
                    MessageBox.Show(bookcount + " books are borrowed! Don't forget to check the return date!");
                }
            }
            UserBorrowed = UserBooks.Where(book => book.Status == "O").ToList();
            UserPrebook = UserBooks.Where(book => book.Status == "P").ToList();
            UserReturn = UserBooks.Where(book => book.Status == "R").ToList();
        }
        public void MoveCategories(string genre)
        {
            SelectedBook.Genre = genre;
            _bookRepository.UpdateBooks(SelectedBook);
        }
        public MainPageVM(user userLogin)
        {
            UserLogin = userLogin;
            BookFilter();
            _bookRecord = new BookRecord();
            SelectedBook=new book();
            UserBookFilter();
        }
    }
}

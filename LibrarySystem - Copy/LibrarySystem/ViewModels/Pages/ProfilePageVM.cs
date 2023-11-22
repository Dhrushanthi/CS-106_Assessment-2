using LibrarySystem.DataAccess;
using LibrarySystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.ViewModels.Pages
{
    public class ProfilePageVM:LoginViewModel
    {
        public user UserLogin { get; set; }
        public user UserFind { get; set; }
        public List<borrowed> UserBooks;
        public List<borrowed> UserReturn;
        public List<borrowed> UserPrebook;
        public List<borrowed> UserBorrow;
        public List<user> UsersList { get; set; }
        public List<book> BooksList { get; set; }
        public List<book> BookDisplay;
        private BooksRepository _booksRepository;
        private UsersRepository _usersRepository;
        private BorrowedRepository _borrowedRepository;
        public bool Return = false;
        public bool Borrow = false;
        public bool Prebook = false;
        public void Profile()
        {
            _booksRepository = new BooksRepository();
            BooksList = new List<book>();
            BooksList = _booksRepository.GetAll();
            if (UserLogin.Type=="A")
            {
                _usersRepository = new UsersRepository();
                UsersList = new List<user>();
                UsersList = _usersRepository.GetAll();
                return;
            }

            _borrowedRepository = new BorrowedRepository();
            UserBooks = new List<borrowed>();
            UserReturn = new List<borrowed>();
            UserPrebook = new List<borrowed>();
            UserBorrow = new List<borrowed>();
            UserBooks = _borrowedRepository.GetAll(UserLogin.ID);
            if(UserBooks!= null)
            {
                UserReturn = UserBooks.Where(a => a.Status == "R").ToList();
                UserPrebook = UserBooks.Where(a => a.Status == "P").ToList();
                UserBorrow = UserBooks.Where(a => a.Status == "B").ToList();
            }
        }
        public void ReturnDisplay()
        {
            BookDisplay = new List<book>();
            if(UserReturn.Count > 0)
            {
                Return = true;
                BookDisplay = BooksList.Join(UserReturn, a => a.ID, b => b.BookID, (a, b) => new book {ID=a.ID,Author=a.Author,Title=a.Title,Image=a.Image }).ToList();
            }
            else
            {
                return;
            }
        }
        public void BorrowedDisplay()
        {
            BookDisplay = new List<book>();
            if (UserBorrow.Count > 0)
            {
                Borrow = true;
                BookDisplay = BooksList.Join(UserBorrow, a => a.ID, b => b.BookID, (a, b) => new book { ID = a.ID, Author = a.Author, Title = a.Title, Image = a.Image }).ToList();
            }
            else
            {
                return;
            }
        }
        public void PrebookDisplay()
        {
            BookDisplay = new List<book>();
            if (UserPrebook.Count>0)
            {
                Prebook = true;
                BookDisplay = BooksList.Join(UserPrebook, a => a.ID, b => b.BookID, (a, b) => new book { ID = a.ID, Author = a.Author, Title = a.Title, Image = a.Image }).ToList();
            }
            else
            {
                return;
            }
        }
        public void FindUser(int userid)
        {
            UserFind = new user();
            UserFind= UsersList.FirstOrDefault(a => a.ID == userid);
        }
        public ProfilePageVM(user userlogin)
        {
            UserLogin = userlogin;
            Profile();
        }
    }

}

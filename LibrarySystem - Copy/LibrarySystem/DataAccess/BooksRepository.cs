using LibrarySystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DataAccess
{
    public class BooksRepository
    {
        private BooksEntities booksContext = null;
        public BooksRepository()
        {
            booksContext = new BooksEntities();
        }
        public book Get(int id)
        {
            return booksContext.books.Find(id);
        }
        public book Select(int id)
        {
            return booksContext.books.FirstOrDefault(a => a.ID == id);
        }
        public List<book>GetAll()
        {
            return booksContext.books.ToList();
        }
        public void UpdateBooks(book Book)
        {
            var bookFind = this.Get(Book.ID);
            if(bookFind!=null)
            {
                bookFind.Author = Book.Author;
                bookFind.Availbility = Book.Availbility;
                bookFind.Genre = Book.Genre;
                bookFind.Status = Book.Status;
                bookFind.Year = Book.Year;
                bookFind.Title = Book.Title;
                booksContext.SaveChanges();
            }
        }
    }
}

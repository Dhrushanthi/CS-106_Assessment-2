using LibrarySystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DataAccess
{
    public class BorrowedRepository
    {
        BorrowedEntities borrowedContext = null;
        public BorrowedRepository()
        {
            borrowedContext = new BorrowedEntities();
        }
        public borrowed Get(int number)
        {
            return borrowedContext.borroweds.Find(number);
        }
        public List<borrowed> GetAll(int userid)
        {
            return borrowedContext.borroweds.Where(b=>b.UserID==userid).ToList();
        }

        public List<borrowed> BookPageBorrow(int bookid,int userid)
        {
            return borrowedContext.borroweds.Where(b => b.BookID == bookid && b.UserID == userid).ToList();
        }
        public void AddBorrowed(borrowed Borrowed)
        {
            if(Borrowed!=null)
            {
                borrowedContext.borroweds.Add(Borrowed);
                borrowedContext.SaveChanges();
            }
        }
        public void UpdateBorrowed(borrowed Borrowed)
        {
            var borrowedFind = this.Get(Borrowed.Number);
            if(borrowedFind!=null)
            {
                borrowedFind.Return = Borrowed.Return;
                borrowedFind.Status = Borrowed.Status;
                borrowedContext.SaveChanges();
            }
        }
    }
}

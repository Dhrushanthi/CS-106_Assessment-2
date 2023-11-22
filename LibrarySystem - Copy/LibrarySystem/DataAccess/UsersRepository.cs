using LibrarySystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DataAccess
{
    public class UsersRepository
    {
        private UsersEntities usersContext = null;
        public UsersRepository()
        {
            usersContext = new UsersEntities();
        }
        public user Get(int id)
        {
            return usersContext.users.Find(id);
        }
        public user Get(string email)
        {
            return usersContext.users.FirstOrDefault(a => a.Email == email);
        }
        public List<user> GetAll()
        {
            return usersContext.users.ToList();
        }
        public user Login(string email,string password)
        {
            var userLogin = usersContext.users.FirstOrDefault(a => a.Email == email);

            if(userLogin!=null&&userLogin.Password==password)
            {
                return userLogin;
            }
            return null;
        }
        public void AddUser(user User)
        {
            if (User!=null)
            {
                usersContext.users.Add(User);
                usersContext.SaveChanges();
            }
        }
        public void UpdateUser(user User)
        {
            var userFind = this.Get(User.ID);
            if(userFind!=null)
            {
                userFind.Email = User.Email;
                userFind.Password = User.Password;
                userFind.Name = User.Name;
                userFind.Gender = User.Gender;
                userFind.DateOfBirth = User.DateOfBirth;
                usersContext.SaveChanges();
            }
        }
    }
}

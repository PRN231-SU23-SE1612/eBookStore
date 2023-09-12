using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class UserRepository : IUserRepository
    {
        public void DeleteUser(User User)
        {
            UserDAO.DeleteUser(User);
        }

        public User GetUserById(int UserId)
        {
            var u = UserDAO.GetUserById(UserId);
            return u;
        }

        public List<User> GetUsers()
        {
            List<User> users = UserDAO.GetUsers();
            return users;
        }

        public void SaveUser(User User)
        {
            UserDAO.SaveUser(User);
        }

        public void UpdateUser(User User)
        {
            UserDAO.UpdateUser(User);
        }
    }
}

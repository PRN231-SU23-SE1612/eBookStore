using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUserById(int UserId);
        void SaveUser(User User);
        void UpdateUser(User User);
        void DeleteUser(User User);
    }
}

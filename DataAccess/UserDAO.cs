using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDAO
    {
        public static List<User> GetUsers()
        {
            var listUsers = new List<User>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    listUsers = context.Users.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listUsers;
        }

        public static User GetUserById(int UserId)
        {
            var User = new User();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    User = context.Users.FirstOrDefault(x => x.Id == UserId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return User;
        }

        public static void SaveUser(User User)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Users.Add(User);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateUser(User User)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry<User>(User).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteUser(User User)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var u = context.Users.SingleOrDefault(x => x.Id == User.Id);
                    context.Users.Remove(u);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

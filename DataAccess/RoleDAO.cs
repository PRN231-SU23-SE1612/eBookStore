using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RoleDAO
    {
        public static List<Role> GetRoles()
        {
            var listRoles = new List<Role>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    listRoles = context.Roles.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listRoles;
        }

        public static Role GetRoleById(int RoleId)
        {
            var Role = new Role();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Role = context.Roles.FirstOrDefault(x => x.RoleId == RoleId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Role;
        }

        public static void SaveRole(Role Role)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Roles.Add(Role);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateRole(Role Role)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry<Role>(Role).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteRole(Role Role)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var u = context.Roles.SingleOrDefault(x => x.RoleId == Role.RoleId);
                    context.Roles.Remove(u);
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

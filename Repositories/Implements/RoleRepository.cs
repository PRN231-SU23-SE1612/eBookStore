using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class RoleRepository : IRoleRepository
    {
        public void DeleteRole(Role Role)
        {
            RoleDAO.DeleteRole(Role);
        }

        public Role GetRoleById(int RoleId)
        {
            var u = RoleDAO.GetRoleById(RoleId);
            return u;
        }

        public List<Role> GetRoles()
        {
            List<Role> Roles = RoleDAO.GetRoles();
            return Roles;
        }

        public void SaveRole(Role Role)
        {
            RoleDAO.SaveRole(Role);
        }

        public void UpdateRole(Role Role)
        {
            RoleDAO.UpdateRole(Role);
        }
    }
}

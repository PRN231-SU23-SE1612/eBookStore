using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoleRepository
    {
        List<Role> GetRoles();
        Role GetRoleById(int RoleId);
        void SaveRole(Role Role);
        void UpdateRole(Role Role);
        void DeleteRole(Role Role);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp
{
    public class RolesInMemoryRepository : IRolesRepository
    {
        private List<Role> roles = new List<Role>();

        public List<Role> GetRoles()
        {
            return roles;
        }

        public void AddRole(Role role)
        {
            roles.Add(role);
        }
       
        public void RoleDelete(string role)
        {
            roles.RemoveAll(x => x.Name == role);
        }

        public Role TryGetByName(string name)
        {
            return roles.FirstOrDefault(role => role.Name == name);
        }
    }
}

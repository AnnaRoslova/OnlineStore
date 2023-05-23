using System;
using System.Collections.Generic;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp
{
    public interface IRolesRepository
    {
        void AddRole(Role role);
        List<Role> GetRoles();
        void RoleDelete(string role);
        public Role TryGetByName(string name);
    }
}
using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp
{
    public class UsersManeger: IUserManeger
    {
        private List<UserAccount> users = new List<UserAccount>();

        public List<UserAccount> GetAllUsers()
        {
            return users;
        }

        public void AddUser (UserAccount user)
        {
            users.Add(user);
        }

        public UserAccount TryGetByName(string name)
        {
            return users.FirstOrDefault(x => x.UserName == name);
        }

        public void Update(UserAccount userAccount)
        {
            var existingUser = users.FirstOrDefault(x => x.UserName == userAccount.UserName);
            if (existingUser == null)
            {
                return;
            }
            existingUser.UserName = userAccount.UserName;
            existingUser.Phone = userAccount.Phone;
            existingUser.Email = userAccount.Email;
            existingUser.Password = userAccount.Password;
        }

        public void ChangePassword(string name, string newPassword)
        {
            var account = TryGetByName(name);
            account.Password = newPassword;
        }
    }
}

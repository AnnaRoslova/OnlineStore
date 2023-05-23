using System.Collections.Generic;
using OnlineShopWebApp.Models;
namespace OnlineShopWebApp
{
    public interface IUserManeger
    {
        public List<UserAccount> GetAllUsers();
        public void AddUser(UserAccount user);

        public UserAccount TryGetByName(string name);
        void Update(UserAccount userAccount);
        void ChangePassword(string name, string newPassword);
    }
}
using OnlineShopWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp.Controllers
{
    [Area("User")]
    public class AccountController : Controller
    {
        private readonly IUserManeger users;

        public AccountController(IUserManeger users)
        {
            this.users = users;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
                return View(nameof(Login));

            var userAccount = users.TryGetByName(login.UserName);
            if (userAccount == null)
            {
                ModelState.AddModelError("", "Пользователь не найден!");
                return View(nameof(Login));
            }
            if (userAccount.Password != login.Password)
            {
                ModelState.AddModelError("", "Неверный пароль!");
                return View(nameof(Login));
            }
            return RedirectToAction( nameof(HomeController.Index)   , "Home");
        }   

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                users.AddUser(new UserAccount
                {
                    UserName = register.UserName,
                    Phone = register.Phone,
                    Email = register.Email,
                    Password = register.Password
                });
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View(nameof(Register));
        }

    }
}

using OnlineShopWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager; 
        private readonly SignInManager<User> signInManager;
        private readonly IUserManeger userManeger;
        public UserController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public ActionResult Index()
        {
            var users = userManager.Users.ToList();
            //var users = userManeger.GetAllUsers();
            if (users != null)
                return View(users);
            return View();
        }

        public ActionResult Add()
        {
            return View("NewUser");
        }

        [HttpPost]
        public ActionResult Add(Register register)
        {
            if (ModelState.IsValid)
            {
                userManeger.AddUser(new UserAccount
                {
                    UserName = register.UserName,
                    Phone = register.Phone,
                    Email = register.Email,
                    Password = register.Password
                });
                return RedirectToAction("Index", "User");
            }
            return View("NewUser");
        }

        public IActionResult Detail(string name)
        {
            var user = userManeger.TryGetByName(name);
            return View(user);
        }

        public IActionResult ChangePassword(string name)
        {
            var changePassword = new ChangePassword
            {
                UserName = name
            };
            return View(changePassword);
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (ModelState.IsValid)
            {
                userManeger.ChangePassword(changePassword.UserName, changePassword.Password);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ChangePassword));
        }
        public IActionResult Edit(string name)
        {
            var user = userManeger.TryGetByName(name);
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(UserAccount userAccount)
        {
            if (!ModelState.IsValid)
            {
                return View(userAccount);
            }
            userManeger.Update(userAccount);
            return RedirectToAction(nameof(Index));
        }
    }
}

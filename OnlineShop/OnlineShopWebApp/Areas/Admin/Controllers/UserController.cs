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
        public UserController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public ActionResult Index()
        {
            var users = userManager.Users.ToList();
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
                User user = new User { Email = register.Email, UserName = register.UserName, Phone = register.Phone };

                var resulst = userManager.CreateAsync(user, register.Password).Result;
                if (resulst.Succeeded)
                {
                    signInManager.SignInAsync(user, false).Wait();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in resulst.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View("NewUser");
        }

        public IActionResult Detail(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
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
                var user = userManager.FindByNameAsync(changePassword.UserName).Result;
                userManager.ChangePasswordAsync(user, changePassword.CurrentPassword,changePassword.Password).Wait();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ChangePassword));
        }
        public IActionResult Edit(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User user, string userId)
        {
            if (ModelState.IsValid)
            {
                var userEdit = userManager.FindByIdAsync(userId).Result;
                userEdit.UserName = user.UserName;
                userEdit.Password = user.Password;
                userEdit.Email = user.Email;
                userEdit.Phone = user.Phone;
                userManager.UpdateAsync(userEdit).Wait();

            }
            return RedirectToAction(nameof(Index));
        }
    }
}

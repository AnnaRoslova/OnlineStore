using OnlineShopWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShop.Db;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineShopWebApp.Controllers
{
    [Area("User")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login(string returnUrl)
        {
            return View(new Login() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    return Redirect(login.ReturnUrl ?? "/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль!");
                }
            }
            return View("Login", login);
        }
        public IActionResult Logout()
        {
            return View(nameof(HomeController.Index), "Home");
        }

        public IActionResult Register(string returnUrl)
        {
            return View(new Register() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public IActionResult Register(Register register)
        {
            if(register.UserName == register.Password)
            {
                ModelState.AddModelError("","Логин и пароль совпадают!");
            }
            if (ModelState.IsValid)
            {
                User user = new User { Email = register.Email, UserName = register.UserName, Phone = register.Phone };

                var resulst = _userManager.CreateAsync(user, register.Password).Result;
                if (resulst.Succeeded)
                {
                    _signInManager.SignInAsync(user, false).Wait();
                    return Redirect(register.ReturnUrl ?? "/Home");
                }
                else
                {
                    foreach (var error in resulst.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(register);
        }

    }
}

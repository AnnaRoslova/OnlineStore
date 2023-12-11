using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Db;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RoleController : Controller
    {
        private readonly IRolesRepository rolesRepository;
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(IRolesRepository rolesRepository, RoleManager<IdentityRole> roleManager)
        {
            this.rolesRepository = rolesRepository;
            this.roleManager = roleManager;
        }
        public ActionResult Index()
        {
            var roles = roleManager.Roles.ToList(); 
            if (roles != null)
            {
                return View(roles);
            }
            return View();
        }
        public ActionResult Remove(string roleName)
        {
            var role = roleManager.FindByNameAsync(roleName).Result;
            if (role != null)
            {
                roleManager.DeleteAsync(role).Wait();
            }
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Role role)
        {
            if (roleManager.FindByNameAsync(role.Name).Result == null)
            {
                if(ModelState.IsValid) 
                {
                    roleManager.CreateAsync(new IdentityRole(role.Name)).Wait();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(role);
        }
    }
}

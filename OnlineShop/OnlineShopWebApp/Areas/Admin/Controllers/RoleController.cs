using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRolesRepository rolesRepository;

        public RoleController(IRolesRepository rolesRepository)
        {
            this.rolesRepository = rolesRepository;
        }
        public ActionResult Index()
        {
            var roles = rolesRepository.GetRoles();
            if (roles != null)
            {
                return View(roles);
            }
            return View();
        }
        public ActionResult Remove(string roleName)
        {
            rolesRepository.RoleDelete(roleName);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Role role)
        {
            if (rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError(" ", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                rolesRepository.AddRole(role);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Orders()
        {
            return View();
        }
        public ActionResult Users()
        {
            return View();
        }

        public ActionResult Roles()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }
    }
}

using System;
using Microsoft.AspNetCore.Mvc;
namespace OnlineShopWebApp.Controllers
{
    public class CompareController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly ICompareRepository compareInMemoryRepository;
        private readonly User user;

        public CompareController(IProductsStorage productsStorage, User user, ICompareRepository compareInMemoryRepository = null)
        {
            this.productsStorage = productsStorage;
            this.user = user;
            this.compareInMemoryRepository = compareInMemoryRepository;
        }

        public IActionResult Index()
        {
            var Compare = compareInMemoryRepository.TryGetBuUserId(user.UserId);
            return View(Compare);
        }
        public IActionResult Add(int productid)
        {
            var product = productsStorage.TryGetById(productid);
            compareInMemoryRepository.Add(product, user.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear(User user)
        {
            compareInMemoryRepository.Clear(user.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int productid)
        {
            compareInMemoryRepository.Delete(productid, user.UserId);
            return RedirectToAction("Index");
        }
    }
}
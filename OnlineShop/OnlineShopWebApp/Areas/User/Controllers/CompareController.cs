using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Area("User")]
    public class CompareController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly ICompareRepository compareInMemoryRepository;

        public CompareController(IProductsStorage productsStorage, ICompareRepository compareInMemoryRepository)
        {
            this.productsStorage = productsStorage;
            this.compareInMemoryRepository = compareInMemoryRepository;
        }

        public IActionResult Index()
        {
            var Compare = compareInMemoryRepository.TryGetBuUserId(Constants.UserId);
            var CompareToViewModel = new CompareViewModel 
            { 
                Id = Compare.Id,
                UserId = Constants.UserId,
                productsCompare = Mapping.productViewModels(Compare.productsCompare)
            };
            return View(CompareToViewModel);
        }
        public IActionResult Add(Guid productid)
        {
            var product = productsStorage.TryGetById(productid);
            compareInMemoryRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear(User user)
        {
            compareInMemoryRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid productid)
        {
            compareInMemoryRepository.Delete(productid, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
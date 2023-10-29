using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsStorage productsStorage;

        public ProductController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }
        public ActionResult Index()
        {
            var products = productsStorage.GetProducts();
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(Mapping.ToProductViewModel(product));
            }
            return View(productsViewModels);
        }
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var productDb = new Product
            {
                Name = product.Name,
                Color = product.Color,
                Cost = product.Cost,
                Compound = product.Compound,
                Description = product.Description,
                ImagePath = product.ImagePath,
                Manufactured = product.Manufactured
            };
            productsStorage.AddProduct(productDb);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(Guid productId)
        {
            var product = productsStorage?.TryGetById(productId);
            productsStorage.ProductDelete(product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(Guid id)
        {
            var product = productsStorage.TryGetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var productDb = new Product
            {
                Name = product.Name,
                Color = product.Color,
                Cost = product.Cost,
                Compound = product.Compound,
                Description = product.Description,
                ImagePath = product.ImagePath,
                Manufactured = product.Manufactured
            };
            productsStorage.Update(productDb);
            return RedirectToAction(nameof(Index));
        }
    }
}

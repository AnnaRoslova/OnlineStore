using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(IProductsStorage productsStorage, IWebHostEnvironment webHostEnvironment)
        {
            this.productsStorage = productsStorage;
            this.webHostEnvironment = webHostEnvironment;
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
                string productImagePath = Path.Combine(webHostEnvironment.WebRootPath + "/images/");
                if(!Directory.Exists(productImagePath))
                {
                    Directory.CreateDirectory(productImagePath);
                }
                var fileName = Guid.NewGuid() + "." + product.UploadedImage.FileName.Split('.').Last();
                using (var fileStream = new FileStream(productImagePath + fileName, FileMode.Create))
                {
                    product.UploadedImage.CopyTo(fileStream);
                }
                var productDb = new Product
                {
                    Name = product.Name,
                    Color = product.Color,
                    Cost = product.Cost,
                    Compound = product.Compound,
                    Description = product.Description,
                    ImagePath = "images/" + fileName,
                    Manufactured = product.Manufactured
                };
                productsStorage.AddProduct(productDb);
                return View(product);
            }
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
                if (product.UploadedImage != null)
                {
                    string productImagePath = Path.Combine(webHostEnvironment.WebRootPath + "/images/");
                    var fileName = Guid.NewGuid() + "." + product.UploadedImage.FileName.Split('.').Last();
                    using (var fileStream = new FileStream(productImagePath + fileName, FileMode.Create))
                    {
                        product.UploadedImage.CopyTo(fileStream);
                    }
                    var productDb = new Product
                    {
                        Name = product.Name,
                        Color = product.Color,
                        Cost = product.Cost,
                        Compound = product.Compound,
                        Description = product.Description,
                        ImagePath = "images/"+fileName,
                        Manufactured = product.Manufactured
                    };
                    productsStorage.Update(productDb);
                }
                return View(product);
            }
           
            return RedirectToAction(nameof(Index));
        }
    }
}

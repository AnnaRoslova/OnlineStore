using OnlineShop.Db;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Helpers
{
    public class Mapping
    {
        public static ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Color = product.Color,
                Cost = product.Cost,
                Description = product.Description,
                Manufactured = product.Manufactured,

            };
        }
        public static List<ProductViewModel> productViewModels(List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            }
            return productsViewModels;
        }
    }
}

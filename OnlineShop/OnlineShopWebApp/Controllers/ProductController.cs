using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public readonly ProductStorage produtStorage;
        public ProductController()
        {
            produtStorage = new ProductStorage();
        }
        public string Index (int id)
        {
            var product = produtStorage.TryGetById(id);
            if (product == null)
                return $"По id {id} товаров не найдено.";
            else
                return $"{product}{product.Description}\n{product.Color}\n{product.Compound}\n{product.Manufactured}\n";
        }
    }
}

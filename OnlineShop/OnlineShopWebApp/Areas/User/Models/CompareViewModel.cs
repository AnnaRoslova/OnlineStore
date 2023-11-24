using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class CompareViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }

        public List<ProductViewModel> productsCompare { get; set; }
    }
}

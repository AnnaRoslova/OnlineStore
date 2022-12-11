using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class Compare
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }

        public List<Product> productsCompare { get; set; }
    }
}

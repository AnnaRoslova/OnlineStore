using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db
{
    public class Product
    {
        public Guid Id { get; set; }

        public decimal Cost { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public string Compound { get; set; }

        public string Manufactured { get; set; }

        public string ImagePath { get; set; }
    }
}

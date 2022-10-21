using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int instanceCounter = 0;
        public int Id { get; }
        public decimal Cost { get; }
        public string Name { get; }
        public string Description { get; }
        public string Color { get; }
        public string Compound { get; }
        public string Manufactured { get; }

        public Product(decimal cost, string name, string description, string color, string compound, string manufactured)
        {
            Id = instanceCounter;
            Cost = cost;
            Name = name;
            Description = description;
            Color = color;
            Compound = compound;
            Manufactured = manufactured;
            instanceCounter++;
        }
        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}\n\n";
        }
    }
}

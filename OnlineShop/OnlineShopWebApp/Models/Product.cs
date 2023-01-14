using System;
namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int instanceCounter = 0;
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Compound { get; set; }
        public string Manufactured { get; set; }

        public string ImagePath { get; set; }


        public Product()
        {
            Id = instanceCounter;
            Id = instanceCounter++;
        }
        public Product(decimal cost, string name, string description, string color, string compound, string manufactured, string imagePath): this()
        {
            Cost = cost;
            Name = name;
            Description = description;
            Color = color;
            Compound = compound;
            Manufactured = manufactured;
            ImagePath = imagePath;
        }
        public Product(int id, decimal cost, string name, string description, string color, string compound, string manufactured, string imagePath)
        {
            Id = id;
            Cost = cost;
            Name = name;
            Description = description;
            Color = color;
            Compound = compound;
            Manufactured = manufactured;
            ImagePath = imagePath;
        }
        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}

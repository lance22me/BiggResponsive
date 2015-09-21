using BiggResponsive.Domain.Interfaces;
using BiggResponsive.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BiggResponsive.Domain.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IEnumerable<Product> products;

        public ProductRepository()
        {
            this.products = AvailableProducts();
        }

        public IEnumerable<Product> GetAll()
        {
            return this.products.OrderBy(p => p.Name);
        }

        private IEnumerable<Product> AvailableProducts()
        {
            var products = new List<Product>();

            Product car = new Product
            {
                ProductId = 200,
                ProductType = "Beetle",
                Name = "Volkswagon Beetle",
                Description = "The coolest car on the planet, or at least was back in the 70's.",
                Price = 26000,
                ProductImage = "Beetle_Blue.jpg",
                AvailableColors = new List<string> { "Blue", "Red", "White", "Yellow" }
            };

            Product jet = new Product
            {
                ProductId = 220,
                ProductType="Jet",
                Name = "Honda HA-420",
                Description = "Kind of like a motorcycle, except it's an airplane and it flies really fast.",
                Price = 983900,
                ProductImage = "Jet_Blue.jpg",
                AvailableColors = new List<string> { "Blue", "Red", "Yellow" }
            };

            Product cup = new Product
            {
                ProductId = 230,
                ProductType = "Cup",
                Name = "Coffee Cup",
                Description = "You grab this in the morning, add primo coffee and two shots expresso and WOW what a great day!",
                Price = 6.99m,
                ProductImage = "Cup_Blue.jpg",
                AvailableColors = new List<string> { "Blue", "Green", "Orange", "Black" }
            };


            Product cake = new Product
            {
                ProductId = 240,
                ProductType = "Cake",
                Name = "Elegant Cake",
                Description = "Imagine the glory of eating one of these, or having friends over and they see this in the kitchen!",
                Price = 420,
                ProductImage = "Cake_Blue.jpg",
                AvailableColors = new List<string> { "Blue","Turquoise","Brown","Pink","Purple","White","Yellow" }
            };

            products.Add(car);
            products.Add(jet);
            products.Add(cup);
            products.Add(cake);

            return products;
        }
    }
}

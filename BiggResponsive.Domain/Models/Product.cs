using BiggResponsive.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace BiggResponsive.Domain.Models
{
    public class Product : IProduct
    {
        private string productImage;

        public Product()
        {
            this.Quantity = 1; 
        }

        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> AvailableColors { get; set; }
        public decimal Price { get; set; }

        public string ProductImage
        {
            get { return this.productImage; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    this.productImage = "/Content/ImagesProducts/NoImage.jpg";
                }
                else
                {
                    this.productImage = "/Content/ImagesProducts/" + value;
                }

            }
        }

        // ------------------------------------------------------------------------------------
        // Things attached to product, that are only relevant to the product while in the cart
        // ------------------------------------------------------------------------------------
        public string SelectedColor { get; set; }
        public int Quantity { get; set; }
    }
}

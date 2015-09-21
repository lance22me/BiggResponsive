using BiggResponsive.Domain.Interfaces;
using System.Collections.Generic;

namespace BiggResponsive.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<IProduct> GetAll()
        {
            var products = this.productRepository.GetAll();
            return products;
        }

    }
}

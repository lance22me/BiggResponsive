using BiggResponsive.Domain.Models;
using System.Collections.Generic;

namespace BiggResponsive.Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
    }
}

using System.Collections.Generic;

namespace BiggResponsive.Domain.Interfaces
{
    public interface IProductService
    {
        IEnumerable<IProduct> GetAll();
    }
}

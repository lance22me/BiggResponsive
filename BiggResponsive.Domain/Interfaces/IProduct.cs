using System.Collections.Generic;

namespace BiggResponsive.Domain.Interfaces
{
    public interface IProduct
    {
        int ProductId { get; set; }
        string ProductType { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        IEnumerable<string> AvailableColors { get; set; }
        string SelectedColor { get; set; }
        decimal Price { get; set; }
    }
}

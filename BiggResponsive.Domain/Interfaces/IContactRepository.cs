using System.Collections.Generic;
using BiggResponsive.Domain.Models;

namespace BiggResponsive.Domain.Interfaces
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAll();
    }
}

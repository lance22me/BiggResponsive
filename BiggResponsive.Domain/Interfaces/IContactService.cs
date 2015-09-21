using System;
using BiggResponsive.Domain.Models;
using System.Collections.Generic;

namespace BiggResponsive.Domain.Interfaces
{
    public interface IContactService
    {
        IEnumerable<Contact> Get();
    }
}

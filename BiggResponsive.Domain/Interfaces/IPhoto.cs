using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiggResponsive.Domain.Interfaces
{
    public interface IPhoto
    {
        int PhotoId { get; set; }
        int PersonId { get; set; }
        string ImagePath { get; set; }
    }
}

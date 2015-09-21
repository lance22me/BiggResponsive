using System.Collections.Generic;
using BiggResponsive.Domain.Models;

namespace BiggResponsive.Domain.Interfaces
{
    public interface IMemberService
    {
        IEnumerable<Member> GetAll();
        IEnumerable<Member> GetByTag(string tag);

    }
}

using System;
using BiggResponsive.Domain.Models;
using System.Collections.Generic;

namespace BiggResponsive.Domain.Interfaces
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAll();
        IEnumerable<Member> GetByTag(string tag);
    }
}

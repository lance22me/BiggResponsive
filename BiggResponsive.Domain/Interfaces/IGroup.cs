using System;
using System.Collections.Generic;
using BiggResponsive.Domain.Models;

namespace BiggResponsive.Domain.Interfaces
{
    public interface IGroup
    {
        Guid GroupId { get; set; }
        string GroupName { get; set; }
        string GroupDescription { get; set; }
        List<Member> Members { get; set; } 
    }
}

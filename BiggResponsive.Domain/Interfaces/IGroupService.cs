using System;
using System.Collections;
using System.Collections.Generic;
using BiggResponsive.Domain.Models;


namespace BiggResponsive.Domain.Interfaces
{
    public interface IGroupService
    {
        IEnumerable<Group> Add(Group group);
        IEnumerable<Group> GetAll();
        Group ToggleGroupMember(Group group, Member person);
    }
}

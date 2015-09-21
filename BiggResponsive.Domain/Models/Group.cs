using System;
using System.Collections.Generic;
using BiggResponsive.Domain.Interfaces;

namespace BiggResponsive.Domain.Models
{
    [Serializable]
    public class Group : IGroup
    {
        public Group()
        {
            this.GroupId = Guid.NewGuid();
            this.Members = new List<Member>();
        }

        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public List<Member> Members { get; set; } 
    }
}

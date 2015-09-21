using System.Collections.Generic;
using System.Linq;
using BiggResponsive.Domain.Interfaces;
using BiggResponsive.Domain.Models;
using BiggResponsive.Domain.Utilities;

namespace BiggResponsive.Service
{

    public class GroupService : IGroupService
    {
        private readonly ISessionStateService sessionService;

        public GroupService()
        {
            // Below: I'm invoking 'new' on SessionStateService and not using IOC because Session 
            // isn't a normal consumable and doesn't exist on same part of the Heap as other objects.
            // Also, run-time objects are not good candidates for IOC.  
            this.sessionService = new SessionStateService();
        }

        public IEnumerable<Group> Add(Group group)
        {
            Guard.ArgumentNotNull(group, "group");

            List<Group> groups = this.sessionService.Get<List<Group>>("Groups") ?? new List<Group>();
            groups.Add(group);

            this.sessionService.Add("Groups", groups);

            return groups;
        }

        public IEnumerable<Group> GetAll()
        {
            var groups = this.sessionService.Get<IEnumerable<Group>>("Groups");
            return groups;
        }

        public Group ToggleGroupMember(Group group, Member person)
        {
            Guard.ArgumentNotNull(group, "group");
            Guard.ArgumentNotNull(person, "person");

            var groups = this.sessionService.TryGet<Group, IEnumerable<Group>>("Groups", group, Add);
            var targetGroup = groups.Where(g => g.GroupId.Equals(group.GroupId)).FirstOrDefault();

            var isInGroup = (targetGroup.Members.Count(m => m.PersonId.Equals(person.PersonId)) == 0) ? false : true ;

            if (!isInGroup)
            {
                targetGroup.Members.Add(person);
            }
            else
            {
                var removePerson = targetGroup.Members.FirstOrDefault(m => m.PersonId == person.PersonId);
                targetGroup.Members.Remove(removePerson);
            }

            this.sessionService.Add("Groups", groups); // or (using HttpContext)  Session["Groups"] = groups;

            return targetGroup;
        }

    }
}

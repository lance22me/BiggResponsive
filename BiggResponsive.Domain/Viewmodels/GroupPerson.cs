using BiggResponsive.Domain.Models;

namespace BiggResponsive.Domain.Viewmodels
{
    public class GroupPerson
    {
        /// <summary>
        /// SelectedGroup is the group that the person will be added to.
        /// </summary>
        /// <value>
        /// The selected group.
        /// </value>
        public Group SelectedGroup { get; set; }

        public Member SelectedMember { get; set; }
    }
}

using System.Collections.Generic;

namespace BiggResponsive.Domain.Models
{
    /// <summary>
    /// No interface ... being a slacker on this one.
    /// </summary>
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Comment { get; set; }
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }        
    }
}

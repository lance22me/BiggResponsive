using System;
using BiggResponsive.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BiggResponsive.Domain.Models
{
    /// <summary>
    /// Built for the nested json sample.
    /// Meant to simulate a joined table query.
    /// Contact.cs has a field for PhoneNumberType "Mobile", "Home" or "Work". Let's pretend that Contact is
    /// a joined table in a db, and THIS table simply as an "ID" for it's type.
    /// </summary>
    public class PhoneNumber : IPhoneNumber
    {
        public int PhoneNumberId { get; set; }      // pretending to be primary key
        public int ContactId { get; set; }          // pretending to be foreign key

        [StringLength(14)]
        public string Phone { get; set; }

        public int PhoneNumberTypeId { get; set; }

        /// <summary>
        /// Home, Mobile, Work. Prose value of PhoneNumberTypeId
        /// </summary>
        /// <value>
        /// The type of the phone number.
        /// </value>
        public string PhoneNumberType { get; set; }
    }
}

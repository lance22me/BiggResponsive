using System;
using System.ComponentModel.DataAnnotations;


namespace BiggResponsive.Domain.Interfaces
{
    public interface IPhoneNumber
    {
        int PhoneNumberId { get; set; }
        int ContactId { get; set; }

        [StringLength(7)]
        string Phone { get; set; }
        int PhoneNumberTypeId { get; set; }

        /// <summary>
        /// 1=Home, 2=Mobile, 3=Work. Prose value of PhoneNumberTypeId
        /// </summary>
        /// <value>
        /// The type of the phone number.
        /// </value>
        string PhoneNumberType { get; set; }
    }
}

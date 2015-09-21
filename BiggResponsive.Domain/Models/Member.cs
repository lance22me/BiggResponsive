using System.ComponentModel.DataAnnotations;
using BiggResponsive.Domain.Interfaces;
using System;

namespace BiggResponsive.Domain.Models
{
    [Serializable]
    public class Member : IMember
    {
        private string profileImage;

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public string ProfileImage
        {
            get { return this.profileImage; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    this.profileImage = "/Content/Images/NoImage.jpg";
                }
                else
                {
                    this.profileImage = "/Content/Images/" + value; 
                }
                
            }
        }

        public string Tags { get; set; }
    }
}

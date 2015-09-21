using System.Collections.Generic;
using System.Linq;
using BiggResponsive.Domain.Enums;
using BiggResponsive.Domain.Extensions;
using BiggResponsive.Domain.Interfaces;
using BiggResponsive.Domain.Models;

namespace BiggResponsive.Domain.Repository
{
    public class ContactRepository : IContactRepository
    {
        private List<PhoneNumber> phoneNumberTable;
        private List<Contact> allCurrentContacts;

        public ContactRepository()
        {
            this.phoneNumberTable = PhoneNumberTable();
            AddPhoneNumberType();
            this.allCurrentContacts = AllContacts();
        }

        public IEnumerable<Contact> GetAll()
        {
            return this.allCurrentContacts;
        }




        #region fake data, simulating two db tables

        private List<Contact> AllContacts()
        {
            var contacts = new List<Contact>();

            // NOTE - The PHONE NUMBER collection is brought in after the fact in JoinObjects()

            var contact1 = new Contact { 
                ContactId = 123,
                Name="Asajj Ventress",
                Subject="I want my light sabers back",
                Email = "AsajjVentress@nowhere.com",
                Comment="Somebody stole my light sabers and I think it was a Jedi. They snuck up on me from behind.",
                PhoneNumbers= this.phoneNumberTable.Where(p => p.ContactId.Equals(123)).ToSafeList()
            };

            var contact2 = new Contact
            {
                ContactId = 765,
                Name = "Ashoka Tano",
                Subject = "A little respect, please",
                Email = "AshokaTano@nowhere.com",
                Comment = "Why is that nobody gives me any respect? I've done everything everybody has asked.  Oh well.",
                PhoneNumbers = this.phoneNumberTable.Where(p => p.ContactId.Equals(765)).ToSafeList()
            };

            var contact3 = new Contact
            {
                ContactId = 575,
                Name = "Mother Talzin",
                Subject = "Anyone see Count Dooku?",
                Email = "NightSisters@nowhere.com",
                Comment = "If anyone sees the Count, let him know I have a new apprentice for him.  He will serve him well, much like his brother did for Sideous.",
                PhoneNumbers = this.phoneNumberTable.Where(p => p.ContactId.Equals(575)).ToSafeList()
            };

            var contact4 = new Contact
            {
                ContactId = 852,
                Name = "Hondo Ohnaka",
                Subject = "That's for sale, if you are interested",
                Email = "PirateTreasure@nowhere.com",
                Comment = "So I acquired this space ship; very nice I might say. It would be for sale to you for a very special price.",
                PhoneNumbers = this.phoneNumberTable.Where(p => p.ContactId.Equals(852)).ToSafeList()
            };

            var contact5 = new Contact
            {
                ContactId = 821,
                Name = "Cad Bane",
                Subject = "Looking for good hat stores. Know any?",
                Email = "TruBlue@nowhere.com",
                Comment = "I want to be out styling a new look, I'm thinking another hat would get me to the next level. Know of any cool vendors?",
                PhoneNumbers = this.phoneNumberTable.Where(p => p.ContactId.Equals(821)).ToSafeList()
            };

            var contact6 = new Contact
            {
                ContactId = 845,
                Name = "Fives",
                Subject = "Dude, they set me up",
                Email = "CT-5555@nowhere.com",
                Comment = "This will sound crazy but I think some brothers have chips that make them more agressive.",
                PhoneNumbers = this.phoneNumberTable.Where(p => p.ContactId.Equals(845)).ToSafeList()
            };

            contacts.Add(contact1);
            contacts.Add(contact2);
            contacts.Add(contact3);
            contacts.Add(contact4);
            contacts.Add(contact5);
            contacts.Add(contact6);

            return contacts;
        }

        private List<PhoneNumber> PhoneNumberTable()
        {
            List<PhoneNumber> phoneTable =  new List<PhoneNumber>();

            var phoneNumber1 = new PhoneNumber {
                PhoneNumberId=9878,
                ContactId=123,
                Phone= "6514261707".FormatPhoneNumber(),
                PhoneNumberTypeId=2
            };

            var phoneNumber2 = new PhoneNumber
            {
                PhoneNumberId = 9879,
                ContactId = 123,
                Phone = "6518764321".FormatPhoneNumber(),
                PhoneNumberTypeId = 1
            };

            var phoneNumber3 = new PhoneNumber
            {
                PhoneNumberId = 9880,
                ContactId = 765,
                Phone = "9525546590".FormatPhoneNumber(),
                PhoneNumberTypeId = 2
            };

            var phoneNumber4 = new PhoneNumber
            {
                PhoneNumberId = 9881,
                ContactId = 575,
                Phone = "9526489908".FormatPhoneNumber(),
                PhoneNumberTypeId = 1
            };

            var phoneNumber5 = new PhoneNumber
            {
                PhoneNumberId = 9885,
                ContactId = 575,
                Phone = "6519900980".FormatPhoneNumber(),
                PhoneNumberTypeId = 2
            };

            var phoneNumber6 = new PhoneNumber
            {
                PhoneNumberId = 9886,
                ContactId = 575,
                Phone = "6519900981".FormatPhoneNumber(),
                PhoneNumberTypeId = 3
            };

            var phoneNumber7 = new PhoneNumber
            {
                PhoneNumberId = 9899,
                ContactId = 852,
                Phone = "5629469481".FormatPhoneNumber(),
                PhoneNumberTypeId = 2
            };

            var phoneNumber8 = new PhoneNumber
            {
                PhoneNumberId = 9900,
                ContactId = 852,
                Phone = "5629469478".FormatPhoneNumber(),
                PhoneNumberTypeId = 3
            };

            var phoneNumber9 = new PhoneNumber
            {
                PhoneNumberId = 9923,
                ContactId = 821,
                Phone = "4531534838".FormatPhoneNumber(),
                PhoneNumberTypeId = 1
            };

            var phoneNumber10 = new PhoneNumber
            {
                PhoneNumberId = 9924,
                ContactId = 821,
                Phone = "4531534839".FormatPhoneNumber(),
                PhoneNumberTypeId = 2
            };

            var phoneNumber11 = new PhoneNumber
            {
                PhoneNumberId = 9926,
                ContactId = 845,
                Phone = "4531534839".FormatPhoneNumber(),
                PhoneNumberTypeId = 3
            };

            phoneTable.Add(phoneNumber1);
            phoneTable.Add(phoneNumber2);
            phoneTable.Add(phoneNumber3);
            phoneTable.Add(phoneNumber4);
            phoneTable.Add(phoneNumber5);
            phoneTable.Add(phoneNumber6);
            phoneTable.Add(phoneNumber7);
            phoneTable.Add(phoneNumber8);
            phoneTable.Add(phoneNumber9);
            phoneTable.Add(phoneNumber10);
            phoneTable.Add(phoneNumber11);

            return phoneTable;
        }

        private void AddPhoneNumberType()
        {
            // guard clause for this.PhoneNumberTable if this were a real app.

            foreach (var phone in this.phoneNumberTable)
            {
                phone.PhoneNumberType = System.Enum.GetName(typeof(PhoneNumberType), phone.PhoneNumberTypeId);
            }
        }

        #endregion
    }
}

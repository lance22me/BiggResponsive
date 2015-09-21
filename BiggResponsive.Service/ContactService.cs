using System;
using BiggResponsive.Domain.Interfaces;
using BiggResponsive.Domain.Models;
using System.Collections.Generic;

namespace BiggResponsive.Service
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository repository;

        public ContactService(IContactRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Contact> Get()
        {
            var contacts = this.repository.GetAll();
            return contacts;
        }
    }
}

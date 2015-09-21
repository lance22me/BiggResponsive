using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BiggResponsive.Domain.Models;
using BiggResponsive.Domain.Interfaces;
using BiggResponsive.Domain.Extensions;

namespace BiggResponsive.Controllers.api
{
    public class ContactController : ApiController
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public async Task<IHttpActionResult> Get()
        {
            var contacts = this.contactService.Get();
            return this.Ok(contacts.ToSafeList());
        }

        // GET api/contact/5
        public string Get(int id)
        {
            return "value";
        }

        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> Post(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
        
            return this.Ok(contact);  // not persisting, just simulating.
        }

        // PUT api/people/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/people/5
        public void Delete(int id)
        {
        }
    }
}

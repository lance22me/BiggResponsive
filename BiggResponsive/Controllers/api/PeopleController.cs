using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BiggResponsive.Domain.Extensions;
using BiggResponsive.Domain.Interfaces;
using BiggResponsive.Domain.Models;
using BiggResponsive.Domain.Utilities;
using Newtonsoft.Json;

namespace BiggResponsive.Controllers.api
{
    public class PeopleController : ApiController
    {
        private readonly IMemberService memberService;

        public PeopleController(IMemberService memberService)
        {
            this.memberService = memberService;
        }

        public IHttpActionResult Get()
        {
            var allPeople = this.memberService.GetAll();
            return this.Ok<List<Member>>(allPeople.ToSafeList());
        }

        // GET api/people/5
        public IHttpActionResult Get(string selectedTag)
        {
            Guard.ParameterNotNullOrEmpty(selectedTag, "selectedTag");

            var people = this.memberService.GetByTag(selectedTag);
            return this.Ok<List<Member>>(people.ToSafeList()); 
        }

        // POST api/people
        public void Post([FromBody]string value){}

        // PUT api/people/5
        public void Put(int id, [FromBody]string value){}

        // DELETE api/people/5
        public void Delete(int id)
        {
        }
    }
}

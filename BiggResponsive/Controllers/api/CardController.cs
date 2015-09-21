using BiggResponsive.Domain.Interfaces;
using BiggResponsive.Domain.Models;
using BiggResponsive.Domain.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;

namespace BiggResponsive.Controllers.api
{
    public class CardController : ApiController
    {
        private readonly ICardService cardService;

        public CardController(ICardService cardService)
        {
            this.cardService = cardService;
        }

        //public async Task<IHttpActionResult> Get() 
        //{
        //    var allCards = this.cardService.GetAllCards();
        //    return this.Ok(allCards.ToList());
        //}

        public IHttpActionResult Get()
        {
            var allCards = this.cardService.GetAllCards();
            return this.Ok<List<Card>>(allCards.ToSafeList());
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
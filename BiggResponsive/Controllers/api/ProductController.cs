using BiggResponsive.Domain.Interfaces;
using BiggResponsive.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace BiggResponsive.Controllers.api
{
    public class ProductController : ApiController
    {

        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }


        public async Task<IHttpActionResult> Get()
        {
            var products = this.productService.GetAll();
            return this.Ok(products.ToList());
        }

        //public IHttpActionResult Get()
        //{
        //    return this.Ok("hello world");
        //}

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

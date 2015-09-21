using System;
using System.Collections.Generic;
using System.Web.Http;
using Ninject.Extensions.Logging;

namespace BiggResponsive.Controllers.api
{
    public class QlikController : ApiController
    {

        private ILogger logger;

        public QlikController(ILogger logger)
        {
            this.logger = logger;
            this.logger.Info("Hello from the QLIK WebAPI on BiggResponsive.");
        }


        // Qlik LOCAL on work machine app "BusyBees"
        // https://001020-pc.apex.com/sense/app/cba62c41-5823-42e5-8a8d-685ccc6ae6e4

        // GET: api/Qlik
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Qlik/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Qlik
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Qlik/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Qlik/5
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BiggResponsive
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // use camel case for JSON data.
            // config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var serializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // <----- switch to PascalCasePropertyNamesContractResoler() to accomodate Angular ?
            serializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;

            // Web API routes
            //config.MapHttpAttributeRoutes(); // <-- replaced by a line in NinjectWebCommon.cs

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
        }
    }
}

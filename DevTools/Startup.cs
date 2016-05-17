using System.Net.Http.Formatting;
using System.Web.Http;

using DevTools;

using Microsoft.Owin;
using Microsoft.Owin.Diagnostics;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace DevTools
{
    public sealed class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpServer server = CreateWebApiConfig();
            app.UseWebApi(server);

            app.UseWelcomePage();
        }

        private static HttpServer CreateWebApiConfig()
        {
            var config = new HttpConfiguration();
            var server = new HttpServer(config);

            config.MapHttpAttributeRoutes();

            config.Formatters.Clear();
            var jsonFormatter = new JsonMediaTypeFormatter {
                SerializerSettings = {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                }
            };
            config.Formatters.Add(jsonFormatter);

            SwaggerConfig.Register(config);

            config.EnsureInitialized();
            return server;
        }
    }
}

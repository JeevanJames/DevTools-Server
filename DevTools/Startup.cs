using System.Web.Http;

using DevTools;

using Microsoft.Owin;

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
        }

        private HttpServer CreateWebApiConfig()
        {
            var config = new HttpConfiguration();
            var server = new HttpServer(config);

            config.MapHttpAttributeRoutes();

            return server;
        }
    }
}

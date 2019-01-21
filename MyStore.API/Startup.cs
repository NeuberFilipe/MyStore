using DomainNotificationHelper.Events;
using Microsoft.Owin.Cors;
using MyStore.API.Helpers;
using MyStore.CrossCutting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Web.Http;
using Unity;

namespace MyStore.API
{
    public class Startup
    {
        public static void ConfigureWebApi(HttpConfiguration configuration)
        {
            var formatters = configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;

            configuration.MapHttpAttributeRoutes();
            configuration.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
        }

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var container = new UnityContainer();

            ConfigureDependencyInjection(config, container);
            ConfigureWebApi(config);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private void ConfigureDependencyInjection(HttpConfiguration config, UnityContainer container)
        {
            DependencyRegister.Register(container);

            config.DependencyResolver = new UnityResolverHelper(container);
            //DomainEvent.Container = new DomainEventsContainer(config.DependencyResolver);
        }
    }
}
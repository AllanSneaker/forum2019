using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using ForumEpam2019.BusinessLayer.Configurations;
using ForumEpam2019.BusinessLayer.Managers;
using ForumEpam2019.BusinessLayer.Repository;
using Unity;

namespace ForumEpam2019.ServiceLayer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //it work
            //var container = new UnityContainer();
            //container.RegisterType<IProfileInfoRepository, ProfileInfoManager>();
            config.DependencyResolver = new UnityResolver(UnityConfig.BuildUnityContainer());


            config.MapHttpAttributeRoutes();
            //config.EnableCors(new EnableCorsAttribute("http://localhost:4200", headers: "*", methods: "*"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

            config.Filters.Add(new AuthorizeAttribute());
        }
    }
}

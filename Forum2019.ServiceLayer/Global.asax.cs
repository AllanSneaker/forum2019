﻿using ForumEpam2019.BusinessLayer.Configurations;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace ForumEpam2019.ServiceLayer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AutoMapperConfig.Initialize();
            //UnityConfig.RegisterComponents();
            //UnityConfig.Initialize();


        }
    }
}

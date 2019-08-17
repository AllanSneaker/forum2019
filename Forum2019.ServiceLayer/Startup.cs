using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;

[assembly: OwinStartup(typeof(ForumEpam2019.ServiceLayer.Startup))]

namespace ForumEpam2019.ServiceLayer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCors(CorsOptions.AllowAll);

            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new OAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                AllowInsecureHttp = true
            };
            app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

        //public void Configuration(IAppBuilder app)
        //{
        //    ConfigureAuth(app);
        //}
        //public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        //public static string PublicClientId { get; private set; }

        //public void ConfigureAuth(IAppBuilder app)
        //{
        //    var userService = System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver
        //        .GetService(typeof(IAccountService)) as IAccountService;

        //    app.UseCookieAuthentication(new CookieAuthenticationOptions());

        //    PublicClientId = "self";
        //    OAuthOptions = new OAuthAuthorizationServerOptions
        //    {
        //        TokenEndpointPath = new PathString("/Token"),
        //        Provider = new OAuthProvider(PublicClientId, userService),
        //        AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
        //        AccessTokenExpireTimeSpan = TimeSpan.FromDays(5),
        //        AllowInsecureHttp = true
        //    };

        //    app.UseOAuthBearerTokens(OAuthOptions);
        //}

    }
}

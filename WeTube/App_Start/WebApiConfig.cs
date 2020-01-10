using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Unity;
using Unity.Lifetime;
using WeTube.Interfaces;
using WeTube.Repository;
using WeTube.Resolver;

namespace WeTube
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();
            container.RegisterType<IAppUserRepository, AppUserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IVideoRepository, VideoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommentRepository, CommentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ILikeRatioRepository, LikeRatioRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}

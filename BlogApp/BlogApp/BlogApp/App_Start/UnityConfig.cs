using BlogApp.Models;
using BlogApp.Repositories;
using BlogApp.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace BlogApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserRepository, UserRepository>();

            container.RegisterType<IBlogService, BlogService>();
            container.RegisterType<IBlogRepository, BlogRepository>();

            container.RegisterSingleton<CurrentUserContext>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
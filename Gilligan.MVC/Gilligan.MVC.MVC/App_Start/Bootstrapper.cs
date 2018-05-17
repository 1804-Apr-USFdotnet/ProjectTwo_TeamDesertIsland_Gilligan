using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using Gilligan.MVC.DomainContracts;
using Gilligan.MVC.DomainServices;
using Gilligan.MVC.Logging;

namespace Gilligan.MVC.MVC
{
    public class Bootstrapper
    {
        private static IContainer _container;

        public static IContainer RegisterTypes()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //services
            builder.RegisterType<HttpService>().As<IHttpService>();
            builder.RegisterType<SearchService>().As<ISearchService>();
            builder.RegisterType<SongService>().As<ISongService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<LoggingService>().As<ILoggingService>();

            _container = builder.Build();

            return _container;
        }
    }
}
using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Gilligan.API.DomainContracts;
using Gilligan.API.DomainServices;
using Gilligan.API.Logging;
using Gilligan.API.Mapping;
using Gilligan.API.Repositories;
using Gilligan.API.RepositoryContracts;

namespace Gilligan.API.Rest
{
    public class Bootstrapper
    {
        private static IContainer _container;

        public static IContainer RegisterTypes()
        {
            var builder = new ContainerBuilder();

            //Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //Automapper
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile()); 
            });
            var mapper = mapperConfiguration.CreateMapper();

            //EF
            builder.RegisterType<GilliganContext>().As<IDbContext>().InstancePerLifetimeScope();

            //NLog
            builder.RegisterType<LoggingService>().As<ILoggingService>();

            //Services
            builder.RegisterType<RatingService>().As<IRatingService>();
            builder.RegisterType<SpotifyService>().As<ISpotifyService>();
            builder.RegisterType<InventoryService>().As<IInventoryService>();

            //Repositories
            builder.RegisterType<AlbumRepository>().As<IAlbumRepository>();
            builder.RegisterType<ArtistRepository>().As<IArtistRepository>();
            builder.RegisterType<GenreRepository>().As<IGenreRepository>();
            builder.RegisterType<RatingRepository>().As<IRatingRepository>();
            builder.RegisterType<SongRepository>().As<ISongRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();

            _container = builder.Build();

            return _container;
        }
    }
}
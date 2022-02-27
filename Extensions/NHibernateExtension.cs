using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Tool.hbm2ddl;
namespace RetailCompany.Extensions
{
    public static class NHibernateExtension
    {
     public static IServiceCollection AddNHibernate(this IServiceCollection services,
        string connectionString)
        {
            var _sessionFactory = Fluently.Configure()
                            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                            .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                            //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, true))
                            .BuildSessionFactory();


            services.AddSingleton(_sessionFactory);
            services.AddScoped(factory => _sessionFactory.OpenSession());

            return services;
        }
    }
}

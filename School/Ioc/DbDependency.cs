using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using School.Infra.Context;

namespace School.API.Ioc
{
    public static class DbDependency
    {
        public static void AddDbDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SchoolContext>(x =>
                x.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                               y => y.MigrationsHistoryTable("HistoryMigrations", "dbo").UseNetTopologySuite())
                );
        }
    }
}

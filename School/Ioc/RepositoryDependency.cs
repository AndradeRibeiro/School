using Microsoft.Extensions.DependencyInjection;
using School.Domain.Interfaces.Repository;
using School.Infra.Repository;

namespace School.API.Ioc
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICourseRepository, CourseRepository>();
        }
    }
}

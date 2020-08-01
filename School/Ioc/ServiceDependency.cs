using Microsoft.Extensions.DependencyInjection;
using School.Domain.Interfaces.Services;
using School.Service.Services;

namespace School.API.Ioc
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<ICourseService, CourseService>();
        }
    }
}

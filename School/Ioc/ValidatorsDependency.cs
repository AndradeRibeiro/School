using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using School.Domain.Interfaces.Validtator;
using School.Domain.Models;
using School.Domain.Models.FluentValidator;
using School.Service.Validators;

namespace School.API.Ioc
{
    public static class ValidatorsDependency
    {
        public static void AddValidatorsDependency(this IServiceCollection services)
        {
            services.AddScoped<ICourseValidator, CourseValidator>();
            services.AddScoped<ICourseDateValidator, CourseDateValidator>();
            services.AddScoped<ICategoryValidator, CategoryValidator>();
        }

        public static void AddFluentValidatorsDependency(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CourseModel>, CourseModelValidator>();
        }
    }
}

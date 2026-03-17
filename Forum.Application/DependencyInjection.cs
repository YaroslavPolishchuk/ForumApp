using Forum.Application.Common.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Forum.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, params Assembly[] assemblies)
        {
            
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            //services.AddAutoMapper(typeof(UserProfile).Assembly); 

            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //// (Необязательно) Добавляем pipeline behavior для автоматической валидации
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}

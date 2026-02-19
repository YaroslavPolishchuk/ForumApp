using Forum.Application.Common.Interfaces.Contexts;
using Forum.Application.Common.Interfaces.IOwnerServices;
using Forum.Application.Common.Services;
using Forum.Infrastructure.Identity.Jwt;
using Forum.Infrastructure.Identity.Token;
using Forum.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Forum.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<VeloContext>(options =>
                    options.UseNpgsql(
                        config.GetConnectionString("DefCon")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.Configure<JwtSettings>(jwt => config.GetSection(JwtSettings.SectionName).Bind(jwt));
            services.AddSingleton(config.GetSection(JwtSettings.SectionName).Get<JwtSettings>()!);            
            services.AddScoped<IAppVeloDbContext>(provider =>
                provider.GetRequiredService<VeloContext>());
            services.AddScoped<IBoardOwnerService, BoardOwnerService>();
            services.AddSingleton<IJwtSettings>(sp => sp.GetRequiredService<IOptions<JwtSettings>>().Value);
            services.AddSingleton<IJwtUtils, JwtUtils>();

            return services;
        }
    }
}

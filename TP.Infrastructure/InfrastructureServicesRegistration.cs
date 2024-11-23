using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TP.Application;
using TP.Application.Contracts.Infrastructure.AccountSerivce;
using TP.Application.Contracts.Persistence;
using TP.Infrastructure.Service;

namespace TP.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastractureServices(this IServiceCollection services, IConfiguration configuration)
        {
          
            
            //AddJwtSetting

            services.Configure<JWTSetting>(configuration.GetSection("JwtSetting"));

            //Add DI

            services.AddScoped(typeof(IAuthService), typeof(AuthService));


            //AddAuthentication

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSetting:Issuer"],
                    ValidAudience = configuration["JwtSetting:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSetting:Key"]))
                };
            });


            return services;
        }
    }
}

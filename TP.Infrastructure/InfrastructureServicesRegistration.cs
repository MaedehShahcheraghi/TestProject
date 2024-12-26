using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Text;
using TP.Application;
using TP.Application.Contracts.Infrastructure.AccountSerivce;
using TP.Application.Contracts.Infrastructure.CaptchaService;
using TP.Application.Contracts.Infrastructure.RedisServices;
using TP.Application.Contracts.Persistence;
using TP.Application.Models.Redis;
using TP.Infrastructure.Policies;
using TP.Infrastructure.Service;

namespace TP.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastractureServices(this IServiceCollection services, IConfiguration configuration)
        {

            //Add Redis
            services.Configure<RedisSertting>(configuration.GetSection("RedisSettings"));

           
            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var redisSettings = sp.GetRequiredService<IOptions<RedisSertting>>().Value;
                var config = new ConfigurationOptions
                {
                    EndPoints = { $"{redisSettings.Host}:{redisSettings.Port}" },
                    Password = redisSettings.Password, 
                    DefaultDatabase = redisSettings.Database 
                };

                return ConnectionMultiplexer.Connect(config);
            });


            //Add MemoryCache
            services.AddMemoryCache();

            //AddJwtSetting

            services.Configure<JWTSetting>(configuration.GetSection("JwtSetting"));

            //Add DI

            services.AddScoped(typeof(IAuthService), typeof(AuthService));
            services.AddScoped(typeof(ICaptchaService), typeof(CaptchaService));
            services.AddScoped(typeof(IRedisService), typeof(RedisService));


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
            services.AddAuthorization(options =>
            {
                AuthorizationPolicies.AddPolicies(options);
            });

            return services;
        }
    }
}

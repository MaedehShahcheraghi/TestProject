﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TP.Application;

namespace TP.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection ConfigureIdentityService(this IServiceCollection services,
            IConfiguration configuration)
        {

            //AddJwtSetting

            services.Configure<JWTSetting>(configuration.GetSection("JwtSetting"));

            //AddDbContext

            services.AddDbContext<TestProjectIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("TestProjectIdentityConnectionString"),
                    b => b.MigrationsAssembly(typeof(TestProjectIdentityDbContext).Assembly.FullName));
            });

            //AddIdentity
            services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<TestProjectIdentityDbContext>().AddDefaultTokenProviders();

            //AddDi

            //services.AddTransient<IAuthService, AuthService>();

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
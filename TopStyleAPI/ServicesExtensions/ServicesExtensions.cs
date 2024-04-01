using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TopStyleAPI.Core.Authorization.Interface;
using TopStyleAPI.Core.Authorization.TokenLifeTimeManager;
using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Core.Services;
using TopStyleAPI.Data;
using TopStyleAPI.Data.Interfaces;
using TopStyleAPI.Data.Repos;
using TopStyleAPI.Domain.Entities;
using TopStyleAPI.Logger.Interfaces;
using TopStyleAPI.Logger.LoggerManager;

namespace TopStyleAPI.ServicesExtensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<ITokenLifeTimeManager, JwtTokenLifeTimeManager>();
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<Customer, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 0;
                options.User.RequireUniqueEmail = true;

            })
                .AddEntityFrameworkStores<TopStyleDbContext>()
                .AddDefaultTokenProviders();

        }
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenLifeTimeManager = new JwtTokenLifeTimeManager();
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secret = jwtSettings["secret"];
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = jwtSettings["validIssuer"],
                    ValidIssuer = jwtSettings["validAudience"],
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = tokenLifeTimeManager.ValidateTokenLifeTime
                };
            });

        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });

            });

        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Data.Repositories;
using Data.Context;
using Domain.Command.Handlers;
using ExternalServices.Services;
using Domain.Interfaces.Services;
using Domain.Services;
using Swashbuckle.AspNetCore.Swagger;
using FluentValidation.AspNetCore;
using Data.Transaction;
using Domain.Command.Results;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using API.Security;
using Microsoft.Extensions.Logging;
using System;
using Domain.Command.Inputs;
using Shared.Notifications;
using Domain.Entities.Validators;

namespace API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private const string ISSUER = "c1f51f42";
        private const string AUDIENCE = "c6bbbb645024";
        private const string SECRET_KEY = "c1f51f42-5727-4d15-b787-c6bbbb645024";

        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "MrVinil", Version = "v1" });
            });

            services.AddCors();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy => policy.RequireClaim("ModernStore", "User"));
                options.AddPolicy("Admin", policy => policy.RequireClaim("ModernStore", "Admin"));
            });

            services.Configure<TokenOptions>(options =>
            {
                options.Issuer = ISSUER;
                options.Audience = AUDIENCE;
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            services.AddScoped<MrVinilContext, MrVinilContext>();
            services.AddScoped<ISpotifyService, SpotifyService>();
            services.AddScoped<ICashBackService, CashBackService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IDiskRepository, DiskRepository>();
            services.AddTransient<IOrderCashBackRepository, OrderCashBackRepository>();
            services.AddTransient<IOrderCashBackItemRepository, OrderCashBackItemRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();

            services.AddTransient<ClientHandler, ClientHandler>();
            services.AddTransient<OrderHandler, OrderHandler>();
            services.AddTransient<OrderCashBackHandler, OrderCashBackHandler>();
            services.AddTransient<DomainNotificationHandler, DomainNotificationHandler>();

            services.AddTransient<ClientValidator, ClientValidator>();

            services.AddTransient<AuthenticateUserCommand, AuthenticateUserCommand>();
            services.AddTransient<NewClient, NewClient>();
            services.AddTransient<NewBasket, NewBasket>();
            services.AddTransient<NewDisk, NewDisk>();
            services.AddTransient<NewOrder, NewOrder>();
            services.AddTransient<NewOrderItem, NewOrderItem>();

            services.AddTransient<ClientResult, ClientResult>();
            services.AddTransient<OrderResult, OrderResult>();

        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = ISSUER,

                ValidateAudience = true,
                ValidAudience = AUDIENCE,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });


            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MrVinil");
            });

            app.UseMvc();
        }
    }
}
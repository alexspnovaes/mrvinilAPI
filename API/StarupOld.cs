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
using Domain.Command;
using Data.Transaction;
using Domain.Command.Results;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace API
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }

        private const string ISSUER = "c1f51f42";
        private const string AUDIENCE = "c6bbbb645024";
        private const string SECRET_KEY = "c1f51f42-5727-4d15-b787-c6bbbb645024";

        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));

        public Startup(IHostingEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();

            Configuration = configurationBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Audience = "http://localhost:5001/";
                options.Authority = "http://localhost:5000/";
            });


            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect(options =>
            {
                options.Authority = Configuration["auth:oidc:authority"];
                options.ClientId = Configuration["auth:oidc:clientid"];
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);

            //services.AddMvc(config =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //                     .RequireAuthenticatedUser()
            //                     .Build();
            //    config.Filters.Add(new AuthorizeFilter(policy));
            //})
            //.AddJsonOptions(
            //    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //);

            services.AddMvc();
            //.AddJsonOptions(
            //    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "MrVinil", Version = "v1" });
            });

            services.AddCors();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy => policy.RequireClaim("MrVinil", "User"));
                options.AddPolicy("Admin", policy => policy.RequireClaim("MrVinil", "Admin"));
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

            services.AddTransient<AuthenticateUserCommand, AuthenticateUserCommand>();
            services.AddTransient<NewClient, NewClient>();
            services.AddTransient<NewBasket, NewBasket>();
            services.AddTransient<NewDisk, NewDisk>();
            services.AddTransient<NewOrder, NewOrder>();
            services.AddTransient<NewOrderItem, NewOrderItem>();

            services.AddTransient<ClientResult, ClientResult>();
            services.AddTransient<OrderResult, OrderResult>();

        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();


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
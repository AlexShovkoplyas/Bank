using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Bank.Infrustructure;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;



namespace Bank.Api
{
    public class Startup
    {
        private const string SwaggerXmlFileName = "Bank.Api.xml";
        private readonly AppSettings appSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            appSettings = Configuration.GetSection("AppSettings").Get<AppSettings>();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(c =>
                {
                    c.Authority = "http://localhost:5000";
                    c.RequireHttpsMetadata = false;
                    c.ApiName = "api1";
                });

            services.AddSwaggerGen(c =>
            {
                string filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, SwaggerXmlFileName);
                c.IncludeXmlComments(filePath);
                c.EnableAnnotations();

                c.SwaggerDoc("v1", new Info { Title = "API", Version = "v1" });

                c.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Type = "oauth2",
                    Flow = "implicit",
                    AuthorizationUrl = "http://localhost:5000/connect/authorize",
                    TokenUrl = "http://localhost:5000/connect/token",
                    Scopes = new Dictionary<string, string>()
                    {
                        { "api1", "My API" }
                    }
                });

                c.OperationFilter<AuthorizeCheckOperationFilter>();
            });

            services.AddMvc();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Add any Autofac modules or registrations.
            // This is called AFTER ConfigureServices so things you
            // register here OVERRIDE things registered in ConfigureServices.
            //
            // You must have the call to AddAutofac in the Program.Main
            // method or this won't be called.
            builder.RegisterModule(new Module());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

                c.OAuthClientId("swaggerui");
                c.OAuthAppName("Swagger UI");
            });           

            app.UseMvc();
        }
    }
}

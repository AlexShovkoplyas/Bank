using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie()
                .AddIdentityServerAuthentication(c =>
                {
                    c.Authority = "http://localhost:5000";
                    c.RequireHttpsMetadata = false;
                    c.ApiName = "api1";
                });

            services.AddSwaggerGen(c =>
            {
                string filePath = Path.Combine(
                    PlatformServices.Default.Application.ApplicationBasePath,
                    SwaggerXmlFileName);
                c.IncludeXmlComments(filePath);
                //c.EnableAnnotations();

                c.SwaggerDoc("v1", new Info { Title = "API", Version = "v1" });

                // Handle OAuth
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

                c.OAuthClientId("swaggerui");
                c.OAuthClientSecret("");
                c.OAuthRealm("");
                c.OAuthAppName("Swagger UI");
            });

            //app.UseIdentityServerAuthentication (new IdentityServerAuthenticationOptions
            //{
            //    Authority = "http://localhost:5000",
            //    RequireHttpsMetadata = false,

            //    ApiName = "api1",
            //});

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}

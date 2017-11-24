using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace src
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSwaggerGen(document =>
            {
                var licence = new License
                {
                    Url = "https://selcukermaya.com/licence"
                };
                var contact = new Contact
                {
                    Email = "selcukermaya@gmail.com",
                    Name = "Selçuk Ermaya",
                    Url = "https://selcukermaya.com"
                };
                var description = "This page includes all endpoints of Todo App API.";
                var title = "Todo API";

                document.SwaggerDoc("v1.1", new Info { Title = title, Version = "v1.1", Description = description, Contact = contact, License = licence });
                document.SwaggerDoc("v1", new Info { Title = title, Version = "v1", Description = description, Contact = contact, License = licence });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Todo.xml");
                document.IncludeXmlComments(xmlPath);
                document.DocInclusionPredicate((name, desc) =>
                {
                    if (!desc.RelativePath.StartsWith($"{name}/"))
                    {
                        return false;
                    }

                    var actionVersion = desc.ActionAttributes().OfType<ApiVersionAttribute>().FirstOrDefault();
                    if (actionVersion != null && actionVersion.Versions.Any())
                    {
                        return actionVersion.Versions.Any(v => $"v{v.ToString()}" == name);
                    }

                    var controllerVersion = desc.ControllerAttributes().OfType<ApiVersionAttribute>().FirstOrDefault();
                    if (controllerVersion != null && controllerVersion.Versions.Any())
                    {
                        return controllerVersion.Versions.Any(v => $"v{v.ToString()}" == name);
                    }

                    return desc.RelativePath.StartsWith(name);
                });


                // Security Definitions
                document.AddSecurityDefinition("Client-Id", new ApiKeyScheme
                {
                    Name = "Client-Id",
                    Description = "",
                    Type = "apiKey",
                    In = "header"
                });
                document.AddSecurityDefinition("Client-Secret", new ApiKeyScheme
                {
                    Name = "Client-Secret",
                    Description = "",
                    Type = "apiKey",
                    In = "header"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "schema/{documentName}.json";
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle("Todo API");

                // Custom CSS
                c.InjectStylesheet("../sources/css/swagger.css");
                // Change the ui path
                c.RoutePrefix = "help";
                c.ShowJsonEditor();
                // Add Endpoints
                c.SwaggerEndpoint("/schema/v1.1.json", "v1.1");
                c.SwaggerEndpoint("/schema/v1.json", "v1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

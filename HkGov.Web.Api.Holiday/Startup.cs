using HkGov.Web.Api.Holiday.Diagnosis;
using HkGov.Web.Api.Holiday.Diagnosis.Probes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Swashbuckle.AspNetCore.Swagger;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace HkGov.Web.Api.Holiday
{
    /// <summary>
    /// Startup class to initial application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Application configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(c =>
            {
                c.EnableEndpointRouting = false;
            });
            services.Configure<AppSettings>(Configuration.GetSection(Constants.Settings.AppSettingSection));
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Constants.Api.Version, new OpenApiInfo { Title = Constants.Api.Title, Version = Constants.Api.Version });
                c.IncludeXmlComments(GetXmlCommentsPath());
            });

            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            services.AddHealthChecks().AddCheck<DataSourceHealthCheckProbe>(name: "Data source health check");
            services.AddOpenTelemetryTracing(builder =>
            {
                builder
                .AddConsoleExporter()
                .AddSource(Constants.ServiceName)
                .SetResourceBuilder(
                    ResourceBuilder.CreateDefault()
                        .AddService(serviceName: Constants.ServiceName, serviceVersion: version))
                .AddHttpClientInstrumentation()
                .AddAspNetCoreInstrumentation();
            });
        }

        /// <summary>
        /// gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                string endpointName = Constants.Api.Title + " " + Constants.Api.Version;
                c.SwaggerEndpoint(Constants.Api.SwaggerEndpoint, endpointName);
            });
            app.UseMvc();
            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    context.Response.ContentType = "application/json";
                    HealthCheckResponse response = new HealthCheckResponse
                    {
                        Status = report.Status.ToString(),
                        HealthCheckProbes = report.Entries.Select(o => new HealthCheckProbe
                        {
                            Component = o.Key,
                            Description = o.Value.Description,
                            Status = o.Value.Status.ToString(),
                            Duration = o.Value.Duration,
                            Exception = o.Value.Exception == null ? string.Empty : o.Value.Exception.ToString(),
                            Message = o.Value.Exception == null ? string.Empty : o.Value.Exception.Message,
                        }),
                        Duration = report.TotalDuration,
                    };
                    await context.Response.Body.WriteAsync(JsonSerializer.SerializeToUtf8Bytes(response));
                }
            });

        }

        private string GetXmlCommentsPath()
        {
            string namespaceName = Assembly.GetCallingAssembly().GetName().Name;
            return string.Format(@"{0}\" + namespaceName + ".xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}

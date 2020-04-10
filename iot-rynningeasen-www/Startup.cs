using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IoTRynningeasenWWW
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //{
            //    options.Authority = Configuration.GetSection("Authorization")["Authority"];
            //    options.Audience = Configuration.GetSection("Authorization")["Audience"];
            //});

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("iot-rynningeasen-policy", builder => builder.Requirements.Add(new ));
            //})

            services.AddSignalR();
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
            services.AddScoped<MeasurementLoggingAttribute>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            // Special for "old site" requests
            app.Use(async (context, next) =>
            {
                var pathValue = context.Request.Path.Value;
                if (pathValue.EndsWith("/temp") || pathValue.EndsWith("/temp/"))
                {
                    context.Request.Path = "/temp/index.html";
                    await next();
                }
                else
                {
                    await next();
                }
            });

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseSignalR(routes => { routes.MapHub<MeasurementsHub>("/serverpush"); });

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer("start");
                }
            });
        }
    }
}
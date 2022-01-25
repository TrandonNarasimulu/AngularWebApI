using EmployeeManagement.Application;
using EmployeeManagement.Infrastructure;
using EmployeeManagement.Infrastructure.Persistence;
using EmployeeManagement.UI.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeManagement.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ApiExceptionFilterAttribute>();
            services.AddCors(options => options.AddPolicy("CorsPolicy",
                        builder =>
                        {
                            builder.AllowAnyOrigin()
                                   .AllowAnyMethod()
                                   .AllowAnyHeader();
                        }));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllersWithViews();

            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddSwaggerDocument();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
            });

            app.UseCors("CorsPolicy");
            app.UseRouting();
            app.UseAuthorization();

            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<EmployeeManagementDbContext>();
            EmployeeManagementDbContextSeedData.SeedSampleDataAsync(context);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}

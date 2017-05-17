


using DomainLayer.Entities;
using DomainLayer.Interfaces;
using DomainLayer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DataLayer.Repositories;
using OldBoysWEB.Services;

namespace OldBoysWEB
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {

            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("wwwroot/appsettings.json");
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IMessagesService, MessagesService>();
            services.AddScoped<IRepo<Traning>, Repo<Traning>>();
            services.AddScoped<IRepo<User>, Repo<User>>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<ITraningService, TraningService>();
            services.AddSingleton(Configuration);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseFileServer(new FileServerOptions
            {
                EnableDefaultFiles = true,
                EnableDirectoryBrowsing = false,
            });
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc(routes => routes.MapRoute("default", "{controller=Home}/{Action=Index}/{id?}"));
            app.Run(async (context) => await context.Response.WriteAsync("Hello World!"));
        }
    }
}

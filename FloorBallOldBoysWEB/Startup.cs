using Data.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;
using FloorBallOldBoysWEB.IdentityUser;
using FloorBallOldBoysWEB.Services;
using FloorBallOldBoysWEB.Utilites;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ISession = FloorBallOldBoysWEB.Utilites.ISession;


namespace FloorBallOldBoysWEB
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {

            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IMessagesService, MessagesService>();
            services.AddScoped<IRepo<Training>, Repo<Training>>();
            services.AddScoped<IRepo<User>, Repo<User>>();
            services.AddScoped<IRepo<Address>, Repo<Address>>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<ITrainingService, TrainingService>();
            services.AddSingleton(Configuration);
            services.AddScoped<ISession, Session>();
            services.AddDbContext<UserAccountContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OldBoys")));
            services.AddIdentity<UserAccount, IdentityRole>(io =>
            {
                io.Password.RequireDigit = false;
                io.Password.RequireLowercase = false;
                io.Password.RequireNonAlphanumeric = false;
                io.Password.RequireUppercase = false;
                io.Password.RequiredLength = 6;
                io.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            }).AddEntityFrameworkStores<UserAccountContext>();
           

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
            //app.UseNodeModules(env.ContentRootPath);
            app.UseIdentity();
            app.UseMvc(routes => routes.MapRoute("default", "{controller=Account}/{Action=Login}/{id?}"));
            app.Run(async (context) => await context.Response.WriteAsync("Hello World!"));
        }
    }
}

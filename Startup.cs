using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Proyecto_sena.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Proyecto_sena.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto_sena
{
    public class Startup
    {
        // private string connection = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            // services.AddDbContext<ApplicationDbContext>(options =>
            //     options.UseSqlite(
            //          Configuration.GetConnectionString("DefaultConnection")));


            // var connectionString = "server=localhost;database=proyecto_innube;user=rosgori;password=" + contraseña_bd + ";treattinyasboolean=true";
            // var serverVersion = ServerVersion.AutoDetect(connectionString);

            // services.AddDbContext<proyecto_innubeContext>(
            // dbContextOptions => dbContextOptions
            //     .UseMySql(connectionString, serverVersion)
            //     .EnableSensitiveDataLogging() // <-- These two calls are optional but help
            //     .EnableDetailedErrors());     // <-- with debugging (remove for production).

            // string contraseña_bd = Configuration["contra_bd"];

            // var builder = new MySqlConnector.MySqlConnectionStringBuilder(Configuration.GetConnectionString("Innube_db"));
            // builder.Password = Configuration["contraseña_bd"];
            // connection = builder.ConnectionString;
            
            // services.AddDbContext<proyecto_innubeContext>(
            //     dbContextOptions =>
            //         dbContextOptions.
            //         UseMySql(connection, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"))
            //         .EnableSensitiveDataLogging()
            //         .EnableDetailedErrors()
            // );

            services.AddDatabaseDeveloperPageExceptionFilter();

            // services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //     .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
            {
                option.LoginPath = "/Sesion/Index";
                // option.AccessDeniedPath = "/Auth/Denegado";
                option.Events = new CookieAuthenticationEvents()
                {
                    OnSigningIn = async context =>
                    {
                        await Task.CompletedTask;
                    },
                    OnSignedIn = async context =>
                    {
                        await Task.CompletedTask;
                    },
                    OnValidatePrincipal = async context =>
                    {
                        await Task.CompletedTask;
                    },

                };

            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}

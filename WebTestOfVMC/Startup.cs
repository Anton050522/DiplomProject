using EmailServices.Interface;
using EmailServices.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.BLL.Services;
using Project.BLL.Services.IServiceIntefaces;
using RailDBProject;
using RailDBProject.Repository;
using Services.Interface;
using Services.Service;

namespace WebTestOfVMC
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
            services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddControllersWithViews();
            services.AddScoped<RailDBContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDefectServices, DefectServices>();
            services.AddScoped<IOperatorServices, OperatorService>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IOrganisationServices, OrganisationServices>();
            services.AddScoped<IGlobalSectionServices, GlobalSectionServices>();
            services.AddScoped<ILocalSectionServices, LocalSectionServices>();
            services.AddScoped<IOperatorServices, OperatorService>();
            services.AddScoped<IDefectoscopeServices, DefectoscopeServices>();
            services.AddScoped<IDangerousDefectServices, DangerousDefectServices>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options => //CookieAuthenticationOptions
               {
                   options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
               });
            services.AddSingleton<IEmailService, EmailService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=User}/{action=GetAllUsers}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    //pattern: "{controller=Home}/{action=Index}/{id?}");
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
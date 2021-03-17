using Centroware.Data.Data;
using Centroware.Model.Entities.Identity;
using Centroware.Repository.Interfaces.Generic;
using Centroware.Repository.Repositories.Generic;
using Centroware.Service.Interfaces;
using Centroware.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Centroware.Web
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
            services.AddDbContext<CentrowareDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<CentrowareUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = false;
            })
                .AddEntityFrameworkStores<CentrowareDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<IBlogCategoryService, BlogCategoryService>();
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<IJobService, JobService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IHomeService, HomeService>();
            services.AddTransient<IWorkService, WorkService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IOpinionService, OpinionService>();
            services.AddTransient<IUserService, UserService>();
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

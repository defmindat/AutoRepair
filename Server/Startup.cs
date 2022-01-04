using Application.Services;
using AutoMapper;
using AutoRepair.Mapper;
using AutoRepair.Middleware;
using Domain.Services;
using Domain.Services.Implementation;
using DomainModel;
using DomainModel.Catalog;
using DomainModel.Customers;
using DomainModel.Offices;
using DomainModel.Requests;
using DomainModel.Vehicles;
using DomainModel.WorkShops;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.Facade;
using Persistence.Repositories;

namespace AutoRepair
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
            var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<DomainModelFacade>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AutoRepairContextConnection")));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DomainModelFacade>();
            
            services.AddControllersWithViews();
            services.AddScoped<IRepository<Customer, long>, CustomerRepository>();
            services.AddScoped<IRepository<Address, long>, AddressRepository>();
            services.AddScoped<IRepository<Office, long>, OfficeRepository>();
            services.AddScoped<IRepository<Vehicle, long>, VehicleRepository>();
            services.AddScoped<IRepository<Workshop, long>, WorkshopRepository>();
            services.AddScoped<IRepository<Manager, string>, ManagerRepository>();
            services.AddScoped<IRepository<Request, long>, RequestRepository>();
            services.AddScoped<IRepository<DiagnosticItem, long>, DiagnosticItemRepository>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IOfficeControllerService, OfficeControllerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
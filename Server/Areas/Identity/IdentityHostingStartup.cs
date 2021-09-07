//using System;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using AutoRepair.Data;
//using AutoRepair.Models;

//[assembly: HostingStartup(typeof(AutoRepair.Areas.Identity.IdentityHostingStartup))]
//namespace AutoRepair.Areas.Identity
//{
//    public class IdentityHostingStartup : IHostingStartup
//    {
//        public void Configure(IWebHostBuilder builder)
//        {
//            builder.ConfigureServices((context, services) => {
//                services.AddDbContext<AutoRepairContext>(options =>
//                    options.UseSqlServer(
//                        context.Configuration.GetConnectionString("AutoRepairContextConnection")));                
//            });
//        }
//    }
//}


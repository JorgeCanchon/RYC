using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ryc.Areas.Identity.Data;
using ryc.Data;

[assembly: HostingStartup(typeof(ryc.Areas.Identity.IdentityHostingStartup))]
namespace ryc.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RyCDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("GearHost")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<RyCDbContext>();
            });
        }
    }
}
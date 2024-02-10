
using Labolatorium_3_v2.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Xml.Linq;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Labolatorium_3_v2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("PostDbContextConnection") ?? throw new InvalidOperationException("Connection string 'PostDbContextConnection' not found.");

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();            
            builder.Services.AddDbContext<PostDbContext>();

            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<PostDbContext>();
            builder.Services.AddDefaultIdentity<IdentityUser>()       
                .AddRoles<IdentityRole>()                             
                .AddEntityFrameworkStores<Data.PostDbContext>();

            builder.Services.AddTransient<IPostService, EFPostService>();
            builder.Services.AddMemoryCache();                        
            builder.Services.AddSession();
            builder.Services.AddControllersWithViews();
            //builder.Services.AddSingleton<IPostService, MemoryPostService>();         
            builder.Services.AddSingleton<IDateTimeProvider, CurrentDateTimeProvider>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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
            app.UseSession();                                         
            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
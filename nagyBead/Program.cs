using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using nagyBead.Areas.Identity.Data;

namespace nagyBead
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<researchContext>(options =>
                options.UseSqlite(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<researchContext>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            using(var scope = app.Services.CreateScope())
            {
                var roleManeger = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "admin", "user" };

                foreach (var role in roles)
                {
                    if(!await roleManeger.RoleExistsAsync(role))
                    {
                        await roleManeger.CreateAsync(new IdentityRole(role));
                    }
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManeger = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                string email = "admin@admin.com";
                string pw = "admin";

                if(await userManeger.FindByEmailAsync(email) == null)
                {
                    var user = new IdentityUser();
                    user.UserName = email;
                    user.Email = email;

                    await userManeger.CreateAsync(user, pw);

                    await userManeger.AddToRoleAsync(user, "admin");
                }

            }

            app.Run();
        }
    }
}
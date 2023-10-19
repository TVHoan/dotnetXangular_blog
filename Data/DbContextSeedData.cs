using DotnetAngular.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DotnetAngular.Data
{
    public class DbContextSeedData 
    {
        private ApplicationDbContext _context;

        public DbContextSeedData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedAdminUser()
        {
            var user = new ApplicationUser
            {
                UserName = "admin@admin.com",
                NormalizedUserName = "admin@admin.com",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var roleStore = new RoleStore<IdentityRole>(_context);

            if (!_context.Roles.Any(r => r.Name == "admin"))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "admin", NormalizedName = "admin" });
            }

            if (!_context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "123456");
                user.PasswordHash = hashed;
                var userStore = new UserStore<ApplicationUser>(_context);
                await userStore.CreateAsync(user);
                await userStore.AddToRoleAsync(user, "admin");
            }

            await _context.SaveChangesAsync();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mhung.Core.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Mhung.Data
{
    public class DataSeeDer
    {

        public async Task SeedAsync(MhungBlogContext context)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            
            var rootAdminRoleId = Guid.NewGuid();

            if (!context.Roles.Any())
            {
                await context.Roles.AddAsync(new AppRole()
                {
                    Id = rootAdminRoleId,
                    Name = "RootAdmin",
                    NormalizedName = "ROOTADMIN",
                    DisplayName = "Quản trị viên"
                });

                await context.SaveChangesAsync();
            }

            if (!context.Roles.Any())
            {
                var userId = Guid.NewGuid();
                var user = new AppUser()
                {
                    Id = userId,
                    FistName = "Manh",
                    LastName = "Hung",
                    Email = "admin@mhung.com.vn",
                    NormalizedEmail = "ADMIN@MHUNG.COM.VN",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    IsActive = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = false,
                    DateCreated = DateTime.Now, 
                };

                user.PasswordHash = passwordHasher.HashPassword(user, "Admin@123");
                await context.Users.AddAsync(user);

                await context.UserRoles.AddAsync(new IdentityUserRole<Guid>()
                {
                    RoleId = rootAdminRoleId,
                    UserId = userId
                });
                await context.SaveChangesAsync();
            }
        }
    }
}

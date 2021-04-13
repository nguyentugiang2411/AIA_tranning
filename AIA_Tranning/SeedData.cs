using AIA_Tranning.Common;
using AIA_Tranning.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIA_Tranning
{
    public class SeedData
    {
        public static void Seed(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            var users = userManager.GetUsersInRoleAsync(UserRoles.User).Result;

            if (userManager.FindByNameAsync("admin@localhost.com").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin@localhost.com",
                    Email = "admin@localhost.com"
                };
                var result = userManager.CreateAsync(user, "P@ssword1").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, UserRoles.Admin).Wait();
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync(UserRoles.Admin).Result)
            {
                var role = new IdentityRole
                {
                    Name = UserRoles.Admin
                };
                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync(UserRoles.User).Result)
            {
                var role = new IdentityRole
                {
                    Name = UserRoles.User
                };
                var result = roleManager.CreateAsync(role).Result;
            }
        }
    }
}

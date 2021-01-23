using Microsoft.AspNetCore.Identity;
using Proje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager,RoleManager<AppRole> rolemanager)
        {
            var adminRole = await rolemanager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await rolemanager.CreateAsync(new AppRole { Name = "Admin" });
            }
            var memberRole = await rolemanager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await rolemanager.CreateAsync(new AppRole { Name = "Member" });
            }
            var adminUser = await userManager.FindByNameAsync("tabiat");
            if (adminUser == null)
            {
                AppUser user = new AppUser
                {
                    Name = "Tabiat",
                    Surname = "Proje",
                    UserName = "tabiat",
                    Email = "tabiat@gmail.com",
                };
                await userManager.CreateAsync(user,"1");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}

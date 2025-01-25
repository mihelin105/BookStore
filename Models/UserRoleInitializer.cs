using Microsoft.AspNetCore.Identity;

namespace BookStore.Models
{
    public static class UserRoleInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var userManager = serviceProvider.GetRequiredService<UserManager<DefaultUser>>();

            string[] roleNames = { "Admin", "User" };

            IdentityResult roleResult;

            foreach(var role in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(role);
                if(!roleExists)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var email = "admin@site.com";
            var password = "Admin@123";

            if(userManager.FindByEmailAsync(email).Result == null)
            {
                DefaultUser user = new()
                {
                    Email = email,
                    UserName = email,
                    FirstName = "Admin",
                    LastName = "Admission",
                    Address = "Kalverstraat",
                    City = "Amsterdam",
                    ZipCode = "1012"
                };

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

        }

    }
}

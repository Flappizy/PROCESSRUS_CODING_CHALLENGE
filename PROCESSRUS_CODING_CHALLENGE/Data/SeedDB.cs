using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PROCESSRUS_CODING_CHALLENGE.Entities.Models;
using PROCESSRUS_CODING_CHALLENGE.Enums;

namespace PROCESSRUS_CODING_CHALLENGE.Data
{
    public static class SeedDB
    {

        public static async Task UseMigrationsAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<APIContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Users.Any())
                {
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                    await SeedData(userManager);
                    await context.SaveChangesAsync();
                }
            }
        }

        private static async Task SeedData(UserManager<User> userManager)
        {
            List<User> users = new List<User>
            {
                new Admin
                {
                    FirstName = "Ade",
                    LastName = "Smith",
                    Company = "Process",
                    UserName = "ade.smith@gmail.com",
                    Email = "ade.smith@gmail.com",
                    AccountType = AccountType.Admin
                },
                new BackOffice
                {
                    FirstName = "John",
                    LastName = "Samuel",
                    Company = "Process",
                    UserName = "john.samuel@gmail.com",
                    Email = "john.samuel@gmail.com",
                    AccountType = AccountType.BackOffice
                },
                new FrontOffice
                {
                    FirstName = "Doe",
                    LastName = "Leo",
                    Company = "Process",
                    UserName = "doe.low@gmail.com",
                    Email = "doe.low@gmail.com",
                    AccountType = AccountType.FrontOffice
                }
            };

            foreach (var user in users)
            {
                if (await userManager.FindByNameAsync(user.UserName) == null)
                {
                    await userManager.CreateAsync(user, "testPassword1!");
                }
            }
        }

    }
}

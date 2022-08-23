using Microsoft.AspNetCore.Identity;
using Scheduler.Api.Authentication;

namespace Scheduler.Api.Data
{
    public class Seeder
    {
        public static async Task Seed(UserManager<User> userManager)
        {
            // tworzenie userów
            User admin = await userManager.FindByNameAsync("Admin");
            if (admin == null)
            {
                admin = new User
                {
                    Email = "maciej.wozniczka@outlook.com",
                    UserName = "Admin"
                };
                await userManager.CreateAsync(admin, "OCa8*2C#aW8q");
            }

            User user = new User
            {
                Email = "maciej.wozniczka@outlook2.com",
                UserName = "ClientAdmin"
            };
            await userManager.CreateAsync(user, "o2OG5F2*Mtcm");

            User user2 = new User
            {
                Email = "maciej.wozniczka@outlook3.com",
                UserName = "ClientUser"
            };
            await userManager.CreateAsync(user2, "O320&7%CVFui");
        }
    }
}
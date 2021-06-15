namespace CourseWork.Data.Seeder
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using CourseWork.Data.Models;

    public class BasicUserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            ApplicationUser userFromDb = await userManager.FindByEmailAsync("student@student.it");

            if (userFromDb != null)
            {
                return;
            }

            var user = new ApplicationUser
            {
                Email = "student@student.it",
                UserName = "student@student.it",
            };

            var result = await userManager.CreateAsync(user, "student123");

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
            }
            await dbContext.SaveChangesAsync();
        }
    }
}

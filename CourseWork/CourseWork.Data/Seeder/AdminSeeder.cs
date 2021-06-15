namespace CourseWork.Data.Seeder
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using CourseWork.Common;
    using CourseWork.Data.Models;
    using System.Linq;

    public class AdminSeeder : ISeeder
    {   
        async Task ISeeder.SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            ApplicationUser userFromDb = await userManager.FindByEmailAsync("admin@admin.it");

            if (userFromDb != null)
            {
                return;
            }

            var user = new ApplicationUser
            {
                Email = "admin@admin.it",
                UserName = "admin@admin.it",
            };
            var result = await userManager.CreateAsync(user, "admin123");
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
            }
            await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
            await dbContext.SaveChangesAsync();
        }
    }
}

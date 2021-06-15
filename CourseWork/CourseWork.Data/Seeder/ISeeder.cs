namespace CourseWork.Data.Seeder
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        virtual Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            return Task.CompletedTask;
        }
    }
}

namespace CourseWork.Data.Seeder
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CourseWork.Data.Models;
    using CourseWork.Data.Seeder.Dtos;
    using CourseWork.Data.XmlFacade;

    public class CardSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var path = Directory.GetCurrentDirectory() + ".Data/Seeder/Datasets/cards.xml";
            var cardsXml = File.ReadAllText(path);
            const string rootElement = "Cards";

            var cardsDtos = XmlConverter.Deserializer<ImportCardsDto>(cardsXml, rootElement);
            var cards = cardsDtos
                .Select(c => new Card
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl,
                    Description = c.Description,
                    Attack = c.Attack,
                    Defense = c.Defense,
                })
                .ToList();

            await dbContext.Cards.AddRangeAsync(cards);
            await dbContext.SaveChangesAsync();
        }
    }
}

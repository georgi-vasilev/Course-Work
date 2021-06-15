namespace CourseWork.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CourseWork.Data;
    using CourseWork.Data.Models;
    using CourseWork.Services.Mapping;
    using CourseWork.ViewModels.Cards;

    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext dbContext;

        public CardsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddCardToUserCollection(string userId, int cardId)
        {
            if (this.dbContext.UserCards.Any(x => x.UserId == userId && x.CardId == cardId))
            {
                return;
            }

            this.dbContext.UserCards.Add(new UserCard
            {
                UserId = userId,
                CardId = cardId,
            });
            await this.dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(CreateCardInputModel input)
        {
            var card = input.To<Card>();

            await this.dbContext.AddAsync(card);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cardToDelete = this.dbContext.Cards.FirstOrDefault(x => x.Id == id);

            this.dbContext.Cards.Remove(cardToDelete);
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<CardViewModel> GetAll()
        {
            return this.dbContext.Cards.Select(x => x.To<CardViewModel>()).ToList();
            //return this.dbContext.Cards.Select(x => new CardViewModel
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Attack = x.Attack,
            //    Description = x.Description,
            //    Defense = x.Defense,
            //    ImageUrl = x.ImageUrl,
            //}).ToList();
        }

        public IEnumerable<CardViewModel> GetById(string id)
        {
            return this.dbContext.UserCards
                .Where(x => x.UserId == id)
                .Select(x => new CardViewModel
                {
                    Id = x.CardId,
                    Name = x.Card.Name,
                    ImageUrl = x.Card.ImageUrl,
                    Attack = x.Card.Attack,
                    Defense = x.Card.Defense,
                    Description = x.Card.Description,
                })
                .ToList();
        }

        public int GetCount()
        {
            return this.dbContext.Cards.Count();
        }

        public IEnumerable<T> GetRandom<T>(int count)
        {
            return this.dbContext.Cards
                .OrderBy(x => Guid.NewGuid())
                .Take(count)
                .To<T>()
                .ToList();
        }

        public async Task RemoveCardFromUserCollection(int cardId, string userId)
        {
            var userCard = this.dbContext.UserCards.FirstOrDefault(x => x.UserId == userId && x.CardId == cardId);
            if (userCard == null)
            {
                return;
            }

            this.dbContext.UserCards.Remove(userCard);
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            var cards = this.dbContext.Cards
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>().ToList();

            return cards;
        }

        public T GetById<T>(int cardId)
        {
            var card = this.dbContext.Cards
                .Where(x => x.Id == cardId)
                .To<T>()
                .FirstOrDefault();

            return card;
        }

        public async Task UpdateAsync(int id, EditCardInputModel model)
        {
            Card card = this.dbContext.Cards.FirstOrDefault(x => x.Id == id);
            card.Name = model.Name;
            card.ImageUrl = model.ImageUrl;
            card.Attack = model.Attack;
            card.Defense = model.Defense;
            card.Description = model.Description;
            await this.dbContext.SaveChangesAsync();
        }
    }
}

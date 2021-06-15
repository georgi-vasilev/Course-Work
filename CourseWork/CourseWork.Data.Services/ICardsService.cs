namespace CourseWork.Data.Services
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using CourseWork.ViewModels.Cards;

    public interface ICardsService
    {
        Task CreateAsync(CreateCardInputModel input);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        IEnumerable<T> GetRandom<T>(int count);

        int GetCount();

        IEnumerable<CardViewModel> GetById(string userId);

        T GetById<T>(int cardId);

        Task DeleteAsync(int id);

        Task AddCardToUserCollection(string userId, int cardId);

        Task RemoveCardFromUserCollection(int cardId, string userId);

        Task UpdateAsync(int id, EditCardInputModel model);
    }
}

namespace CourseWork.ViewModels.Cards
{
    using System.Collections.Generic;

    public class CardsListViewModel : PagingViewModel
    {
        public IEnumerable<CardsInListViewModel> Cards { get; set; }
    }
}

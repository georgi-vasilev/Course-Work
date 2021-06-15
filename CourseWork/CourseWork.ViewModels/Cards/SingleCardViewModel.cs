namespace CourseWork.ViewModels.Cards
{
    using CourseWork.Data.Models;
    using CourseWork.Services.Mapping;

    public class SingleCardViewModel : BaseCardViewModel, IMapFrom<Card>
    {
        public int Attack { get; set; }

        public int Defense { get; set; }

        public string Description { get; set; }
    }
}

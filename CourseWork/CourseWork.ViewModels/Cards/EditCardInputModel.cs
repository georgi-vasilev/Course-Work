namespace CourseWork.ViewModels.Cards
{
    using CourseWork.Data.Models;
    using CourseWork.Services.Mapping;

    public class EditCardInputModel : BaseCardViewModel, IMapFrom<Card>
    {
        public string Description { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }
    }
}

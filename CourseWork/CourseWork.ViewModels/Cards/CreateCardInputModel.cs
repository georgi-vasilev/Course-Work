namespace CourseWork.ViewModels.Cards
{
    using System.ComponentModel.DataAnnotations;

    using CourseWork.Data.Models;
    using CourseWork.Services.Mapping;

    public class CreateCardInputModel : BaseCardViewModel, IMapTo<Card>
    {
        [Range(1, 100_000)]
        public int Attack { get; set; }

        [Range(1, 100_000)]
        public int Defense { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}

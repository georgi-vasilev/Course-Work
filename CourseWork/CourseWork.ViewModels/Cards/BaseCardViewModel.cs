namespace CourseWork.ViewModels.Cards
{
    using System.ComponentModel.DataAnnotations;

    public class BaseCardViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}

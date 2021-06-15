namespace CourseWork.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Card
    {
        public Card()
        {
            this.UserCards = new HashSet<UserCard>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [Range(1, 100_000)]
        public int Attack { get; set; }

        [Range(1, 100_000)]
        public int Defense { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public virtual ICollection<UserCard> UserCards { get; set; }
    }
}

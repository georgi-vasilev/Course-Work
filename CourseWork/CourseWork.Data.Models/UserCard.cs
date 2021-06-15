namespace CourseWork.Data.Models
{
    public class UserCard
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int CardId { get; set; }

        public virtual Card Card { get; set; }

    }
}

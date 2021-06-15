namespace CourseWork.Data.Models
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.UserCards = new HashSet<UserCard>();
        }

        public virtual ICollection<UserCard> UserCards { get; set; }

    }
}

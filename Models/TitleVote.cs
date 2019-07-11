using Microsoft.AspNetCore.Identity;

namespace NTytL.Models
{
    public class TitleVote
    {
        public virtual IdentityUser User { get; set; }
        public virtual Title Title { get; set; }
    }
}

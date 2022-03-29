using Microsoft.AspNetCore.Identity;

namespace ChallengeAlternativo.API.Entities
{
    public class User : IdentityUser
    {
        public bool IsActive { get; set; }
    }
}

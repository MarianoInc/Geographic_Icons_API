using System.ComponentModel.DataAnnotations;

namespace ChallengeAlternativo.API.ViewModels.Auth.Login
{
    public class LoginRequestViewModel
    {
        [Required]
        [MinLength(6)]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}

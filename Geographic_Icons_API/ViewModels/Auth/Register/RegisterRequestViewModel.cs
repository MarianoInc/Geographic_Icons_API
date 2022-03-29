﻿using System.ComponentModel.DataAnnotations;
namespace ChallengeAlternativo.API.ViewModels.Auth.Register
{
    public class RegisterRequestViewModel
    {
        [Required]
        [MinLength(6)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}

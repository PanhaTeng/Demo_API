﻿using System.ComponentModel.DataAnnotations;
namespace ASP_JWT.SecurityConfig
{
    public class RegistrationRequest
    {

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}

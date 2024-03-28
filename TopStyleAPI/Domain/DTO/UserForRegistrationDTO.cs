﻿using System.ComponentModel.DataAnnotations;

namespace TopStyleAPI.Domain.DTO
{
    public class UserForRegistrationDTO
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string? Email {  get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<string>? Roles { get; set; }
    }
}

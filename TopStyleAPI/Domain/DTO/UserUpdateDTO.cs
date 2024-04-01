using System.ComponentModel.DataAnnotations;

namespace TopStyleAPI.Domain.DTO
{
    public class UserUpdateDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        [StringLength(256, ErrorMessage = "Max length of email is 256 characters.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string PhoneNumber { get; set; }

    }
}

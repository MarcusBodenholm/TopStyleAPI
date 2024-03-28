using System.ComponentModel.DataAnnotations;

namespace TopStyleAPI.Domain.DTO
{
    public class ProductCreateDTO
    {
        [Required(ErrorMessage = "Title is a required field.")]
        [MaxLength(500, ErrorMessage = "Maximum length for the title is 100 characters.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is a required field.")]
        [MaxLength(1000, ErrorMessage = "Maximum length for the description is 1000 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is a required field.")]
        public int Price { get; set; }
        [Required(ErrorMessage = "CategoryID is a required field.")]
        public int CategoryID { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TopStyleAPI.Domain.Entities
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(100)]
        public string CategoryName { get; set; }
        public virtual List<Product> Products { get; set; }

    }
}

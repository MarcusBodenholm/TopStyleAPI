using System.ComponentModel.DataAnnotations;

namespace TopStyleAPI.Domain.Entities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public int Price { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}

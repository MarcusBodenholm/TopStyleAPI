using System.ComponentModel.DataAnnotations;

namespace TopStyleAPI.Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public DateTime OrderCreated {  get; set; }
        public double OrderTotal { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}

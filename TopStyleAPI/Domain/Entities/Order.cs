using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TopStyleAPI.Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public DateTime OrderCreated {  get; set; }
        public double OrderTotal { get; set; }
        [JsonIgnore]
        public virtual Customer Customer { get; set; }
        [JsonIgnore]
        public virtual List<Product> Products { get; set; }
    }
}

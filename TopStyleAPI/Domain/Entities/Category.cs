using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TopStyleAPI.Domain.Entities
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(100)]
        public string CategoryName { get; set; }
        [JsonIgnore]
        public virtual List<Product> Products { get; set; }

    }
}

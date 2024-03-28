using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace TopStyleAPI.Domain.Entities
{
    public class Customer : IdentityUser
    {
        [JsonIgnore]
        public virtual List<Order> Orders { get; set; }
    }
}

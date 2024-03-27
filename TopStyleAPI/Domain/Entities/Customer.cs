using Microsoft.AspNetCore.Identity;

namespace TopStyleAPI.Domain.Entities
{
    public class Customer : IdentityUser
    {
        public virtual List<Order> Orders { get; set; }
    }
}

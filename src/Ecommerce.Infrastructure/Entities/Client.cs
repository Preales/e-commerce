using Ecommerce.Infrastructure.Entities.Base;
using System.Collections.Generic;

namespace Ecommerce.Infrastructure.Entities
{
    public class Client : BaseEntity<string>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Shipping> Shippings { get; set; }
        public virtual ICollection<Order> Orders{ get; set; }
    }
}
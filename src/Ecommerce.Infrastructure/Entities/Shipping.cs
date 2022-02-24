using Ecommerce.Infrastructure.Entities.Base;
using System;

namespace Ecommerce.Infrastructure.Entities
{
    public class Shipping : BaseEntity<Guid>
    {
        public string ClientId { get; set; }
        public string Country { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public virtual Client Client { get; set; }
        public virtual Order Order { get; set; }
    }
}
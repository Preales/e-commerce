using Ecommerce.Infrastructure.Entities.Base;
using System.Collections.Generic;

namespace Ecommerce.Infrastructure.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Tax { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
using Ecommerce.Infrastructure.Entities.Base;
using System;

namespace Ecommerce.Infrastructure.Entities
{
    public class OrderDetail : BaseEntity<Guid>
    {
        public Guid OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Tax { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
using Ecommerce.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;

namespace Ecommerce.Infrastructure.Entities
{
    public class Order : BaseEntity<Guid>
    {
        public string ClientId { get; set; }
        public Guid ShippingId { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal AmountTotal { get; set; }
        public virtual Client Client { get; set; }
        public virtual Shipping Shipping { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
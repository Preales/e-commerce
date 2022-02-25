using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Service.Dtos
{
    public class OrderRequestDto
    {
        public string ClientId { get; set; }
        public Guid ShippingId { get; set; }

        public decimal DiscountTotal { get => OrderDetails.Sum(x => x.Discount); }
        public decimal AmountTotal { get => OrderDetails.Sum(x => x.Amount); }

        public DateTime CreationDate { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Ecommerce.Service.Dtos
{
    public class OrderDto
    {
        public string ClientId { get; set; }
        public Guid ShippingId { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal AmountTotal { get; set; }
        public DateTime CreationDate { get; set; }
        public List<OrderDetailUpdateDto> OrderDetails { get; set; }
    }

    public class OrderUpdateDto : OrderDto
    {
        public Guid Id { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
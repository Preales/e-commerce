using System;
using System.Collections.Generic;

namespace Ecommerce.Service.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string ClientId { get; set; }
        public Guid ShippingId { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal AmountTotal { get; set; }
        public DateTime CreationDate { get; set; }
        public List<OrderDetailUpdateDto> OrderDetails { get; set; }
    }

    public class OrderUpdateDto : OrderDto
    {
        public DateTime? ModificationDate { get; set; }
    }

    public class OrderInlcudeDto : OrderDto
    {
        public ClientDto Client { get; set; }
        public ShippingUpdateDto Shipping { get; set; }
    }
}
using System;

namespace Ecommerce.Business.Api.Models
{
    public class OrderModel
    {
        public string ClientId { get; set; }
        public Guid ShippingId { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal AmountTotal { get; set; }
    }

    public class OrderUpdateModel : OrderModel
    {
        public Guid Id { get; set; }
    }
}
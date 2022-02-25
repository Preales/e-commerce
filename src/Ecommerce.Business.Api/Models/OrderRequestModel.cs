using System;
using System.Collections.Generic;

namespace Ecommerce.Business.Api.Models
{
    public class OrderRequestModel
    {
        public string ClientId { get; set; }
        public Guid ShippingId { get; set; }
        public List<OrderDetailRequestModel> OrderDetails { get; set; }
    }
}
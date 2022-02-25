using System;

namespace Ecommerce.Business.Api.Models
{

    public class OrderDetailModel : OrderDetailRequestModel
    {
        public Guid OrderId { get; set; }

    }

    public class OrderDetailRequestModel
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Tax { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount
        {
            get => ((Price - Discount) + ((Price - Discount) * (Tax / 100m))) * Quantity;            
        }
    }

    public class OrderDetailUpdateModel : OrderDetailModel
    {
        public Guid Id { get; set; }
    }
}
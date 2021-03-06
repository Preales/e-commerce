using System;

namespace Ecommerce.Service.Dtos
{
    public class OrderDetailDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Tax { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class OrderDetailUpdateDto : OrderDetailDto
    {
        public DateTime? ModificationDate { get; set; }
    }
}
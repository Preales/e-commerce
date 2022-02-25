using System;

namespace Ecommerce.Service.Dtos
{
    public class ShippingDto
    {
        public Guid Id { get; set; }
        public string ClientId { get; set; }
        public string Country { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class ShippingUpdateDto : ShippingDto
    {
        public DateTime? ModificationDate { get; set; }
    }
}
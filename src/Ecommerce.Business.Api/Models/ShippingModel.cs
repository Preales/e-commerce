using System;

namespace Ecommerce.Business.Api.Models
{
    public class ShippingModel
    {
        public string ClientId { get; set; }
        public string Country { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }

    public class ShippingUpdateModel : ShippingModel
    {
        public Guid Id { get; set; }
    }
}
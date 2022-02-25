using System;

namespace Ecommerce.Business.Api.Models
{
    public class ProductModel
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Tax { get; set; }
    }

    public class ProductUpdateModel : ProductModel
    {
        public int Id { get; set; }
    }
}
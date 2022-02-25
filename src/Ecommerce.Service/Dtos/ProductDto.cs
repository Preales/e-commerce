using System;

namespace Ecommerce.Service.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Tax { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class ProductUpdateDto : ProductDto
    {
        public DateTime? ModificationDate { get; set; }
    }
}
using Ecommerce.Service.Dtos;
using Ecommerce.Service.Interfaces.Base;

namespace Ecommerce.Service.Interfaces
{
    public interface IProductService : IBaseService<ProductDto, ProductUpdateDto, int>
    {
    }
}
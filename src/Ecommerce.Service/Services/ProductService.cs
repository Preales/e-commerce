using AutoMapper;
using Ecommerce.Infrastructure.Entities;
using Ecommerce.Infrastructure.UnitOfWork;
using Ecommerce.Service.Dtos;
using Ecommerce.Service.Interfaces;
using Ecommerce.Service.Services.Base;

namespace Ecommerce.Service.Services
{
    public class ProductService : BaseService<Product, ProductDto, ProductUpdateDto, int>, IProductService
    {
        public ProductService(
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}

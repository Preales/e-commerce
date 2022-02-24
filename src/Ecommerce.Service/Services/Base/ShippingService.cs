using AutoMapper;
using Ecommerce.Infrastructure.Entities;
using Ecommerce.Infrastructure.UnitOfWork;
using Ecommerce.Service.Dtos;
using Ecommerce.Service.Interfaces;
using System;

namespace Ecommerce.Service.Services.Base
{
    public class ShippingService : BaseService<Shipping, ShippingDto, ShippingUpdateDto, Guid>, IShippingService
    {
        public ShippingService(
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}

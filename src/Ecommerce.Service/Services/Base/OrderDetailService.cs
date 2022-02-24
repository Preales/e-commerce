using AutoMapper;
using Ecommerce.Infrastructure.Entities;
using Ecommerce.Infrastructure.UnitOfWork;
using Ecommerce.Service.Dtos;
using Ecommerce.Service.Interfaces;
using System;

namespace Ecommerce.Service.Services.Base
{
    public class OrderDetailService : BaseService<OrderDetail, OrderDetailDto, OrderDetailUpdateDto, Guid>, IOrderDetailService
    {
        public OrderDetailService(
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}

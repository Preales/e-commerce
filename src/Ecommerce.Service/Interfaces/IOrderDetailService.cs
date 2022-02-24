using Ecommerce.Service.Dtos;
using Ecommerce.Service.Interfaces.Base;
using System;

namespace Ecommerce.Service.Interfaces
{
    public interface IOrderDetailService : IBaseService<OrderDetailDto, OrderDetailUpdateDto, Guid>
    {
    }
}
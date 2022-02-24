using Ecommerce.Service.Dtos;
using Ecommerce.Service.Interfaces.Base;
using System;

namespace Ecommerce.Service.Interfaces
{
    public interface IOrderService : IBaseService<OrderDto, OrderUpdateDto, Guid>
    {
    }
}
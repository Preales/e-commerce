using Ecommerce.Service.Dtos;
using Ecommerce.Service.Interfaces.Base;
using System;
using System.Threading.Tasks;

namespace Ecommerce.Service.Interfaces
{
    public interface IOrderService : IBaseService<OrderDto, OrderUpdateDto, Guid>
    {
        Task<OrderInlcudeDto> GetByIdIncludeAsync(Guid id);
        Task<(bool status, string message, Guid id)> PostAsync(OrderRequestDto entity);
    }
}
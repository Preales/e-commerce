using Ecommerce.Service.Dtos;
using Ecommerce.Service.Interfaces.Base;
using System;

namespace Ecommerce.Service.Interfaces
{
    public interface IShippingService : IBaseService<ShippingDto, ShippingUpdateDto, Guid>
    {
    }
}
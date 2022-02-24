using Ecommerce.Service.Dtos;
using Ecommerce.Service.Interfaces.Base;

namespace Ecommerce.Service.Interfaces
{
    public interface IClientService : IBaseService<ClientDto, ClientUpdateDto, string>
    {
    }
}
using AutoMapper;
using Ecommerce.Infrastructure.Entities;
using Ecommerce.Infrastructure.UnitOfWork;
using Ecommerce.Service.Dtos;
using Ecommerce.Service.Interfaces;

namespace Ecommerce.Service.Services.Base
{
    public class ClientService : BaseService<Client, ClientDto, ClientUpdateDto, string>, IClientService
    {
        public ClientService(
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}

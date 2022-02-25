using AutoMapper;
using Ecommerce.Infrastructure.Entities;
using Ecommerce.Infrastructure.Repository;
using Ecommerce.Infrastructure.UnitOfWork;
using Ecommerce.Service.Dtos;
using Ecommerce.Service.Interfaces;
using Ecommerce.Service.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services
{
    public class OrderService : BaseService<Order, OrderDto, OrderUpdateDto, Guid>, IOrderService
    {
        public readonly IRepository<Client> _repositoryClient;
        public readonly IRepository<Shipping> _repositoryShipping;
        public readonly IRepository<Product> _repositoryProduct;
        public OrderService(
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper)
        {
            _repositoryClient = unitOfWork.CreateRepository<Client>();
            _repositoryShipping = unitOfWork.CreateRepository<Shipping>();
            _repositoryProduct = unitOfWork.CreateRepository<Product>();
        }

        public async Task<OrderInlcudeDto> GetByIdIncludeAsync(Guid id)
        {
            var result = await _repository
                .FirstOrDefaultAsync(x => id.Equals(x.Id) && !x.Deleted, include : i => i.Include(s => s.OrderDetails)
                                                                                        .Include(s => s.Client)
                                                                                        .Include(s => s.Shipping));
            return _mapper.Map<OrderInlcudeDto>(result);
        }

        public async Task<(bool status, string message, Guid id)> PostAsync(OrderRequestDto entity)
        {
            var existingClient = await _repositoryClient.FirstOrDefaultAsync(x => x.Id == entity.ClientId && !x.Deleted);
            if (existingClient is null) return (false, "Cliente no existe", Guid.Empty);

            var existingShipping = await _repositoryShipping.FirstOrDefaultAsync(x => x.Id == entity.ShippingId && x.ClientId == entity.ClientId && !x.Deleted);
            if (existingShipping is null) return (false, "Datos de envio no existe", Guid.Empty);

            string messageProduct = string.Empty;
            foreach (var item in entity.OrderDetails)
            {
                var existingProduct = await _repositoryProduct.FirstOrDefaultAsync(x => x.Id == item.ProductId && !x.Deleted);
                if (existingProduct is null) messageProduct = $"{item.ProductId},";
                item.CreationDate = DateTime.Now;
            }

            if (!string.IsNullOrEmpty(messageProduct))
                return (false, $"Producto(s) {messageProduct} no existe(n)", Guid.Empty);

            var obj = _mapper.Map<Order>(entity);
            _repository.Insert(obj);
            var status = await _unitOfWork.SaveAsync();
            return (status, "Pedido creado exitosamente", obj.Id);
        }
    }
}
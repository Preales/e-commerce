using AutoMapper;
using Ecommerce.Business.Api.Models;
using Ecommerce.Infrastructure.Entities;
using Ecommerce.Service.Dtos;

namespace Ecommerce.Business.Api.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ClientModel, ClientDto>().ReverseMap();
            CreateMap<ClientModel, ClientUpdateDto>().ReverseMap();
            CreateMap<ClientDto, Client>().ReverseMap();
            CreateMap<ClientUpdateDto, Client>().ReverseMap();

            CreateMap<OrderDetailModel, OrderDetailDto>().ReverseMap();
            CreateMap<OrderDetailRequestModel, OrderDetailDto>().ReverseMap();
            CreateMap<OrderDetailUpdateModel, OrderDetailUpdateDto>().ReverseMap();
            CreateMap<OrderDetailDto, OrderDetail>().ReverseMap();
            CreateMap<OrderDetailUpdateDto, OrderDetail>().ReverseMap();

            CreateMap<OrderModel, OrderDto>().ReverseMap();
            CreateMap<OrderUpdateModel, OrderUpdateDto>().ReverseMap();
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<OrderUpdateDto, Order>().ReverseMap();
            CreateMap<OrderInlcudeDto, Order>().ReverseMap();

            CreateMap<OrderRequestModel, OrderRequestDto>().ReverseMap();
            CreateMap<OrderRequestDto, Order>().ReverseMap();

            CreateMap<ProductModel, ProductDto>().ReverseMap();
            CreateMap<ProductUpdateModel, ProductUpdateDto>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();

            CreateMap<ShippingModel, ShippingDto>().ReverseMap();
            CreateMap<ShippingUpdateModel, ShippingUpdateDto>().ReverseMap();
            CreateMap<ShippingDto, Shipping>().ReverseMap();
            CreateMap<ShippingUpdateDto, Shipping>().ReverseMap();
        }
    }
}
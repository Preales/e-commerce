using AutoMapper;
using Ecommerce.Business.Api.Models;
using Ecommerce.Common.Dtos;
using Ecommerce.Common.Enums;
using Ecommerce.Service.Dtos;
using Ecommerce.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Ecommerce.Business.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrderService _service;
        private readonly ILogger<OrdersController> _logger;
        private readonly IMapper _mapper;

        public OrdersController(
            ILogger<OrdersController> logger,
            IOrderService service,
            IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseService<OrderDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            _logger.LogInformation(nameof(GetByIdAsync));

            var result = await _service.GetByIdAsync(id);
            var existResult = result != null;
            var response = new ResponseService<OrderDto>
            {
                Status = existResult,
                Message = existResult ? GenericEnumerator.Status.Ok.ToStringAttribute() : GenericEnumerator.Status.Error.ToStringAttribute(),
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("GetByIdInclude/{id}")]
        [ProducesResponseType(typeof(ResponseService<OrderInlcudeDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByIdIncludeAsync(Guid id)
        {
            _logger.LogInformation(nameof(GetByIdIncludeAsync));

            var result = await _service.GetByIdIncludeAsync(id);
            var existResult = result != null;
            var response = new ResponseService<OrderInlcudeDto>
            {
                Status = existResult,
                Message = existResult ? GenericEnumerator.Status.Ok.ToStringAttribute() : GenericEnumerator.Status.Error.ToStringAttribute(),
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("{page:int}/{limit:int}")]
        [ProducesResponseType(typeof(ResponseService<IEnumerable<OrderDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync(int? page, int? limit)
        {
            _logger.LogInformation(nameof(GetAllAsync));

            var result = await _service.GetAllAsync(page ?? 1, limit ?? 1000, "Id");
            var resultDtos = result as OrderDto[] ?? result.ToArray();
            var response = new ResponseService<IEnumerable<OrderDto>>
            {
                Status = resultDtos.Any(),
                Message = resultDtos.Any() ? GenericEnumerator.Status.Ok.ToStringAttribute() : GenericEnumerator.Status.Error.ToStringAttribute(),
                Data = resultDtos
            };
            return Ok(response);
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        [ProducesResponseType(typeof(ResponseService<Guid>), (int)HttpStatusCode.Created)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(OrderModel))]
        public async Task<IActionResult> PostAsync([FromBody] OrderModel request)
        {
            _logger.LogInformation(nameof(PostAsync));

            var objRequest = _mapper.Map<OrderDto>(request);
            objRequest.CreationDate = DateTime.Now;

            var (status, id) = await _service.PostAsync(objRequest);

            return Ok(new ResponseService<Guid>
            {
                Status = status,
                Data = status ? id : default
            });
        }

        [HttpPut("{id}")]
        [DisableRequestSizeLimit]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResponseService<bool>), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(OrderUpdateModel))]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] OrderUpdateModel request)
        {
            _logger.LogInformation(nameof(PutAsync));

            if (request == null || id != request.Id)
            {
                return BadRequest();
            }

            var objRequest = _mapper.Map<OrderUpdateDto>(request);
            objRequest.ModificationDate = DateTime.Now;

            var status = await _service.PutAsync(id, objRequest);

            return Ok(new ResponseService<bool>
            {
                Status = status
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResponseService<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            _logger.LogInformation(nameof(DeleteAsync));

            var status = await _service.DeleteAsync(id);

            return Ok(new ResponseService<bool>
            {
                Status = status
            });
        }

        [HttpDelete("logic/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResponseService<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteLogicAsync(Guid id)
        {
            _logger.LogInformation(nameof(DeleteAsync));

            DeletedInfo<Guid> info = new()
            {
                Id = id
            };

            var status = await _service.DeleteLogicAsync(info);

            return Ok(new ResponseService<bool>
            {
                Status = status
            });
        }
    }
}
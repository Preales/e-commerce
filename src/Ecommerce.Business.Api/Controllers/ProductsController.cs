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
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _service;
        private readonly ILogger<ProductsController> _logger;
        private readonly IMapper _mapper;

        public ProductsController(
            ILogger<ProductsController> logger,
            IProductService service,
            IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseService<ProductDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            _logger.LogInformation(nameof(GetByIdAsync));

            var result = await _service.GetByIdAsync(id);
            var existResult = result != null;
            var response = new ResponseService<ProductDto>
            {
                Status = existResult,
                Message = existResult ? GenericEnumerator.Status.Ok.ToStringAttribute() : GenericEnumerator.Status.Error.ToStringAttribute(),
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("{page:int}/{limit:int}")]
        [ProducesResponseType(typeof(ResponseService<IEnumerable<ProductDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync(int? page, int? limit)
        {
            _logger.LogInformation(nameof(GetAllAsync));

            var result = await _service.GetAllAsync(page ?? 1, limit ?? 1000, "Id");
            var resultDtos = result as ProductDto[] ?? result.ToArray();
            var response = new ResponseService<IEnumerable<ProductDto>>
            {
                Status = resultDtos.Any(),
                Message = resultDtos.Any() ? GenericEnumerator.Status.Ok.ToStringAttribute() : GenericEnumerator.Status.Error.ToStringAttribute(),
                Data = resultDtos
            };
            return Ok(response);
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        [ProducesResponseType(typeof(ResponseService<int>), (int)HttpStatusCode.Created)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(ProductModel))]
        public async Task<IActionResult> PostAsync([FromBody] ProductModel request)
        {
            _logger.LogInformation(nameof(PostAsync));

            var objRequest = _mapper.Map<ProductDto>(request);
            objRequest.CreationDate = DateTime.Now;

            var (status, id) = await _service.PostAsync(objRequest);

            return Ok(new ResponseService<int>
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
        [Produces(MediaTypeNames.Application.Json, Type = typeof(ProductUpdateModel))]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ProductUpdateModel request)
        {
            _logger.LogInformation(nameof(PutAsync));

            if (request == null || id != request.Id)
            {
                return BadRequest();
            }

            var objRequest = _mapper.Map<ProductUpdateDto>(request);
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
        public async Task<IActionResult> DeleteAsync(int id)
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
        public async Task<IActionResult> DeleteLogicAsync(int id)
        {
            _logger.LogInformation(nameof(DeleteAsync));

            DeletedInfo<int> info = new()
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
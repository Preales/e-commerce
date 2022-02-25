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
    public class PaymentsController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly ILogger<PaymentsController> _logger;
        private readonly IMapper _mapper;

        public PaymentsController(
            ILogger<PaymentsController> logger,
            IOrderService service,
            IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        [ProducesResponseType(typeof(ResponseService<Guid>), (int)HttpStatusCode.Created)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(OrderRequestModel))]
        public async Task<IActionResult> PostAsync([FromBody] OrderRequestModel request)
        {
            _logger.LogInformation(nameof(PostAsync));

            var objRequest = _mapper.Map<OrderRequestDto>(request);
            objRequest.CreationDate = DateTime.Now;

            var (status, message, id) = await _service.PostAsync(objRequest);

            return Ok(new ResponseService<Guid>
            {
                Status = status,
                Message = message,
                Data = status ? id : default
            });
        }
    }
}

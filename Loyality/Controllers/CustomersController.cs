using Loyality.Application.DTOs.Customers;
using Loyality.Application.Features.Customers.Commands;
using Loyality.Application.Features.Customers.Queries;
using Loyality.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Loyality.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct )
        {
            var result = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerDto dto)
        {
            var customerId = await _mediator.Send(new CreateCustomerCommand(dto));
            return CreatedAtAction(nameof(Create), new { id = customerId }, customerId);

        }
    }
}

using Discount.Application.UseCases.DiscountCases.Commands;
using Discount.Application.UseCases.DiscountCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiscount()
        {
            var result = await _mediator.Send(new GetAllDiscountsQuery());

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetDiscount()
        {
            var result = new List<string>() { "Item1 Discount", "Item2 Discount", "Item3" }; ;

            return Ok(result);
        }
    }
}

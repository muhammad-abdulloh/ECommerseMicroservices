using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.CatalogCases.Commands;
using Catalog.Application.UseCases.CatalogCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers.CatalogControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogsController(ICatalogDbContext context, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCatalog(CreateCatalogCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCatalogs()
        {
            var catalogs = await _mediator.Send(new GetAllCatalogsQuery());

            return Ok(catalogs);
        }

        [HttpGet]
        public async Task<IActionResult> getCatalog()
        {
            var catalogs = new List<string>(){ "Item1", "Item2", "Item3" };

            return Ok(catalogs);
        }
    }
}

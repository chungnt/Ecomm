using Ecomm.Data.Models;
using Ecomm.Domain.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecomm.Api
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ISender _mediator;
        public ProductController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] SearchPagingModel pagings, [FromQuery] ProductSearchFilterModel? filters)
        {
            var result = await _mediator.Send(new SearchProductQuery(pagings, filters));
            return Ok(result);
        }
    }
}

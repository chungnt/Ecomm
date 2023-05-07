using Ecomm.Data.Models;
using Ecomm.Domain.Product.Commands;
using Ecomm.Domain.Product.Queries;
using Ecomm.Models;
using Ecomm.Models.Base;
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
        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] InsertProductRequest request)
        {
            try
            {
                var result = await _mediator.Send(new InsertProductCommand(request.Sku, request.Name, request.Description, "admin"));
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

using AutoMapper;
using Ecomm.Data.Dto.Product;
using Ecomm.Data.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomm.Domain.Product.Queries
{
    public record GetProductByIdQuery : IRequest<ProductDto>
    {
        public GetProductByIdQuery(int id)
        {
            ProductId = id;
        }
        public int ProductId { get; set; }
    }
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository; 
        private readonly IMapper _mapper;
        public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _productRepository.GetByIdAsync(request.ProductId);
            return _mapper.Map<ProductDto>(item);
        }
    }
}

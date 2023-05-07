using AutoMapper;
using Ecomm.Data.Dto.Product;
using Ecomm.Data.Repositories.ProductRepository;
using Ecomm.Domain.Product.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomm.Domain.Product.Commands
{
    public class InsertProductCommand : IRequest<ProductDto>
    {
        public string Sku { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string User { get; set; } = string.Empty;
    }
    public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, ProductDto>
    {
        private IProductRepository _productRepository; 
        private readonly IMapper _mapper;
        public InsertProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            var item = await _productRepository.InsertAsync(new Data.Entities.Product() 
            { 
                Name = request.Name,
                Description = request.Description,
                Sku = request.Sku,
                CreatedBy = request.User
            });
            return _mapper.Map<ProductDto>(item);
        }
    }
}

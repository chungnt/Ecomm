using AutoMapper;
using Ecomm.Data.Repositories.ProductRepository;
using MediatR;

namespace Ecomm.Domain.Product.Commands
{
    public class InsertProductCommand : IRequest<bool>
    {
        public InsertProductCommand(string sku, string name, string? desc, string user)
        {
            Sku = sku;
            Name = name;
            Description = desc;
            User = user;
        }
        public string Sku { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string User { get; set; } = string.Empty;
    }
    public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, bool>
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public InsertProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.InsertAsync(new Data.Entities.Product()
            {
                Name = request.Name,
                Description = request.Description,
                Sku = request.Sku,
                CreatedBy = request.User
            });
        }
    }
}

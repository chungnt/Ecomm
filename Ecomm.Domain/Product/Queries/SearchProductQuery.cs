using AutoMapper;
using Ecomm.Data.Dto.Product;
using Ecomm.Data.Models;
using Ecomm.Data.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomm.Domain.Product.Queries
{
    public record SearchProductQuery : IRequest<SearchModel<ProductDto>>
    {
        public SearchProductQuery(SearchPagingModel paging, ProductSearchFilterModel? filters = null)
        {
            Paging = paging;
            Filters = filters;
        }
        public SearchPagingModel Paging { get; set; } = new SearchPagingModel();
        public SearchFilterModel? Filters { get; set; }
    }
    public class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, SearchModel<ProductDto>>
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public SearchProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<SearchModel<ProductDto>> Handle(SearchProductQuery request, CancellationToken cancellationToken)
        {
            var results = await _productRepository.SearchAsync(new SearchPagingModel(), new ProductSearchFilterModel());
            
            return new SearchModel<ProductDto>()
            {
                Paging = request.Paging, 
                Filters = request.Filters,
                Items = _mapper.Map<IEnumerable<Data.Entities.Product>, IEnumerable<ProductDto>>(results.Items),
                Total = results.TotalCount
            };
        }
    }
}

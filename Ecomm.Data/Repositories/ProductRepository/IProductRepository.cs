using Ecomm.Data.Entities;
using Ecomm.Data.Models;

namespace Ecomm.Data.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<(int TotalCount, IEnumerable<Product> Items)> SearchAsync(SearchPagingModel paging, ProductSearchFilterModel filter);
        Task<bool> InsertAsync(Product dto);
        Task<bool> UpdateAsync(Product dto);
        Task<bool> DeleteAsync(Product dto);
    }
}

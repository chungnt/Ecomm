using Ecomm.Data.Dto.Product;
using Ecomm.Data.Entities;
using Ecomm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomm.Data.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<(int TotalCount, IEnumerable<Product> Items)> SearchAsync(SearchPagingModel paging, ProductSearchFilterModel filter);
        Task<Product> InsertAsync(Product dto);
        Task<Product> UpdateAsync(Product dto);
        Task<Product> DeleteAsync(Product dto);
    }
}

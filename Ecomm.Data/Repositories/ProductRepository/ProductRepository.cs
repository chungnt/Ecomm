using Dapper.Contrib.Extensions;
using Ecomm.Data.Dto.Product;
using Ecomm.Data.Models;
using Ecomm.Data.Entities;
using AutoMapper;
using Dapper;

namespace Ecomm.Data.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommDbContext _context;
        public ProductRepository(EcommDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            using var conn = _context.CreateConnection();
            var item = await conn.GetAsync<Product>(id);
            return item;
        }

        public async Task<(int TotalCount, IEnumerable<Product> Items)> SearchAsync(SearchPagingModel paging, ProductSearchFilterModel filters)
        {
            using var conn = _context.CreateConnection();
            var items = await conn.QueryAsync<Product>($"SELECT * FROM product");
            return (items.Count(), items.ToList());
        }

        public Task<Product> InsertAsync(Product dto)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product dto)
        {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteAsync(Product dto)
        {
            throw new NotImplementedException();
        }
    }
}

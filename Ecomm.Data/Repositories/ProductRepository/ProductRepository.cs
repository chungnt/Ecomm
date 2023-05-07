using Ecomm.Data.Dto.Product;
using Ecomm.Data.Models;
using Ecomm.Data.Entities;
using AutoMapper;
using Dapper;
using Dapper.Database.Extensions;

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

        public async Task<bool> InsertAsync(Product entity)
        {
            using var conn = _context.CreateConnection();
            entity.CreatedDate = DateTime.UtcNow;
            return await conn.InsertAsync(entity);
        }

        public Task<bool> UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Contexts;
using Supermarket.API.Domain.Repositories;

namespace Supermarket.API.Domain.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository    
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.Include(p => p.Category)
                                          .ToListAsync();
        }
    }
}

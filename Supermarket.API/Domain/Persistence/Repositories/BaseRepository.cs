using Supermarket.API.Domain.Persistence.Contexts;

namespace Supermarket.API.Domain.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;
        //  receives an instance of our AppDbContext through dependency injection and exposes a protected property
        // _context gives access to all methods we need to handle database operations.
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}

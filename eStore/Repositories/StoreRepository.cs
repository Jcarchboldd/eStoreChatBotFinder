using eStore.Data;
using eStore.Models;

namespace eStore.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly StoreDbContext _context;

        public StoreRepository(StoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> GetProducts()
        {
            return _context.Products;
        }
    }
}
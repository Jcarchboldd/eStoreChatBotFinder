using eStore.Models;

namespace eStore.Repositories
{
    public interface IStoreRepository
    {
        IQueryable<Product> GetProducts();
        // void AddProduct(Product product);
        // void UpdateProduct(Product product);
        // void DeleteProduct(int id);
    }
}
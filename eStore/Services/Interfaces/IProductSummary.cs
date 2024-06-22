using eStore.Models.ViewModels;

namespace eStore.Services.Interfaces {
    public interface IProductSummary
    {
        /// <summary>
        /// Retrieves a summary of products based on the specified product page.
        /// </summary>
        /// <param name="productPage">The page number of the products to retrieve.</param>
        /// <returns>A <see cref="ProductListViewModel"/> containing the summary of products.</returns>
        ProductListViewModel GetProductSummary(int productPage);
    }

}




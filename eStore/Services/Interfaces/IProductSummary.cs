using eStore.Models.ViewModels;

namespace eStore.Services.Interfaces {
    public interface IProductSummary
    {
        /// <summary>
        /// Retrieves a summary of products based on the specified page number and identified products.
        /// </summary>
        /// <param name="productPage">The page number of the products to retrieve.</param>
        /// <param name="identifiedProducts">A comma-separated string of identified products to filter the results.</param>
        /// <returns>A <see cref="ProductListViewModel"/> containing the summary of products and paging information.</returns>
        ProductListViewModel GetProductSummary(int productPage, string? Product = null);
    }

}




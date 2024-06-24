using eStore.Models;
using eStore.Models.ViewModels;
using eStore.Repositories;
using eStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eStore.Services {
    public class ProductSummaryService(IStoreRepository storeRepository) : IProductSummary
    {
        private readonly IStoreRepository _storeRepository = storeRepository;
        public int PageSize = 6;
        
        /// <summary>
        /// Retrieves a summary of products based on the specified page number and identified products.
        /// </summary>
        /// <param name="productPage">The page number of the products to retrieve.</param>
        /// <param name="identifiedProducts">A comma-separated string of identified products to filter the results.</param>
        /// <returns>A <see cref="ProductListViewModel"/> containing the summary of products and paging information.</returns>
        public ProductListViewModel GetProductSummary(int productPage, string? identifiedProducts = null)
        {
            IQueryable<Product> query = _storeRepository.GetProducts();

            if (!string.IsNullOrEmpty(identifiedProducts))
            {
                List<string> listProducts = identifiedProducts.Split(',').Select(p => p.Trim()).ToList();
                query = query.Where(p =>
                    listProducts.Any(name =>
                        EF.Functions.Like(p.Name, "%" + name + "%") || 
                        (p.Description != null && EF.Functions.Like(p.Description, "%" + name + "%"))
                    )
                );
            }

            var products = query
                .Select(p => new ProductSummaryDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    Category = p.Category,
                    ImageUrl = p.ImageUrl
                })
                .OrderBy(p => p.Id)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            return new ProductListViewModel {
                Products = products,
                PagingInfo = new PagingInfo {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = query.Count()
                }
            };
        }

    }
    
}




using System.Text.RegularExpressions;
using eStore.Models.ViewModels;
using eStore.Repositories;
using eStore.Services.Interfaces;
using FuzzySharp;

namespace eStore.Services {
    public class ProductSummaryService(IStoreRepository storeRepository) : IProductSummary
    {
        private IStoreRepository _storeRepository = storeRepository;
        public int PageSize = 6;
        
        public ProductListViewModel GetProductSummary(int productPage, string? Product = null)
        {
            var products = new List<ProductSummaryDto>();
            
            if (Product == null)
            {
                products = _storeRepository.GetProducts()
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
            }

            if (Product != null)
            {
                products = _storeRepository.GetProducts()
                .Select(p => new ProductSummaryDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    Category = p.Category,
                    ImageUrl = p.ImageUrl
                })
                .ToList();

                List<string> listProducts = Product.Split(',').Select(p => p.Trim()).ToList();

                products = products.Where(p => 
                    listProducts.Any(name => FuzzySearch(name, p.Name)) || 
                    listProducts.Any(name => p.Description != null && FuzzySearch(name, p.Description)) ||
                    listProducts.Any(name => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) ||
                    listProducts.Any(name => p.Description != null && p.Description.Contains(name, StringComparison.OrdinalIgnoreCase)) ||
                    listProducts.Any(name => p.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase)) ||
                    listProducts.Any(name => p.Name.EndsWith(name, StringComparison.OrdinalIgnoreCase)) ||
                    listProducts.Any(name => Regex.IsMatch(p.Name, $@"\b{name}\b", RegexOptions.IgnoreCase)) ||
                    (p.Description != null && listProducts.Any(name => Regex.IsMatch(p.Description, $@"\b{name}\b", RegexOptions.IgnoreCase)))
                )
                .Distinct()
                .ToList();
            }

            return new ProductListViewModel {
                Products = products,
                PagingInfo = new PagingInfo {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _storeRepository.GetProducts().Count()
                }
            };
        }

        private bool FuzzySearch(string searchTerm, string text)
        {
            int threshold = 80;
            return Fuzz.Ratio(searchTerm, text) > threshold;
        }
    }
    
}




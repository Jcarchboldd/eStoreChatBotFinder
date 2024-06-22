using eStore.Models.ViewModels;
using eStore.Repositories;
using eStore.Services.Interfaces;

namespace eStore.Services {
    public class ProductSummaryService(IStoreRepository storeRepository) : IProductSummary
    {
        private IStoreRepository _storeRepository = storeRepository;
        public int PageSize = 3;

        public ProductListViewModel GetProductSummary(int productPage)
        {
            var productsDto = _storeRepository.GetProducts()
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
                .Take(PageSize);

            return new ProductListViewModel {
                Products = productsDto,
                PagingInfo = new PagingInfo {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _storeRepository.GetProducts().Count()
                }
            };
        }
    }

}




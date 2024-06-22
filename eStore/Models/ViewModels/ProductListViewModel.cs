using eStore.Models;
using eStore.Models.ViewModels;

namespace eStore.Models.ViewModels;

public class ProductListViewModel
{
    public IEnumerable<ProductSummaryDto> Products { get; set; } = Enumerable.Empty<ProductSummaryDto>();
    public PagingInfo PagingInfo { get; set; } = new PagingInfo();

}

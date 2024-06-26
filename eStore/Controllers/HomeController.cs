using eStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eStore.Controllers
{
    public class HomeController(IProductSummary iProductSummary) : Controller
    {
        private readonly IProductSummary _iProductSummary = iProductSummary;

        [HttpGet]
        public ViewResult Index(int productPage = 1) 
        => View(_iProductSummary.GetProductSummary(productPage));

        [HttpGet]
        public PartialViewResult GetProductSummaryPage(int productPage, string? listProducts = null)
        {
            var model = _iProductSummary.GetProductSummary(productPage, listProducts);
            return PartialView("/Views/Shared/Partials/ProductSummary.cshtml", model);
        }

    }
}
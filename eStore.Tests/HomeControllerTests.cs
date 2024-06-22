using eStore.Controllers;
using eStore.Models;
using eStore.Models.ViewModels;
using eStore.Repositories;
using eStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace eStore.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfProducts()
        {
            // Arrange
            var mockRepo = new Mock<IProductSummary>();
            mockRepo.Setup(repo => repo.GetProductSummary(1))
                .Returns(new ProductListViewModel { Products = new ProductSummaryDto[] {
                    new() { Name = "Hydrogen", Description = "Chemical element with the symbol H", Price = 1.008M },
                    new() { Name = "Oxygen", Description = "Chemical element with the symbol O", Price = 15.999M },
                    new() { Name = "Carbon", Description = "Chemical element with the symbol C", Price = 12.011M } }});
            var controller = new HomeController(mockRepo.Object);

            // Act
            ProductListViewModel result = controller.Index().ViewData.Model as ProductListViewModel ?? new();

            // Assert
            var model = result.Products.ToArray();
            Assert.True(model.Count() == 3);
            Assert.Equal("Oxygen", model.ElementAt(1).Name);
            Assert.Equal("Chemical element with the symbol C", model.ElementAt(2).Description);
        }

    }
}
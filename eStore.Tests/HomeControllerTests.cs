using eStore.Controllers;
using eStore.Models;
using eStore.Models.ViewModels;
using eStore.Repositories;
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
            var mockRepo = new Mock<IStoreRepository>();
            mockRepo.Setup(repo => repo.GetProducts())
                .Returns((new Product[] { 
                    new() { Name = "Hydrogen", Description = "Chemical element with the symbol H", Price = 1.008M },
                    new() { Name = "Oxygen", Description = "Chemical element with the symbol O", Price = 15.999M },
                    new() { Name = "Carbon", Description = "Chemical element with the symbol C", Price = 12.011M } }).AsQueryable<Product>());
            var controller = new HomeController(mockRepo.Object);

            // Act
            ProductListViewModel result = controller.Index().ViewData.Model as ProductListViewModel ?? new();

            // Assert
            var model = result.Products.ToArray();
            Assert.True(model.Count() == 3);
            Assert.Equal("Oxygen", model.ElementAt(1).Name);
            Assert.Equal("Chemical element with the symbol C", model.ElementAt(2).Description);
        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            var mockRepo = new Mock<IStoreRepository>();
            mockRepo.Setup(repo => repo.GetProducts())
                .Returns((new Product[] { 
                    new() { Name = "Hydrogen", Description = "Chemical element with the symbol H", Price = 1.008M },
                    new() { Name = "Oxygen", Description = "Chemical element with the symbol O", Price = 15.999M },
                    new() { Name = "Carbon", Description = "Chemical element with the symbol C", Price = 12.011M } }).AsQueryable<Product>());
            var controller = new HomeController(mockRepo.Object) { PageSize = 1 };

            // Act
            ProductListViewModel result = controller.Index(1)?.ViewData.Model as ProductListViewModel ?? new();

            // Assert
            var model = result.Products.ToArray();
            Assert.True(model.Length == 1);
            Assert.Equal("Hydrogen", model.ElementAt(0).Name);
            Assert.Equal("Chemical element with the symbol H", model.ElementAt(0).Description);
        }
    }
}
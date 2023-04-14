using Microsoft.AspNetCore.Mvc;
using Moq;
using Tischreservierung.Controllers;
using Core.Models;
using Core.Contracts;

namespace Tischreservierung.Tests.RestaurantTest.Controller
{
    public class RestaurantCategoryControllerTest
    {
        [Fact]
        public async Task GetRestaurantCategories()
        {
            var restaurantCategoryRepository = new Mock<IRestaurantCategoryRepository>();
            restaurantCategoryRepository.Setup(r => r.GetRestaurantCategories()).ReturnsAsync(GetRestaurantCategoryTestData());
            var restaurantCategoryController = new RestaurantCategoriesController(restaurantCategoryRepository.Object);

            var actionResult = await restaurantCategoryController.GetRestaurantCategories();
            var result = actionResult.Result as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result!.StatusCode);
            Assert.Equal(3, ((List<Category>)result.Value!).Count());

            restaurantCategoryRepository.Verify(r => r.GetRestaurantCategories(), Times.Once);
            restaurantCategoryRepository.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetRestaurantCategory()
        {
            var repository = new Mock<IRestaurantCategoryRepository>();
            repository.Setup(r => r.GetRestaurantCategory("Pizza")).ReturnsAsync(GetRestaurantCategoryTestData()[0]);

            var controller = new RestaurantCategoriesController(repository.Object);

            var actionResult = await controller.GetRestaurantCategory("Pizza");

            Assert.NotNull(actionResult);
            Assert.Equal("Pizza", actionResult.Value!.Name);

            repository.Verify(r => r.GetRestaurantCategory(It.IsAny<string>()));
            repository.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task InsertRestaurantCategory()
        {
            Category restaurantCategory = GetRestaurantCategoryTestData()[0];

            var repository = new Mock<IRestaurantCategoryRepository>();
            repository.Setup(r => r.InsertRestaurantCategory(It.IsAny<Category>()));
            var controller = new RestaurantCategoriesController(repository.Object);

            var actionResult = await controller.PostRestaurantCategory(restaurantCategory);

            Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var result = actionResult.Result as CreatedAtActionResult;

            Assert.NotNull(result);
            Assert.Equal(201, result!.StatusCode);
            Assert.Equal(restaurantCategory, result.Value as Category);

            repository.Verify(r => r.InsertRestaurantCategory(restaurantCategory));
            repository.Verify(r => r.Save());
            repository.VerifyNoOtherCalls();

        }

        [Fact]
        public async Task DeleteRestauratCategory()
        {
            var repository = new Mock<IRestaurantCategoryRepository>();

            repository.Setup(r => r.GetRestaurantCategory("Pizza")).ReturnsAsync(new Category());
            repository.Setup(r => r.DeleteRestaurantCategory(It.IsAny<Category>()));
            var controller = new RestaurantCategoriesController(repository.Object);

            var actionResult = await controller.DeleteRestaurantCategory("Pizza");

            Assert.IsType<NoContentResult>(actionResult);

            repository.Verify(r => r.GetRestaurantCategory("Pizza"));
            repository.Verify(r => r.DeleteRestaurantCategory(It.IsAny<Category>()));
            repository.Verify(r => r.Save());
            repository.VerifyNoOtherCalls();
        }

        private static List<Category> GetRestaurantCategoryTestData()
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            restaurants.Add(new Restaurant() { Id = 1, Name = "R1" });
            restaurants.Add(new Restaurant() { Id = 2, Name = "R2" });
            restaurants.Add(new Restaurant() { Id = 3, Name = "R3" });


            List<Category> restaurantCategories = new List<Category>();
            restaurantCategories.Add(new Category() { Name = "Pizza", Restaurants = restaurants });
            restaurantCategories.Add(new Category() { Name = "Pommes", Restaurants = restaurants });
            restaurants.Add(new Restaurant() { Id = 4, Name = "R4" });
            restaurantCategories.Add(new Category() { Name = "Ita", Restaurants = restaurants });
            return restaurantCategories;
        }
    }
}

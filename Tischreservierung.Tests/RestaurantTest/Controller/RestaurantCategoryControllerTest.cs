using Microsoft.AspNetCore.Mvc;
using Moq;
using Tischreservierung.Controllers;
using Core.Models;
using Core.Contracts;
using Microsoft.AspNetCore.Http;
using System.Web.Http.Results;
using WebApi.Controllers;

namespace Tischreservierung.Tests.RestaurantTest.Controller
{
    public class RestaurantCategoryControllerTest
    {
        [Fact]
        public async Task GetRestaurantCategories()
        {
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.RestaurantCategories.GetAll()).ReturnsAsync(GetRestaurantCategoryTestData());
            var restaurantCategoryController = new RestaurantCategoriesController(uow.Object);

            var actionResult = await restaurantCategoryController.GetRestaurantCategories();

            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(3, ((List<Category>)result.Value!).Count());

            uow.Verify(x => x.RestaurantCategories.GetAll());
            uow.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetRestaurantCategory()
        {
            int categoryId = 10;
            Category category = new() { Id = categoryId, Name = "Pizza" };

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.RestaurantCategories.GetById(categoryId)).ReturnsAsync(category);

            var controller = new RestaurantCategoriesController(uow.Object);

            var actionResult = await controller.GetRestaurantCategory(categoryId);

            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(category, result.Value);

            uow.Verify(x => x.RestaurantCategories.GetById(categoryId));
            uow.VerifyNoOtherCalls();
        }

        [Fact]
        public async void GetRestaurantCategory_ReturnsNotFound()
        {
            int categoryId = 10;

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.RestaurantCategories.GetById(categoryId)).ReturnsAsync((Category?)null);
            var controller = new RestaurantCategoriesController(uow.Object);

            var actionResult = await controller.GetRestaurantCategory(categoryId);

            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(actionResult.Result);
            var result = actionResult.Result as Microsoft.AspNetCore.Mvc.NotFoundResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result!.StatusCode);

            uow.Verify(x => x.RestaurantCategories.GetById(categoryId));
            uow.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task InsertRestaurantCategory()
        {
            Category restaurantCategory = GetRestaurantCategoryTestData()[0];

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.RestaurantCategories.Insert(It.IsAny<Category>()));
            var controller = new RestaurantCategoriesController(uow.Object);

            var actionResult = await controller.PostRestaurantCategory(restaurantCategory);

            Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var result = actionResult.Result as CreatedAtActionResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result!.StatusCode);
            Assert.Equal(restaurantCategory, result.Value as Category);

            uow.Verify(x => x.RestaurantCategories.Insert(restaurantCategory));
            uow.Verify(x => x.SaveChangesAsync());
            uow.VerifyNoOtherCalls();

        }

        [Fact]
        public async Task DeleteRestauratCategory()
        {
            int categoryId = 10;

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.RestaurantCategories.GetById(categoryId)).ReturnsAsync(new Category());
            uow.Setup(x => x.RestaurantCategories.Delete(It.IsAny<Category>()));
            var controller = new RestaurantCategoriesController(uow.Object);

            var actionResult = await controller.DeleteRestaurantCategory(categoryId);

            Assert.IsType<NoContentResult>(actionResult);
            var result = actionResult as NoContentResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);

            uow.Verify(x => x.RestaurantCategories.GetById(categoryId));
            uow.Verify(x => x.RestaurantCategories.Delete(It.IsAny<Category>()));
            uow.Verify(x => x.SaveChangesAsync());
            uow.VerifyNoOtherCalls();
        }

        [Fact]
        public async void DeleteRestaurantCategory_ReturnsNotFound()
        {
            int categoryId = 10;

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.RestaurantCategories.GetById(categoryId)).ReturnsAsync((Category?)null);
            var controller = new RestaurantCategoriesController(unitOfWork.Object);

            var actionResult = await controller.DeleteRestaurantCategory(categoryId);

            var result = actionResult as Microsoft.AspNetCore.Mvc.NotFoundResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result!.StatusCode);

            unitOfWork.Verify(x => x.RestaurantCategories.GetById(categoryId));
            unitOfWork.VerifyNoOtherCalls();
        }

        private static List<Category> GetRestaurantCategoryTestData()
        {
            List<Category> restaurantCategories = new()
            {
                new Category() { Id = 1, Name = "Pizza" },
                new Category() { Id = 2, Name = "Pommes" },
                new Category() { Id = 3, Name = "Ita" }
            };
            return restaurantCategories;
        }
    }
}

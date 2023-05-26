using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using Tischreservierung.Controllers;
using Persistence.Data.RestaurantRepo;
using Core.Models;
using Core.Contracts;
using Microsoft.AspNetCore.Http;
using WebApi.Controllers;

namespace Tischreservierung.Tests.RestaurantTest.Controller
{
    public class RestaurantControllerTest
    {
        [Fact]
        public async Task GetAllRestaurants()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Restaurants.GetAll()).ReturnsAsync(GetRestaurantTestData);
            var controller = new RestaurantsController(unitOfWork.Object);

            var actionResult = await controller.GetRestaurants();
            var result = actionResult.Result as ObjectResult;
            

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(4, (result.Value as IEnumerable<Restaurant>)!.Count());

            unitOfWork.Verify(x => x.Restaurants.GetAll());
            unitOfWork.VerifyNoOtherCalls();
        }

        [Fact]
        public async void GetReservation()
        {
            int restaurantId = 10;
            Restaurant restaurant = new Restaurant()
            {
                Id = restaurantId,
                Name = "R1"
            };

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Restaurants.GetById(restaurantId)).ReturnsAsync(restaurant);
            var controller = new RestaurantsController(unitOfWork.Object);

            var actionResult = await controller.GetRestaurant(restaurantId);
            var result = actionResult.Result as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(restaurant, result.Value);

            unitOfWork.Verify(x => x.Restaurants.GetById(restaurantId));
            unitOfWork.VerifyNoOtherCalls();
        }

        [Fact]
        public async void GetRestaurant_ReturnsNotFound()
        {
            int restaurant = 10;

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Restaurants.GetById(restaurant)).ReturnsAsync((Restaurant?)null);
            var controller = new RestaurantsController(unitOfWork.Object);

            var actionResult = await controller.GetRestaurant(restaurant);
            var result = actionResult.Result as NotFoundResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result!.StatusCode);

            unitOfWork.Verify(x => x.Restaurants.GetById(restaurant));
            unitOfWork.VerifyNoOtherCalls();
        }


        [Fact]
        public async Task DeleteRestaurant()
        {
            int restaurantId = 10;
            Restaurant restaurant = new Restaurant()
            {
                Id = restaurantId,
                Name = "R1"
            };

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Restaurants.GetById(restaurantId)).ReturnsAsync(restaurant);
            unitOfWork.Setup(x => x.Restaurants.Delete(It.IsAny<Restaurant>()));
            var controller = new RestaurantsController(unitOfWork.Object);

            var actionResult = await controller.DeleteRestaurant(restaurantId);
            var result = actionResult as NoContentResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);

            unitOfWork.Verify(x => x.Restaurants.GetById(restaurantId));
            unitOfWork.Verify(x => x.Restaurants.Delete(It.IsAny<Restaurant>()));
            unitOfWork.Verify(x => x.SaveChangesAsync());
            unitOfWork.VerifyNoOtherCalls();
        }

        [Fact]
        public async void DeleteRetaurant_ReturnsNotFound()
        {
            int restaurantId = 10;

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Restaurants.GetById(restaurantId)).ReturnsAsync((Restaurant?)null);
            var controller = new RestaurantsController(unitOfWork.Object);

            var actionResult = await controller.DeleteRestaurant(restaurantId);
            var result = actionResult as NotFoundResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result!.StatusCode);

            unitOfWork.Verify(x => x.Restaurants.GetById(restaurantId));
            unitOfWork.VerifyNoOtherCalls();
        }

        private static List<Restaurant> GetRestaurantTestData()
        {
            List<Restaurant> restaurants = new();
            restaurants.Add(new Restaurant() { Id = 1, Name = "R1" });
            restaurants.Add(new Restaurant() { Id = 2, Name = "R2" });
            restaurants.Add(new Restaurant() { Id = 3, Name = "R3" });
            restaurants.Add(new Restaurant() { Id = 4, Name = "R4" });
            return restaurants;
        }
    }
}
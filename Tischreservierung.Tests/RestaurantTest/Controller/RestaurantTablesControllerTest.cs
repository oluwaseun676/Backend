using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tischreservierung.Controllers;
using Persistence.Data.RestaurantRepo;
using Core.Models;
using Core.Contracts;
using Microsoft.AspNetCore.Http;
using Persistence.Data;
using System.Web.Http.Results;

namespace Tischreservierung.Tests.RestaurantTest.Controller
{
    public class RestaurantTablesControllerTest
    {
        [Fact]
        public async Task GetAllRestaurantTables()
        {
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.RestaurantTables.GetAll()).ReturnsAsync(GetRestaurantTableTestData);
            var controller = new RestaurantTablesController(uow.Object);

            var actionResult = await controller.GetRestaurantTables();

            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(6, ((List<RestaurantTable>)result.Value!).Count());

            uow.Verify(x => x.RestaurantTables.GetAll());
            uow.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetRestaurantTableReturnsNotFound()
        {
            int tableId = 10;

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.RestaurantTables.GetById(tableId)).ReturnsAsync((RestaurantTable?)null);
            var controller = new RestaurantTablesController(uow.Object);

            var actionResult = await controller.GetRestaurantTable(10);

            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(actionResult.Result);
            var result = actionResult.Result as Microsoft.AspNetCore.Mvc.NotFoundResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result!.StatusCode);

            uow.Verify(x => x.RestaurantTables.GetById(tableId));
            uow.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetRestauranTableById()
        {
            int tableId = 10;
            RestaurantTable table = new() { Id = tableId, SeatPlaces = 5, RestaurantId = 20 };

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.RestaurantTables.GetById(tableId)).ReturnsAsync(table);
            var controller = new RestaurantTablesController(uow.Object);

            var actionResult = await controller.GetRestaurantTable(tableId);

            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(table, result.Value);

            uow.Verify(x => x.RestaurantTables.GetById(tableId));
            uow.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task PostRestaurantTable()
        {
            int tableId = 10;
            RestaurantTable table = new() { Id = tableId, SeatPlaces = 5, RestaurantId = 20 };

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.RestaurantTables.Insert(It.IsAny<RestaurantTable>()));
            var controller = new RestaurantTablesController(uow.Object);

            var actionResult = await controller.PostRestaurantTable(table);

            Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var result = actionResult.Result as CreatedAtActionResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result!.StatusCode);
            Assert.Equal(table, result.Value as RestaurantTable);

            uow.Verify(x => x.RestaurantTables.Insert(table));
            uow.Verify(x => x.SaveChangesAsync());
            uow.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteRestaurantTable()
        {
            int tableId = 10;

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.RestaurantTables.GetById(tableId)).ReturnsAsync(new RestaurantTable() { Id = tableId });
            uow.Setup(x => x.RestaurantTables.Delete(It.IsAny<RestaurantTable>()));
            var controller = new RestaurantTablesController(uow.Object);

            var actionResult = await controller.DeleteRestaurantTable(tableId);

            Assert.IsType<NoContentResult>(actionResult);
            var result = actionResult as NoContentResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);

            uow.Verify(x => x.RestaurantTables.GetById(tableId));
            uow.Verify(x => x.RestaurantTables.Delete(It.IsAny<RestaurantTable>()));
            uow.Verify(x => x.SaveChangesAsync());
            uow.VerifyNoOtherCalls();
        }

        [Fact]
        public async void DeleteRestaurantTable_ReturnsNotFound()
        {
            int tableId = 10;

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.RestaurantTables.GetById(tableId)).ReturnsAsync((RestaurantTable?)null);
            var controller = new RestaurantTablesController(uow.Object);

            var actionResult = await controller.DeleteRestaurantTable(tableId);

            var result = actionResult as Microsoft.AspNetCore.Mvc.NotFoundResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result!.StatusCode);

            uow.Verify(x => x.RestaurantTables.GetById(tableId));
            uow.VerifyNoOtherCalls();
        }


        private static List<RestaurantTable> GetRestaurantTableTestData()
        {
            List<RestaurantTable> tables = new()
            {
                new RestaurantTable() { Id = 1, SeatPlaces = 2, RestaurantId = 1 },
                new RestaurantTable() { Id = 2, SeatPlaces = 4, RestaurantId = 1 },
                new RestaurantTable() { Id = 3, SeatPlaces = 3, RestaurantId = 1 },
                new RestaurantTable() { Id = 4, SeatPlaces = 4, RestaurantId = 2 },
                new RestaurantTable() { Id = 5, SeatPlaces = 3, RestaurantId = 2 },
                new RestaurantTable() { Id = 6, SeatPlaces = 3, RestaurantId = 3 }
            };
            return tables;
        }
    }
}

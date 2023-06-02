using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tischreservierung.Controllers.Person;
using Core.Models;
using Core.Contracts;
using Core.Models.User;
using Microsoft.AspNetCore.Http;

namespace Tischreservierung.Tests.Person.Controller
{
    public class EmployeeControllerTest
    {
        [Fact]
        public async Task GetAllEmployeeForRestaurant()
        {
            int restaurantId = 1;
            List<Employee> employees = TestData();
            employees.RemoveAt(3);

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.Employees.GetByRestaurant(restaurantId)).ReturnsAsync(employees);
            var controller = new EmployeeController(uow.Object);

            var actionResult = await controller.GetEmployeeByRestaurantId(restaurantId);

            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(3, ((List<Employee>)result.Value!).Count());

            uow.Verify(x => x.Employees.GetByRestaurant(restaurantId));
            uow.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetEmployeeByID()
        {
            int id = 2;

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.Employees.GetById(id)).ReturnsAsync(TestData()[1]);
            var controller = new EmployeeController(uow.Object);

            var actionResult = await controller.GetEmployeeById(id);

            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;


            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal("Steini@gmail.com", ((Employee)result.Value!).EMail);

            uow.Verify(x => x.Employees.GetById(id));
            uow.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteEmployee()
        {
            int id = 2;

            var uow = new Mock<IUnitOfWork>();

            uow.Setup(x => x.Employees.GetById(id)).ReturnsAsync(new Employee());
            uow.Setup(x => x.Employees.Delete(It.IsAny<Employee>()));
            var controller = new EmployeeController(uow.Object);

            var actionResult = await controller.DeleteCustomer(id);

            Assert.IsType<NoContentResult>(actionResult);

            uow.Verify(x => x.Employees.GetById(id));
            uow.Verify(x => x.Employees.Delete(It.IsAny<Employee>()));
            uow.Verify(x => x.SaveChangesAsync());
            uow.VerifyNoOtherCalls();
        }

        [Fact]
        public void PostEmployee()
        {
            Employee employee = new()
            {
                Id = 10,
                Name = "Sepp",
                FamilyName = "Apfel",
                EMail = "birnenseppl@gmail.com",
                Password = "testF",
                IsAdmin = true,
                Restaurant = TestData()[3].Restaurant
            };

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.Employees.Insert(employee));
            var controller = new EmployeeController(uow.Object);

            var actionResult = controller.PostEmployee(employee);

            Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var result = actionResult.Result as CreatedAtActionResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result!.StatusCode);
            Assert.Equal(employee, result.Value as Employee);

            uow.Verify(x => x.Employees.Insert(employee));
            uow.Verify(x => x.SaveChangesAsync());
            uow.VerifyNoOtherCalls();
        }

        private static List<Employee> TestData()
        {
            Restaurant restaurant = new Restaurant() { Id = 1, Name = "Test Restaurant" };
            Restaurant restaurant2 = new Restaurant() { Id = 2, Name = "Test Bar" };
            List<Employee> data = new()
            {
                new Employee()
                {
                    Id = 1,
                    Name = "Elias",
                    FamilyName = "Bauer",
                    EMail = "belias@gmail.com",
                    Password = "testG",
                    IsAdmin = true,
                    Restaurant = restaurant
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Felix",
                    FamilyName = "Stein",
                    EMail = "Steini@gmail.com",
                    Password = "testH",
                    IsAdmin = false,
                    Restaurant = restaurant
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Sarah",
                    FamilyName = "Müller",
                    EMail = "Sarah-Müller@gmail.com",
                    Password = "testI",
                    IsAdmin = false,
                    Restaurant = restaurant
                },
                new Employee()
                {
                    Id = 4,
                    Name = "Lena",
                    FamilyName = "Baumann",
                    EMail = "l.bau-testBar@gmail.com",
                    Password = "testJ",
                    IsAdmin = false,
                    Restaurant = restaurant2
                }
            };

            return data;
        }
    }
}

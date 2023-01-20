using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tischreservierung.Controllers.Person;
using Tischreservierung.Data.Person;
using Tischreservierung.Models;
using Tischreservierung.Models.Person;

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

            var employeeRepo = new Mock<IEmployeeRepository>();
            employeeRepo.Setup(d => d.GetByRestaurantId(restaurantId))
                .ReturnsAsync(employees);
            var employeeCont = new EmployeeController(employeeRepo.Object);

            var actionResult = await employeeCont.GetEmployeeByRestaurantId(restaurantId);

            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result!.StatusCode);
            Assert.Equal(3, ((List<Employee>)result.Value!).Count());

            employeeRepo.Verify(c => c.GetByRestaurantId(restaurantId));
            employeeRepo.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetEmployeeByID()
        {
            int id = 2;

            var employeeRepo = new Mock<IEmployeeRepository>();
            employeeRepo.Setup(d => d.GetEmployeeById(id)).ReturnsAsync(TestData()[1]);
            var employeeCont = new EmployeeController(employeeRepo.Object);

            var actionResult = await employeeCont.GetEmployeeById(id);

            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;


            Assert.NotNull(result);
            Assert.Equal(200, result!.StatusCode);
            Assert.Equal("Steini@gmail.com", ((Employee)result.Value!).EMail);
        }

        [Fact]
        public async Task DeleteEmployee()
        {
            int id = 2;

            var employeeRepo = new Mock<IEmployeeRepository>();

            employeeRepo.Setup(e => e.GetEmployeeById(id)).ReturnsAsync(new Employee());
            employeeRepo.Setup(e => e.DeleteEmployee(It.IsAny<Employee>()));
            var employeeCont = new EmployeeController(employeeRepo.Object);

            var actionResult = await employeeCont.DeleteCustomer(id);

            Assert.IsType<NoContentResult>(actionResult);

            employeeRepo.Verify(r => r.GetEmployeeById(id));
            employeeRepo.Verify(r => r.DeleteEmployee(It.IsAny<Employee>()));
            employeeRepo.Verify(r => r.Save());
            employeeRepo.VerifyNoOtherCalls();
        }

        [Fact]
        public void PostEmployee()
        {
            Employee emp = new Employee()
            {
                Id = 10,
                Name = "Sepp",
                FamilyName = "Apfel",
                EMail = "birnenseppl@gmail.com",
                Password = "testF",
                IsAdmin = true,
                Restaurant = TestData()[3].Restaurant
            };

            var employeeRepo = new Mock<IEmployeeRepository>();
            employeeRepo.Setup(d => d.SetEmployee(emp));
            var employeeCont = new EmployeeController(employeeRepo.Object);

            var actionResult = employeeCont.PostEmployee(emp);

            Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var result = actionResult.Result as CreatedAtActionResult;

            Assert.NotNull(result);
            Assert.Equal(201, result!.StatusCode);
            Assert.Equal(emp, result.Value as Employee);

            employeeRepo.Verify(c => c.SetEmployee(emp));
            employeeRepo.Verify(c => c.Save());
            employeeRepo.VerifyNoOtherCalls();
        }

        private static List<Employee> TestData()
        {
            Restaurant restaurant = new Restaurant() { Id = 1, Name = "Test Restaurant" };
            Restaurant restaurant2 = new Restaurant() { Id = 2, Name = "Test Bar" };
            List<Employee> data = new List<Employee>();

            data.Add(new Employee()
            {
                Id = 1,
                Name = "Elias",
                FamilyName = "Bauer",
                EMail = "belias@gmail.com",
                Password = "testG",
                IsAdmin = true,
                Restaurant = restaurant
            });
            data.Add(new Employee()
            {
                Id = 2,
                Name = "Felix",
                FamilyName = "Stein",
                EMail = "Steini@gmail.com",
                Password = "testH",
                IsAdmin = false,
                Restaurant = restaurant
            });
            data.Add(new Employee()
            {
                Id = 3,
                Name = "Sarah",
                FamilyName = "Müller",
                EMail = "Sarah-Müller@gmail.com",
                Password = "testI",
                IsAdmin = false,
                Restaurant = restaurant
            });
            data.Add(new Employee()
            {
                Id = 4,
                Name = "Lena",
                FamilyName = "Baumann",
                EMail = "l.bau-testBar@gmail.com",
                Password = "testJ",
                IsAdmin = false,
                Restaurant = restaurant2
            });

            return data;
        }
    }
}

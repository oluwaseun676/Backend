using Microsoft.AspNetCore.Mvc;
using Moq;
using Tischreservierung.Controllers.Person;
using Core.Contracts;
using Core.Models.User;
using Microsoft.AspNetCore.Http;

namespace Tischreservierung.Tests.Person.Controller
{
    public class CustomerControllerTest
    {
        [Fact]
        public async Task GetAllCustomers()
        {
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.Customers.GetAll()).ReturnsAsync(TestData());
            var controller = new CustomerController(uow.Object);

            var actionResult = await controller.GetCustomers();

            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(4, ((List<Customer>)result.Value!).Count());

            uow.Verify(x => x.Customers.GetAll());
            uow.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetCorrectCustomerByMail()
        {
            string mail = "witz@gmail.com";

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.Customers.GetByEMail(mail)).ReturnsAsync(TestData()[3]);
            var controller = new CustomerController(uow.Object);

            var actionResult = await controller.GetCustomerByMail(mail);

            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal("testDataD", ((Customer)result.Value!).CustomerNumber);

            uow.Verify(x => x.Customers.GetByEMail(mail));
            uow.VerifyNoOtherCalls();
        }

        [Fact]
        public void CreateNewCustomer()
        {
            Customer customer = new()
            {
                Id = 10,
                Name = "Sepp",
                FamilyName = "Apfel",
                EMail = "birnenseppl@gmail.com",
                Password = "testF",
                CustomerNumber = "testDataF"
            };

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.Customers.Insert(customer));
            var controller = new CustomerController(uow.Object);

            var actionResult = controller.PostCustomer(customer);

            Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var result = actionResult.Result as CreatedAtActionResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result!.StatusCode);
            Assert.Equal(customer, result.Value as Customer);

            uow.Verify(x => x.Customers.Insert(customer));
            uow.Verify(x => x.SaveChangesAsync());
            uow.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DeleteCustomer()
        {
            string mail = "witz@gmail.com";

            var uow = new Mock<IUnitOfWork>();

            uow.Setup(x => x.Customers.GetByEMail(mail)).ReturnsAsync(new Customer());
            uow.Setup(x => x.Customers.Delete(It.IsAny<Customer>()));
            var controller = new CustomerController(uow.Object);

            var actionResult = await controller.DeleteCustomer(mail);

            Assert.IsType<NoContentResult>(actionResult);

            uow.Verify(x => x.Customers.GetByEMail(mail));
            uow.Verify(x => x.Customers.Delete(It.IsAny<Customer>()));
            uow.Verify(x => x.SaveChangesAsync());
            uow.VerifyNoOtherCalls();
        }


        private static List<Customer> TestData()
        {
            List<Customer> data = new()
            {
                new Customer()
                {
                    Id = 1,
                    Name = "Markus",
                    FamilyName = "Witz",
                    EMail = "markus@gmail.com",
                    Password = "testA",
                    CustomerNumber = "testDataA"
                },
                new Customer()
                {
                    Id = 2,
                    Name = "Hermann",
                    FamilyName = "Bauer",
                    EMail = "h.bauer@gmail.com",
                    Password = "testB",
                    CustomerNumber = "testDataB"
                },
                new Customer()
                {
                    Id = 3,
                    Name = "Sebastian",
                    FamilyName = "Witzeneder",
                    EMail = "funnymail@gmx.at",
                    Password = "testC",
                    CustomerNumber = "testDataC"
                },
                new Customer()
                {
                    Id = 4,
                    Name = "Hermann",
                    FamilyName = "Witz",
                    EMail = "witz@gmail.com",
                    Password = "testD",
                    CustomerNumber = "testDataD"
                }
            };

            return data;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tischreservierung.Controllers;
using Core.Models;
using Core.Contracts;
using Microsoft.AspNetCore.Http;

namespace Tischreservierung.Tests.RestaurantTest.Controller
{
    public class ZipCodeControllerTest
    {
        [Fact]
        public async Task GetAllRestaurants()
        {
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.ZipCodes.GetAll()).ReturnsAsync(GetZipCodeTestData());
            var controller = new ZipCodesController(uow.Object);

            var actionResult = await controller.GetZipCodes();
            var result = actionResult.Result as ObjectResult;


            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(4, (result.Value as IEnumerable<ZipCode>)!.Count());

            uow.Verify(x => x.ZipCodes.GetAll());
            uow.VerifyNoOtherCalls();
        }


        [Fact]
        public async Task GetZipCodesByZipCodeNr()
        {
            string zipCode = "4470";
            List<ZipCode> zipCodes = GetZipCodeTestData();

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.ZipCodes.GetByZipCode(zipCode)).ReturnsAsync(new List<ZipCode>() { zipCodes[0] });
            var controller = new ZipCodesController(uow.Object);

            var actionResult = await controller.GetZipCodesByZipCode(zipCode);
            var result = actionResult.Result as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Single((result.Value as IEnumerable<ZipCode>)!);

            uow.Verify(x => x.ZipCodes.GetByZipCode(It.IsAny<string>()));
            uow.VerifyNoOtherCalls();
        }


        [Fact]
        public async Task GetZipCodesByDistrict()
        {
            string district = "Linz-Land";
            List<ZipCode> zipCodes = GetZipCodeTestData();

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.ZipCodes.GetByDistrict(district)).ReturnsAsync(new List<ZipCode>() { zipCodes[0], zipCodes[3] });
            var controller = new ZipCodesController(uow.Object);

            var actionResult = await controller.GetZipCodesByDistrict(district);

            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(2, (result.Value as IEnumerable<ZipCode>)!.Count());

            uow.Verify(x => x.ZipCodes.GetByDistrict(It.IsAny<string>()));
            uow.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetZipCodesByLocation()
        {
            string location = "Linz";
            List<ZipCode> zipCodes = GetZipCodeTestData();

            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.ZipCodes.GetByLocation(location)).ReturnsAsync(new List<ZipCode>() { zipCodes[1], zipCodes[2] });
            var controller = new ZipCodesController(uow.Object);

            var actionResult = await controller.GetZipCodesByLocation(location);
            var result = actionResult.Result as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(2, (result.Value as IEnumerable<ZipCode>)!.Count());

            uow.Verify(x => x.ZipCodes.GetByLocation(It.IsAny<string>()));
            uow.VerifyNoOtherCalls();
        }

        private static List<ZipCode> GetZipCodeTestData()
        {
            List<ZipCode> zipCodes = new()
            {
                new ZipCode() { ZipCodeNr = "4470", District = "Linz-Land", Location = "Enns" },
                new ZipCode() { ZipCodeNr = "4020", District = "Linz", Location = "Linz" },
                new ZipCode() { ZipCodeNr = "4030", District = "Linz", Location = "Linz" },
                new ZipCode() { ZipCodeNr = "4460", District = "Linz-Land", Location = "Leonding" }
            };
            return zipCodes;
        }
    }
}

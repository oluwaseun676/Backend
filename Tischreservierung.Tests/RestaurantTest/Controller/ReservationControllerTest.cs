using Core.Contracts;
using Core.DTO;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace Tischreservierung.Tests.RestaurantTest.Controller
{
    public class ReservationControllerTest
    {
        [Fact]
        public async void GetReservation()
        {
            int reservationId = 10;
            Reservation reservation = new Reservation()
            {
                Id = reservationId,
                CustomerId = 1,
                RestaurantTableId = 101,
                RestaurantId = 1,
                ReservationDay = DateTime.Now,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(3)
            };

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Reservations.GetById(reservationId)).ReturnsAsync(reservation);
            var controller = new ReservationsController(unitOfWork.Object);

            var actionResult = await controller.GetReservation(reservationId);
            var result = actionResult.Result as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(reservation, result.Value);

            unitOfWork.Verify(x => x.Reservations.GetById(reservationId));
            unitOfWork.VerifyNoOtherCalls();
        }

        [Fact]
        public async void GetReservation_ReturnsNotFound()
        {
            int reservationId = 10;

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Reservations.GetById(reservationId)).ReturnsAsync((Reservation?)null);
            var controller = new ReservationsController(unitOfWork.Object);

            var actionResult = await controller.GetReservation(reservationId);
            var result = actionResult.Result as NotFoundResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result!.StatusCode);

            unitOfWork.Verify(x => x.Reservations.GetById(reservationId));
            unitOfWork.VerifyNoOtherCalls();
        }

        [Fact]
        public async void PostReservation()
        {
            ReservationPostDto reservation = new ReservationPostDto()
            {
                CustomerId = 1,
                RestaurantTableId = 101,
                RestaurantId = 1,
                ReservationDay = DateTime.Now,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(3)
            };

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Reservations.Insert(It.IsAny<Reservation>()));
            var controller = new ReservationsController(unitOfWork.Object);

            var actionResult = await controller.PostReservation(reservation);
            var result = actionResult.Result as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result!.StatusCode);

            unitOfWork.Verify(x => x.Reservations.Insert(It.IsAny<Reservation>()));
            unitOfWork.Verify(x => x.SaveChangesAsync());
            unitOfWork.VerifyNoOtherCalls();
        }

        [Fact]
        public async void DeleteReservation()
        {
            int reservationId = 10;
            Reservation reservation = new Reservation()
            {
                Id = reservationId,
                CustomerId = 1,
                RestaurantTableId = 101,
                RestaurantId = 1,
                ReservationDay = DateTime.Now,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(3)
            };

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Reservations.GetById(reservationId)).ReturnsAsync(reservation);
            unitOfWork.Setup(x => x.Reservations.Delete(It.IsAny<Reservation>()));
            var controller = new ReservationsController(unitOfWork.Object);

            var actionResult = await controller.DeleteReservation(reservationId);
            var result = actionResult as NoContentResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);

            unitOfWork.Verify(x => x.Reservations.GetById(reservationId));
            unitOfWork.Verify(x => x.Reservations.Delete(It.IsAny<Reservation>()));
            unitOfWork.Verify(x => x.SaveChangesAsync());
            unitOfWork.VerifyNoOtherCalls();
        }

        [Fact]
        public async void DeleteReservation_ReturnsNotFound()
        {
            int reservationId = 10;

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Reservations.GetById(reservationId)).ReturnsAsync((Reservation?)null);
            var controller = new ReservationsController(unitOfWork.Object);

            var actionResult = await controller.DeleteReservation(reservationId);
            var result = actionResult as NotFoundResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result!.StatusCode);

            unitOfWork.Verify(x => x.Reservations.GetById(reservationId));
            unitOfWork.VerifyNoOtherCalls();
        }

        private static List<Reservation> GetReservationTestData()
        {
            List<Reservation> reservations = new();
            reservations.Add(new Reservation() { CustomerId = 1, RestaurantTableId = 101, RestaurantId = 1, ReservationDay = DateTime.Now, StartTime = DateTime.Now, EndTime = DateTime.Now });
            reservations.Add(new Reservation() { CustomerId = 1, RestaurantTableId = 102, RestaurantId = 1, ReservationDay = DateTime.Now, StartTime = DateTime.Now, EndTime = DateTime.Now });
            reservations.Add(new Reservation() { CustomerId = 1, RestaurantTableId = 102, RestaurantId = 1, ReservationDay = DateTime.Now, StartTime = DateTime.Now, EndTime = DateTime.Now });
            reservations.Add(new Reservation() { CustomerId = 2, RestaurantTableId = 105, RestaurantId = 2, ReservationDay = DateTime.Now, StartTime = DateTime.Now, EndTime = DateTime.Now });
            reservations.Add(new Reservation() { CustomerId = 2, RestaurantTableId = 105, RestaurantId = 2, ReservationDay = DateTime.Now, StartTime = DateTime.Now, EndTime = DateTime.Now });
            reservations.Add(new Reservation() { CustomerId = 3, RestaurantTableId = 106, RestaurantId = 2, ReservationDay = DateTime.Now, StartTime = DateTime.Now, EndTime = DateTime.Now });

            return reservations;
        }
    }
}

using Core.Contracts;
using Core.DTO;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReservationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _unitOfWork.Reservations.GetById(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }


        [HttpGet("byCustomer/{customerId}")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservationsByCustomer(int customerId)
        {
            return Ok(await _unitOfWork.Reservations.GetByCustomer(customerId));
        }

        [HttpGet("byRestaurant/{restaurantId}")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservationsByRestaurant(int restaurantId)
        {
            return Ok(await _unitOfWork.Reservations.GetByRestaurant(restaurantId));
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(ReservationPostDto reservation)
        {
            Reservation reservationToInsert = new Reservation()
            {
                ReservationDay = reservation.ReservationDay,
                StartTime = reservation.StartTime,
                EndTime = reservation.EndTime,
                CustomerId = reservation.CustomerId,
                RestaurantId = reservation.RestaurantId,
                RestaurantTableId = reservation.RestaurantTableId
            };

            _unitOfWork.Reservations.Insert(reservationToInsert);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetReservation", new { id = reservationToInsert.Id }, reservationToInsert);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _unitOfWork.Reservations.GetById(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _unitOfWork.Reservations.Delete(reservation);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}

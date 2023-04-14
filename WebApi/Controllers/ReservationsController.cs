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
        private readonly IReservationRepository _reservationRepository;

        public ReservationsController(IReservationRepository repository)
        {
            _reservationRepository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _reservationRepository.GetReservationById(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }


        [HttpGet("byCustomer/{customerId}")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservationByCustomer(int customerId)
        {
            return Ok(await _reservationRepository.GetReservationsByCustomer(customerId));
        }

        [HttpGet("byRestaurant/{restaurantId}")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservationByRestaurant(int restaurantId)
        {
            return Ok(await _reservationRepository.GetReservationsByRestaurant(restaurantId));
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(ReservationPostDTO reservation)
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

            _reservationRepository.InsertReservation(reservationToInsert);
            await _reservationRepository.Save();

            return CreatedAtAction("GetReservation", new { id = reservationToInsert.Id }, reservationToInsert);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _reservationRepository.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _reservationRepository.DeleteReservation(reservation);
            await _reservationRepository.Save();

            return NoContent();
        }
    }
}

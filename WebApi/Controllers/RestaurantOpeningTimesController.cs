using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.RestaurantRepo;
using Core.Models;
using Core.Contracts;

namespace Tischreservierung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantOpeningTimesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RestaurantOpeningTimesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("restaurant")]
        public async Task<ActionResult<IEnumerable<RestaurantOpeningTime>>> GetRestaurantOpeningTimeForRestaurant(int id)
        {
            var restaurantOpeningTime = await _unitOfWork.OpeningTimes.GetByRestaurant(id);

            if (restaurantOpeningTime == null)
            {
                return NotFound();
            }

            return Ok(restaurantOpeningTime);
        }

        [HttpGet("day")]
        public async Task<ActionResult<IEnumerable<RestaurantOpeningTime>>> GetRestaurantOpeningTimeForDay(int day)
        {
            var restaurantOpeningTime = await _unitOfWork.OpeningTimes.GetByDay(day);

            if (restaurantOpeningTime == null)
            {
                return NotFound();
            }

            return Ok(restaurantOpeningTime);
        }

        [HttpGet("restaurantDay")]
        public async Task<ActionResult<IEnumerable<RestaurantOpeningTime>>> GetRestaurantOpeningTimeForRestaurantAndDay(int id,int day)
        {
            var restaurantOpeningTime = await _unitOfWork.OpeningTimes.GetByDayAndRestaurant(id, day);

            if (restaurantOpeningTime == null)
            {
                return NotFound();
            }

            return Ok(restaurantOpeningTime);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantOpeningTime(int id,RestaurantOpeningTime openingTime)
        {
            if (id != openingTime.Id)
            {
                return BadRequest();
            }

            _unitOfWork.OpeningTimes.Update(openingTime);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantOpeningTimeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<RestaurantOpeningTime>> PostRestaurantOpeningTime(RestaurantOpeningTime restaurantOpeningTime)
        {
            _unitOfWork.OpeningTimes.Insert(restaurantOpeningTime);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantOpeningTime", new { id = restaurantOpeningTime.Id }, restaurantOpeningTime);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantOpeningTime(int id)
        {
            var restaurantOpeningTime = await _unitOfWork.OpeningTimes.GetById(id);
            if (restaurantOpeningTime == null)
            {
                return NotFound();
            }

            _unitOfWork.OpeningTimes.Delete(restaurantOpeningTime);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        private bool RestaurantOpeningTimeExists(int id)
        {
            return _unitOfWork.OpeningTimes.GetById(id) != null;
        }
    }
}

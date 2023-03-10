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
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantRepository _repository;


        //private readonly ILogger<RestaurantsController> _logger;
        public RestaurantsController(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            var restaurants = await _repository.GetRestaurants();
            
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _repository.GetRestaurantById(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(Restaurant restaurant)
        {
            //_logger.LogInformation(restaurant.Name);
            bool inserted = _repository.InsertRestaurant(restaurant);
            if (inserted)
            {
                await _repository.Save();

                return CreatedAtAction("GetRestaurant", new { id = restaurant.Id }, restaurant);
            }

            return NotFound("ZipCode existiert nicht!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await _repository.GetRestaurantById(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _repository.DeleteRestaurant(restaurant);
            await _repository.Save();

            return NoContent();
        }
    }
}
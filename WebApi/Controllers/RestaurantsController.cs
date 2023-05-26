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
using Core.DTO;

namespace Tischreservierung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RestaurantsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            var restaurants = await _unitOfWork.Restaurants.GetAll();
            
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _unitOfWork.Restaurants.GetById(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(RestaurantPostDto restaurant)
        {
            Restaurant? res = await _unitOfWork.Restaurants.InsertRestaurantAsync(restaurant);
            if (res == null)
                return BadRequest();
            await _unitOfWork.SaveChangesAsync();
            return Ok(res.Id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await _unitOfWork.Restaurants.GetById(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _unitOfWork.Restaurants.Delete(restaurant);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
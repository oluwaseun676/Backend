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
    public class RestaurantTablesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RestaurantTablesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantTable>>> GetRestaurantTables()
        {
            var table = await _unitOfWork.RestaurantTables.GetAll();

            return Ok(table);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RestaurantTable>>> GetRestaurantTable(int id)
        {
            var restaurant = await _unitOfWork.RestaurantTables.GetById(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        [HttpGet("/byRestaurant/{restaurantId}")]
        public async Task<ActionResult<IEnumerable<RestaurantTable>>> GetRestaurantTablesByRestaurant(int restaurantId)
        {
            var table = await _unitOfWork.RestaurantTables.GetRestaurantTablesByRestaurant(restaurantId);

            return Ok(table);
        }

        [HttpPost]
        public async Task<ActionResult<RestaurantTable>> PostRestaurantTable(RestaurantTable restaurantTable)
        {
            _unitOfWork.RestaurantTables.Insert(restaurantTable);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantTable", new { id = restaurantTable.Id }, restaurantTable);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantTable(int id)
        {
            var restaurant = await _unitOfWork.RestaurantTables.GetById(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _unitOfWork.RestaurantTables.Delete(restaurant);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}

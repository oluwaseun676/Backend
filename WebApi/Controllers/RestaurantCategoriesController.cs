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
    public class RestaurantCategoriesController : ControllerBase
    {
        private readonly IRestaurantCategoryRepository _restaurantCategoryRepository;

        public RestaurantCategoriesController(IRestaurantCategoryRepository repository)
        {
            _restaurantCategoryRepository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetRestaurantCategories()
        {
            return Ok(await _restaurantCategoryRepository.GetRestaurantCategories());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetRestaurantCategory(string id)
        {
            var restaurantCategory = await _restaurantCategoryRepository.GetRestaurantCategory(id);

            if (restaurantCategory == null)
            {
                return NotFound();
            }

            return restaurantCategory;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostRestaurantCategory(Category restaurantCategory)
        {
            _restaurantCategoryRepository.InsertRestaurantCategory(restaurantCategory);
            await _restaurantCategoryRepository.Save();

            return CreatedAtAction("GetRestaurantCategory", new { id = restaurantCategory.Id }, restaurantCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantCategory(string id)
        {
            var restaurantCategory = await _restaurantCategoryRepository.GetRestaurantCategory(id);
            if (restaurantCategory == null)
            {
                return NotFound();
            }

            _restaurantCategoryRepository.DeleteRestaurantCategory(restaurantCategory);
            await _restaurantCategoryRepository.Save();
            return NoContent();
        }
    }
}

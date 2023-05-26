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
        private readonly IUnitOfWork _unitOfWork;
        public RestaurantCategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetRestaurantCategories()
        {
            IEnumerable<Category> categories = await _unitOfWork.RestaurantCategories.GetAll();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetRestaurantCategory(int id)
        {
            var restaurantCategory = await _unitOfWork.RestaurantCategories.GetById(id);

            if (restaurantCategory == null)
            {
                return NotFound();
            }

            return restaurantCategory;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostRestaurantCategory(Category restaurantCategory)
        {
            _unitOfWork.RestaurantCategories.Insert(restaurantCategory);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantCategory", new { id = restaurantCategory.Id }, restaurantCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantCategory(int id)
        {
            var restaurantCategory = await _unitOfWork.RestaurantCategories.GetById(id);
            if (restaurantCategory == null)
            {
                return NotFound();
            }

            _unitOfWork.RestaurantCategories.Delete(restaurantCategory);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}

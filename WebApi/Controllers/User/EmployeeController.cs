using Microsoft.AspNetCore.Mvc;
using Persistence.Data.User;
using Core.Models.User;
using Core.Contracts;

namespace Tischreservierung.Controllers.Person
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetEmployeeById(int id)
        {
            return Ok(await _unitOfWork.Employees.GetById(id));
        }


        [HttpGet("{restaurantId}")]
        public async Task<ActionResult<List<Customer>>> GetEmployeeByRestaurantId(int id)
        {
            return Ok(await _unitOfWork.Employees.GetByRestaurant(id));
        }

        [HttpPost]
        public async Task<ActionResult> PostEmployee(Employee data)
        {
            _unitOfWork.Employees.Insert(data);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetCustomerById", new { id = data.Id }, data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var employee = await _unitOfWork.Employees.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            _unitOfWork.Employees.Delete(employee);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}

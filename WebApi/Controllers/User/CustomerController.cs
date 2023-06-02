using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Persistence.Data.User;
using Core.Models;
using Core.Models.User;
using Core.Contracts;

namespace Tischreservierung.Controllers.Person
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return Ok(await _unitOfWork.Customers.GetAll());
        }

        [HttpGet("{Mail}")]
        public async Task<ActionResult<Customer>> GetCustomerByMail(string mail)
        {
            return Ok(await _unitOfWork.Customers.GetByEMail(mail));
        }

        [HttpDelete("{Mail}")]
        public async Task<ActionResult> DeleteCustomer(string mail)
        {
            var customer = await _unitOfWork.Customers.GetByEMail(mail);
            if (customer == null)
            {
                return NotFound();
            }

            _unitOfWork.Customers.Delete(customer);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost()]
        public async Task<ActionResult> PostCustomer(Customer data)
        {
            _unitOfWork.Customers.Insert(data);

            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetCustomerByMail", new { mail = data.EMail }, data);
        }
    }
}

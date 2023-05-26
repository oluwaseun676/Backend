using Core.Contracts;
using Core.Models.User;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data.User;

namespace WebApi.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("check")]
        public async Task<ActionResult<Person>> CheckPassword(string email, string password)
        {
            return Ok(await _unitOfWork.Persons.CheckPassword(email, password));
        }
    }
}

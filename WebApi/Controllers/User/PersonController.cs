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
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet("check")]
        public async Task<ActionResult<Person>> CheckPassword(string email, string password)
        {
            return Ok(await _personRepository.CheckPassword(email, password));
        }
    }
}

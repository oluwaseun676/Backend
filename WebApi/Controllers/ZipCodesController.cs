using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Core.Models;
using Core.Contracts;

namespace Tischreservierung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZipCodesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ZipCodesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZipCode>>> GetZipCodes()
        {
            IEnumerable<ZipCode> zipCodes = await _unitOfWork.ZipCodes.GetAll();

            return Ok(zipCodes);
        }

        [HttpGet("{zipcode}")]
        public async Task<ActionResult<IEnumerable<ZipCode>>> GetZipCodesByZipCode(string zipcode)
        {
            var zipCode = await _unitOfWork.ZipCodes.GetByZipCode(zipcode);

            return Ok(zipCode);
        }

        [HttpGet("byLocation")]
        public async Task<ActionResult<IEnumerable<ZipCode>>> GetZipCodesByLocation(string location)
        {
            return Ok( await _unitOfWork.ZipCodes.GetByLocation(location));

        }

        [HttpGet("byDistrict")]
        public async Task<ActionResult<IEnumerable<ZipCode>>> GetZipCodesByDistrict(string district)
        {
            return Ok(await _unitOfWork.ZipCodes.GetByDistrict(district));

        }

        [HttpGet("byZipCodeAndLocation")]
        public async Task<ActionResult<IEnumerable<ZipCode>>> GetZipCodesByZipCodeAndLocation
            (string zipZode, string location)
        {
            return Ok(await _unitOfWork.ZipCodes.GetByZipCodeAndLocation(zipZode,location));

        }

    }
}

using cw11.DTO.Request;
using cw11.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IPharmacyDbService _context;

        public DoctorController(IPharmacyDbService context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_context.ReadDoctors());
        }

        [HttpGet("{idDoctor}")]
        public IActionResult GetDoctor(int idDoctor)
        {
            var response = _context.ReadDoctor(idDoctor);
            if (response == null)
            {
                return NotFound("Doctor with id " + idDoctor + " not found!");
            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateDoctor(CreateDoctorDTO createDoctor)
        {
            var response = _context.CreateDoctor(createDoctor);
            return Created("Doctor has been added", response);
        }

        [HttpPut("/update")]
        public IActionResult UpdateDoctor(UpdateDoctorDTO updateDoctor)
        {
            var response = _context.UpdateDoctor(updateDoctor);
            if (response == null)
            {
                return NotFound("Doctor with id " + updateDoctor.IdDoctor + " not found!");
            }

            return Ok(response);
        }

        [HttpDelete("{idDoctor}")]
        public IActionResult DeleteDoctor(int idDoctor)
        {
            var response = _context.DeleteDoctor(idDoctor);
            if (response == null)
            {
                return NotFound("Doctor with id " + idDoctor + " not found!");
            }

            return Ok(response);
        }
    }
}

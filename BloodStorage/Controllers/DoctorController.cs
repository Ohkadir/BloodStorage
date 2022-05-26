using BloodStorage.Models;
using BloodStorage.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ICrudService<Doctor, int> _doctorService;

        public DoctorController(ICrudService<Doctor, int> doctorService)

        {

            _doctorService = doctorService;

        }

        // GET all action

        [HttpGet] // auto returns data with a Content-Type of application/json

        public ActionResult<List<Doctor>> GetAll() => _doctorService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Doctor> Get(int id)
        {
            var doctor = _doctorService.Get(id);
            if (doctor is null) return NotFound();
            else return doctor;
        }

        // POST action
        [HttpPost]

        public IActionResult Create(Doctor doctor)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _doctorService.Add(doctor);
                return CreatedAtAction(nameof(Create), new { id = doctor.DocId }, doctor);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Doctor doctor)
        {
            var existingDoctor = _doctorService.Get(id);
            if (existingDoctor is null || existingDoctor.DocId != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _doctorService.Update(existingDoctor, doctor);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingDoctor = _doctorService.Get(id);
            if (existingDoctor is null) return NotFound();
            _doctorService.Delete(id);
            return NoContent();
        }



    }
}

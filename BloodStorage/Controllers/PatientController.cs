using BloodStorage.Models;
using BloodStorage.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly ICrudService<Patient, int> _patientService;

        public PatientController(ICrudService<Patient, int> patientService)

        {

            _patientService = patientService;

        }



        // GET all action

        [HttpGet] // auto returns data with a Content-Type of application/json

        public ActionResult<List<Patient>> GetAll() => _patientService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Patient> Get(int id)
        {
            var patient = _patientService.Get(id);
            if (patient is null) return NotFound();
            else return patient;
        }

        // POST action
        [HttpPost]
        
        public IActionResult Create(Patient patient)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _patientService.Add(patient);
                return CreatedAtAction(nameof(Create), new { id = patient.NHSId }, patient);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Patient patient)
        {
            var existingPatient = _patientService.Get(id);
            if (existingPatient is null || existingPatient.NHSId != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _patientService.Update(existingPatient, patient);
                return NoContent();
            }




            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingPatient = _patientService.Get(id);
            if (existingPatient is null) return NotFound();
           _patientService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        [Route("info")]
        public ActionResult<List<string>> GetInfo()
        {
            return ((PatientService)_patientService).GetJoinedData().ToList();
        }

    }
}

namespace Liver_Disease_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Medical Assistant")]
    public class PatientsController : ControllerBase
    {
        private readonly IServicePatient _servicePatient;

        public PatientsController(IServicePatient servicePatient)
        {
            _servicePatient = servicePatient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _servicePatient.GetAllPatientDtos();
            return Ok(patients);
        }
        [HttpGet("nationalId/{nationalId}")]
        public async Task<IActionResult> GetPatientByNationalId(string nationalId)
        {
            var patient = await _servicePatient.GetPatientByNationalId(nationalId);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        [HttpGet("address/{address}")]
        public async Task<IActionResult> GetPatientByAddress(string address)
        {
            var patient = await _servicePatient.GetPatientByAddress(address);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetPatientByName(string name)
        {
            var patient = await _servicePatient.GetPatientByName(name);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] PatientDto patient)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (patient == null)
            {
                return BadRequest("Patient data is null");
            }
            var addedPatient = await _servicePatient.AddPatientDtoAsync(patient);
            return CreatedAtAction("api/Patients",addedPatient);
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var deletedPatient = await _servicePatient.DeletePatientDto(id);
            if (deletedPatient == null)
            {
                return NotFound($"Patient with ID {id} not found.");
            }
            return Ok(deletedPatient);
        }
    }
}

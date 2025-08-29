namespace Liver_Disease_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IServiceDoctor _serviceDoctor;

        public DoctorsController(IServiceDoctor serviceDoctor)
        {
            _serviceDoctor = serviceDoctor;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var items = await _serviceDoctor.GetAllDoctorDtos();
            return Ok(items);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var doctorId = await _serviceDoctor.GetDoctorById(id);
            return Ok(doctorId);
        }
        [HttpGet("name/{doctor}")]
        public async Task<IActionResult>GetDoctorByName(string doctor)
        {
            var doctorName = await _serviceDoctor.GetDoctorByName(doctor);
            return Ok(doctorName);
        }
        [HttpGet("specialization/{Specialization}")]
        public async Task<IActionResult> GetDoctorBySpecialization(string Specialization)
        {
            var doctorSpecialization = await _serviceDoctor.GetDoctorBySpecialization(Specialization);
            return Ok(doctorSpecialization);
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult>AddDoctor(DoctorDto doctor)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var doctorAdd = await _serviceDoctor.AddDoctorDto(doctor);
            return Created("api /Doctors",doctorAdd);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult>DeleteDoctor(int id)
        {
            var doctor = await _serviceDoctor.DeleteDoctorDto(id);
            if (doctor == null) return NotFound($"Id : {id}");
            return NoContent();
        }
    }
}

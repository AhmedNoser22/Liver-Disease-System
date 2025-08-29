namespace Liver_Disease_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Medical Assistant")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IServicesAppointment _servicesAppointment;

        public AppointmentsController(IServicesAppointment servicesAppointment)
        {
            _servicesAppointment = servicesAppointment;
        }
        [HttpGet]
        public  async Task<IActionResult>GetAllApointments()
        {
            var Appointment = await _servicesAppointment.GetAppointmentAsync();
            return Ok(Appointment);
        }
        [HttpGet("Patient/{PatientId}")]
        public async Task<IActionResult>GetByPatientId(int PatientId)
        {
            var patient = await _servicesAppointment.GetByPatientId(PatientId);
            return Ok(patient);
        }
        [HttpGet("Doctor/{DoctorId}")]
        public async Task<IActionResult>GetByDoctorId(int DoctorId)
        {
            var patient = await _servicesAppointment.GetByPatientId(DoctorId);
            return Ok(patient);
        }
        [HttpPost]
        public async Task<IActionResult>AddAppointments(AppointmentDto appointment)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var appointmentName = await _servicesAppointment.AddAppointment(appointment);
            return Created("api/Appointments", appointmentName);
        }
    }
}

namespace Liver_Disease_System.Services
{
    public interface IServicesAppointment
    {
        Task<IEnumerable<AppointmentDto>> GetAppointmentAsync();    
        Task<AppointmentDto> GetByDoctorId(int id);
        Task<AppointmentDto> GetByPatientId(int id);
        Task<AppointmentDto> AddAppointment(AppointmentDto appointment);
    }
}

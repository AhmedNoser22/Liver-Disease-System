namespace Liver_Disease_System.Services
{
    public interface IServiceDoctor
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctorDtos();
        Task<DoctorDto> GetDoctorByName(string name);
        Task<DoctorDto> GetDoctorBySpecialization(string name);
        Task<DoctorDto> GetDoctorById(int id);
        Task<DoctorDto> AddDoctorDto(DoctorDto doctor);
        Task<DoctorDto> DeleteDoctorDto(int id);
    }
}

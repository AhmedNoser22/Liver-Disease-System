namespace Liver_Disease_System.Services
{
    public interface IServicePatient
    {
        Task<IEnumerable<PatientDto>> GetAllPatientDtos();
        Task<PatientDto> GetPatientByNationalId(string nationalId);
        Task<PatientDto> GetPatientByAddress(string address);
        Task<PatientDto> GetPatientByName(string name);
        Task<PatientDto> AddPatientDtoAsync(PatientDto patient);
        Task<PatientDto> DeletePatientDto(int id);
    }
}

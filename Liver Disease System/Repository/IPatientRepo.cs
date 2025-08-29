namespace Liver_Disease_System.Repository
{
    public interface IPatientRepo : IGenericRepository<Patient>
    {
        Task<Patient> GetPatientByNationalId(string nationalId);
        Task<Patient> GetPatientByAddress(string Address);
    }
}

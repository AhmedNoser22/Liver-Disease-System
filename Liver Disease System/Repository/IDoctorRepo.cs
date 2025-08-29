namespace Liver_Disease_System.Repository
{
    public interface IDoctorRepo:IGenericRepository<Doctor>
    {
        Task<Doctor> GetBySpecialization(string Specialization);
    }
}

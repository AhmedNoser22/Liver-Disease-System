namespace Liver_Disease_System.Repository
{
    public interface IMedicalRecordRepo:IGenericRepository<MedicalRecord>
    {
        Task<IEnumerable<MedicalRecord>> GetByLiverStage(string liverStage);
    }
}

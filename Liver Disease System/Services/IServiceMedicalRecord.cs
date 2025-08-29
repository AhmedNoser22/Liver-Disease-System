namespace Liver_Disease_System.Services
{
    public interface IServiceMedicalRecord
    {
        Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsAsync();
        Task<MedicalRecord> GetById(int id);
        Task<IEnumerable<MedicalRecordDto>> GetByLiverStage(string liverStage);
        Task<IdentityResult> AddMedicalRecordDto(CreateMedicalRecordDto medicalRecord);
    }
}

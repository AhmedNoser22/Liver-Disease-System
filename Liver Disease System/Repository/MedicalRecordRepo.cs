namespace Liver_Disease_System.Repository
{
    public class MedicalRecordRepo : GenericRepository<MedicalRecord>, IMedicalRecordRepo
    {
        private readonly AppDbContext _context;

        public MedicalRecordRepo(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MedicalRecord>> GetByLiverStage(string liverStage)
        {
           var medicalRecord = await _context.MedicalRecord
                .Where(m=>m.LiverStage==liverStage)
                .ToListAsync();
            if (medicalRecord == null || !medicalRecord.Any())
            {
                throw new KeyNotFoundException($"No medical records found for liver stage {liverStage}");
            }
            return medicalRecord;
        }
    }
}

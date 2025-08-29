namespace Liver_Disease_System.Repository
{
    public class PatientRepo:GenericRepository<Patient>, IPatientRepo
    {
        private readonly AppDbContext _context;
        public PatientRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        // Additional methods specific to PatientRepo can be added here
        public async Task<Patient> GetPatientByNationalId(string nationalId)
        {
            if (nationalId == null)
            {
                throw new ArgumentNullException(nameof(nationalId), "National ID cannot be null");
            }
            var patient = await _context.Patient.Where(p => p.NationalId == nationalId).FirstOrDefaultAsync();
            if (patient == null)
            {
                throw new KeyNotFoundException($"Patient with National ID {nationalId} not found");
            }
            return patient;
        }
        public async Task<Patient> GetPatientByAddress(string address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address), "Address cannot be null");
            }
            var patient = await _context.Patient.Where(p => p.Address == address).FirstOrDefaultAsync();
            if (patient == null)
            {
                throw new KeyNotFoundException($"Patient with Address {address} not found");
            }
            return patient;
        }
    }
}

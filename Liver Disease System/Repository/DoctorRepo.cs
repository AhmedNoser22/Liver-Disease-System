namespace Liver_Disease_System.Repository
{
    public class DoctorRepo:GenericRepository<Doctor>,IDoctorRepo
    {
        private readonly AppDbContext _context; 
        public DoctorRepo(AppDbContext context):base(context)
        {
            _context = context;
        }
        public async Task<Doctor> GetBySpecialization(string Specialization)
        {
            var doctor = await _context.Doctor.
                 Where(x => x.Specialization == Specialization)
                 .FirstOrDefaultAsync();
            if(doctor==null)
            {
                throw new KeyNotFoundException($"Doctor with Specialization {Specialization} not found");
            }
            return doctor;
        }
    }
}

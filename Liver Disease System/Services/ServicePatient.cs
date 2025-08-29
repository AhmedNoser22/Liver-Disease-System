namespace Liver_Disease_System.Services
{
    public class ServicePatient : IServicePatient
    {
        private readonly IPatientRepo _patientRepo;
        private readonly IMapper _mapper;
        public ServicePatient(IPatientRepo patientRepo, IMapper mapper)
        {
            _patientRepo = patientRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PatientDto>> GetAllPatientDtos()
        {
            var patients = await _patientRepo.GetAll();
            return _mapper.Map<IEnumerable<PatientDto>>(patients);
        }
        public async Task<PatientDto> GetPatientByNationalId(string nationalId)
        {
            var patient = await _patientRepo.GetPatientByNationalId(nationalId);
            return _mapper.Map<PatientDto>(patient);
        }
        public async Task<PatientDto> GetPatientByAddress(string address)
        {
            var patient = await _patientRepo.GetPatientByAddress(address);
            return _mapper.Map<PatientDto>(patient);
        }
        public async Task<PatientDto> GetPatientByName(string name)
        {
            var patient = await _patientRepo.GetByEntity(x=>x.Name==name);
            return _mapper.Map<PatientDto>(patient);
        }
        public async Task<PatientDto> AddPatientDtoAsync(PatientDto patient)
        {
            var patientEntity = _mapper.Map<Patient>(patient);
            var addedPatient = await _patientRepo.Add(patientEntity);
            await _patientRepo.Complete();
            return _mapper.Map<PatientDto>(addedPatient);
        }
        public async Task<PatientDto> DeletePatientDto(int id)
        {
            var patient =await _patientRepo.GetById(id);
            if (patient == null)
            {
                throw new KeyNotFoundException($"Patient with ID {id} not found.");
            }
            await _patientRepo.Delete(id);
            await _patientRepo.Complete();
            return _mapper.Map<PatientDto>(patient);
        }
    }
}

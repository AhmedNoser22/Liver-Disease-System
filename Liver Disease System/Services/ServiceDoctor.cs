namespace Liver_Disease_System.Services
{
    public class ServiceDoctor : IServiceDoctor
    {
        private readonly IDoctorRepo _doctorRepo;
        private readonly IMapper _mapper;
        public ServiceDoctor(IMapper mapper, IDoctorRepo doctorRepo)
        {
            _mapper = mapper;
            _doctorRepo = doctorRepo;
        }
        public async Task<IEnumerable<DoctorDto>> GetAllDoctorDtos()
        {
            var items = await _doctorRepo.GetAll();
            return _mapper.Map<IEnumerable<DoctorDto>>(items);
        }
        public async Task<DoctorDto> GetDoctorById(int id)
        {
            var doctor = await _doctorRepo.GetById(id);
            return _mapper.Map<DoctorDto>(doctor);
        }
        public async Task<DoctorDto> GetDoctorByName(string name)
        {
            var doctor = await _doctorRepo.GetByEntity(x=>x.Name==name);
            return _mapper.Map<DoctorDto>(doctor);
        }
        public async Task<DoctorDto> GetDoctorBySpecialization(string name)
        {
            var doctor = await _doctorRepo.GetBySpecialization(name);
            return _mapper.Map<DoctorDto>(doctor);
        }
        public async Task<DoctorDto> AddDoctorDto(DoctorDto doctor)
        {
            var doctorMap = _mapper.Map<Doctor>(doctor);
            var addDoctor = await _doctorRepo.Add(doctorMap);
            await _doctorRepo.Complete();
            return _mapper.Map<DoctorDto>(addDoctor);
        }
        public async Task<DoctorDto>DeleteDoctorDto(int id)
        {
            var item = await _doctorRepo.GetById(id);
            if(item==null)
            {
                throw new KeyNotFoundException($"Doctor with ID {id} not found.");
            }
            await _doctorRepo.Delete(id);
            await _doctorRepo.Complete();
            return _mapper.Map<DoctorDto>(item);
        }
    }
}

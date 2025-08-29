namespace Liver_Disease_System.Services
{
    public class ServicesAppointment : IServicesAppointment
    {
        private readonly IGenericRepository<Appointment> _repository;
        private readonly IMapper _mapper;

        public ServicesAppointment(IGenericRepository<Appointment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AppointmentDto>> GetAppointmentAsync()
        {
            var appointment = await _repository.GetAll(); 
            var AppointMap = _mapper.Map<IEnumerable<AppointmentDto>>(appointment);
            return AppointMap;
        }
        public async Task<AppointmentDto> GetByDoctorId(int id)
        {
            var item = await _repository.GetByEntity(x => x.DoctorId == id);
            if(item==null)
            {
                throw new KeyNotFoundException();
            }
            var appointMap = _mapper.Map<AppointmentDto>(item);
            return appointMap;
        }
        public async Task<AppointmentDto> GetByPatientId(int id)
        {
            var item = await _repository.GetByEntity(x => x.PatientId == id);
            if(item==null)
            {
                throw new KeyNotFoundException();
            }
            var appointMap = _mapper.Map<AppointmentDto>(item);
            return appointMap;
        }
        public async Task<AppointmentDto> AddAppointment(AppointmentDto appointment)
        {
            var appointMap = _mapper.Map<Appointment>(appointment);
            await _repository.Add(appointMap);
            await _repository.Complete();
            return appointment;

        }
    }
}

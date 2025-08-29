namespace Liver_Disease_System.Services
{
    public class ServiceMedicine : IServiceMedicine
    {
        private readonly IGenericRepository<Medicine>_genericRepository;
        private readonly IMapper _mapper;

        public ServiceMedicine(IGenericRepository<Medicine> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MedicineDto>> GetAllMedicines()
        {
            var medicines = await _genericRepository.GetAll();
            return _mapper.Map<IEnumerable<MedicineDto>>(medicines);
        }

        public async Task<MedicineDto> GetByName(string name)
        {
            var medicine = await _genericRepository.GetByEntity(x => x.Name == name);
            return _mapper.Map<MedicineDto>(medicine);
        }
        public async Task<MedicineDto> AddMedicine(MedicineDto medicine)
        {
            var medicineAdded = _mapper.Map<Medicine>(medicine);
            var CreateMedicine = await _genericRepository.Add(medicineAdded);
            await _genericRepository.Complete();
            if (CreateMedicine == null) return null!;
            return _mapper.Map<MedicineDto>(CreateMedicine);
        }
        public async Task<MedicineDto> DeleteMedicine(int id)
        {
            var item = await _genericRepository.GetById(id);
            if (item == null) return null!;
            var medicine = await _genericRepository.Delete(id);
            await _genericRepository.Complete();
            return _mapper.Map<MedicineDto>(medicine);
        }
    }
}

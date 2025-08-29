namespace Liver_Disease_System.Services
{
    public class ServiceMedicalRecord:IServiceMedicalRecord
    {
        private readonly IMedicalRecordRepo _medicalRecordRepo;
        private readonly IMapper _mapper;
        public ServiceMedicalRecord(IMedicalRecordRepo medicalRecordRepo, IMapper mapper)
        {
            _medicalRecordRepo = medicalRecordRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsAsync()
        {
            var medicalRecords = await _medicalRecordRepo.GetAll();
            if (medicalRecords == null || !medicalRecords.Any())
            {
                throw new KeyNotFoundException("No medical records found");
            }
            return _mapper.Map<IEnumerable<MedicalRecordDto>>(medicalRecords);
        }
        public async Task<IEnumerable<MedicalRecordDto>> GetByLiverStage(string liverStage)
        {
            var medicalRecord = await _medicalRecordRepo.GetByLiverStage(liverStage);
            if (medicalRecord == null || !medicalRecord.Any())
            {
                throw new KeyNotFoundException($"No medical records found for liver stage {liverStage}");
            }
            return _mapper.Map<IEnumerable<MedicalRecordDto>>(medicalRecord);
        }
        public async Task<MedicalRecord> GetById(int id)
        {
            var medical = await _medicalRecordRepo.GetById(id);
            if (medical == null)
            {
                throw new ArgumentNullException(nameof(medical), "Medical record cannot be null");
            }
            return medical;
        }
        public async Task<IdentityResult> AddMedicalRecordDto(CreateMedicalRecordDto medicalRecord)
        {
            byte[]? imageBytes = null;  
            if (medicalRecord.DiagnosisImage != null)
            {
                if
                        (
                        !FileSetting.AllowedExtensions.Contains(Path.GetExtension(medicalRecord.DiagnosisImage.FileName).ToLower())
                        && medicalRecord.DiagnosisImage.Length >= FileSetting.MaxFileSize
                        )
                {
                    throw new ArgumentException("Invalid file type or size. Allowed types: jpg, png. Max size: 1 MB.");
                }
                var stream = new MemoryStream();
                await medicalRecord.DiagnosisImage.CopyToAsync(stream);
                imageBytes = stream.ToArray();
            }
            var record = _mapper.Map<MedicalRecord>(medicalRecord);
            record.DiagnosisImage = imageBytes;
                
            var result = await _medicalRecordRepo.Add(record);
            await _medicalRecordRepo.Complete();
            if (result == null)
            {
                throw new Exception("Failed to add medical record");
            }
            return IdentityResult.Success;
        }
        


    }
}

namespace Liver_Disease_System.Mapping
{
    public class MappingSetting:Profile
    {
        public MappingSetting()
        {
            // Mapping configurations for MedicalRecord and related DTOs
            CreateMap<MedicalRecord, MedicalRecordDto>();
            CreateMap<CreateMedicalRecordDto, MedicalRecord>()
                .ForMember(dest => dest.DiagnosisImage, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            // Mapping configurations for Patient and related DTOs
            CreateMap<Patient, PatientDto>();
            CreateMap<PatientDto, Patient>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            // Mapping configurations for Doctor and related DTOs
            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorDto, Doctor>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            // Mapping configurations for Appointment and related DTOs
            CreateMap<Appointment, AppointmentDto>();
            CreateMap<AppointmentDto, Appointment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            // Mapping configurations for Medicine and related DTOs
            CreateMap<MedicineDto, Medicine>()
                .ForMember(dest => dest.Id, src => src.Ignore());
            CreateMap<Medicine, MedicineDto>();
            // Mapping configurations for Auth and related DTOs
            CreateMap<RegisterDto, AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            // Mapping configurations for Users and related DTOs
            CreateMap<AppUser, AppUserDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

        }
    }
}

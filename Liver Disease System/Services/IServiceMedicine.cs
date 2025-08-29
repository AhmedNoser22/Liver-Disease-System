namespace Liver_Disease_System.Services
{
    public interface IServiceMedicine
    {
        Task<IEnumerable<MedicineDto>> GetAllMedicines();
        Task<MedicineDto> GetByName(string name);
        Task<MedicineDto> AddMedicine(MedicineDto medicine);
        Task<MedicineDto> DeleteMedicine(int id);

    }
}

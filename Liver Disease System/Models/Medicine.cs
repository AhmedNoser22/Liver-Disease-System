namespace Liver_Disease_System.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Dosage { get; set; } = default!;
        public ICollection<PatientMedicine> PatientMedicines { get; set; } = new List<PatientMedicine>();
    }
}

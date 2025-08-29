using System.Threading.Tasks;

namespace Liver_Disease_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IServiceMedicine _serviceMedicine;

        public MedicinesController(IServiceMedicine serviceMedicine)
        {
            _serviceMedicine = serviceMedicine;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicine()
        {
            var medicines = await _serviceMedicine.GetAllMedicines();
            return Ok(medicines);
        }
        [HttpGet("Name")]
        public async Task<IActionResult>GetMedicineByName(string Name)
        {
            var medicine = await _serviceMedicine.GetByName(Name);
            return Ok(medicine);
        }
        [Authorize("Doctor")]
        [HttpPost]
        public async Task<IActionResult>AddMedicine(MedicineDto medicine)
        {
            var medicineCreated = await _serviceMedicine.AddMedicine(medicine);
            return Ok(medicineCreated);
        }
        [Authorize("Doctor")]
        [HttpDelete]
        public async Task<IActionResult>DeleteMedicine(int id)
        {
            await _serviceMedicine.DeleteMedicine(id);
            return NoContent();
        }
    }
}

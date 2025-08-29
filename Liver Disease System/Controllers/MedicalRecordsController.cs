namespace Liver_Disease_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IServiceMedicalRecord _serviceMedicalRecord;
        public MedicalRecordsController(IServiceMedicalRecord serviceMedicalRecord)
        {
            _serviceMedicalRecord = serviceMedicalRecord;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMedicalRecords()
        {
            var records =await _serviceMedicalRecord.GetMedicalRecordsAsync();
            if (records == null)
            {
                return NotFound("No medical records found.");
            }
            return Ok(records);
        }
        [Authorize(Roles = "Medical Assistant")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicalRecordById(int id)
        {
            var record =await _serviceMedicalRecord.GetById(id);
            if (record == null)
            {
                return NotFound($"Medical record with ID {id} not found.");
            }
            return Ok(record);
        }
        [Authorize(Roles ="Doctor")]
        [HttpGet("liverStage/{liverStage}")]
        public async Task<IActionResult> GetMedicalRecordsByLiverStage([FromRoute]string liverStage)
        {
            var records =await _serviceMedicalRecord.GetByLiverStage(liverStage);
            if(records==null)
            {
                return NotFound($"No medical records found for liver stage {liverStage}.");
            }
            return Ok(records);
        }
        [Authorize(Roles = "Medical Assistant")]
        [HttpPost]
        public async Task<IActionResult> AddMedicalRecord(CreateMedicalRecordDto medicalRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(medicalRecord==null)
            {
                return BadRequest("Medical record data is required.");
            }
            if
                (
                !FileSetting.AllowedExtensions.Contains(Path.GetExtension(medicalRecord.DiagnosisImage?.FileName).ToLower())
                && medicalRecord.DiagnosisImage?.Length >= FileSetting.MaxFileSize
                )
            {
                return BadRequest("Invalid file type or size. Allowed types: jpg, png. Max size: 1 MB.");
            }
            var result = await _serviceMedicalRecord.AddMedicalRecordDto(medicalRecord);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Created("api/MedicalRecords", medicalRecord);
        }

    }
}

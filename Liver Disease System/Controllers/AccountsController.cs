namespace Liver_Disease_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IServiceAuth _serviceAuth;
        private readonly UserManager<AppUser> _userManager;
        public AccountsController(IServiceAuth serviceAuth, UserManager<AppUser> userManager)
        {
            _serviceAuth = serviceAuth;
            _userManager = userManager;
        }
        [HttpPost("Register")]
        public async Task<IActionResult>Register([FromForm]RegisterDto register)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (await _userManager.FindByEmailAsync(register.Email) != null)
                return BadRequest("Email Is Existing");
            await _serviceAuth.RegisterDto(register);
            return Ok("Created");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm]LoginDto login)
        {
            if (!ModelState.IsValid) return BadRequest();
            var Token =  await _serviceAuth.LoginterDto(login);
            return Ok(Token);
        }
        [Authorize("Admin")]
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _serviceAuth.GetAllUser();
            return Ok(users);
        }

    }
}

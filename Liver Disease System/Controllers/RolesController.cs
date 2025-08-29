namespace Liver_Disease_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RolesController : ControllerBase
    {
        private readonly IServiceRole _serviceRole;
        public RolesController(IServiceRole serviceRole)
        {
            _serviceRole = serviceRole;
        }
        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _serviceRole.GetRoleAsync();
            return Ok(roles);
        }
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(RolesDto role)
        {
            var result = await _serviceRole.AddRole(role);
            if (result.Succeeded)
            {
                return Ok("Role created successfully");
            }
            return BadRequest(result.Errors);
        }
        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRole(RolesDto role)
        {
            var result = await _serviceRole.DeleteRoleAsync(role);
            if (result.Succeeded)
            {
                return Ok("Role deleted successfully");
            }
            return BadRequest(result.Errors);
        }
        [HttpGet("GetRolesOfUser")]
        public async Task<IActionResult> GetRolesOfUser(string userName)
        {
            var roles = await _serviceRole.GetAllRolesAddedToUser(userName);
            return Ok(roles);
        }
        [HttpPost("AddRoleToUser")]
        public async Task<IActionResult> AddRoleToUser(AddRolesToUserDto role)
        {
            var result = await _serviceRole.AddRoleToUser(role);
            if (result.Succeeded)
            {
                return Ok("Role added to user successfully");
            }
            return BadRequest(result.Errors);
        }
        [HttpDelete("RemoveRoleFromUser")]
        public async Task<IActionResult> RemoveRoleFromUser(AddRolesToUserDto role)
        {
            var result = await _serviceRole.DeleteRoleToUser(role);
            if (result.Succeeded)
            {
                return Ok("Role removed from user successfully");
            }
            return BadRequest(result.Errors);
        }
    }
}

namespace Liver_Disease_System.Services
{
    public class ServiceRole : IServiceRole
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public ServiceRole(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<string>> GetRoleAsync()
            => await _roleManager.Roles.Select(r => r.Name!).ToListAsync();
        public async Task<IdentityResult> AddRole(RolesDto role)
        {
            var rolename = await _roleManager.RoleExistsAsync(role.RoleName);
            if (rolename) return IdentityResult.Failed(new IdentityError { Description= "Role already exists." });
            var roleCreated = new IdentityRole(role.RoleName);
            return await _roleManager.CreateAsync(roleCreated);
        }
        public async Task<IdentityResult> DeleteRoleAsync(RolesDto role)
        {
            var roleName = await _roleManager.FindByNameAsync(role.RoleName);
            if(roleName==null) return IdentityResult.Failed(new IdentityError { Description = "Role not found." });
            return await _roleManager.DeleteAsync(roleName);

        }
        public async Task<IEnumerable<string>> GetAllRolesAddedToUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) IdentityResult.Failed();
            return await _userManager.GetRolesAsync(user!);
        }
        public async Task<IdentityResult> AddRoleToUser(AddRolesToUserDto rolesToUserDto)
        {
            var user = await _userManager.FindByNameAsync(rolesToUserDto.UserName);
            if (user == null) return IdentityResult.Failed();
            var role = await _roleManager.RoleExistsAsync(rolesToUserDto.RoleName);
            if (!role) return IdentityResult.Failed();
            return await _userManager.AddToRoleAsync(user,rolesToUserDto.RoleName);
        }
        public async Task<IdentityResult> DeleteRoleToUser(AddRolesToUserDto rolesToUserDto)
        {
            var user = await _userManager.FindByNameAsync(rolesToUserDto.UserName);
            if (user == null) return IdentityResult.Failed();
            var role = await _roleManager.RoleExistsAsync(rolesToUserDto.RoleName);
            if (!role) return IdentityResult.Failed();
            return await _userManager.RemoveFromRoleAsync(user, rolesToUserDto.RoleName);
        }
    }
}

namespace Liver_Disease_System.Services
{
    public class ServiceAuth:IServiceAuth
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IServiceToken _servicetoken;
        private readonly IMapper _mapper;

        public ServiceAuth(UserManager<AppUser> userManager, IMapper mapper, IServiceToken servicetoken)
        {
            _userManager = userManager;
            _mapper = mapper;
            _servicetoken = servicetoken;
        }
        public async Task<IdentityResult> RegisterDto(RegisterDto register)
        {
            var usermap = _mapper.Map<AppUser>(register);
            var UserName = await _userManager.FindByEmailAsync(register.Email);
            if (UserName != null)
            {
                throw new Exception("Not Allowed");
            }
            var createdUser = await _userManager.CreateAsync(usermap,register.Password);
            if (!createdUser.Succeeded) return null!;
            await _userManager.AddToRoleAsync(usermap,"User");
            return IdentityResult.Success;
        }
        public async Task<string> LoginterDto(LoginDto login)
        {
            var email = await _userManager.FindByEmailAsync(login.Email);
            if(email==null) return null!;
            var user = await _userManager.CheckPasswordAsync(email, login.Password);
            if (!user)
            {
                return null!;
            }
            var token = await _servicetoken.GenerateToken(email);
            return token;
        }
        public async Task<IEnumerable<AppUserDto>> GetAllUser()
        {
            var UsersDto =  await _userManager.Users.ToListAsync();
            return _mapper.Map<IEnumerable<AppUserDto>>(UsersDto);
        }
    }
}

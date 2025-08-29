namespace Liver_Disease_System.Services
{
    public interface IServiceAuth
    {
        Task<IdentityResult> RegisterDto(RegisterDto register);
        Task<string> LoginterDto(LoginDto login);
        Task<IEnumerable<AppUserDto>> GetAllUser();
    }
}

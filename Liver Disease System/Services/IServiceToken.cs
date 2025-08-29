namespace Liver_Disease_System.Services
{
    public interface IServiceToken
    {
        Task<string> GenerateToken(AppUser user);
    }
}

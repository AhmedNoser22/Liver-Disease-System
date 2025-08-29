namespace Liver_Disease_System.Services
{
    public interface IServiceRole
    {
        Task<IEnumerable<string>> GetRoleAsync();
        Task<IdentityResult> AddRole(RolesDto role);
        Task<IdentityResult> DeleteRoleAsync(RolesDto role);
        Task<IEnumerable<string>>GetAllRolesAddedToUser(string userName);
        Task<IdentityResult>AddRoleToUser(AddRolesToUserDto rolesToUserDto);
        Task<IdentityResult>DeleteRoleToUser(AddRolesToUserDto rolesToUserDto);

    }
}

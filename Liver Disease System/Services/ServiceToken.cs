namespace Liver_Disease_System.Services
{
    public class ServiceToken : IServiceToken
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public ServiceToken(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> GenerateToken(AppUser user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var signing = new SigningCredentials
                (
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                SecurityAlgorithms.HmacSha256
                );
            var designToken = new JwtSecurityToken
                (
               issuer: _configuration["Jwt:Issuer"],
               audience: _configuration["Jwt:Audience"],
               signingCredentials:signing,
               expires:DateTime.Now.AddMinutes(40),
               claims:claims
                );
            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(designToken);
            return tokenHandler;
        }
    }
}

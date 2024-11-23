using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TP.Application;
using TP.Application.Contracts.Infrastructure.AccountSerivce;
using TP.Domain;

namespace TP.Infrastructure.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JWTSetting options;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AuthService(UserManager<ApplicationUser> userManager,IOptions<JWTSetting> options,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.options = options.Value;
            this.signInManager = signInManager;
        }

        #region Register
        public async Task<RegisterationResponse> Register(RegisterationRequest request)
        {
            var exsitUserName = await userManager.FindByNameAsync(request.UserName);
            if (exsitUserName != null)
            {
                throw new Exception($"the userName {request.UserName} alreay exsit");
            }
            var exsitEamil = await userManager.FindByEmailAsync(request.Email);
            if (exsitEamil != null)
            {
                throw new Exception($"the Email {request.Email} alreay exsit");
            }
           
            var user = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirsteName,
                LastName = request.LastName
            };
            var result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Adminstrator");
                return new RegisterationResponse()
                {
                    UserId = user.Id
                };
            }
            else
            {
                throw new Exception($"creation failed {result.Errors}");
            }
        }
        #endregion

        #region Login
        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null) {
                throw new Exception($"the user with {request.Email} not found.");
            }
            var result=await signInManager.PasswordSignInAsync(user.UserName, request.Password,false,false);
            if (!result.Succeeded) { 
                throw new Exception($"Credentials for the {user.UserName} is not valid.");
            }
            var jwttoken = await GenerateToken(user);
            var respons = new AuthResponse()
            {
                Email = user.Email,
                UserName = user.UserName,
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwttoken)
            };
            return respons;


        }
        #endregion

        #region Utilites
        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var Userclaims=await userManager.GetClaimsAsync(user);
           
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(CustomClaimTypes.Uid,user.Id),

            }.Union(Userclaims);

            var symmetricSecurityKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Key));
            var signinCredentials=new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256);
            var JwtSecurityToken = new JwtSecurityToken(
                issuer: options.Issuer,
                audience: options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(options.DurationInMinutes),
                signingCredentials: signinCredentials
                );
            return JwtSecurityToken;

        }
        #endregion
    }
}

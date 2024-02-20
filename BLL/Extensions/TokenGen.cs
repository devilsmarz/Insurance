using BeautyTrackSystem.BLL.Helpers;
using BeautyTrackSystem.BLL.Models;
using BeautyTrackSystem.DLL.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BeautyTrackSystem.BLL.Extensions
{
    public class TokenGen
    {
        internal static JwtModel GenerateToken(UserEntityModel user)
        {
            JwtModel jwtViewModel = new JwtModel();

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.RoleId.ToString())
            };

           SymmetricSecurityKey key =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWT_TOP_SECRET_KEYYES_JUST_FOR_EXAMPLE_PURPOSES_BUT_MAKE_IT_LONGER"));

            ClaimsIdentity subject = new ClaimsIdentity(claims);
            DateTime expires = DateTime.Now.AddDays(1);
            SigningCredentials credits = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = expires,
                SigningCredentials = credits
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            jwtViewModel.ExpireDate = expires;
            jwtViewModel.Jwt = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return jwtViewModel;
        }
    }
}

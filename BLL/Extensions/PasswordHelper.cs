using BeautyTrackSystem.BLL.Models;
using System.Security.Cryptography;
using System.Text;

namespace BeautyTrackSystem.BLL.Extensions
{
    public static class PasswordHelper
    {
        internal static PasswordModel CreatePasswordHash(String password)
        {
            using HMACSHA512 hmac = new HMACSHA512();
            PasswordModel passEntity = new PasswordModel
            {
                PasswordSalt = hmac.Key,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password))
            };

            return passEntity;
        }
        internal static Boolean VerifyPasswordHash(String password, Byte[] passwordHash, Byte[] passwordSalt)
        {
            using HMACSHA512 hmac = new HMACSHA512(passwordSalt);
            Byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return !computedHash.Where((t, i) => t != passwordHash[i]).Any();
        }
    }
}

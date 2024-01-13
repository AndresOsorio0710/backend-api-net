using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Backend.Utilities
{
    public class TokenManager
    {
        public static double ExpirationTime { get; set; }
        public static string SecretKey { get; set; }
        public static string MethodEncrypt { get; set; }

        public static string GenerateToken()
        {
            if (!String.IsNullOrEmpty(SecretKey) && !String.IsNullOrEmpty(MethodEncrypt) && ExpirationTime > 0 )
            {
                JwtSecurityToken token = new JwtSecurityToken(
                 expires: DateTime.Now.AddMinutes(ExpirationTime),
                 signingCredentials:
                     new SigningCredentials(
                     new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),
                     GetEncryptionMethod(MethodEncrypt))
                 );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return string.Empty;
        }

        public static string GetEncryptionMethod(string method)
        {
            switch (method)
            {
                case "HS512":
                    return SecurityAlgorithms.HmacSha512;
                case "RSASHA256":
                    return SecurityAlgorithms.RsaSha256;
                case "SHA512":
                    return SecurityAlgorithms.Sha512;
                default:
                    return null;
            }
        }
    }
}

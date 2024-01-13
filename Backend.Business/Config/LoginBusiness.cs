using Backend.Business.Interface.Config;
using Backend.Entities.Models;
using Backend.Entities.References;
using Backend.Utilities;

namespace Backend.Business.Config
{
    public class LoginBusiness : ILoginBusiness
    {
        private readonly ConfigurationManager configurationManager;

        public LoginBusiness()
        {
            this.configurationManager = new ConfigurationManager();
        }

        private Authorization GenerateToken()
        {
            TokenManager.MethodEncrypt = configurationManager.ConfigJwtValues.JwtMethodEncrypt;
            TokenManager.ExpirationTime = configurationManager.ConfigJwtValues.JwtExpirationTime;
            TokenManager.SecretKey = configurationManager.ConfigJwtValues.JwtKey;
            return new Authorization { 
                AccessToken= TokenManager.GenerateToken(),
            };
        }

        private Result<bool> ValidateCredentials(Authenticate authenticate)
        {
            if (authenticate.UserName.Equals(this.configurationManager.ConfigJwtValues.JwtDefaultUser))
            {
                if (authenticate.Password.Equals(this.configurationManager.ConfigJwtValues.JwtDefaultPassword))
                {
                    return ResponseManager.ResponseOk200<bool>(new List<bool>
                    {
                        true
                    },
                    this.GenerateToken());
                }
            }
            return ResponseManager.ResponseConflict409<bool>("Conflict: Incorrect credentials.");
        }

        public Result<bool> GetToken(Authenticate authenticate)
        {
            if (String.IsNullOrEmpty(authenticate.UserName))
            {
                return ResponseManager.ResponseConflict409<bool>("Conflict: Incomplete login information, user required.");
            }
            if (String.IsNullOrEmpty(authenticate.Password))
            {
                return ResponseManager.ResponseConflict409<bool>("Conflict: Incomplete login information, password required.");
            }
            if (String.IsNullOrEmpty(authenticate.DeviceId))
            {
                return ResponseManager.ResponseConflict409<bool>("Conflict: Incomplete login information, device ID required.");
            }
            return this.ValidateCredentials(authenticate);
        }
    }
}

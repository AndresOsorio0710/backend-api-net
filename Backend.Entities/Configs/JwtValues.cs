namespace Backend.Entities.Configs
{
    public class JwtValues
    {
        public string JwtKey { get; set; }
        public string JwtMethodEncrypt { get; set; }
        public int JwtExpirationTime { get; set; }
        public string JwtDefaultPassword { get; set; }
        public string JwtDefaultUser { get; set; }

        public JwtValues()
        {
            this.JwtKey = String.Empty;
            this.JwtMethodEncrypt = String.Empty;
            this.JwtExpirationTime = 0;
            this.JwtDefaultPassword = String.Empty;
            this.JwtDefaultUser = String.Empty;
        }

        public JwtValues(string jwtKey, string jwtMethodEncrypt, string jwtExpirationTime, string jwtDefaultPassword, string jwtDefaultUser)
        {
            this.JwtKey = jwtKey;
            this.JwtMethodEncrypt = jwtMethodEncrypt;
            this.JwtExpirationTime = int.Parse(jwtExpirationTime);
            this.JwtDefaultPassword = jwtDefaultPassword;
            this.JwtDefaultUser = jwtDefaultUser;
        }
    }
}

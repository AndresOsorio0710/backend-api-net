using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Resources;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Backend.Entities.Configs;

[assembly: CLSCompliant(true)]
[assembly: NeutralResourcesLanguage("es-CO")]
namespace Backend.Utilities
{
    public class ConfigurationManager
    {
        private readonly IConfiguration configuration;
        public static string ApplicationPath { get; set; }
        public JwtValues ConfigJwtValues { get; set; }
        public Entities.Configs.Cryptography ConfigCryptography { get; set; }
        public DBFirebaseValues DBFirebaseValues { get; set; }
        public ConfigurationManager()
        {
            GetrApplicationPath();
            this.configuration = new ConfigurationBuilder()
                .SetBasePath(ApplicationPath)
                .AddJsonFile("appsettings.json", false, false)
                .AddEnvironmentVariables()
                .Build();
            this.SetJwtValues();
            this.SetCryptography();
            this.SetFirebaseCredentialPath();
        }

        private void SetFirebaseCredentialPath()
        {
            int index = ApplicationPath.IndexOf("\\bin", StringComparison.OrdinalIgnoreCase);
            this.DBFirebaseValues = new DBFirebaseValues(
                ApplicationPath.Substring(0, index) + configuration["DBFirebaseValues:CredentialPath"],
                configuration["DBFirebaseValues:Variable"],
                configuration["DBFirebaseValues:ProjectId"]);
        }

        private void SetCryptography()
        {
            this.ConfigCryptography = new Entities.Configs.Cryptography(
                configuration["Cryptography:Key"],
                configuration["Cryptography:IV"],
                configuration["Cryptography:Iterations"]
                );
        }

        private void SetJwtValues()
        {
            this.ConfigJwtValues = new JwtValues(
                configuration["JwtValues:Key"],
                configuration["JwtValues:MethodEncrypt"],
                configuration["JwtValues:ExpirationTime"],
                configuration["JwtValues:DefaultPassword"],
                configuration["JwtValues:DefaultUser"]
                );
        }

        public static void GetrApplicationPath()
        {
            var builder = Host.CreateDefaultBuilder();
            var hostEnvironment = builder.Build().Services.GetRequiredService<IHostEnvironment>();
            ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }
}

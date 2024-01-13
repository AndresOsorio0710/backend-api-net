using Backend.Utilities.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Backend.API.Filters
{
    public class EjemploFilter:ActionFilterAttribute
    {
        private readonly ILogger<EjemploFilter> _logger;

        private readonly Utilities.ConfigurationManager configurationManager;

        private readonly IWebHostEnvironment env;

        public EjemploFilter(ILogger<EjemploFilter> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            this.configurationManager = new Utilities.ConfigurationManager();
            this.env = env;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                CryptographyManager.Key = this.configurationManager.ConfigCryptography.Key;
                CryptographyManager.IV = this.configurationManager.ConfigCryptography.IV;
                CryptographyManager.Iterations = this.configurationManager.ConfigCryptography.Iterations;

                string result = JsonConvert.SerializeObject(objectResult.Value);
                objectResult.Value = CryptographyManager.Encrypt(result);
            }
            base.OnActionExecuted(context);
        }
    }
}

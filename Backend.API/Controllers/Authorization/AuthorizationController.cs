using Backend.Business.Interface.Config;
using Backend.Entities.Models;
using Backend.Entities.References;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers.Authorization
{
    public class AuthorizationController : ApiController
    {
        private readonly ILoginBusiness loginBusiness;

        public AuthorizationController(ILoginBusiness loginBusiness)
        {
            this.loginBusiness = loginBusiness;
        }

        [Produces("application/json", Type = typeof(Result<bool>))]
        [HttpPost("Login")]
        public IActionResult Login(Authenticate authenticate)
        {
            var result = this.loginBusiness.GetToken(authenticate);
            return StatusCode((int)result.TransactionResult.ResponseCode, result);
        }

        [Produces("application/json", Type = typeof(string))]
        [HttpGet("ValidateToken")]
        [Authorize]
        public IActionResult ValidateToken()
        {
            return Ok("Token Válido");
        }
    }
}

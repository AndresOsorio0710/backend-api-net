using Backend.Business.Interface.Prueba;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers.Prueba
{
    public class PruebaController : ApiController
    {
        private readonly IPruebaBusiness pruebaBusiness;
        public PruebaController(IPruebaBusiness pruebaBusiness) { 
            this.pruebaBusiness = pruebaBusiness;
        }

        [Produces("application/json", Type = typeof(string))]
        [HttpPost("Get")]
        [Authorize]
        public IActionResult Get(Entities.Models.Prueba prueba)
        {
            var result = this.pruebaBusiness.Get(prueba);
            return StatusCode((int)result.TransactionResult.ResponseCode, result);
        }

        [Produces("application/json", Type = typeof(string))]
        [HttpPost("Add")]
        [Authorize]
        public IActionResult Add(Entities.Models.Prueba prueba)
        {
            var result = this.pruebaBusiness.Add(prueba);
            return StatusCode((int)result.TransactionResult.ResponseCode, result);
        }

        [Produces("application/json", Type = typeof(string))]
        [HttpPost("Update")]
        [Authorize]
        public IActionResult Update(Entities.Models.Prueba prueba)
        {
            var result = this.pruebaBusiness.Update(prueba);
            return StatusCode((int)result.TransactionResult.ResponseCode, result);
        }
    }
}

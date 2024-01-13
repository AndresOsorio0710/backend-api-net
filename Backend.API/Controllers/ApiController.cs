using Backend.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    //[ServiceFilter(typeof(EjemploFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
    }
}

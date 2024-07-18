using Microsoft.AspNetCore.Mvc;
using FizzBuzzApi.Model;
using FizzBuzzApi.Services;
namespace FizzBuzzApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzzService _fizzBuzzService;
        //Dependacy Injection By Construtor Injecction
        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        [HttpPost]
        public ActionResult<FizzBuzzResult> Post([FromBody] FizzBuzzValues request)
        {
            var response = _fizzBuzzService.ProcessValues(request.Values);
            return Ok(response);
        }
    }
}

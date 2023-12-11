using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevAgendaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConselhosController : ControllerBase
    {
        private readonly ILogger<ConselhosController> _logger;
        private readonly IConselhosAppService _conselhosAppService;

        public ConselhosController(ILogger<ConselhosController> logger, IConselhosAppService conselhosAppService)
        {
            _logger = logger;
            _conselhosAppService = conselhosAppService;
        }


        [HttpGet(Name = "GetConselhos")]
        public async Task<IActionResult> GetConselhos()
        {
            var result = await _conselhosAppService.GetConselhos();

            return Ok(result);
        }
    }
}

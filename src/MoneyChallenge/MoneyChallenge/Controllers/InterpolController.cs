using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyChallenge.Data;
using MoneyChallenge.Interfaces;
using MoneyChallenge.Services;

namespace MoneyChallenge.Controllers
{
    [Route("MoneyChallenge/Interpol")]
    [ApiController]
    public class InterpolController : Controller
    {
        private readonly FBIContext _dbContext;
        private readonly IInterpolService _interpolService;

        public InterpolController(FBIContext dbContext, IInterpolService interpolService)
        {
            _dbContext = dbContext;
            _interpolService = interpolService;
        }

        [HttpGet("PopulateDataBase")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPersonInterpol()
        {
            var wantedList = _interpolService.GetWantedPeopleList();

            if (wantedList == null)
            {
                return BadRequest("Não foi possivel obter lista de procurados do FBI");
            }

            _dbContext.AddRange(wantedList);
            await _dbContext.SaveChangesAsync();

            return Ok("Dados obtidos atraves da API do FBI e populado banco de dados com sucesso.");
        }
    }
}

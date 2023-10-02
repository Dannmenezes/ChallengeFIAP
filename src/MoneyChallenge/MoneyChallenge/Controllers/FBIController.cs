using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyChallenge.Data;
using MoneyChallenge.Interfaces;
using MoneyChallenge.Models;
using MoneyChallenge.Services;

namespace MoneyChallenge.Controllers
{
    [Route("MoneyChallenge/FBI")]
    [ApiController]
    public class FBIController : Controller
    {
        private readonly IFBIService _fbiService;
        private readonly FBIContext _dbContext;

        public FBIController(IFBIService fbiService, FBIContext dbContext)
        {
            _fbiService = fbiService;
            _dbContext = dbContext;
        }

        [HttpGet("PopulateDataBase")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPersonFbi()
        {
            var wantedList = _fbiService.GetWantedPeopleList();

            if (wantedList == null)
            {
                return BadRequest("Não foi possivel obter lista de procurados do FBI");
            }

            _dbContext.AddRange(wantedList);
            await _dbContext.SaveChangesAsync();

            return Ok("Dados obtidos atraves da API do FBI e populado banco de dados com sucesso.");
        }

        [HttpGet("ConsultaPorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<FBIPerson>>> GetPersonFbiById(int id)
        {
            var wanted = _fbiService.GetWantedPeopleById(id);

            if (wanted == null)
            {
                return BadRequest("Não foi possivel obter procurado na base de dados");
            }

            _dbContext.AddRange(wanted);
            await _dbContext.SaveChangesAsync();

            return Ok("Dados obtidos atraves da API do FBI e populado banco de dados com sucesso.");
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<FBIPerson>>> DeleteFbiData(int id)
        {
            var wantedList = _fbiService.GetWantedPeopleById(id);

            if (wantedList == null)
            {
                return BadRequest("Não foi possivel obter procurado na base do FBI");
            }

            _dbContext.AddRange(wantedList);
            await _dbContext.SaveChangesAsync();

            return Ok("Dados obtidos atraves da API do FBI e populado banco de dados com sucesso.");
        }
    }
}

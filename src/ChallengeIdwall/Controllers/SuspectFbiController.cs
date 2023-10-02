using ChallengeIdwall.Interfaces;
using ChallengeIdwall.Model;
using ChallengeIdwall.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static ChallengeIdwall.Context.ChallengeDbContext;

namespace ChallengeIdwall.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuspectFbiController : Controller
    {
        private readonly IWantedService _wantedService;
        private readonly DataBaseContext _dataBaseContext;

        public SuspectFbiController(DataBaseContext context, IWantedService wantedService)
        {
            _wantedService = wantedService;
            _dataBaseContext = context;
        }

        [HttpGet("populate-database")]
        public async Task<IActionResult> PopulateDatabase()
        {
            var wantedPersons = await _wantedService.GetWantedPersonAsync();

            if (wantedPersons == null)
            {
                return BadRequest("Falha ao buscar dados da API do FBI.");
            }

            _dataBaseContext.FBITable.AddRange(wantedPersons);
            await _dataBaseContext.SaveChangesAsync();

            return Ok("Dados populados no banco de dados com sucesso.");
        }

        [HttpGet("ConsultaPorId")]
        public async Task<IActionResult> ListAll(int id)
        {
            _dataBaseContext.FBITable.Find(id);

            return Ok("Procurado consultado com sucesso no banco de dados");
        }

        [HttpDelete("DeletarPorcurado")]
        public async Task<IActionResult> DeleteWanted(int id)
        {
            _dataBaseContext.FBITable.ExecuteDelete();

            return Ok("Procurado deletado com sucesso da base de dados");
        }
    }
}

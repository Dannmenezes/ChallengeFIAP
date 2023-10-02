using ChallengeIdwall.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static ChallengeIdwall.Context.ChallengeDbContext;

namespace ChallengeIdwall.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InterpolController : Controller
    {
        private readonly IWantedService _wantedService;
        private readonly DataBaseContext _dataBaseContext;

        public InterpolController(DataBaseContext context, IWantedService wantedService)
        {
            _wantedService = wantedService;
            _dataBaseContext = context;
        }

        [HttpGet("PopulateInterpolDataBase")]
        public async Task<IActionResult> PopulateInterpolDatabase()
        {
            var wantedPersons = await _wantedService.GetInterpolWanted();

            if (wantedPersons == null)
            {
                return BadRequest("Falha ao buscar dados da API da Interpol");
            }

            _dataBaseContext.Interpol.AddRange();
            await _dataBaseContext.SaveChangesAsync();

            return Ok("Dados populados no banco de dados com sucesso.");
        }

        [HttpGet("ConsultaPorId")]
        public async Task<IActionResult> ListAll(int id)
        {
            _dataBaseContext.Interpol.Find(id);

            return Ok("Procurado consultado com sucesso no banco de dados");
        }
    }
}

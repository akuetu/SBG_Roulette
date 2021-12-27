using Microsoft.AspNetCore.Mvc;
using Roulette.API.Model;
using Roulette.API.Services;
using Roulette.Core.Model;

namespace Roulette.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        //private readonly IRouletteService _rouletteService;
        private  RouletteService _rouletteService;

        public RouletteController()
        {
           
        }

        [HttpGet("ping")]
        public IActionResult GetPing()
        {
            return Ok("Pong");
        }

        [HttpPost("bet")]
        public IActionResult PostBet([FromBody] RouletteBetModel model)
        {
            _rouletteService = new RouletteService();
            //validate model
            //BetModel betModel, Account account

            var response =  _rouletteService.CalculateBet(model.TypeOfBet, model.Bets, model.Account);

          return Ok(response);
        }
    }
}

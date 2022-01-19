using System;
using Microsoft.AspNetCore.Mvc;
using Roulette.API.Model;
using Roulette.Service.Exceptions;
using Roulette.Service.Model;
using Roulette.Service.Services;

namespace Roulette.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteService _rouletteService;
        private readonly IAccountService _iAccountService;

        public RouletteController(IRouletteService rouletteService, IAccountService iAccountService)
        {
            _rouletteService = rouletteService;
            _iAccountService = iAccountService;
        }

        [HttpPost("addmoney")]
        public IActionResult PostMoney([FromBody] decimal value)
        {
           
            _iAccountService.AddMoney(value);

            return Ok(new {Balance = _iAccountService.Balance()});
        }

        [HttpPost("bet")]
        public IActionResult PostBet([FromBody] RouletteBetModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Please submit required fields.");

            BetResponse response;

            try
            {
                response = _rouletteService.CalculateBet(model.TypeOfBet, model.Bets, model.Account);

            }
            catch (ArgumentException e)
            {
                return BadRequest(new { Error = e.Message });

            }
            catch (RowInvalidException e)
            {
                return BadRequest(new { Error = e.Message });

            }
            catch (Exception)
            {
                return BadRequest(new { Error = "Internal error." });
            }

            return Ok(response);
        }
    }
}

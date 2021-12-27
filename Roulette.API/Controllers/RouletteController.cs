﻿using Microsoft.AspNetCore.Mvc;
using Roulette.API.Model;
using Roulette.API.Services;
using Roulette.Core.Model;

namespace Roulette.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteService _rouletteService;
        
        public RouletteController(IRouletteService rouletteService)
        {
            _rouletteService = rouletteService;
        }

        
        [HttpPost("bet")]
        public IActionResult PostBet([FromBody] RouletteBetModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Please submit required fields.");

            var response =  _rouletteService.CalculateBet(model.TypeOfBet, model.Bets, model.Account);

          return Ok(response);
        }
    }
}

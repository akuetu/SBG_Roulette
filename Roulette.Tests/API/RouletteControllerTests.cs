using System;
using Microsoft.AspNetCore.Mvc;
using Roulette.API.Controllers;
using Roulette.API.Model;
using Roulette.Domain.Entities;
using Roulette.Service.Services;
using Roulette.Service.Shared;
using Xunit;

namespace Roulette.Tests.API
{
    public class RouletteControllerTests
    {
        private readonly RouletteController _rouletteController;
        public RouletteControllerTests()
        {
            _rouletteController = new RouletteController(new RouletteService(), new AccountService());
        }

        [Fact]
        public void PostBet_Should_ReturnsOkResultWhenValidObjectPassed()
        {
            var model = new RouletteBetModel
            {
                TypeOfBet = TypeOfBet.Zero,
                Bets = {},
                Account = new Account()
                {
                    UserAccount = new UserAccount(){Id = 1, Name = "Jane Doe"},
                    Game = new Game(){ Id = 1, Session = Guid.Parse("ea5b1378-3a8b-44b9-8de4-4f73f92a63f0") }
                }
            };

            var response = _rouletteController.PostBet(model);

            Assert.IsType<OkObjectResult>(response);

        }
        
        [Fact]
        public void PostBet_Should_ReturnsBadRequestWhenInvalidObjectPassed()
        {
            var model = new RouletteBetModel() { };

            var response = _rouletteController.PostBet(model);

            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public void PostBet_Should_ReturnsInvalidTypeOfBetOptionWhenTypeBetIsWrong()
        {
            var model = new RouletteBetModel
            {
                TypeOfBet = (TypeOfBet)100,
                Bets = { },
                Account = new Account() { }
            };
       
            var badRequestResponse = _rouletteController.PostBet(model) as BadRequestObjectResult;

            var expectedResponse = new BadRequestObjectResult(new {Error = "Invalid Type of Option."});

            Assert.IsType<BadRequestObjectResult>(badRequestResponse);
            Assert.Equal(expectedResponse.Value.ToString(), badRequestResponse.Value.ToString());
        }

    }
}

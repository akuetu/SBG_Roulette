using System;
using System.Linq;
using Moq;
using Roulette.Service;
using Roulette.Service.Base;
using Roulette.Service.Interface;
using Roulette.Service.Model;
using Roulette.Service.Services;
using Roulette.Service.Shared;
using Xunit;

namespace Roulette.Tests.Service
{
    public class RouletteBetTests
    {
        private readonly Board _board;
        private const int Rows = 12;
        private const int Cols = 3;

        private readonly Mock<IRouletteWheel> _mock = new Mock<IRouletteWheel>();

        public RouletteBetTests()
        {
            _board = new Board(Rows, Cols);
        }


        [Fact]
        public void CalculateBet_Should_ReturnExceptionWhenTypeOfBetIsWrong()
        {
            var bet = new int[] { 0 };

            _mock.Setup(x => x.Spin()).Returns(0);

            var wheelNumber = _mock.Object.Spin();

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Zero + 100,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var rouletteBet = new RouletteBet();

            var exception = Assert.Throws<ArgumentException>(() => rouletteBet.CalculateBet(betModel, new Account()));

            Assert.Equal("Invalid Type of Option.", exception.Message);

        }
    }
}
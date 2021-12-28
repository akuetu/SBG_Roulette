using System;
using System.Linq;
using Moq;
using Roulette.Core;
using Roulette.Core.Base;
using Roulette.Core.Interface;
using Roulette.Core.Model;
using Xunit;

namespace Roulette.Tests
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
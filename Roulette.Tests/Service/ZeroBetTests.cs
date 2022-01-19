using System;
using System.Linq;
using Moq;
using Roulette.Service;
using Roulette.Service.Base;
using Roulette.Service.Interface;
using Roulette.Service.Model;
using Roulette.Service.Shared;
using Roulette.Service.Validations;
using Xunit;

namespace Roulette.Tests.Service
{
    public class ZeroBetTests
    {
        private readonly RouletteBet _rouletteBet;
        private readonly Board _board;
        private const int Rows = 12;
        private const int Cols = 3;

        private readonly Mock<IRouletteWheel> _mock = new Mock<IRouletteWheel>();

        public ZeroBetTests()
        {
            _rouletteBet = new RouletteBet();
            _board = new Board(Rows, Cols);
        }

        [Fact]
        public void CalculateBet_Should_ReturnTrueWhenBetIsCorrect()
        {
            var bet = new int[] { 0 };

            _mock.Setup(x => x.Spin()).Returns(0);

            var wheelNumber = _mock.Object.Spin();

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Zero,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.True(result.Status);

            _mock.Verify(x => x.Spin(), Times.Once());
        }


        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        [InlineData(3, false)]
        public void CalculateBet_Should_ReturnInlineResult(int wheelNumber, bool expected)
        {
            var bet = new int[] { 0 };

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Zero,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.Equal(expected, result.Status);
        }

        [Fact]
        public void ValidateZeroBetInput_value_Should_ReturnExceptionWhenPassWrongArgument()
        {
            var bet = new int[] { 1 };

            var exception = Assert.Throws<ArgumentException>(() => ZeroBetValidation.ValidateZeroBetInput(bet));

            Assert.Equal("Invalid Argument.", exception.Message);
        }

        [Fact]
        public void ValidateZeroBetInput_Length_Should_ReturnExceptionWhenLengthIsWrong()
        {
            var bet = new int[] { 0, 1 };

            var exception = Assert.Throws<ArgumentException>(() => ZeroBetValidation.ValidateZeroBetInput(bet));

            Assert.Equal("Invalid Argument.", exception.Message);

        }

    }
}

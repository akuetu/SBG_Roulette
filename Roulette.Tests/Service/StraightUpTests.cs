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
    public class StraightUpTests
    {
        private readonly RouletteBet _rouletteBet;
        private readonly Board _board;
        private const int Rows = 12;
        private const int Cols = 3;

        private readonly Mock<IRouletteWheel> _mock = new Mock<IRouletteWheel>();

        public StraightUpTests()
        {
            _rouletteBet = new RouletteBet();
            _board = new Board(Rows, Cols);
        }

        [Fact]
        public void CalculateBet_Should_ReturnTrueWhenBetCorrect()
        {
            var bet = new int[] { 2 };

            _mock.Setup(x => x.Spin()).Returns(2);

            var wheelNumber = _mock.Object.Spin();

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.StraightUp,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.True(result.Status);

            _mock.Verify(x => x.Spin(), Times.Once());
        }



        [Theory]
        [InlineData(2, new int[] { 2 }, true)]
        [InlineData(4, new int[] { 4 }, true)]
        [InlineData(6, new int[] { 6 }, true)]
        [InlineData(20, new int[]{20} , true)]
        [InlineData(21, new int[] { 21 }, true)]
        [InlineData(22, new int[] { 22 }, true)]
        [InlineData(23, new int[] { 23 }, true)]
        [InlineData(30, new int[] { 30 }, true)]
        [InlineData(34, new int[] { 34 }, true)]
        [InlineData(32, new int[] { 32 }, true)]
        [InlineData(0, new int[] { 0 }, true)]
        [InlineData(1, new int[] { 3 }, false)]
        [InlineData(3, new int[] { 1 }, false)]
        [InlineData(5, new int[] { 4 }, false)]
        [InlineData(23, new int[] { 1 }, false)]
        [InlineData(25, new int[] { 2 }, false)]
        [InlineData(27, new int[] { 7 }, false)]
        [InlineData(31, new int[] { 30 }, false)]
        [InlineData(35, new int[] { 22 }, false)]

        public void CalculateBet_Should_ReturnInlineResult(int wheelNumber, int[] bet, bool expected)
        {
            _mock.Setup(x => x.Spin()).Returns(wheelNumber);

            var localWheelNumber = _mock.Object.Spin();

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.StraightUp,
                Bets = bet.ToArray(),
                WheelNumber = localWheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.Equal(expected,result.Status);
        }

    }
}

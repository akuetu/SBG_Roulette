using System.Linq;
using Moq;
using Roulette.Core;
using Roulette.Core.Base;
using Roulette.Core.Interface;
using Roulette.Core.Model;
using Xunit;

namespace Roulette.Tests
{
    public class OddBetTests
    {
        private readonly RouletteBet _rouletteBet;
        private readonly Board _board;
        private const int Rows = 12;
        private const int Cols = 3;

        private readonly Mock<IRouletteWheel> _mock = new Mock<IRouletteWheel>();

        public OddBetTests()
        {
            _rouletteBet = new RouletteBet();
            _board = new Board(Rows, Cols);
        }

        [Fact]
        public void CalculateBet_Should_ReturnTrueWhenBetAndSpinAreEven()
        {
            var bet = new int[] { 5 };

            _mock.Setup(x => x.Spin()).Returns(5);

            var wheelNumber = _mock.Object.Spin();

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Odd,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account(500));

            Assert.True(result.Status);

            _mock.Verify(x => x.Spin(), Times.Once());
        }



        [Theory]

        [InlineData(1, true)]
        [InlineData(3, true)]
        [InlineData(5, true)]
        [InlineData(7, true)]
        [InlineData(9, true)]
        [InlineData(11, true)]
        [InlineData(13, true)]
        [InlineData(15, true)]
        [InlineData(17, true)]
        [InlineData(19, true)]
        [InlineData(21, true)]
        [InlineData(23, true)]
        [InlineData(25, true)]
        [InlineData(27, true)]
        [InlineData(31, true)]
        [InlineData(35, true)]
        [InlineData(2, false)]
        [InlineData(4, false)]
        [InlineData(6, false)]
        [InlineData(8, false)]
        [InlineData(10, false)]
        [InlineData(16, false)]
        [InlineData(20, false)]
        [InlineData(24, false)]
        [InlineData(26, false)]
        [InlineData(28, false)]
        [InlineData(30, false)]
        [InlineData(34, false)]
        [InlineData(32, false)]
        [InlineData(36, false)]
        public void CalculateBet_Should_ReturnInlineResult(int wheelNumber, bool expected)
        {
            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Odd,
                Bets = null,
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account(500));

            Assert.Equal(expected, result.Status);
        }

    }
}

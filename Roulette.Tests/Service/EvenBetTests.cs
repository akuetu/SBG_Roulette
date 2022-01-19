using System.Linq;
using Moq;
using Roulette.Service;
using Roulette.Service.Base;
using Roulette.Service.Interface;
using Roulette.Service.Model;
using Roulette.Service.Shared;
using Xunit;

namespace Roulette.Tests.Service
{
    public class EvenBetTests
    {
        private readonly RouletteBet _rouletteBet;
        private readonly Board _board;
        private const int Rows = 12;
        private const int Cols = 3;

        private readonly Mock<IRouletteWheel> _mock = new Mock<IRouletteWheel>();

        public EvenBetTests()
        {
            _rouletteBet = new RouletteBet();
            _board = new Board(Rows, Cols);
        }

        [Fact]
        public void CalculateBet_Should_ReturnTrueWhenBetAndSpinAreEven()
        {
            var bet = new int[] { 2 };

            _mock.Setup(x => x.Spin()).Returns(2);

            var wheelNumber = _mock.Object.Spin();

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Even,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.True(result.Status);

            _mock.Verify(x => x.Spin(), Times.Once());
        }



        [Theory]
        [InlineData(2, true)]
        [InlineData(4, true)]
        [InlineData(6, true)]
        [InlineData(8, true)]
        [InlineData(10, true)]
        [InlineData(16, true)]
        [InlineData(20, true)]
        [InlineData(24, true)]
        [InlineData(26, true)]
        [InlineData(28, true)]
        [InlineData(30, true)]
        [InlineData(34, true)]
        [InlineData(32, true)]
        [InlineData(36, true)]
        [InlineData(1, false)]
        [InlineData(3, false)]
        [InlineData(5, false)]
        [InlineData(7, false)]
        [InlineData(9, false)]
        [InlineData(11, false)]
        [InlineData(13, false)]
        [InlineData(15, false)]
        [InlineData(17, false)]
        [InlineData(19, false)]
        [InlineData(21, false)]
        [InlineData(23, false)]
        [InlineData(25, false)]
        [InlineData(27, false)]
        [InlineData(31, false)]
        [InlineData(35, false)]

        public void CalculateBet_Should_ReturnInlineResult(int wheelNumber, bool expected)
        {

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Even,
                Bets = null,
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.Equal(expected, result.Status);
        }

    }
}

 

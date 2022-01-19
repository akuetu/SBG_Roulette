using Moq;
using Roulette.Core;
using Roulette.Service;
using Roulette.Service.Base;
using Roulette.Service.Interface;
using Roulette.Service.Model;
using Roulette.Service.Shared;
using Xunit;

namespace Roulette.Tests.Service
{
    public class BlackBetTests
    {
        private readonly RouletteBet _rouletteBet;
        private readonly Board _board;
        private const int Rows = 12;
        private const int Cols = 3;

        private readonly Mock<IRouletteWheel> _mock = new Mock<IRouletteWheel>();

        
        public BlackBetTests()
        {
            _rouletteBet = new RouletteBet();
            _board = new Board(Rows, Cols);
        }


        [Theory]
        [InlineData(15, true)]
        [InlineData(4, true)]
        [InlineData(2, true)]
        [InlineData(17, true)]
        [InlineData(6, true)]
        [InlineData(13, true)]
        [InlineData(11, true)]
        [InlineData(10, true)]
        [InlineData(8, true)]
        [InlineData(24, true)]
        [InlineData(33, true)]
        [InlineData(20, true)]
        [InlineData(31, true)]
        [InlineData(22, true)]
        [InlineData(29, true)]
        [InlineData(28, true)]
        [InlineData(35, true)]
        [InlineData(26, true)]
        public void CalculateBet_Should_ReturnTrueWhenSpinTheRightNumber(int bet, bool expected)
        {
            _mock.Setup(x => x.Spin()).Returns(29);

            var wheelNumber = _mock.Object.Spin();

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Black,
                Bets = new int[] { bet },
                WheelNumber = wheelNumber,
                Board = _board
            };
            
            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.Equal(expected, result.Status);
        }




        [Theory]
        [InlineData(15, false)]
        [InlineData(4, false)]
        [InlineData(2, false)]
        [InlineData(17, false)]
        [InlineData(6, false)]
        [InlineData(13, false)]
        [InlineData(11, false)]
        [InlineData(10, false)]
        [InlineData(8, false)]
        [InlineData(24, false)]
        [InlineData(33, false)]
        [InlineData(20, false)]
        [InlineData(31, false)]
        [InlineData(22, false)]
        [InlineData(29, false)]
        [InlineData(28, false)]
        [InlineData(35, false)]
        [InlineData(26, false)]
        public void CalculateBet_Should_ReturnFalseWhenSpinTheWrongNumber(int bet, bool expected)
        {

            _mock.Setup(x => x.Spin()).Returns(9);

            var wheelNumber = _mock.Object.Spin();

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Black,
                Bets = new int[] { bet },
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.Equal(expected, result.Status);
        }


        [Theory]
        [InlineData(16, false)]
        [InlineData(5, false)]
        [InlineData(3, false)]
        [InlineData(34, false)]
        [InlineData(21, false)]
        [InlineData(32, false)]
        [InlineData(36, false)]
        [InlineData(27, false)]
        public void CalculateBet_Should_ReturnFalseWhenPieceNotBlack(int bet, bool expected)
        {

            _mock.Setup(x => x.Spin()).Returns(27);

            var wheelNumber = _mock.Object.Spin();

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Black,
                Bets = new int[] { bet },
                WheelNumber = wheelNumber,
                Board = _board
            };
            
            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.Equal(expected, result.Status);
        }
    }
}

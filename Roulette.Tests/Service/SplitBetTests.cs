using System.Collections.Generic;
using Moq;
using Roulette.Core;
using Roulette.Core.Base;
using Roulette.Core.Interface;
using Roulette.Service;
using Roulette.Service.Model;
using Xunit;

namespace Roulette.Tests
{
    public class SplitBetTests 
    {
        private readonly RouletteBet _rouletteBet;
        private readonly Board _board;
        private const int Rows = 12;
        private const int Cols = 3;

        private readonly Mock<IRouletteWheel> _mock = new Mock<IRouletteWheel>();

        public SplitBetTests()
        {
            _rouletteBet = new RouletteBet();
            _board = new Board(Rows, Cols);
        }

        [Fact]
        public void CalculateBet_Should_ReturnTrueWhenBetIsCorrect()
        {
            var bet = new List<int> { 1, 2 };

            _mock.Setup(x => x.Spin()).Returns(2);

            var wheelNumber = _mock.Object.Spin();

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Split,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.True(result.Status);

            _mock.Verify(x => x.Spin(), Times.Once());
        }


        [Fact]
        public void CalculateBet_Should_ReturnFalseWheBetIsWrong()
        {
            var bet = new List<int> {2, 3 };

            _mock.Setup(x => x.Spin()).Returns(0);

            var wheelNumber = _mock.Object.Spin();

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Split,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.False(result.Status);

            _mock.Verify(x => x.Spin(), Times.Once());
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void CalculateBet_With_Data_Should_ReturnTrueWhenBetIsCorrect(List<int> bet, int wheelNumber)
        {

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Split,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.True(result.Status);
        }

        [Theory]
        [MemberData(nameof(DataWithInvalidCornerValues))]
        public void CalculateBet_With_Data_Should_ReturnFalseWhenBetIsWrong(List<int> bet, int wheelNumber)
        {

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Split,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.False(result.Status);
        }

        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { new List<int> { 10, 11 }, 10 };
            yield return new object[] { new List<int> { 1, 4 }, 4 };
            yield return new object[] { new List<int> { 2, 5 }, 5 };
            yield return new object[] { new List<int> {28, 29 }, 28 };
            yield return new object[] { new List<int> { 33, 36 }, 36 };
        }

        public static IEnumerable<object[]> DataWithInvalidCornerValues()
        {
            yield return new object[] { new List<int> { 10, 11 }, 1 };
            yield return new object[] { new List<int> { 1, 4 }, 34 };
            yield return new object[] { new List<int> { 2, 5 }, 25 };
            yield return new object[] { new List<int> { 28, 29 }, 8 };
            yield return new object[] { new List<int> { 33, 36 }, 6 };
        }
    }
}

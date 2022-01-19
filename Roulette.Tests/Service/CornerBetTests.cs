using System.Collections.Generic;
using Moq;
using Roulette.Core;
using Roulette.Core.Base;
using Roulette.Core.Interface;
using Roulette.Core.Model;
using Roulette.Service;
using Xunit;

namespace Roulette.Tests
{
    public class CornerBetTests
    {
        private readonly RouletteBet _rouletteBet;
        private readonly Board _board;
        private const int Rows = 12;
        private const int Cols = 3;

        private readonly Mock<IRouletteWheel> _mock = new Mock<IRouletteWheel>();

        
        public CornerBetTests()
        {
            _rouletteBet = new RouletteBet();
            _board = new Board(Rows, Cols);
        }

        [Fact]
        public void CalculateBet_Should_ReturnTrueWhenBetIsCorrect()
        {
            var bet = new List<int> { 1, 2, 4, 5 };

            _mock.Setup(x => x.Spin()).Returns(4);

            var wheelNumber = _mock.Object.Spin();

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Corner,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };
   
            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.True(result.Status);

            _mock.Verify(x => x.Spin(), Times.Once());
        }


        [Fact]
        public void CalculateBet_Should_ReturnFalseWhenBetIsWrong()
        {
            var bet = new List<int> { 1, 2, 4, 5 };

            _mock.Setup(x => x.Spin()).Returns(0);

            var wheelNumber = _mock.Object.Spin();

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Corner,
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
                TypeOfBet = TypeOfBet.Corner,
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
                TypeOfBet = TypeOfBet.Corner,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.False(result.Status);
        }

        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { new List<int> { 1, 2, 4, 5 }, 4 };
            yield return new object[] { new List<int> { 2, 3, 5, 6 }, 6 };
            yield return new object[] { new List<int> { 10, 11, 13, 14 }, 11 };
            yield return new object[] { new List<int> { 17, 18, 20, 21 }, 17 };
            yield return new object[] { new List<int> { 32, 33, 35, 36 }, 36 };
        }

        public static IEnumerable<object[]> DataWithInvalidCornerValues()
        {
            yield return new object[] { new List<int> { 1, 2, 3, 5 }, 4 };
            yield return new object[] { new List<int> { 2, 1, 5, 6 }, 6 };
            yield return new object[] { new List<int> { 10, 11, 11, 14 }, 11 };
            yield return new object[] { new List<int> { 7, 18, 20, 21 }, 17 };
            yield return new object[] { new List<int> { 0, 33, 35, 36 }, 36 };
        }
    }
}


using System.Collections.Generic;
using Moq;
using Roulette.Core;
using Roulette.Core.Base;
using Roulette.Core.Interface;
using Roulette.Service;
using Roulette.Service.Base;
using Roulette.Service.Model;
using Roulette.Service.Shared;
using Xunit;

namespace Roulette.Tests
{
    public class StreetBetTests
    {
        private readonly RouletteBet _rouletteBet;
        private readonly Board _board;
        private const int Rows = 12;
        private const int Cols = 3;

        private readonly Mock<IRouletteWheel> _mock = new Mock<IRouletteWheel>();

        public StreetBetTests()
        {
            _rouletteBet = new RouletteBet();
            _board = new Board(Rows, Cols);
        }

        [Fact]
        public void CalculateBet_Should_ReturnTrueWhenSpinTheRightNumber()
        {
            var bet = new List<int> { 22, 23, 24 };

            _mock.Setup(x => x.Spin()).Returns(24);

            var wheelNumber = _mock.Object.Spin();

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Street,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.True(result.Status);

            _mock.Verify(x => x.Spin(), Times.Once());
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void CalculateBet_With_Data_Should_ReturnTrueWhenSpinTheRightNumber(List<int> bet, int wheelNumber)
        {
            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Street,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.True(result.Status);
        }

        [Theory]
        [MemberData(nameof(DataWithInvalidCornerValues))]
        public void CalculateBet_With_Data_Should_ReturnFalseWhenSpinWrongNumber(List<int> bet, int wheelNumber)
        {
            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.Street,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.False(result.Status);
        }

        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { new List<int> { 1, 2, 3 }, 1 };
            yield return new object[] { new List<int> { 7, 8, 9 }, 8 };
            yield return new object[] { new List<int> { 16, 17, 18 }, 18 };
            yield return new object[] { new List<int> { 25, 26, 27 }, 27 };
            yield return new object[] { new List<int> { 34, 35, 36 }, 36 };
        }

        public static IEnumerable<object[]> DataWithInvalidCornerValues()
        {
            yield return new object[] { new List<int> { 1, 2, 3 }, 5 };
            yield return new object[] { new List<int> { 7, 8, 9 }, 10 };
            yield return new object[] { new List<int> { 16, 17, 18 }, 28 };
            yield return new object[] { new List<int> { 25, 26, 27 }, 17 };
            yield return new object[] { new List<int> { 34, 35, 36 }, 30 };
        }
    }
}

using System.Collections.Generic;
using Moq;
using Roulette.Core;
using Roulette.Core.Base;
using Roulette.Core.Exceptions;
using Roulette.Core.Interface;
using Roulette.Core.Model;
using Xunit;

namespace Roulette.Tests
{
    public class DoubleStreetBetTests
    {
        private readonly RouletteBet _rouletteBet;
        private readonly Board _board;
        private const int Rows = 12;
        private const int Cols = 3;

        private readonly Mock<IRouletteWheel> _mock = new Mock<IRouletteWheel>();
        private readonly Mock<IBet> _iBetMock = new Mock<IBet>();

        public DoubleStreetBetTests()
        {
            _rouletteBet = new RouletteBet();
            _board = new Board(Rows, Cols);
        }

        [Fact]
        public void CalculateBet_Should_ReturnTrueWhenSpinTheRightNumber()
        {
            var bet = new List<int> { 4, 5, 6, 7, 8, 9 };

            _mock.Setup(x => x.Spin()).Returns(6);

            var wheelNumber = _mock.Object.Spin();

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.DoubleStreet,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account(500));

            Assert.True(result.Status);

            _mock.Verify(x => x.Spin(), Times.Once());
        }

        [Fact]
        public void CalculateBet_Should_ReturnFalseWhenSpinNumberIsWrong()
        {
            var bet = new List<int> { 4, 5, 6, 7, 8, 9 };

            _mock.Setup(x => x.Spin()).Returns(1);

            var wheelNumber = _mock.Object.Spin();

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.DoubleStreet,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account(500));

            Assert.False(result.Status);
        }

        [Fact]
        public void CalculateBet_Should_ReturnFalseWhenBetIsWrong()
        {
            var bet = new List<int> { 9, 8, 7, 6, 5, 14 };

            _mock.Setup(x => x.Spin()).Returns(6);

            var wheelNumber = _mock.Object.Spin();

            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.DoubleStreet,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var exception = Assert.Throws<RowInvalidException>(() => _rouletteBet.CalculateBet(betModel, new Account(500)));

            Assert.Equal("Invalid row values.", exception.Message);

        }


        [Theory]
        [MemberData(nameof(Data))]
        public void CalculateBet_With_Data_Should_ReturnTrueWhenSpinTheRightNumber(List<int> bet, int wheelNumber)
        {
            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.DoubleStreet,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account(500));

            Assert.True(result.Status);
        }

        [Theory]
        [MemberData(nameof(DataWithInvalidCornerValues))]
        public void CalculateBet_With_Data_Should_ReturnFalseWhenSpinWrongNumber(List<int> bet, int wheelNumber)
        {
            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.DoubleStreet,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account(500));

            Assert.False(result.Status);
        }

        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { new List<int> { 4, 5, 6, 7, 8, 9 }, 4 };
            yield return new object[] { new List<int> { 7, 8, 9, 10, 11, 12 }, 8 };
            yield return new object[] { new List<int> { 16, 17, 18, 19, 20, 21 }, 18 };
            yield return new object[] { new List<int> { 25, 26, 27, 28, 29, 30 }, 27 };
            yield return new object[] { new List<int> { 31, 32, 33, 34, 35, 36 }, 36 };
        }

        public static IEnumerable<object[]> DataWithInvalidCornerValues()
        {
            yield return new object[] { new List<int> { 4, 5, 6, 7, 8, 9 }, 1 };
            yield return new object[] { new List<int> { 7, 8, 9, 10, 11, 12 }, 2 };
            yield return new object[] { new List<int> { 16, 17, 18, 19, 20, 21 }, 3 };
            yield return new object[] { new List<int> { 25, 26, 27, 28, 29, 30 }, 4 };
            yield return new object[] { new List<int> { 31, 32, 33, 34, 35, 36 }, 5 };
        }
    }
}

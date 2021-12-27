﻿using System;
using System.Collections.Generic;
using Moq;
using Roulette.Core;
using Roulette.Core.Base;
using Roulette.Core.Interface;
using Roulette.Core.Model;
using Xunit;

namespace Roulette.Tests
{
    public class ThirdColumnBetTests
    {
        private readonly RouletteBet _rouletteBet;
        private readonly Board _board;
        private const int Rows = 12;
        private const int Cols = 3;

        private readonly Mock<IBet> _iBetMock = new Mock<IBet>();

        public ThirdColumnBetTests()
        {
            _rouletteBet = new RouletteBet();
            _board = new Board(Rows, Cols);
        }


        [Theory]
        [MemberData(nameof(Data))]
        public void CalculateBet_With_Data_Should_ReturnTrueWhenBetAndSpinAreCorrect(List<int> bet, int wheelNumber)
        {
            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.ThirdColumn,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account(500));

            Assert.True(result.Status);
        }


        [Theory]
        [MemberData(nameof(DataWithInvalidValues))]
        public void CalculateBet_With_Data_Should_ReturnFalseWhenBetAndSpinAreWrong(List<int> bet, int wheelNumber)
        {
            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.ThirdColumn,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var exception = Assert.Throws<ArgumentException>(() => _rouletteBet.CalculateBet(betModel, new Account(500)));

            Assert.Equal("Invalid Argument.", exception.Message);
        }

        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { new List<int> { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 }, 24 };
        }

        public static IEnumerable<object[]> DataWithInvalidValues()
        {
            yield return new object[] { new List<int> { 1, 3, 7, 10, 13, 16, 19, 20, 25, 28, 31, 34 }, 10 };
        }


    }
}
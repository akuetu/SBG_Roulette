﻿using System;
using System.Collections.Generic;
using Roulette.Service;
using Roulette.Service.Base;
using Roulette.Service.Model;
using Roulette.Service.Services;
using Roulette.Service.Shared;
using Xunit;

namespace Roulette.Tests.Service
{
    public class ThirdDozenBetTests
    {
        private readonly RouletteBet _rouletteBet;
        private readonly Board _board;
        private const int Rows = 12;
        private const int Cols = 3;

        public ThirdDozenBetTests()
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
                TypeOfBet = TypeOfBet.ThirdDozen,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var result = _rouletteBet.CalculateBet(betModel, new Account());

            Assert.True(result.Status);
        }


        [Theory]
        [MemberData(nameof(DataWithInvalidValues))]
        public void CalculateBet_With_Data_Should_ReturnExceptionWhenBetAndSpinAreIncorrect(List<int> bet, int wheelNumber)
        {
            var betModel = new BetModel()
            {
                TypeOfBet = TypeOfBet.ThirdDozen,
                Bets = bet.ToArray(),
                WheelNumber = wheelNumber,
                Board = _board
            };

            var exception = Assert.Throws<ArgumentException>(() => _rouletteBet.CalculateBet(betModel, new Account()));

            Assert.Equal("Invalid Argument.", exception.Message);
        }

        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { new List<int> { 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 }, 30 };
        }

        public static IEnumerable<object[]> DataWithInvalidValues()
        {
            yield return new object[] { new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 10 };
        }

    }
}



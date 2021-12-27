﻿using Roulette.Core.Base;
using Roulette.Core.Model;

namespace Roulette.Core
{
    public class RouletteBet
    {

        public BetResponse CalculateBet(BetModel betModel, Account account)
        {
            var isItWinningBet = CalculateBet(betModel);
            var balance = account.Balance();
            return new BetResponse
            {
                BetResult = isItWinningBet ? TypeBetResult.Win : TypeBetResult.Loose,
                Status = isItWinningBet,
                Balance = balance,
                Message = string.Empty,
                WheelNumber = betModel.WheelNumber,
                TypeOfBet = betModel.TypeOfBet
            };
        }

        private static bool CalculateBet(BetModel betModel)
        {
            var dictionary = BetDictionary.CreateDictionary(betModel);
            var isItWinningBet = dictionary.ContainsKey(betModel.TypeOfBet) && dictionary[betModel.TypeOfBet].CalculateBet();
            return isItWinningBet;
        }

    }
}
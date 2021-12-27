using System;
using Roulette.Core.Base;
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
                Message = isItWinningBet ? "YOU WIN" : "YOU LOOSE",
                WheelNumber = betModel.WheelNumber,
                TypeOfBet = betModel.TypeOfBet
            };
        }

        private static bool CalculateBet(BetModel betModel)
        {
            var dictionary = BetDictionary.CreateDictionary(betModel);

            if (!dictionary.ContainsKey(betModel.TypeOfBet)) throw new ArgumentException("Invalid Type of Option.");

            var isItWinningBet = dictionary[betModel.TypeOfBet].CalculateBet();

            return isItWinningBet;
        }

    }
}

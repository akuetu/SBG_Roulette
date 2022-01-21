using System;
using Roulette.Service.Model;
using Roulette.Service.Shared;

namespace Roulette.Service.Services
{
    public class RouletteBet
    {

        public BetResponse CalculateBet(BetModel betModel, Account account)
        {
            var isItWinningBet = CalculateBet(betModel);

            FinancialManagement(account, isItWinningBet);

            var balance = account.Balance();

            return new BetResponse
            {
                BetResult = isItWinningBet ? TypeBetResult.Win : TypeBetResult.Loose,
                Status = isItWinningBet,
                Balance = balance,
                Message = isItWinningBet ? "YOU WIN" : "YOU LOOSE",
                WheelNumber = betModel.WheelNumber,
                TypeOfBet = betModel.TypeOfBet,
                UserAccount = account.UserAccount,
                Game = account.Game
            };
        }

        private static bool CalculateBet(BetModel betModel)
        {
            var dictionary = BetDictionary.CreateDictionary(betModel);

            if (!dictionary.ContainsKey(betModel.TypeOfBet)) throw new ArgumentException("Invalid Type of Option.");

            var isItWinningBet = dictionary[betModel.TypeOfBet].CalculateBet();

            return isItWinningBet;
        }

        private static void FinancialManagement(Account account, bool isItWinningBet)
        {
            if (isItWinningBet)
            {
                account.AddMoney(10);
            }
            else
            {
                account.RemoveMoney(10);
            }
        }

    }
}

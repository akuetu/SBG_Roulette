using System;
using Roulette.Service.Interface;
using Roulette.Service.Model;
using Roulette.Service.Shared;
using Roulette.Service.Validations;

namespace Roulette.Service.Rules
{
    public class SecondColumnBet : IBet
    {
        private readonly BetModel _betModel;

        public SecondColumnBet(BetModel betModel)
        {
            _betModel = betModel;
        }
        public bool CalculateBet()
        {
            if (!FirstSecondAndThirdColumnBetValidation.ValidateBet(_betModel.Bets, Common.SecondColumnList()))
            {
                throw new ArgumentException("Invalid Argument.");
            }
            return Common.SecondColumnList().Contains(_betModel.WheelNumber);
        }
    }
}

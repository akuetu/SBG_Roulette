using System;
using Roulette.Service.Interface;
using Roulette.Service.Model;
using Roulette.Service.Shared;
using Roulette.Service.Validations;

namespace Roulette.Service.Rules
{
    public class FirstColumnBet : IBet
    {
        private readonly BetModel _betModel;

        public FirstColumnBet(BetModel betModel)
        {
            _betModel = betModel;
        }
        public bool CalculateBet()
        {
            if (!FirstSecondAndThirdColumnBetValidation.ValidateBet(_betModel.Bets, Common.FirstColumnList()))
            {
                throw new ArgumentException("Invalid Argument.");
            }

            return Common.FirstColumnList().Contains(_betModel.WheelNumber);
        }
    }
}

using System;
using Roulette.Service.Interface;
using Roulette.Service.Model;
using Roulette.Service.Shared;
using Roulette.Service.Validations;

namespace Roulette.Service.Rules
{
    public class ThirdColumnBet : IBet
    {
        private readonly BetModel _betModel;

        public ThirdColumnBet(BetModel betModel)
        {
            _betModel = betModel;
        }
        public bool CalculateBet()
        {
            if (!FirstSecondAndThirdColumnBetValidation.ValidateBet(_betModel.Bets, Common.ThirdColumnList()))
            {
                throw new ArgumentException("Invalid Argument.");
            }
            return Common.ThirdColumnList().Contains(_betModel.WheelNumber);
        }
    }
}

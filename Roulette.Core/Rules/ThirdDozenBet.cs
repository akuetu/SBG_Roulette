using System;
using Roulette.Core.Base;
using Roulette.Core.Interface;
using Roulette.Core.Model;
using Roulette.Core.Validations;

namespace Roulette.Core.Rules
{
    public class ThirdDozenBet : IBet
    {
        private readonly BetModel _betModel;

        public ThirdDozenBet(BetModel betModel)
        {
            _betModel = betModel;
        }
        public bool CalculateBet()
        {
            if (!FirstSecondAndThirdColumnBetValidation.ValidateBet(_betModel.Bets, Common.ThirdDozenList()))
            {
                throw new ArgumentException("Invalid Argument.");
            }
            return Common.ThirdDozenList().Contains(_betModel.WheelNumber);
        }
    }
}

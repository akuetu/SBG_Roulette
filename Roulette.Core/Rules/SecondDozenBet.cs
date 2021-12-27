using System;
using Roulette.Core.Base;
using Roulette.Core.Interface;
using Roulette.Core.Model;
using Roulette.Core.Validations;

namespace Roulette.Core.Rules
{
    public class SecondDozenBet : IBet
    {
        private readonly BetModel _betModel;

        public SecondDozenBet(BetModel betModel)
        {
            _betModel = betModel;
        }
        public bool CalculateBet()
        {
            if (!FirstSecondAndThirdColumnBetValidation.ValidateBet(_betModel.Bets, Common.SecondDozenList()))
            {
                throw new ArgumentException("Invalid Argument.");
            }
            return Common.SecondDozenList().Contains(_betModel.WheelNumber);
        }
    }
}

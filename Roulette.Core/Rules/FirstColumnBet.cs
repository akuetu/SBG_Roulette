using System;
using Roulette.Core.Base;
using Roulette.Core.Interface;
using Roulette.Core.Model;
using Roulette.Core.Validations;

namespace Roulette.Core.Rules
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

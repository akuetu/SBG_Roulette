using System;
using Roulette.Core.Base;
using Roulette.Core.Interface;
using Roulette.Core.Validations;
using Roulette.Service.Model;

namespace Roulette.Core.Rules
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

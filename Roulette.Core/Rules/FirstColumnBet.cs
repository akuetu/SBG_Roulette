using System;
using Roulette.Core.Interface;
using Roulette.Core.Validations;
using Roulette.Service.Base;
using Roulette.Service.Interface;
using Roulette.Service.Model;
using Roulette.Service.Shared;

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

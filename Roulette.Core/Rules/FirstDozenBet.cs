using System;
using Roulette.Core.Interface;
using Roulette.Core.Validations;
using Roulette.Service.Base;
using Roulette.Service.Model;
using Roulette.Service.Shared;

namespace Roulette.Core.Rules
{
    public class FirstDozenBet : IBet
    {
        private readonly BetModel _betModel;

        public FirstDozenBet(BetModel betModel)
        {
            _betModel = betModel;
        }

        public bool CalculateBet()
        {
            if (!FirstSecondAndThirdColumnBetValidation.ValidateBet(_betModel.Bets, Common.FirstDozenList()))
            {
                throw new ArgumentException("Invalid Argument.");
            }
            return Common.FirstDozenList().Contains(_betModel.WheelNumber);
        }
    }
}

using System;
using Roulette.Core.Validations;
using Roulette.Service.Base;
using Roulette.Service.Interface;
using Roulette.Service.Model;
using Roulette.Service.Shared;

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

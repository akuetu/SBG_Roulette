using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Base;
using Roulette.Core.Interface;
using Roulette.Core.Model;
using Roulette.Core.Validations;

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

﻿using System;
using Roulette.Core.Base;
using Roulette.Core.Interface;
using Roulette.Core.Model;
using Roulette.Core.Validations;

namespace Roulette.Core.Rules
{
    public class SecondColumnBet : IBet
    {
        private readonly BetModel _betModel;

        public SecondColumnBet(BetModel betModel)
        {
            _betModel = betModel;
        }
        public bool CalculateBet()
        {
            if (!FirstSecondAndThirdColumnBetValidation.ValidateBet(_betModel.Bets, Common.SecondColumnList()))
            {
                throw new ArgumentException("Invalid Argument.");
            }
            return Common.SecondColumnList().Contains(_betModel.WheelNumber);
        }
    }
}
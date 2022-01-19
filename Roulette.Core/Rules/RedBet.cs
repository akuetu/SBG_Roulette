﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Interface;
using Roulette.Core.Validations;
using Roulette.Service.Base;
using Roulette.Service.Interface;
using Roulette.Service.Model;
using Roulette.Service.Shared;

namespace Roulette.Core.Rules
{
    public class RedBet : IBet
    {
        private readonly BetModel _betModel;

        public RedBet(BetModel betModel)
        {
            _betModel = betModel;
        }


        public bool CalculateBet()
        {
           
            var redPieces = Common.RedPieces();
            return redPieces.Contains(_betModel.WheelNumber);
        }

    }
}

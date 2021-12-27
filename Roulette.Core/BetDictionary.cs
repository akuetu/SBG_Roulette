using System.Collections.Generic;
using Roulette.Core.Base;
using Roulette.Core.Interface;
using Roulette.Core.Model;
using Roulette.Core.Rules;

namespace Roulette.Core
{
    public static class BetDictionary
    {
        public static Dictionary<TypeOfBet, IBet> CreateDictionary(BetModel betModel)
        {
            var dictionary = new Dictionary<TypeOfBet, IBet>
            {
                { TypeOfBet.Zero, new ZeroBet(betModel)},
                { TypeOfBet.Black, new BlackBet(betModel)},
                { TypeOfBet.Red,new RedBet(betModel)},
                { TypeOfBet.Even, new  EvenBet(betModel)},
                { TypeOfBet.Odd, new  OddBet(betModel)},
                { TypeOfBet.StraightUp, new  StraightUpBet(betModel)},
                { TypeOfBet.Street, new StreetBet(betModel)},
                { TypeOfBet.DoubleStreet,new DoubleStreetBet(betModel)},                
                { TypeOfBet.FirstDozen,new  FirstDozenBet(betModel)},
                { TypeOfBet.SecondDozen,new SecondDozenBet(betModel)},
                { TypeOfBet.ThirdDozen, new ThirdDozenBet(betModel)},
                { TypeOfBet.FirstColumn,new FirstColumnBet(betModel)},
                { TypeOfBet.SecondColumn, new SecondColumnBet(betModel)},
                { TypeOfBet.ThirdColumn,new ThirdColumnBet(betModel)},
                { TypeOfBet.Corner, new CornerBet(betModel)},
                { TypeOfBet.Split, new SplitBet(betModel)},
            };

            return dictionary;
        }
    }
}

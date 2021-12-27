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
            };

            return dictionary;
        }
    }
}

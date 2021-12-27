using Roulette.Core.Base;
using Roulette.Core.Model;

namespace Roulette.API.Model
{
    public class RouletteBetModel
    {
        public TypeOfBet TypeOfBet { get; set; }

        public int[] Bets { get; set; }

        public Account Account { get; set; }
    }
}

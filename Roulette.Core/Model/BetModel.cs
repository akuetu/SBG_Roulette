using Roulette.Core.Base;
using Roulette.Service.Base;
using Roulette.Service.Shared;

namespace Roulette.Service.Model
{
    public class BetModel
    {
        public TypeOfBet TypeOfBet { get; set; }

        public int[] Bets { get; set; }

        public int WheelNumber { get; set; }

        public Board Board { get; set; }
    }
}

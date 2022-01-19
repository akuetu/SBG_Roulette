using Roulette.Core.Base;

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

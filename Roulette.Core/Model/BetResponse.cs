using Roulette.Core.Base;

namespace Roulette.Core.Model
{
   public class BetResponse
    {
        public TypeBetResult BetResult { get; set; }

        public decimal Balance { get; set; }

        public string Message { get; set; }

        public bool Status { get; set; }

        public int WheelNumber { get; set; }

        public TypeOfBet TypeOfBet { get; set; }
    }
}

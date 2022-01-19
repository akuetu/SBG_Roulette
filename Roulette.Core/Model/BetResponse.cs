 using Roulette.Service.Shared;

 namespace Roulette.Service.Model
{
   public class BetResponse
    {
        public TypeBetResult BetResult { get; set; }

        public decimal Balance { get; set; }

        public string Message { get; set; }

        public bool Status { get; set; }

        public int WheelNumber { get; set; }

        public TypeOfBet TypeOfBet { get; set; }

        public UserAccount UserAccount { get; set; }
    }
}

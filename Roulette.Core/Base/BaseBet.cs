using System.Linq;

namespace Roulette.Service.Base
{
    public class BaseBet
    {
        public static bool IsCorrectBet(int wheelNumber, int[] bets)
        {
            return bets.Contains(wheelNumber);
        }
    }
}

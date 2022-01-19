using Roulette.Core.Base;
using Roulette.Core.Model;

namespace Roulette.API.Services
{
    public interface IRouletteService
    {
        public BetResponse CalculateBet(TypeOfBet typeOfBet, int[] bet, Account account);
    }
}

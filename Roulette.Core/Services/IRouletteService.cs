using Roulette.Core.Base;
using Roulette.Service.Model;

namespace Roulette.Service.Services
{
    public interface IRouletteService
    {
        public BetResponse CalculateBet(TypeOfBet typeOfBet, int[] bet, Account account);
    }
}

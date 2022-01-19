using Roulette.Service.Base;
using Roulette.Service.Model;
using Roulette.Service.Shared;

namespace Roulette.Service.Services
{
    public interface IRouletteService
    {
        public BetResponse CalculateBet(TypeOfBet typeOfBet, int[] bet, Account account);
    }
}

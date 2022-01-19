using Roulette.Core.Base;
using Roulette.Core.Model;

namespace Roulette.Service.Roulette
{
    public interface IRouletteService
    {
        public BetResponse CalculateBet(TypeOfBet typeOfBet, int[] bet, Core.Model.Account account);
    }
}

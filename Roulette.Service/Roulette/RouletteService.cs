using Roulette.Core;
using Roulette.Core.Base;
using Roulette.Core.Model;
using Roulette.Service.Roulette;

namespace Roulette.API.Services
{
    public class RouletteService: IRouletteService
    {
        private readonly RouletteBet _roulette;
        private readonly RouletteWheel _rouletteWheel;
        private readonly Board _board;
        private const int Rows = 12;
        private const int Cols = 3;

        public RouletteService()
        {
            _roulette = new RouletteBet();
            _board = new Board(Rows, Cols);
            _rouletteWheel = new RouletteWheel();
        }
        

        public BetResponse CalculateBet(TypeOfBet typeOfBet, int[] bet, Account account)
        {
            var betModel = new BetModel
            {
                TypeOfBet = typeOfBet,
                Bets = bet,
                Board = _board,
                WheelNumber = _rouletteWheel.Spin()
            };

            return _roulette.CalculateBet(betModel, account);
        }

    }
}

using Roulette.Core.Base;

namespace Roulette.API.Services
{
    public class BetService
    {
        private const int Rows = 12;
        private const int Cols = 3;
        private readonly Board _board;

        public BetService()
        {
            _board = new Board(Rows, Cols);
        }


    }
}

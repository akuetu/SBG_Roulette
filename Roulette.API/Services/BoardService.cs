using Roulette.Core.Base;

namespace Roulette.API.Services
{
    public class BoardService
    {
        private const int Rows = 12;
        private const int Cols = 3;
        private readonly Board _board;

        public BoardService()
        {
            _board = new Board(Rows, Cols);
        }


        public Board LoadBoard()
        {
            return _board;
        }
    }
}

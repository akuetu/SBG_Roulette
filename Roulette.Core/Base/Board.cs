using Roulette.Core.Base;
using Roulette.Service.Shared;

namespace Roulette.Service.Base
{
    public class Board
    {
        public int Rows { get; set; }
        public int Cols { get; set; }

        //2D array
        public Cell[,] Grid { get; set; }

        public Board(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Grid = new Cell[Rows, Cols];

            InitializeBoardPieces();
        }

        private void InitializeBoardPieces()
        {
            var pieceNumber = 1;

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Cols; j++)
                {
                    var cell = new Cell(i, j)
                    {
                        Piece = new Piece()
                        {
                            Number = pieceNumber,
                            Color = GetPieceColorByNumber(pieceNumber)
                        }
                    };
                    Grid[i, j] = cell;
                    pieceNumber++;
                }
            }
        }

        private static PieceColor GetPieceColorByNumber(int number)
        {
            var numList = Common.RedPieces();

            return numList.Contains(number) ? PieceColor.Red : PieceColor.Black;
        }


    }
}

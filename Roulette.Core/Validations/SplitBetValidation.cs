using System;
using System.Linq;
using Roulette.Service.Base;
using Roulette.Service.Shared;

namespace Roulette.Service.Validations
{
    public static class SplitBetValidation
    {
        public static bool ValidateSplitBet(int[] bets)
        {
            var boardElements = Common.AllBoardGridElements();

            return ValidateVerticalBoundary(boardElements.ToArray(), bets);

        }

        private static bool ValidateVerticalBoundary(int[] boardElements, int[] bets)
        {
            var horizontalBoundary = Common.HorizontalBoundary();

            return ValidateHorizontalBoundary(horizontalBoundary, bets) && ValidateHorizontalRows(boardElements, bets);

        }

        private static bool ValidateHorizontalBoundary(int[] horizontalBoundary, int[] bets)
        {
            var rowBoundary = new int[2];
            for (var row = 0; row < horizontalBoundary.Length; row += 2)
            {
                rowBoundary[0] = horizontalBoundary[row];
                rowBoundary[1] = horizontalBoundary[row + 1];

                if (Enumerable.SequenceEqual(bets, rowBoundary))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateHorizontalRows(int[] boardElements, int[] bets)
        {
            var rowValues = new int[2];
            try
            {

                for (var row = 0; row < boardElements.Length - 1; row++)
                {
                    rowValues[0] = boardElements[row];
                    rowValues[1] = boardElements[row + 1];

                    if (Enumerable.SequenceEqual(bets.OrderBy(e => e), rowValues.OrderBy(e => e)))
                    {
                        return true;
                    }
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            return false;
        }


        //refactoring
        public static bool ValidateGridColumns(int[] bets, Board board)
        {
            const int totalGridRows = 11;

            var cell01 = new int[2];
            var cell02 = new int[2];
            var cell03 = new int[2];


            for (var i = 0; i < totalGridRows; i += 1)
            {
                cell01[0] = board.Grid[i, 0].Piece.Number;
                cell01[1] = board.Grid[i + 1, 0].Piece.Number;

                if (Enumerable.SequenceEqual(bets, cell01))
                {
                    return true;
                }

                cell02[0] = board.Grid[i, 1].Piece.Number;
                cell02[1] = board.Grid[i + 1, 1].Piece.Number;

                if (Enumerable.SequenceEqual(bets, cell02))
                {
                    return true;
                }

                cell03[0] = board.Grid[i, 2].Piece.Number;
                cell03[1] = board.Grid[i + 1, 2].Piece.Number;

                if (Enumerable.SequenceEqual(bets, cell03))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
 

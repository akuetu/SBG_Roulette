using System.Collections.Generic;
using System.Linq;
using Roulette.Service.Base;
using Roulette.Service.Extensions;

namespace Roulette.Service.Validations
{
    public static class StreetBetValidation
    {
        public static bool ValidateGridRow(int[] bets, Board board, int splitSize)
        {
            var boardElements = new int[36];

            for (var i = 0; i < board.Grid.Length; i++)
            {
                boardElements[i] = i + 1;
            }

            var splittedList = boardElements.Split<int>(splitSize).ToList();

            return ValidateEvenRows(splittedList, bets);

        }

        public static bool ValidateEvenRows(List<IEnumerable<int>> splittedList, int[] bets)
        {
            foreach (var row in splittedList)
            {
                if (Enumerable.SequenceEqual(bets.OrderBy(e => e), row.OrderBy(e => e))) return true;
            }

            return false;
        }
    }
}

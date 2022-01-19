using System;
using System.Collections.Generic;
using System.Linq;
using Roulette.Service.Base;
using Roulette.Service.Extensions;
using Roulette.Service.Model;

namespace Roulette.Service.Validations
{
    public static class DoubleStreetBetValidation
    {

        public static bool ValidateDoubleStreet(int[] bets, Board board, int splitSize)
        {
            var boardElements = new int[36];

            for (var i = 0; i < board.Grid.Length; i++)
            {
                boardElements[i] = i + 1;
            }

            var splittedList = boardElements.Split<int>(splitSize).ToList();

            return ValidateOddRows(splittedList, bets);
        }

        public static bool ValidateOddRows(List<IEnumerable<int>> splittedList, int[] bets)
        {
            try
            {

                for (var row = 1; row <= splittedList.Count - 1; row++)
                {
                    var r1 = splittedList[row].ToList();
                    var r2 = splittedList[row + 1].ToList();
                    r1.AddRange(r2);

                    if (Enumerable.SequenceEqual(bets.OrderBy(e => e), r1.OrderBy(e => e)))
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


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Core.Validations
{
    public static class FirstSecondAndThirdColumnBetValidation
    {
        public static bool ValidateBet(int[] bets, List<int> column)
        {
            return Enumerable.SequenceEqual(bets.OrderBy(e => e), column.OrderBy(e => e));
        }
    }
}

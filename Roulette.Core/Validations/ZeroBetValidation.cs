using System;

namespace Roulette.Core.Validations
{
    public static class ZeroBetValidation
    {
        public static void ValidateZeroBetInput(int[] bet)
        {
            if (bet.Length > 1 || bet[0] != 0)
            {
                throw new ArgumentException($"Invalid Argument.");
            }
        }
    }
}

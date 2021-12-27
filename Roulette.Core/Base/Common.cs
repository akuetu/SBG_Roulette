using System.Collections.Generic;

namespace Roulette.Core.Base
{
    public class Common
    {
        public static List<int> BlackPieces()
        {
            return new List<int>() { 15, 4, 2, 17, 6, 13, 11, 8, 10, 24, 33, 20, 31, 22, 29, 28, 35, 26 };
        }

        public static List<int> RedPieces()
        {
            return new List<int>() { 32, 19, 21, 25, 34, 27, 36, 30, 23, 5, 16, 1, 14, 9, 18, 7, 12, 3 };
        }
    }
}

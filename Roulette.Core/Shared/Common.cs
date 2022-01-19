using System.Collections.Generic;
using System.Linq;

namespace Roulette.Service.Shared
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

        public static int[] HorizontalBoundary()
        {
            return new int[] { 3, 4, 6, 7, 9, 10, 12, 13, 15, 16, 18, 19, 21, 22, 24, 25, 27, 28, 30, 31 };
        }

        public static List<int> AllBoardGridElements()
        {
            return Enumerable.Range(1, 36).ToList();
        }

        public static List<int> FirstDozenList()
        {
            return Enumerable.Range(1, 12).ToList();
        }

        public static List<int> SecondDozenList()
        {
            return Enumerable.Range(13, 12).ToList();
        }

        public static List<int> ThirdDozenList()
        {
            return Enumerable.Range(25, 12).ToList();
        }

        public static List<int> FirstColumnList()
        {
            var list = new List<int>();
            const int firstColumnUpperLimit = 34;

            for (var i = 1; i <= firstColumnUpperLimit; i += 3)
            {
                list.Add(i);
            }

            return list;
        }

        public static List<int> SecondColumnList()
        {
            var list = new List<int>();
            const int secondColumnUpperLimit = 35;

            for (var i = 2; i <= secondColumnUpperLimit; i += 3)
            {
                list.Add(i);
            }

            return list;
        }

        public static List<int> ThirdColumnList()
        {
            var list = new List<int>();
            const int thirdColumnUpperLimit = 36;

            for (var i = 3; i <= thirdColumnUpperLimit; i += 3)
            {
                list.Add(i);
            }

            return list;
        }
    }
}

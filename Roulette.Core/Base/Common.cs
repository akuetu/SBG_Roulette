﻿using System.Collections.Generic;
using System.Linq;

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
    }
}

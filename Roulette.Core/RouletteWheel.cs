using System;
using Roulette.Core.Interface;

namespace Roulette.Service
{
    public class RouletteWheel : IRouletteWheel
    {
        private readonly Random _random = new Random();

        public int Spin()
        {
            return _random.Next(0, 36);
        }
    }
}

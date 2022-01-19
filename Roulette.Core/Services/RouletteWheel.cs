using System;
using Roulette.Service.Interface;

namespace Roulette.Service.Services
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

using Roulette.Core.Base;
using Roulette.Core.Interface;
using Roulette.Core.Model;

namespace Roulette.Core.Rules
{
    public class ZeroBet : IBet
    {
        private readonly BetModel _betModel;

        public ZeroBet(BetModel betModel)
        {
            _betModel = betModel;
        }
        public bool CalculateBet()
        {
            return _betModel.WheelNumber == 0;
        }
    }
}

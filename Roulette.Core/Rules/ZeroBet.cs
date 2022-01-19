using Roulette.Service.Interface;
using Roulette.Service.Model;

namespace Roulette.Service.Rules
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

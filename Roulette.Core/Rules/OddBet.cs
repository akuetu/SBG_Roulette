using Roulette.Service.Interface;
using Roulette.Service.Model;

namespace Roulette.Service.Rules
{
    public class OddBet : IBet
    {
        private readonly BetModel _betModel;

        public OddBet(BetModel betModel)
        {
            _betModel = betModel;
        }
        public bool CalculateBet()
        {
            return _betModel.WheelNumber % 2 != 0;
        }
    }
}

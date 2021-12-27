using Roulette.Core.Interface;
using Roulette.Core.Model;

namespace Roulette.Core.Rules
{
    public class EvenBet : IBet
    {
        private readonly BetModel _betModel;

        public EvenBet(BetModel betModel)
        {
            _betModel = betModel;
        }

        public bool CalculateBet()
        {
            return _betModel.WheelNumber % 2 == 0;
        }

    }
}

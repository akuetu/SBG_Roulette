using Roulette.Core.Interface;
using Roulette.Service.Model;

namespace Roulette.Core.Rules
{
    public class StraightUpBet : IBet
    {
        private readonly BetModel _betModel;

        public StraightUpBet(BetModel betModel)
        {
            _betModel = betModel;
        }

        public bool CalculateBet()
        {
            return _betModel.WheelNumber == _betModel.Bets[0];
        }

    }
}

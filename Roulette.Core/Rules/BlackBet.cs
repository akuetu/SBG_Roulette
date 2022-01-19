using Roulette.Service.Base;
using Roulette.Service.Interface;
using Roulette.Service.Model;
using Roulette.Service.Shared;

namespace Roulette.Core.Rules
{
    public class BlackBet : IBet
    {
        private readonly BetModel _betModel;

        public BlackBet(BetModel betModel)
        {
            _betModel = betModel;
        }
        public bool CalculateBet()
        {
            var blackPieces = Common.BlackPieces();
            return blackPieces.Contains(_betModel.WheelNumber);
        }
    }
}

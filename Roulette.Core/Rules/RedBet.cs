using Roulette.Service.Interface;
using Roulette.Service.Model;
using Roulette.Service.Shared;

namespace Roulette.Service.Rules
{
    public class RedBet : IBet
    {
        private readonly BetModel _betModel;

        public RedBet(BetModel betModel)
        {
            _betModel = betModel;
        }


        public bool CalculateBet()
        {
           
            var redPieces = Common.RedPieces();
            return redPieces.Contains(_betModel.WheelNumber);
        }

    }
}

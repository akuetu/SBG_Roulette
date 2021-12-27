using Roulette.Core.Base;
using Roulette.Core.Exceptions;
using Roulette.Core.Interface;
using Roulette.Core.Model;
using Roulette.Core.Validations;

namespace Roulette.Core.Rules
{
    public class StreetBet : IBet
    {
        private readonly BetModel _betModel;

        public StreetBet(BetModel betModel)
        {
            _betModel = betModel;
        }
        public bool CalculateBet()
        {
            const int splitSize = 3;
            var result = StreetBetValidation.ValidateGridRow(_betModel.Bets, _betModel.Board, splitSize);

            if (!result) throw new RowInvalidException("Invalid row values.");

            return BaseBet.IsCorrectBet(_betModel.WheelNumber, _betModel.Bets);
        }
    }
}

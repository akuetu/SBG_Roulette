using Roulette.Core.Base;
using Roulette.Core.Exceptions;
using Roulette.Core.Interface;
using Roulette.Core.Model;
using Roulette.Core.Validations;

namespace Roulette.Core.Rules
{
    public class SplitBet : IBet
    {
        private readonly BetModel _betModel;

        public SplitBet(BetModel betModel)
        {
            _betModel = betModel;
        }

        public bool CalculateBet()
        {
            const int splitSize = 3;

            var isValidColumn = SplitBetValidation.ValidateGridColumns(_betModel.Bets, _betModel.Board);

            if (isValidColumn) return BaseBet.IsCorrectBet(_betModel.WheelNumber, _betModel.Bets);

            var isValidRow = SplitBetValidation.ValidateSplitBet(_betModel.Bets);

            if (!isValidRow) throw new RowInvalidException("Invalid row/col values.");

            return BaseBet.IsCorrectBet(_betModel.WheelNumber, _betModel.Bets);
        }

    }
}
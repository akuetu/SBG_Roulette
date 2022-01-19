using Roulette.Core.Validations;
using Roulette.Service.Base;
using Roulette.Service.Exceptions;
using Roulette.Service.Interface;
using Roulette.Service.Model;

namespace Roulette.Service.Rules
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
            var isValidColumn = SplitBetValidation.ValidateGridColumns(_betModel.Bets, _betModel.Board);

            if (isValidColumn) return BaseBet.IsCorrectBet(_betModel.WheelNumber, _betModel.Bets);

            var isValidRow = SplitBetValidation.ValidateSplitBet(_betModel.Bets);

            if (!isValidRow) throw new RowInvalidException("Invalid row/col values.");

            return BaseBet.IsCorrectBet(_betModel.WheelNumber, _betModel.Bets);
        }

    }
}
using Roulette.Service.Base;
using Roulette.Service.Exceptions;
using Roulette.Service.Interface;
using Roulette.Service.Model;
using Roulette.Service.Validations;

namespace Roulette.Service.Rules
{
    public class DoubleStreetBet : IBet
    {
        private readonly BetModel _betModel;

        public DoubleStreetBet(BetModel betModel)
        {
            _betModel = betModel;
        }

        public bool CalculateBet()
        {
            const int splitSize = 3;
            var result = DoubleStreetBetValidation.ValidateDoubleStreet(_betModel.Bets, _betModel.Board, splitSize);

            if (!result) throw new RowInvalidException("Invalid row values.");

            return BaseBet.IsCorrectBet(_betModel.WheelNumber, _betModel.Bets);
        }
    }
}

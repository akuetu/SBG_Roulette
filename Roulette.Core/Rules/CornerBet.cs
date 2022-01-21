using System.Linq;
using Roulette.Service.Base;
using Roulette.Service.Interface;
using Roulette.Service.Model;

namespace Roulette.Service.Rules
{
    public class CornerBet : IBet
    {
        private readonly BetModel _betModel;

        public CornerBet(BetModel betModel)
        {
            _betModel = betModel;
        }

        public bool CalculateBet()
        {
            var row01 = new int[2];
            var row02 = new int[2];
            var row03 = new int[2];
            var row04 = new int[2];


            for (var i = 0; i < _betModel.Board.Rows - 1; i++)
            {
                //first group
                row01[0] = _betModel.Board.Grid[i, 0].Piece.Number;
                row01[1] = _betModel.Board.Grid[i + 1, 0].Piece.Number;

                row02[0] = _betModel.Board.Grid[i, 1].Piece.Number;
                row02[1] = _betModel.Board.Grid[i + 1, 1].Piece.Number;

                var mergeFirstGroupArray = row01.Concat(row02).ToArray();

                var firstResult =  IsTheBetCorrect(mergeFirstGroupArray);

                if (firstResult) return BaseBet.IsCorrectBet(_betModel.WheelNumber, _betModel.Bets); 

                //second group
                row03[0] = _betModel.Board.Grid[i, 1].Piece.Number;
                row03[1] = _betModel.Board.Grid[i + 1, 1].Piece.Number;

                row04[0] = _betModel.Board.Grid[i, 2].Piece.Number;
                row04[1] = _betModel.Board.Grid[i + 1, 2].Piece.Number;

                var mergeSecondGroupArray = row03.Concat(row04).ToArray();

                var secondResult = IsTheBetCorrect(mergeSecondGroupArray);

                if (secondResult) return BaseBet.IsCorrectBet(_betModel.WheelNumber, _betModel.Bets);
            }

            return false;
        }

        private bool IsTheBetCorrect(int[] mergedGroupArray)
        {
            return Enumerable.SequenceEqual(_betModel.Bets.OrderBy(e => e), mergedGroupArray.OrderBy(e => e));
        }
    }
}

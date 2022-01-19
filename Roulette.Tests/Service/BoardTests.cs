using System.Collections.Generic;
using System.Linq;
using Roulette.Core.Base;
using Xunit;

namespace Roulette.Tests
{
    public class BoardTests
    {
        private const int Rows = 12;
        private const int Cols = 3;
        private readonly Board _board;
        public BoardTests()
        {
             _board = new Board(Rows, Cols);
        }

        [Fact]
        public void Validate_BoardGridLength_ReturnsRouletteBoardDimension()
        {
            var board = new Board(Rows, Cols);
            var grid = board.Grid;

            Assert.Equal(36, grid.Length);
        }

        [Fact]
        public void Validate_RedColor_ReturnsOnlyRedColorPieces()
        {
            var redPieces = new List<int>() { 32, 19, 21, 25, 34, 27, 36, 30, 23, 5, 16, 1, 14, 9, 18, 7, 12, 3 };

            var expectedRedPieces = new List<int>();

            
           
            var grid = _board.Grid;


            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Cols; j++)
                {
                    if (grid[i, j].Piece.Color == PieceColor.Red)
                    {
                        expectedRedPieces.Add(grid[i, j].Piece.Number);
                    }

                }
            }

            Assert.True(Enumerable.SequenceEqual(redPieces.OrderBy(e => e), expectedRedPieces.OrderBy(e => e)));
            Assert.Equal(redPieces.OrderBy(e => e), expectedRedPieces.OrderBy(e => e));

        }
        
        [Fact]
        public void Validate_BlackColor_ReturnsOnlyBlackColorPieces()
        {
            var blackPieces = new List<int>() { 15, 4, 2, 17, 6, 13, 11, 8, 10, 24, 33, 20, 31, 22, 29, 28, 35, 26 };

            var expectedBlackPieces = new List<int>();

            
           
            var grid = _board.Grid;


            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Cols; j++)
                {
                    if (grid[i, j].Piece.Color == PieceColor.Black)
                    {
                        expectedBlackPieces.Add(grid[i, j].Piece.Number);
                    }

                }
            }

            Assert.True(Enumerable.SequenceEqual(blackPieces.OrderBy(e => e), expectedBlackPieces.OrderBy(e => e)));
            Assert.Equal(blackPieces.OrderBy(e => e), expectedBlackPieces.OrderBy(e => e));


        }

    }
}

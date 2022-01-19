namespace Roulette.Service.Model
{
    public class Cell
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public Piece Piece { get; set; }


        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}

namespace Roulette.Service.Shared
{

    public enum PieceColor
    {
        Black,
        Red
    }

    public enum TypeOfBet
    {
        Zero = 0,
        StraightUp = 1,
        Split = 2,
        Street = 3,
        Corner = 4,
        DoubleStreet = 6,
        FirstColumn = 7,
        SecondColumn = 8,
        ThirdColumn = 9,
        FirstDozen = 10,
        SecondDozen = 11,
        ThirdDozen = 12,
        Odd = 13,
        Even = 14,
        Red = 15,
        Black = 16,
    }

    public enum TypeBetResult
    {
        Loose,
        Win
    }
}

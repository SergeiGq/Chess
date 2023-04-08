namespace Chess.Figures;

public class Knight : Figure
{
    public Knight(Coordinate coordinate, Color color) : base(coordinate, color)
    {
        Coordinate = coordinate;
        Color = color;
    }

    public override char Symbol { get; } = '♘';

    protected override void PossibleMove(Board board)
    {
        var coordinateList = new List<Coordinate>();
        var possibleCoordinateLeft1 = new Coordinate(Coordinate.X + 1, Coordinate.Y - 2);
        var possibleCoordinateLeft2 = new Coordinate(Coordinate.X + 1, Coordinate.Y + 2);
        var possibleCoordinateLeft3 = new Coordinate(Coordinate.X + 2, Coordinate.Y + 1);
        var possibleCoordinateLeft4 = new Coordinate(Coordinate.X + 2, Coordinate.Y - 1);
        var possibleCoordinateRight1 = new Coordinate(Coordinate.X - 1, Coordinate.Y - 2);
        var possibleCoordinateRight2 = new Coordinate(Coordinate.X - 1, Coordinate.Y + 2);
        var possibleCoordinateRight3 = new Coordinate(Coordinate.X - 2, Coordinate.Y + 1);
        var possibleCoordinateRight4 = new Coordinate(Coordinate.X - 2, Coordinate.Y - 1);
        coordinateList.Add(possibleCoordinateLeft1);
        coordinateList.Add(possibleCoordinateLeft2);
        coordinateList.Add(possibleCoordinateLeft3);
        coordinateList.Add(possibleCoordinateLeft4);
        coordinateList.Add(possibleCoordinateRight1);
        coordinateList.Add(possibleCoordinateRight2);
        coordinateList.Add(possibleCoordinateRight3);
        coordinateList.Add(possibleCoordinateRight4);
        foreach (var item in coordinateList)
        {
            if (item.X >= 0 && item.X <= 7 && item.Y >= 0 && item.Y <= 7)
            {
                var figure = board.Figures.FirstOrDefault(n => n.Coordinate == item);
                if (figure == null || figure.Color != Color)
                {
                    PossibleMoves.Add(item);
                    
                }
            }
        }
    }
}
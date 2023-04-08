namespace Chess.Figures;

public class King : Figure
{
    public King(Coordinate coordinate, Color color) : base(coordinate, color)
    {
        Coordinate = coordinate;
        Color = color;
        IsFirst = true;
    }

    public override char Symbol { get; } = '♔';
    public bool IsFirst { get; set; } 
    protected override void PossibleMove(Board board)
    {
        Coordinate coordinate = new(Coordinate.X, Coordinate.Y);
        coordinate.X++;
        if (coordinate.X < 8 && coordinate.X >= 0)
        {
            for (int y = coordinate.Y - 1, count = 0; count < 3; y++, count++)
            {
                var figureOrDefault = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);
                if (y is >= 0 and < 8)
                {
                    if (figureOrDefault == null || figureOrDefault.Color != Color)
                    {
                        PossibleMoves.Add(new Coordinate(coordinate.X, y));
                    }
                }
            }
        }

        coordinate.X--;
        for (int y = coordinate.Y - 1, count = 0; count < 2; y = y + 2, count++)
        {
            var figureOrDefault = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);
            if (y is >= 0 and < 8)
            {
                if (figureOrDefault == null || figureOrDefault.Color != Color)
                {
                    PossibleMoves.Add(new Coordinate(coordinate.X, y));
                }
            }
        }

        coordinate.X--;
        if (coordinate.X < 8 && coordinate.X >= 0)
        {
            for (int y = coordinate.Y - 1, count = 0; count < 3; y++, count++)
            {
                var figureOrDefault = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);
                if (y is >= 0 and < 8)
                {
                    if (figureOrDefault == null || figureOrDefault.Color != Color)
                    {
                        PossibleMoves.Add(new Coordinate(coordinate.X, y));
                    }
                }
            }
        }
    }
}
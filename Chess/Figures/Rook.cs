namespace Chess.Figures;

public class Rook : Figure
{
    public Rook(Coordinate coordinate, Color color) : base(coordinate, color)
    {
        Coordinate = coordinate;
        Color = color;
    }

    public override char Symbol { get; } = '♖';

    protected override void PossibleMove(Board board)
    {
        var coordinate = new Coordinate(Coordinate.X, Coordinate.Y);
        for (int x = Coordinate.X + 1, y = Coordinate.Y; x < 8; x++)
        {
            coordinate.X = x;
            coordinate.Y = y;
            var figureOrNot = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);
            if (figureOrNot == null || figureOrNot.Color != Color)
            {
                PossibleMoves.Add(new Coordinate(coordinate.X, coordinate.Y));
                if (figureOrNot != null)
                {
                    break;
                }
            }
            else
            {
                break;
            }
        }

        for (int x = Coordinate.X - 1, y = Coordinate.Y; x >= 0; x--)
        {
            coordinate.X = x;
            coordinate.Y = y;
            var figureOrNot = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);
            if (figureOrNot == null || figureOrNot.Color != Color)
            {
                PossibleMoves.Add(new Coordinate(coordinate.X, coordinate.Y));
                if (figureOrNot != null)
                {
                    break;
                }
            }
            else
            {
                break;
            }
        }

        for (int x = Coordinate.X, y = Coordinate.Y + 1; y < 8; y++)
        {
            coordinate.X = x;
            coordinate.Y = y;
            var figureOrNot = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);
            if (figureOrNot == null || figureOrNot.Color != Color)
            {
                PossibleMoves.Add(new Coordinate(coordinate.X, coordinate.Y));
                if (figureOrNot != null)
                {
                    break;
                }
            }
            else
            {
                break;
            }
        }

        for (int x = Coordinate.X, y = Coordinate.Y - 1; y >= 0; y--)
        {
            coordinate.X = x;
            coordinate.Y = y;
            var figureOrNot = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);
            if (figureOrNot == null || figureOrNot.Color != Color)
            {
                PossibleMoves.Add(new Coordinate(coordinate.X, coordinate.Y));
                if (figureOrNot != null)
                {
                    break;
                }
            }
            else
            {
                break;
            }
        }
    }
}
namespace Chess.Figures;

public class Bishop : Figure
{
    public Bishop(Coordinate coordinate, Color color) : base(coordinate, color)
    {
        Coordinate = coordinate;
        Color = color;
    }

    public override char Symbol { get; } = '♗';

    protected override void PossibleMove(Board board)
    {
        var coordinate = new Coordinate(Coordinate.X, Coordinate.Y);

        for (int x = Coordinate.X + 1, y = Coordinate.Y + 1; x < 8 && y < 8; x++, y++)
        {
            coordinate.X = x;
            coordinate.Y = y;
            var figureOrNot = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);
            if (figureOrNot == null || figureOrNot.Color != Color)
            {
                PossibleMoves.Add(new Coordinate(coordinate.X,coordinate.Y));
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

        for (int x = Coordinate.X + 1, y = Coordinate.Y - 1; x < 8 && y >= 0; x++, y--)
        {
            coordinate.X = x;
            coordinate.Y = y;
            var figureOrNot = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);
            if (figureOrNot == null || figureOrNot.Color != Color)
            {
                PossibleMoves.Add(new Coordinate(coordinate.X,coordinate.Y));
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

        for (int x = Coordinate.X - 1, y = Coordinate.Y + 1; x >= 0 && y < 8; x--, y++)
        {
            coordinate.X = x;
            coordinate.Y = y;
            var figureOrNot = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);
            if (figureOrNot == null || figureOrNot.Color != Color)
            {
                PossibleMoves.Add(new Coordinate(coordinate.X,coordinate.Y));
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

        for (int x = Coordinate.X - 1, y = Coordinate.Y - 1; x >= 0 && y >= 0; x--, y--)
        {
            coordinate.X = x;
            coordinate.Y = y;
            var figureOrNot = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);
            if (figureOrNot == null || figureOrNot.Color != Color)
            {
                PossibleMoves.Add(new Coordinate(coordinate.X,coordinate.Y));
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
namespace Chess.Figures;

public class Pawn : Figure
{
    public bool IsFirstMove { get; set; } = true;

    public Pawn(Coordinate coordinate, Color color) : base(coordinate, color)
    {
        Coordinate = coordinate;
        Color = color;
    }

    public override char Symbol { get; } = '♙';

    protected override void PossibleMove(Board board)
    {
        if (Color == Color.White)
        {
            Coordinate coordinate = new(Coordinate.X, Coordinate.Y);
            if (IsFirstMove)
            {
                for (int i = 0; i < 2; i++)
                {
                    coordinate.X++;
                    var figureOrNot = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);

                    if (figureOrNot == null)
                    {
                        PossibleMoves.Add(new Coordinate(coordinate.X, coordinate.Y));
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                coordinate.X++;
                var figureOrNot = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);
                if (coordinate.X < 8 && coordinate.X >= 0)
                {
                    if (figureOrNot == null)
                    {
                        PossibleMoves.Add(new Coordinate(coordinate.X, coordinate.Y));
                    }
                }
            }

            coordinate = new Coordinate(Coordinate.X, Coordinate.Y);
            coordinate.Y++;
            coordinate.X++;

            var figureOrNot1 = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);
            if (figureOrNot1 != null && figureOrNot1.Color != Color)
            {
                PossibleMoves.Add(new Coordinate(coordinate.X, coordinate.Y));
            }

            coordinate.Y -= 2;
            figureOrNot1 = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);
            if (figureOrNot1 != null && figureOrNot1.Color != Color)
            {
                PossibleMoves.Add(new Coordinate(coordinate.X, coordinate.Y));
            }
        }

        if (Color == Color.Black)
        {
            Coordinate coordinate = new(Coordinate.X, Coordinate.Y);
            if (IsFirstMove)
            {
                for (int i = 0; i < 2; i++)
                {
                    coordinate.X--;
                    var figureOrNot = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);

                    if (figureOrNot == null)
                    {
                        PossibleMoves.Add(new Coordinate(coordinate.X, coordinate.Y));
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                coordinate.X--;
                var figureOrNot = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);
                if (coordinate.X < 8 && coordinate.X >= 0)
                {
                    if (figureOrNot == null)
                    {
                        PossibleMoves.Add(new Coordinate(coordinate.X, coordinate.Y));
                    }
                }
            }

            coordinate = new Coordinate(Coordinate.X, Coordinate.Y);
            coordinate.Y++;
            coordinate.X--;

            var figureOrNot1 = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);
            if (figureOrNot1 != null && figureOrNot1.Color != Color)
            {
                PossibleMoves.Add(new Coordinate(coordinate.X, coordinate.Y));
            }

            coordinate.Y -= 2;
            figureOrNot1 = board.Figures.FirstOrDefault(n => n.Coordinate == coordinate);
            if (figureOrNot1 != null && figureOrNot1.Color != Color)
            {
                PossibleMoves.Add(new Coordinate(coordinate.X, coordinate.Y));
            }
        }
    }
}
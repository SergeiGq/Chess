namespace Chess.Figures;

public abstract class Figure
{
    protected Figure(Coordinate coordinate, Color color)
    {
        Coordinate = coordinate;
        Color = color;
    }

    public abstract char Symbol { get; }
    public Coordinate Coordinate { get; set; }
    public Color Color { get; set; }
    public List<Coordinate> PossibleMoves { get; set; } = new();

    protected abstract void PossibleMove(Board board);

    public void CreatePossibleMove(Board board)
    {
        PossibleMoves.Clear();
        PossibleMove(board);
    }

    public Figure Copy()
    {
        var memberwiseClone = (Figure)MemberwiseClone();
        memberwiseClone.PossibleMoves = new List<Coordinate>();
        memberwiseClone.Coordinate = new Coordinate(Coordinate.X, Coordinate.Y);
        return memberwiseClone;
    }
}
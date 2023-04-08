namespace Chess;

public class Coordinate
{
    public Coordinate(int x,int y)
    {
        X = x;
        Y = y;
    }
    public static bool operator == (Coordinate nm1, Coordinate mn2)
    {
        return nm1.X==mn2.X&&nm1.Y==mn2.Y;
    }

    public static bool operator != (Coordinate nm1, Coordinate mn2)
    {
        return !(nm1.X==mn2.X&&nm1.Y==mn2.Y);
    }
    public int X { get; set; }
    public int Y { get; set; }
}
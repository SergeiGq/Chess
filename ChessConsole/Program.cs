using ChessConsole;


void Main()
{
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    var letters = new List<string>() { " ", "A", "B", "C", "D", "E", "F", "G", "H" };
    var PeshW = new Pesh() { Type = 1, Symbol = "♙", Side = "W", X = 2 };
    var KingW = new King() { Type = 0, Symbol = "♔", Side = "W", X = 1, Y = 5 };
    var RookW = new Rook() { Type = 5, Symbol = "♖", Side = "W", X = 1, Y = 1 };
    var RookW2 = new Rook() { Type = 5, Symbol = "♖", Side = "W", X = 1, Y = 8 };
    var QueenW = new Queen() { Type = 8, Symbol = "♕", Side = "W", X = 1, Y = 4 };
    var BishopW = new Bishop() { Type = 3, Symbol = "♗", Side = "W", X = 1, Y = 3 };
    var BishopW2 = new Bishop() { Type = 3, Symbol = "♗", Side = "W", X = 1, Y = 6 };
    var KnightW = new Knight() { Type = 2, Symbol = "♘", Side = "W", X = 1, Y = 2 };
    var KnightW2 = new Knight() { Type = 2, Symbol = "♘", Side = "W", X = 1, Y = 7 };
    var PeshB = new Pesh() { Type = 1, Symbol = "♙", Side = "B", X = 7 };
    var KingB = new King() { Type = 0, Symbol = "♚", Side = "B", X = 8, Y = 5 };
    var RookB = new Rook() { Type = 5, Symbol = "♜", Side = "B", X = 8, Y = 1 };
    var RookB2 = new Rook() { Type = 5, Symbol = "♜", Side = "B", X = 8, Y = 8 };
    var QueenB = new Queen() { Type = 8, Symbol = "♛", Side = "B", X = 8, Y = 4 };
    var BishopB = new Bishop() { Type = 3, Symbol = "♝", Side = "B", X = 8, Y = 3 };
    var BishopB2 = new Bishop() { Type = 3, Symbol = "♝", Side = "B", X = 8, Y = 6 };
    var KnightB = new Knight() { Type = 2, Symbol = "♞", Side = "B", X = 8, Y = 2 };
    var KnightB2 = new Knight() { Type = 2, Symbol = "♞", Side = "B", X = 8, Y = 7 };
    var ff = new EmptyF() { Symbol = "*" };
    var string1 = new List<Figure>() { RookW, KnightW, BishopW, QueenW, KingW, BishopW2, KnightW2, RookW2 };
    var string2 = new List<Figure>();
    for (int i = 1; i <= 8; i++)
    {
        PeshW.Y = i;
        string2.Add(PeshW);
    }

    var string7 = new List<Figure>();
    for (int i = 1; i <= 8; i++)
    {
        PeshB.Y = i;
        string7.Add(PeshB);
    }

    var string8 = new List<Figure>() { RookB, KnightB, BishopB, QueenB, KingB, BishopB2, KnightB2, RookB2 };
    var string3 = new List<Figure>() { ff, ff, ff, ff, ff, ff, ff, ff };
    var map = new List<List<Figure>>() { string1, string2, string3, string3, string3, string3, string7, string8 };

    Print1(letters);
    Console.WriteLine();
    Print(map);
    Console.WriteLine();

    while (!IsFinish())
    {
        string x = "";
        string y = "";

        Figure figure = new Figure();
        int x1 = -1, x2 = -1, y1 = -1, y2 = -1;
        Console.WriteLine("Figure x y and move x y");
        Console.WriteLine("Figure x y");
        x = Console.ReadLine();
        y1 = Convert(x[0]) ;
        x1 = int.Parse(x[1].ToString());
        Console.WriteLine("Move x y");
        x = Console.ReadLine();
        y2 = Convert(x[0]);
        x2 = int.Parse(x[1].ToString());
        foreach (var item in map)
        {
            foreach (var item1 in item)
            {
                if (item1.X == x1 && item1.Y == y1)
                {
                    figure = item1;
                }
            }
        }

        map[x1-1][y1-1] = ff;
        map[x2-1][y2-1] = figure;
        Print1(letters);
        Console.WriteLine();
        Print(map);
    }
}

int Convert(char x)
{
    switch (x)
    {
        case 'A':
            return 1;
        case 'B':
            return 2;
        case 'C':
            return 3;
        case 'D':
            return 4;
        case 'E':
            return 5;
        case 'F':
            return 6;
        case 'G':
            return 7;
        case 'H':
            return 8;
    }

    return 0;
}

void Print(List<List<Figure>> map)
{
    for (int i = 0; i < map.Count; i++)
    {
        Console.Write(i + 1 + "\t");
        for (int j = 0; j < map.Count; j++)
        {
            if (map[i][j].Symbol == "*")
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(map[i][j].Symbol + "\t");
                Console.ForegroundColor = ConsoleColor.White;
                continue;
            }

            if (map[i][j].Side == "W")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(map[i][j].Symbol + "\t");
                continue;
            }

            if (map[i][j].Side == "B")
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(map[i][j].Symbol + "\t");
                continue;
            }
        }

        Console.WriteLine();
        
    }
}


void Print1(List<string> map)
{
    for (int i = 0; i < map.Count; i++)
    {
        Console.Write(map[i] + "\t");
    }

    Console.WriteLine();
}

//сделать
bool IsFinish()
{
    return false;
}


Main();
using Chess.Figures;

namespace Chess;

enum TypeFigure
{
    King = 6,
    Pawn = 1,
    Knight = 2,
    Bishop = 3,
    Queen = 8,
    Rook = 5
}

public class Board
{
    public Board()
    {
        StatusGame = StatusGame.Normal;
        CurrentColor = Color.White;
        Figures = new List<Figure>();
        for (int i = 0; i < 8; i++)
        {
            CreateFigures(1, i, Color.White, TypeFigure.Pawn);
            CreateFigures(6, i, Color.Black, TypeFigure.Pawn);
        }

        CreateFigures(7, 0, Color.Black, TypeFigure.Rook);
        CreateFigures(7, 1, Color.Black, TypeFigure.Knight);
        CreateFigures(7, 2, Color.Black, TypeFigure.Bishop);
        CreateFigures(7, 3, Color.Black, TypeFigure.Queen);
        CreateFigures(7, 4, Color.Black, TypeFigure.King);
        CreateFigures(7, 5, Color.Black, TypeFigure.Bishop);
        CreateFigures(7, 6, Color.Black, TypeFigure.Knight);
        CreateFigures(7, 7, Color.Black, TypeFigure.Rook);

        CreateFigures(0, 0, Color.White, TypeFigure.Rook);
        CreateFigures(0, 1, Color.White, TypeFigure.Knight);
        CreateFigures(0, 2, Color.White, TypeFigure.Bishop);
        CreateFigures(0, 3, Color.White, TypeFigure.Queen);
        CreateFigures(0, 4, Color.White, TypeFigure.King);
        CreateFigures(0, 5, Color.White, TypeFigure.Bishop);
        CreateFigures(0, 6, Color.White, TypeFigure.Knight);
        CreateFigures(0, 7, Color.White, TypeFigure.Rook);
    }

    public Board(List<Figure> figures, Color currentColor, StatusGame statusGame)
    {
        Figures = figures;
        CurrentColor = currentColor;
        StatusGame = statusGame;
    }

    public List<Figure> Figures { get; set; }
    public Color CurrentColor { get; set; }
    public StatusGame StatusGame { get; set; }

    private bool Simulate(Coordinate currentCoordinate, Coordinate nextCoordinate)
    {
        var simulateBoard = new Board(Figures.Select(n => n.Copy()).ToList(), CurrentColor, StatusGame);
        var res = simulateBoard.MoveWithoutCheck(currentCoordinate, nextCoordinate);
        if (!res)
        {
            return false;
        }

        CheckCheck(simulateBoard);
        if (simulateBoard.StatusGame == StatusGame.Check)
        {
            simulateBoard.Print();
            return false;
        }

        return true;
    }


    public bool MoveWithCheck(Coordinate currentCoordinate, Coordinate nextCoordinate)
    {
        if (StatusGame == StatusGame.Mat)
        {
            return false;
        }

        var isHas = false;
        var figure = Figures.FirstOrDefault(n => n.Coordinate == currentCoordinate);
        var figureNext = Figures.FirstOrDefault(n => n.Coordinate == nextCoordinate);
        if (figure != null && figure.Color == CurrentColor)
        {
            figure.CreatePossibleMove(this);
            if (StatusGame == StatusGame.Check)
            {
                var resSimulate = Simulate(currentCoordinate, nextCoordinate);
                if (!resSimulate)
                {
                    return false;
                }
            }


            foreach (var coordinate in figure.PossibleMoves)
            {
                if (coordinate == nextCoordinate)
                {
                    isHas = true;
                    break;
                }
            }
        }
        else
        {
            return false;
        }

        if (isHas)
        {
            if (figureNext != null)
            {
                Figures.Remove(figureNext);
            }

            figure.Coordinate = nextCoordinate;
            switch (CurrentColor)
            {
                case Color.Black:
                    CurrentColor = Color.White;
                    break;
                case Color.White:
                    CurrentColor = Color.Black;
                    break;
            }

            CheckCheck(this);
            if (StatusGame == StatusGame.Check)
            {
                CheckMat(this);
            }

            return true;
        }

        return false;
    }

    private bool SimulateMat()
    {
        var simulateBoard = new Board(Figures.Select(n => n.Copy()).ToList(), CurrentColor, StatusGame);
        var figures = simulateBoard.Figures.Where(n => n.Color == CurrentColor);
        foreach (var figure in figures)
        {
            figure.CreatePossibleMove(simulateBoard);
            if (figure.PossibleMoves.Count == 0)
            {
                continue;
            }

            foreach (var coordinate in figure.PossibleMoves.ToList())
            {
                simulateBoard.MoveWithoutCheck(figure.Coordinate, coordinate);
                CheckCheck(simulateBoard);
                if (simulateBoard.StatusGame == StatusGame.Normal)
                {
                    return false;
                }

                simulateBoard = new Board(Figures.Select(n => n.Copy()).ToList(), CurrentColor, StatusGame);
            }
        }

        return true;
    }

    private void CheckMat(Board board)
    {
        var resSimulate = SimulateMat();
        if (resSimulate)
            StatusGame = StatusGame.Mat;
    }

    public bool MoveWithoutCheck(Coordinate currentCoordinate, Coordinate nextCoordinate)
    {
        var isHas = false;
        var figure = Figures.FirstOrDefault(n => n.Coordinate == currentCoordinate);
        var figureNext = Figures.FirstOrDefault(n => n.Coordinate == nextCoordinate);
        if (figure != null && figure.Color == CurrentColor)
        {
            figure.CreatePossibleMove(this);


            foreach (var coordinate in figure.PossibleMoves)
            {
                if (coordinate == nextCoordinate)
                {
                    isHas = true;
                    break;
                }
            }
        }
        else
        {
            return false;
        }

        if (isHas)
        {
            if (figureNext != null)
            {
                Figures.Remove(figureNext);
            }

            figure.Coordinate = nextCoordinate;
            switch (CurrentColor)
            {
                case Color.Black:
                    CurrentColor = Color.White;
                    break;
                case Color.White:
                    CurrentColor = Color.Black;
                    break;
            }

            CheckCheck(this);

            return true;
        }

        return false;
    }

    private void CheckCheck(Board board)
    {
        var king1 = board.Figures.First(n => n.GetType() == typeof(King));
        var king2 = board.Figures.Last(n => n.GetType() == typeof(King));
        Print();
        foreach (var figure in board.Figures)
        {
            figure.CreatePossibleMove(board);
            foreach (var coordinate in figure.PossibleMoves)
            {
                if (coordinate == king1.Coordinate && figure.Color != king1.Color)
                {
                    board.StatusGame = StatusGame.Check;
                    return;
                }

                if (coordinate == king2.Coordinate && figure.Color != king2.Color)
                {
                    board.StatusGame = StatusGame.Check;

                    return;
                }
            }

            board.StatusGame = StatusGame.Normal;
        }
    }

    public void Print()
    {
        var colorDelta = '♚' - '♔';
        Figure figure;
        for (int i = 7; i >= 0; i--)
        {
            for (int j = 0; j < 8; j++)
            {
                figure = Figures.FirstOrDefault(n => n.Coordinate == new Coordinate(i, j));
                if (figure != null)
                {
                    if (figure.Color == Color.Black)
                    {
                        Console.Write((char)(figure.Symbol + colorDelta));
                    }
                    else
                    {
                        Console.Write(figure.Symbol);
                    }
                }
                else
                {
                    Console.Write(i + ":" + j);
                }

                Console.Write("\t");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();
    }

    private void CreateFigures(int x, int y, Color color, TypeFigure typeFigure)
    {
        Coordinate coordinate = new(x, y);
        switch (typeFigure)
        {
            case TypeFigure.Rook:
                var rook = new Rook(coordinate, color);
                Figures.Add(rook);
                break;
            case TypeFigure.Knight:
                var knight = new Knight(coordinate, color);
                Figures.Add(knight);
                break;
            case TypeFigure.Bishop:
                var bishop = new Bishop(coordinate, color);
                Figures.Add(bishop);
                break;
            case TypeFigure.Queen:
                var queen = new Queen(coordinate, color);
                Figures.Add(queen);
                break;
            case TypeFigure.King:
                var king = new King(coordinate, color);
                Figures.Add(king);
                break;
            case TypeFigure.Pawn:
                var pawn = new Pawn(coordinate, color);
                Figures.Add(pawn);
                break;
        }
    }
}
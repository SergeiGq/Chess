using Chess;
using Chess.Figures;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace TestChess;

public class Tests
{
    [Test]
    public void TestCreateBoard()
    {
        var board = new Board();
        board.Print();
        That(board.Figures, Has.Count.EqualTo(32));
    }

    [Test]
    public void TestRookWhiteFigure()
    {
        var board = new Board();

        var x = board.Figures.First(n => n.Coordinate == new Coordinate(0, 0));
        That(x.Color, Is.EqualTo(Color.White));
    }

    [Test]
    public void CheckMovesPawn()
    {
        var board = new Board();
        var firstOrDefault = board.Figures.First(n => n.Coordinate == new Coordinate(1, 0));
        firstOrDefault.CreatePossibleMove(board);
        That(firstOrDefault.PossibleMoves.Count > 0, Is.True);
    }

    [Test]
    public void MovePawn()
    {
        var board = new Board();

        board.MoveWithCheck(new Coordinate(1, 0), new Coordinate(2, 0));
        var x = board.Figures.First(n => n.Coordinate == new Coordinate(2, 0));
        That(x, Is.Not.Null);
    }

    [Test]
    public void MoveKnight()
    {
        var board = new Board();
        var knight = board.Figures.First(n => n.GetType() == typeof(Knight) && n.Color == Color.White);
        var nextCoordinate = new Coordinate(knight.Coordinate.X + 2, knight.Coordinate.Y + 1);
        board.MoveWithCheck(knight.Coordinate, nextCoordinate);
        var x = board.Figures.First(n => n.Coordinate == nextCoordinate);
        That(x, Is.Not.Null);
    }

    [Test]
    public void MovePawnBlack()
    {
        var board = new Board();
        board.MoveWithCheck(new Coordinate(1, 0), new Coordinate(3, 0));
        board.MoveWithCheck(new Coordinate(6, 1), new Coordinate(4, 1));
        var x = board.Figures.First(n => n.Coordinate == new Coordinate(4, 1));
        That(x, Is.Not.Null);
    }

    [Test]
    public void MoveKillPawn()
    {
        var board = new Board();
        board.MoveWithCheck(new Coordinate(1, 0), new Coordinate(3, 0));
        board.MoveWithCheck(new Coordinate(6, 1), new Coordinate(4, 1));
        board.MoveWithCheck(new Coordinate(3, 0), new Coordinate(4, 1));
        That(board.Figures.Count, Is.EqualTo(31));
        That(board.StatusGame, Is.EqualTo(StatusGame.Normal));
    }

    [Test]
    public void CheckCheck()
    {
        var board = new Board();
        That(board.MoveWithCheck(new Coordinate(1, 5), new Coordinate(3, 5)));
        That(board.MoveWithCheck(new Coordinate(6, 4), new Coordinate(4, 4)));
        That(board.MoveWithCheck(new Coordinate(1, 4), new Coordinate(3, 4)));
        That(board.MoveWithCheck(new Coordinate(7, 3), new Coordinate(3, 7)));
        That(board.StatusGame, Is.EqualTo(StatusGame.Check));
    }
  
    [Test]
    public void CheckMat()
    {
        var board = new Board();
        That(board.MoveWithCheck(new Coordinate(1, 5), new Coordinate(2, 5)));
        That(board.MoveWithCheck(new Coordinate(6, 4), new Coordinate(4, 4)));
        That(board.MoveWithCheck(new Coordinate(1, 6), new Coordinate(3, 6)));
        That(board.MoveWithCheck(new Coordinate(7, 3), new Coordinate(3, 7)));
        That(board.StatusGame, Is.EqualTo(StatusGame.Mat));
    }
}
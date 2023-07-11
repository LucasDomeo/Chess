using System;
using Board;
using Project_Xadres;
using Chess;

namespace ProjectXadres
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();
                while (!match.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);


                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadChessPosition().toPosition();
                        match.ValidatingOriginPosition(origin);

                        bool[,] posiblepositions = match.boardd.piece(origin).PosibleMoviments();

                        Console.Clear();
                        Screen.PrintBoard(match.boardd, posiblepositions);


                        Console.WriteLine();
                        Console.Write("Destination: ");
                        Position destiny = Screen.ReadChessPosition().toPosition();
                        match.ValidatingDestinyPosition(origin, destiny);

                        match.PerformMove(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
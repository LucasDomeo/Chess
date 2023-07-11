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
                    Console.Clear();
                    Screen.PrintBoard(match.boardd);


                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().toPosition();

                    bool[,] posiblepositions = match.boardd.piece(origin).PosibleMoviments();

                    Console.Clear();
                    Screen.PrintBoard(match.boardd, posiblepositions);

                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadChessPosition().toPosition();

                    match.ExecuteMov(origin, destiny);
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
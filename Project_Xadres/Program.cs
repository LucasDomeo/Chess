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
                    Console.WriteLine("Origin: ");
                    Position origin = Screen.ReadChessPosition().toPosition();

                    Console.WriteLine("Destiny: ");
                    Position destiny = Screen.ReadChessPosition().toPosition();
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
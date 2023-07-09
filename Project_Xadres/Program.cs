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
                boardd bd = new boardd(8, 8);

                bd.SetPiece(new Horse(bd, Color.Black), new Position(0, 0));
                bd.SetPiece(new King(bd, Color.White), new Position(5, 1));

                Screen.PrintBoard(bd);

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
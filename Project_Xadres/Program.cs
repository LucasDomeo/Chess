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
            boardd bd = new boardd(8, 8);

            bd.SetPiece(new Horse(bd, Color.Black), new Position(0, 0));

            Screen.PrintBoard(bd); 

            Console.ReadLine();

        }
    }
}
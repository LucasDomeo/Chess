using System;
using Board;
using Project_Xadres;

namespace ProjectXadres
{
    class Program
    {
        static void Main(string[] args)
        {
            boardd bd = new boardd(8, 8);

            Screen.PrintBoard(bd); 

            Console.ReadLine();

        }
    }
}
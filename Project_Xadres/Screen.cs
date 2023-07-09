using System;
using Board;

namespace Project_Xadres
{
    class Screen
    {
        public static void PrintBoard(boardd bd)
        {
            for (int i = 0;i < bd.line; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0;j < bd.column; j++)
                {
                    if (bd.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Screen.PrintColor(bd.piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintColor(Pieces pieces) 
        { 
            if(pieces.color == Color.White)
            {
                Console.Write(pieces);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(pieces);
                Console.ForegroundColor = aux;
            }
        }
    }
}

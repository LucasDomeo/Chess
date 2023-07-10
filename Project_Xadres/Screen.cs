using System;
using Board;
using Chess;

namespace Project_Xadres
{
    class Screen
    {
        public static void PrintBoard(board b)
        {
            for (int i = 0; i < b.line; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0;j < b.column; j++)
                {
                    if (b.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Screen.PrintColor(b.piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static chessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new chessPosition(column, line);
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

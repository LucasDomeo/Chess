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
                    Screen.PrintColor(b.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintBoard(board b, bool[,] PosiblePositions)
        {
            ConsoleColor originalBack = Console.BackgroundColor;
            ConsoleColor AlteredBack = ConsoleColor.Red;

            for (int i = 0; i < b.line; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < b.column; j++)
                {
                    if (PosiblePositions[i, j])
                    {
                        Console.BackgroundColor = AlteredBack;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBack;
                    }
                    Screen.PrintColor(b.piece(i, j));
                    Console.BackgroundColor = originalBack;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = originalBack;
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
            if (pieces == null)
            {
                Console.Write("- ");
            }
            else
            {

                if (pieces.color == Color.White)
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
                Console.Write(" ");
            }
        }
    }
}

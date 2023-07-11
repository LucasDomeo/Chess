using System.Collections.Generic;
using System.Text.RegularExpressions;
using Board;
using Chess;

namespace Project_Xadres
{
    class Screen
    {
        public static void PrintMatch(ChessMatch match)
        {
            PrintBoard(match.boardd);
            Console.WriteLine();
            PrintCapPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.turn);
            Console.WriteLine("Waiting play: " + match.CurrentPlayer);
        }

        public static void PrintCapPieces(ChessMatch match)
        {
            Console.WriteLine("  Captured Pieces");
            Console.Write("White: ");
            PrintConj(match.capturedpieces(Color.White));
            Console.Write("Black: ");
            PrintConj(match.capturedpieces(Color.Black));
            Console.WriteLine();
        }

        public static void PrintConj(HashSet<Pieces> conj)
        {
            Console.Write("[");
            foreach(Pieces x in conj)
            {
                Console.Write(x + " ");
            }
            Console.Write("]  ");
        }

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

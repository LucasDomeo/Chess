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
                for (int j = 0;j < bd.column; j++)
                {
                    if (bd.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(bd.piece(i, j) + " ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}

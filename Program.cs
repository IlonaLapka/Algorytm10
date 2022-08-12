using System;

namespace Algorytm10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj pozycje pierwszej krolowej: ");
            string position = Console.ReadLine();

            int X = position[0] - 96;
            int Y = position[1] - '0';
            FindGoodPositions(X, Y);
        }

        static void FindGoodPositions(int X, int Y)
        {
            bool[,] chess = new bool[9, 9];
            for (int i = 8; i > 0; i--)
            {
                for (int j = 1; j < 9; j++)
                {
                    if(i == Y && j == X) chess[j, i] = false;
                    else if(i == Y || j == X) chess[j, i] = false;
                    else chess[j, i] = true;
                }
            }

            int x = X;
            int y = Y;
            //Lewy dol
            while (x > 0 && y > 0)
            {
                chess[x--, y--] = false;
            }

            x = X;
            y = Y;
            //lewa gora
            while (x > 0 && y < 9)
            {
                chess[x--, y++] = false;
            }

            x = X;
            y = Y;
            //prawa gora
            while (x < 9 && y < 9)
            {
                chess[x++, y++] = false;
            }

            x = X;
            y = Y;
            //prawy dol
            while (x < 9 && y > 0)
            {
                chess[x++, y--] = false;
            }

            char letter = 'a';
            for (int i = 8; i >= 0; i--)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        Console.Write("  ");
                        continue;
                    }
                    if (j == 0)
                    {
                        Console.Write(i + " ");
                        continue;
                    }
                    if(i == 0)
                    {
                        Console.Write(letter++ + " ");
                        continue;
                    }
                    
                    if (chess[j, i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (i == Y && j == X)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write((chess[j, i] ? 1 : 0) + " ");
                    
                }
                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }
}

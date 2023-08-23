using System;
using System.Buffers;
using System.ComponentModel;
using System.Runtime.ExceptionServices;

namespace MyApp
{
    class Program
    {
        class Map
        {
            int[,] tiles =
            {
                { 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1 }
            };

            public void Render()
            {
                ConsoleColor defaultColor =  Console.ForegroundColor;
                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    for (int x = 0; x < tiles.GetLength(0); x++)
                    {
                        if (tiles[y, x] == 1)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\u25cf");
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = defaultColor;
            }
        }

        static void Main(string[] args)
        {
            int[,] arr1 = new int[2, 3];
            arr1[0, 0] = 1;
            arr1[0, 1] = 2;
            arr1[0, 2] = 3;
            arr1[1, 0] = 4;
            arr1[1, 1] = 5;
            arr1[1, 2] = 6;

            int[,] arr2 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] arr3 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] arr4 = { { 1, 2, 3 }, { 4, 5, 6 } };

            Map map = new Map();
            map.Render();
        }
    }
}
using System;
using System.Collections.Generic;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            //list[0] = 1; 
            list.Add(1);

            for (int i = 2; i < 6; i++)
            {
                list.Add(i);
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine();

            list.Insert(0, -1);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine();

            list.RemoveAt(1);


            foreach (int value in list)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine();
        }
    }
}
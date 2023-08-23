using System;
using System.Buffers;
using System.ComponentModel;

namespace MyApp 
{
    class Program
    { 
        static void Main(string[] args)
        {
            int[] arr1 = new int[5];
            arr1[0] = 1;
            arr1[1] = 2;
            arr1[2] = 3;
            arr1[3] = 4;
            arr1[4] = 5;

            int[] arr2 = new int[5] { 1, 2, 3, 4, 5 };
            int[] arr3 = new int[] { 1, 2, 3, 4, 5 };
            int[] arr4 = { 1, 2, 3, 4, 5 };


            for (int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine(arr1[i]);
            }

            foreach (int i in arr2)
            {
                Console.WriteLine(i);
            }

            int[] array = new int[3] { 10, 20, 30 };
            int[] refer = array;

            refer[0] = 50;

            foreach(int value in array)
            {
                Console.WriteLine(value);
            }


        }
    }
}
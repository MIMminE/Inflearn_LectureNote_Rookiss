using System;
using System.Buffers;
using System.ComponentModel;

namespace MyApp 
{
    class Program
    { 
        static void Main(string[] args)
        {
            int base10 = 10;
            int base2 = 0b10;
            int base16 = 0x10;

            Console.WriteLine(base10);
            Console.WriteLine(base2);
            Console.WriteLine(base16);
        }
    }
}
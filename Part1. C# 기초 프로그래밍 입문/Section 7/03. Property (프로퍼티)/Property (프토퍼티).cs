using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace MyApp
{
    class Type
    {
        private int _typeNumber;

        public int typeNumber
        {
            get { return  _typeNumber; }
            set { this._typeNumber = value; }
        }

        // 자동구현 Property
        public int typeNumber2 { get; set; } = 100; // C# 7.0부터 사용 가능한 초기화 기능

    }
    class Program
    {
        static void Main(string[] args)
        {
            Type type = new Type();

            Console.WriteLine(type.typeNumber2);

            type.typeNumber = 1;
            type.typeNumber2 = 2;

            Console.WriteLine(type.typeNumber);
            Console.WriteLine(type.typeNumber2);
        }
    } 
}
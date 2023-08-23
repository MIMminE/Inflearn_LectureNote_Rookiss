using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace MyApp
{
    class Monster 
    {
        public string monsterName;

        public Monster()
        {
            this.monsterName = "Default";
        }

        public Monster(string monsterName)
        {
            this.monsterName = monsterName;
        }
    }

    class MyList<T>
    {
        public T[] arr = new T[10];    

        public T getItem(int i)
        {
            return arr[i];
        }
    }

    class TypeClass <T> where T : new()
    {
        
    }

    class Program
    {
        static void FindFirst<T>(T[] list)
        {
            Console.WriteLine(list[0]);
        }

        static void Main(string[] args)
        {
            MyList<Monster> list = new MyList<Monster>();
            list.arr[0] = new Monster("Skeleton");
            string monsterName = list.getItem(0).monsterName;

            int[] arr = new int[3] { 1, 2, 3};
            FindFirst<int>(arr);

            TypeClass<Monster> mon = new TypeClass<Monster>();
        }
    }
}
using System;
using System.Collections.Generic;

namespace MyApp
{
    class Monster
    {
        static int monsterSerialNum = 0;
        public int monsterId;
        public Monster() { monsterSerialNum++; monsterId = monsterSerialNum; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Monster> dic = new Dictionary<int, Monster>();
            dic.Add(1, new Monster());
            dic.Add(2, new Monster());
            //Console.WriteLine(dic[1].monsterId);
            Monster mon;
            if (dic.TryGetValue(1, out mon))
            {
                Console.WriteLine(mon.monsterId);
            }
            dic.Remove(1);

            dic.Clear();
        }
    }
}
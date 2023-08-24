using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace MyApp
{
    enum Status{
        None,
        Alive,
        Invincible
    }


    class Monster
    {
        static int counter = 1;
        private int _id;
        private int _hp;
        private Status status;

        public void SetHp(int hp)
        {
            if (status != Status.Invincible)
            {
                _hp = hp;
            }
            else
            {
                Console.WriteLine("무적상태입니다.");
            }
        }

        public int GetHp() { return this._hp; }


        public Monster()
        {
            _id = counter++;
            _hp = 20;
            status = Status.Invincible;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Monster monster = new Monster();
            monster.SetHp(100);
            
        }
    } 
}
using System;
using System.Runtime.CompilerServices;

namespace MyApp
{
    class Player
    {
        private int id;
        protected int hp;
        protected int attack;

        public void ChangeId(int value)
        {
            this.id = value;
        }

        public void ShowInfo()
        {
            Console.WriteLine(this.id);
            Console.WriteLine(this.hp);
            Console.WriteLine(this.attack);
        }
    }

    class Knight : Player
    {
        public Knight(int value)
        {
            this.hp = 100;
            this.attack = 10;

            ChangeId(value);
        }
    }


    class program
    {
       static void Main(string[] args)
       {
            Knight knight = new Knight(120);
            knight.ShowInfo();
       }
    }
}
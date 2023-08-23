using System;

namespace MyApp
{
    // OOP의 상속성 

    class Player
    {
        static public int counter = 1;
        public int id;
        public int hp;
        public int attack;

        public Player()
        {
            Console.WriteLine("Player 생성자 호출!");
        }

        public Player(int hp)
        {
            this.hp = hp;
            Console.WriteLine("Player hp 생성자 호출");
        }

    }

    class Knight : Player
    {
        public Knight() : base(10)
        {
            Console.WriteLine("Knight 생성자 호출!");
            Console.WriteLine(this.hp);
        }

    }

    class program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight();   
        }
    }
}
using System;
using System.Security.Cryptography.X509Certificates;

namespace MyApp
{
    class Knight
    {
        public int hp;
        public int attack;
    }
    class Program
    {

        class Knight
        {
            public int hp;
            public int attack;

            public Knight()
            {
                hp = 100;
                attack = 10;
                Console.WriteLine("기본 생성자입니다!");
            }

            public Knight(int hp) : this()
            {
                this.hp = hp;
                Console.WriteLine("hp 생성자입니다!");
            }
            
            public Knight(int hp, int attack) : this(hp)
            {
                this.attack = attack;
                Console.WriteLine("hp, attack 생성자입니다!");
            }


            public void ShowStat() {
                Console.WriteLine($"hp : {this.hp}, attack : {this.attack}");
            }
        }
        static void Main(string[] args)
        {
            int hp = 1000;
            int attack = 10;
            Knight knight = new Knight(hp, attack);
            knight.ShowStat();
        }
    }
}
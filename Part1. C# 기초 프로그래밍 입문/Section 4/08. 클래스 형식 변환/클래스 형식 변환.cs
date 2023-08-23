using System;
using System.Runtime.CompilerServices;

namespace MyApp
{
    class Player
    {
        protected int hp;
        protected int attack;

        protected Player(int hp, int attack)
        {
            this.hp = hp;
            this.attack = attack;
        }

        static public void ShowInfo(Player player)
        {
            Console.WriteLine($"hp:{player.hp} attack:{player.attack}");
            bool isMage = (player is Mage);
            if (isMage)
            {
                Mage mage = (Mage)player;
                Console.WriteLine($"mp:{mage.getMp()}");    
            }
            else if(player is Knight) 
            { 
                Knight knight = (Knight)player;
                Console.WriteLine($"str:{knight.getStr()}");
            }
            
        }

        static public void ShowInfoVer2(Player player)
        {
            Console.WriteLine($"hp:{player.hp} attack:{player.attack}");
            Mage mage = player as Mage;
            Knight knight = player as Knight;  
            if (mage != null)
            {
                Console.WriteLine($"mp :: {mage.getMp()}");
            }
            else if (knight  != null)
            {
                Console.WriteLine($"str :: {knight.getStr()}");
            }
        }
    }

    class Knight : Player
    {
        private int str;

        public Knight(int hp, int attack) : base(hp, attack)
        {
            this.str = 25;
        }

        public int getStr() { return  str; }
    }

    class Mage : Player
    {
        private int mp;

        public Mage(int hp, int attack) : base(hp, attack)
        {
            this.mp = 250;
        }

        public int getMp(){return this.mp;}
    }

    class program
    {
       static void Main(string[] args)
       {
            Knight knight = new Knight(100, 10);
            //Player.ShowInfo(knight);
            Player.ShowInfoVer2(knight);

            Mage mage = new Mage(70, 15);
            Player.ShowInfo(mage);

        }
    }
}
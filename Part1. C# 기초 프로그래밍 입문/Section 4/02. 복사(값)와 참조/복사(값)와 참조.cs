using System;

namespace MyApp
{
    class Knight
    {
        public int hp;
        public int attack;

        public Knight Clone()
        {
            Knight cloneKnight = new Knight();
            cloneKnight.hp = hp;
            cloneKnight.attack = attack;
            return cloneKnight;
        }
    }

    struct Mage
    {
        public int hp;
        public int attack;
    }

    class Program
    {

        static void KnightKill(Knight knight)
        {
            knight.hp -= 100;
        }

        static void MageKill(Mage mage)
        {
            mage.hp -= 100;
        }

        static void Main(string[] args)
        {
            Knight knight = new Knight();
            knight.hp = 100;
            knight.attack = 10;
            Knight knight2 = knight;
            Knight knight3 = knight.Clone();

            KnightKill(knight);

            Mage mage;
            mage.hp = 100;
            mage.attack = 10;

            Mage mage2 = mage;
            mage2.hp = 70;

            MageKill(mage);

            Console.WriteLine(mage.hp);
            Console.WriteLine(mage2.hp);
            Console.WriteLine(knight.hp);
            Console.WriteLine(knight2.hp);
            Console.WriteLine(knight3.hp);
        }
    }
}
using System;

namespace MyApp
{
    class Knight
    {
        public int hp;
        public int attack;

        public void Move()
        {
            Console.WriteLine("이동합니다.");
        }

        public void Attack()
        {
            Console.WriteLine("공격합니다.");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight();
            knight.hp = 100;
            knight.attack = 10;

            Console.WriteLine($"생성된 캐릭터의 hp는 {knight.hp}입니다.");
            Console.WriteLine($"생성된 캐릭터의 공격력은 {knight.attack}입니다.");

            knight.Move();
            knight.Attack();
        }
    }
}
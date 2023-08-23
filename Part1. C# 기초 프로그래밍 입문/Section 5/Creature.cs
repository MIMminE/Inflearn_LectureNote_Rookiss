using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    class Creature
    {
        protected int hp;
        protected int damage;
        protected bool alive;

        public static void Battle(Creature battleCreature1, Creature battleCreature2)
        {
            while (battleCreature1.alive && battleCreature2.alive)
            {
                battleCreature1.Attack(battleCreature2);
                if (!(battleCreature2.alive))
                {
                    Console.WriteLine("승리했습니다.");
                    Console.WriteLine($"남은 HP : {battleCreature1.hp}\n");
                    break;
                }
                battleCreature2.Attack(battleCreature1);
            }

            battleCreature1.ShowInfo();
            battleCreature2.ShowInfo();

            Console.WriteLine("\n");
        }


        public virtual void Attack(Creature target) { }

        protected void Die()
        {
            this.alive = false;
        }

        public void Damage(int inputDamgage) 
        {
            this.hp -= inputDamgage;
            if (this.hp <= 0) { this.Die(); }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"hp : {hp} damage : {damage} alive : {alive}");
        }

        protected void AttacksNum(Creature target, int num)
        {
            for (int i = 0; i < num; i++)
            {
                target.Damage(this.damage);
            }
        }
        public bool GetAlive()
        {
            return this.alive;
        }

    }

    class Player : Creature
    {
        protected Player(int hp, int damage)
        {
            base.hp = hp;
            base.damage = damage;  
            base.alive = true;
        }
    }

    class Monster : Creature
    {
        static public Monster CreateMonster()
        {
            Monster monster = null;
            Random rand = new Random();
            int randValue = rand.Next(1, 4);

            switch (randValue)
            {
                case 1:
                    Console.WriteLine("Orc가 생성되었습니다.");
                    monster = new Orc();
                    break;
                case 2:
                    Console.WriteLine("Skeleton가 생성되었습니다.");
                    monster = new Skeleton();
                    break;
                case 3:
                    Console.WriteLine("Harpy가 생성되었습니다.");
                    monster = new Harpy();
                    break;
                default:
                    break;
            }
            
            return monster;
        }
        protected Monster(int hp, int damage)
        {
            base.hp = hp;
            base.damage = damage;
            base.alive = true;
        }
    }
}

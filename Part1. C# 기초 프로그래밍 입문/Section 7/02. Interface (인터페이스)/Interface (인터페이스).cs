using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace MyApp
{
    abstract class Monster
    {
        public virtual void shout() 
        {
            Console.WriteLine("Shout1");
        }

        public abstract void shout2();
    }

    class Orc : Monster 
    {
        public override void shout2()
        {
            Console.WriteLine("Shout2");
        }
    }
    
    interface IFlyable
    {
        void Fly();
    }

    class FlyableOrc : Orc, IFlyable // 기본 클래스의 다중 상속 불가능
    {
        public void Fly()
        {
            Console.WriteLine("Orc Fly");
        }

        public override void shout2()
        {
            Console.WriteLine("FlyableOrc Shout!");
        }
    }

    class Program
    {
        static void DoFly(IFlyable flyable)
        {
            flyable.Fly();
        }

        static void Main(string[] args)
        {
            Orc orc = new Orc();
            orc.shout();
            orc.shout2();

            FlyableOrc flyableOrc = new FlyableOrc();
            flyableOrc.Fly();


            IFlyable flyable = new FlyableOrc();

            DoFly(flyableOrc);
        }
    }
}
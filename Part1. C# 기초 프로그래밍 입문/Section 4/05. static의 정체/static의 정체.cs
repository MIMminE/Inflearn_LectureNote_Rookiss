using System;

namespace MyApp 
{
    class Knigth
    {
        static public int counter = 1;

        public int id;
        public int hp;
        public int attack;


        static public void PlusConuter()
        {
            counter++;
        }

        static public Knigth CreateKnight()
        {
            Knigth knigth = new Knigth();
            knigth.hp = 100;
            knigth.attack = 10;
            return knigth;
        }

        public Knigth()
        {
            id = counter;
            counter++;

            hp = 100;
            attack = 10;
            Console.WriteLine($"기본 생성자입니다. id번호는 {id}");
        }
    }


    class Program
    { 
        static void Main(string[] args)
        {
            Knigth knight1 = new Knigth();
            Knigth.PlusConuter();
            Knigth knight2 = new Knigth();
            Knigth knight3 = new Knigth();
            Knigth knight4 = Knigth.CreateKnight();
        
        }
    }
}
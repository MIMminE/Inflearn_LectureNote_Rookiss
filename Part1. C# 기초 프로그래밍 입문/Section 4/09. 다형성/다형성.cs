using System;

namespace MyApp
{
    class Player
    {
        public virtual void Move()
        {
            Console.WriteLine("Player 이동!");
        }
    }

    class Knight : Player
    {
        public override void Move()
        {
            Console.WriteLine("Knight 이동!");
        }

    }

    class Mage : Player
    {
        public override void Move()
        {
            Console.WriteLine("Mage 이동!");
        }
    }

    class HighKnight : Knight
    {
        public override void Move()
        {
            base.Move();
            Console.WriteLine("HighKnight 이동!");
        }
    }


    class program
    {
        static public void PlayerMove(Player player)
        {
            player.Move();
        }

        static void Main(string[] args)
        {
            Knight knight = new Knight();
            PlayerMove(knight);

            HighKnight highKnight = new HighKnight();
            PlayerMove(highKnight);
        }
    }
}
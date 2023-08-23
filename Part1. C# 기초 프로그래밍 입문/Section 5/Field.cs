using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    class Field
    {
        protected bool active;
        protected bool battleOK;

        protected Field(bool battleOk)
        {
            active = false;
            this.battleOK = battleOk;
        }

        public virtual void EnterField() 
        {
            this.active = true;
        }

        public virtual Player ProcessField() { return null; }
    }

    class Lobby : Field
    {
        public Lobby() : base(false) { }
        public override void EnterField()
        {
            base.EnterField();
            Console.WriteLine("로비에 입장했습니다.");
        }
        public override Player ProcessField()
        {
            Player player = null;
            Console.WriteLine("직업을 선택하세요\n[1]Knight \n[2]Mage \n[3]Archer");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    player = new Knight();
                    break;
                case "2":
                    player = new Mage();
                    break;
                case "3":
                    player = new Archer();
                    break;
                default:
                    break;
            }
            return player;
        }
    }   

    class BattleField : Field
    {
        private Monster monster;
        public BattleField() : base(true) { }
        public override void EnterField()
        {
            base.EnterField();
            Console.WriteLine("배틀 필드에 입장했습니다.");
        }
        public void ProcessField(Player player)
        {
            monster = Monster.CreateMonster();
            Random rand = new Random();
            Console.WriteLine("[1] 전투개시");
            Console.WriteLine("[2] 회피시도");
            string input = Console.ReadLine();
            if (input == "1")
            {
                Creature.Battle(player, monster);
            }
            else if (input == "2")
            {
                Console.WriteLine("회피시도!");
            }
            else
            {
                Console.WriteLine("잘못입력");
            }
        }
    }

    class Town : Field
    {
        public Town() : base(false) { }
        public override void EnterField()
        {
            base.EnterField();
            Console.WriteLine("마을에 입장했습니다.");
        }

        public override Player ProcessField()
        {
            while(true)
            {
                Console.WriteLine("[1] 배틀 필드로 나가기.");
                Console.WriteLine("[2] 마을에 머물기");
                string input = Console.ReadLine();
                if (input == "1")
                    break;
            }
            return null;
        }
    }
}

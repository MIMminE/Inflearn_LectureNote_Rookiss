using static CSharp.Program;

namespace CSharp
{
    class Program
    {
        public enum ClassType
        {
            None,
            Knight,
            Archer,
            Mage
        }

        struct Player
        {
            public int hp;
            public int attack;
        }

        public enum MonsterType
        {
            None,
            Slime,
            Orc,
            Skeleton
        }

        struct Monster
        {
            public int hp;
            public int attack;
        }


        static ClassType ChooseClass()
        {
            Console.WriteLine("직업을 선택하세요");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");

            int choose = Convert.ToInt32(Console.ReadLine());

            if (choose >= Enum.GetValues(typeof(ClassType)).Length)
                return ClassType.None;

            ClassType[] enumArray = (ClassType[])Enum.GetValues(typeof(ClassType));
            return enumArray[choose];
        }

        static void CreatePlayer(ClassType classType, out Player player)
        {
            switch (classType)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.Archer:
                    player.hp = 75;
                    player.attack = 12;
                    break;
                case ClassType.Mage:
                    player.hp = 50;
                    player.attack = 15;
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
        }

        static void CreateRandomMonster(out Monster monster)
        {
            Random random = new Random();
            MonsterType[] monsterTypeValuse = (MonsterType[])Enum.GetValues(typeof(MonsterType));
            MonsterType randMonsterType = monsterTypeValuse[random.Next(1, 4)];

            MonsterType mon = (MonsterType)1;
            Console.WriteLine(mon );
            switch (randMonsterType)
            {
                case MonsterType.Slime:
                    Console.WriteLine("슬라임이 스폰되었습니다.");
                    monster.attack = 2;
                    monster.hp = 20;
                    break;

                case MonsterType.Orc:
                    Console.WriteLine("오크가 스폰되었습니다.");
                    monster.attack = 4;
                    monster.hp = 40;
                    break;

                case MonsterType.Skeleton:
                    Console.WriteLine("스켈레톤이 스폰되었습니다.");
                    monster.attack = 3;
                    monster.hp = 50;
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;

            }
        }

        static void EnterField()
        {
            Console.WriteLine("필드에 접속했습니다");

            Monster monster;
            CreateRandomMonster(out monster);

            // 랜덤으로 1~3 몬스터 중 하나를 리스폰
            // [1] 전투 모드
            // [2] 일정 확률로 마을로 도망
        }

        static void EnterGame()
        {
            while (true)
            {

                Console.WriteLine("게임에 접속했습니다");
                Console.WriteLine("[1] 필드로 간다");
                Console.WriteLine("[2] 로비로 돌아가기");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    //필드로 이동
                    EnterField();
                }
                else if (input == "2")
                {
                    // 로비로 이동
                    break;
                }

            }

        }


        static void Main(string[] args)
        {
            ClassType chooseType = ClassType.None;
            while (chooseType == ClassType.None)
            {
                chooseType = ChooseClass();
                if(chooseType != ClassType.None)
                {
                    Player player;
                    CreatePlayer(chooseType, out player);
                    EnterGame();
                }
            }
            
        }
    }
}
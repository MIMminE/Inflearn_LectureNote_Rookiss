using System;

/*
 * 
 * 1. 직업을 선택 :: (Knight, Archer, Mage)
 * 2. 필드 입장 여부 선택
 * 3. 몬스터 랜덤 생성 :: (Oak, Skeleton, harpy)
 * 4. 전투 돌입 여부 선택 :: (33% 확률로 회피 가능 선택지 제공)
 * 5. 전투 돌입 -> 플레이어와 몬스터 순차적으로 공격
 * 6. 플레이어 승리 시 몬스터 리스폰 및 전투 돌입 여부 선택...
 * 7. 플레이어 체력 고갈 시 '패배했습니다' 출력 후 게임 종료
 *
 *
 * < 프로그래밍 고려 사항 > 
 * 1. ret, out 예약어 활용할 것
 * 2. 함수 위주의 절차지향 프로그래밍 기법으로 작성할 것
 * 3. 구조체를 활용하여 몬스터와 플레이어의 속성 정의할 것
 */

namespace MyApp
{
    class Program
    {
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3
        }
        enum MonsterType
        {
            None = 0,
            Oak = 1,
            Skeleton = 2,
            harpy = 3
        }

        struct Player
        {
            public int hp;
            public int attack;
            public ClassType class_code;
        }

        struct Monster
        {
            public int hp;
            public int attack;
            public MonsterType monster_code;
        }

        // 클래스에 대한 선택만 받는 메소드와 선택된 메소드를 이용하여 플레이어 캐릭터를 생성하는 메소드를 따로 두어
        // out 예약어에 대한 실습을 진행해보자.

        static void ChoiceClass(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("직업을 선택하세요.\n" +
                    "[1] Knight\n" +
                    "[2] Archer\n" +
                    "[3] Mage");
                // 강사님은 Console.WriteLine를 여러 개 사용했지만, 개행문자(\n)를 사용해도 무관하다 !
                // WriteLine 메소드는 개행 기능을 포함하고 있는 모양이다. 

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        player.hp = 100;
                        player.attack = 10;
                        player.class_code = ClassType.Knight;
                        break;
                    case "2":
                        player.hp = 75;
                        player.attack = 12;
                        player.class_code = ClassType.Archer;
                        break;
                    case "3":
                        player.hp = 50;
                        player.attack = 15;
                        player.class_code = ClassType.Mage;
                        break;
                    default:
                        break;
                }
                if (choice == "1" || choice == "2" || choice == "3")
                {
                    break;
                }
            }
        }

        static void EnterFeild(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("필드에 입장하시겠습니까?\n" +
                    "[1] YES\n" +
                    "[2] No");
                string selectEnter = Console.ReadLine();

                if (selectEnter == "1")
                {
                    Console.WriteLine("필드에 입장합니다!");
                    RespawnMonster(ref player); 
                    break;
                }
            }
        }
        static void RespawnMonster(ref Player player)
        {
            while (true)
            {
                Random rand = new Random();
                int ranValue = rand.Next(1, 4);

                Monster monster;

                switch (ranValue)
                {
                    case 1:
                        Console.WriteLine("Oak가 생성되었습니다. 전투를 진행하시겠습니까?");
                        monster.hp = 50;
                        monster.attack = 3;
                        monster.monster_code = MonsterType.Oak;
                        SelectBattle(ref player, ref monster);
                        break;
                    case 2:
                        Console.WriteLine("Skeleton가 생성되었습니다.");
                        monster.hp = 40;
                        monster.attack = 4;
                        monster.monster_code = MonsterType.Skeleton;
                        SelectBattle(ref player, ref monster);
                        break;
                    case 3:
                        Console.WriteLine("harpy가 생성되었습니다.");
                        monster.hp = 30;
                        monster.attack = 5;
                        monster.monster_code = MonsterType.harpy;
                        SelectBattle(ref player, ref monster);
                        break;
                    default:
                        break;
                }
                if (player.hp <= 0)
                    break;
            }
            
        }

        static void SelectBattle(ref Player player, ref Monster monster)
        {
            string input = null;

            while(input != "1" || input != "2")
            {
                Console.WriteLine("[1] 전투돌입 \n[2] 회피시도");
                input = Console.ReadLine();
                if (input == "2")
                {
                    Random rand = new Random();
                    int randValue = rand.Next(0, 3);

                    if (randValue == 0)
                    {
                        Console.WriteLine("회피에 성공했습니다.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("회피에 실패했습니다. 전투에 돌입합니다.");
                        Battle(ref player, ref monster);
                        return;
                    }
                }
                else if(input == "1")
                {
                    Console.WriteLine("전투에 돌입합니다.");
                    Battle(ref player, ref monster);
                    return;
                }
            }
        }

        static void Battle(ref Player player, ref Monster monster)
        {
            while(!(monster.hp <= 0 || player.hp <= 0))
            {
                monster.hp -= player.attack;
                if (monster.hp > 0)
                {
                    player.hp -= monster.attack;
                    if (player.hp <= 0)
                    {
                        Console.WriteLine("패배했습니다.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("승리했습니다.");
                    Console.WriteLine($"현재 남은 hp: {player.hp}");
                    break;
                }
            }   
        }

        static void Main(string[] args)
        {
            Player player = new Player();
            ChoiceClass(ref player);
            EnterFeild(ref player);
            Console.WriteLine("게임을 종료합니다.");
        }
    }
}



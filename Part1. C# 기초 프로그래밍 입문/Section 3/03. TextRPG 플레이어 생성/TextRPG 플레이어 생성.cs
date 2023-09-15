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
            switch(classType)
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
                }
            }
            
        }
    }
}
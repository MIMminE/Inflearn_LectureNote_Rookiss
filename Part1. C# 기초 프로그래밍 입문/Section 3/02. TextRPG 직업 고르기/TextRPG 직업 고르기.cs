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

        static public ClassType ChooseClass()
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


        static void Main(string[] args)
        {
            ClassType ChooseType = ClassType.None;
            while (ChooseType == ClassType.None)
            {
                ChooseType = ChooseClass();
            }
            
        }
    }
}
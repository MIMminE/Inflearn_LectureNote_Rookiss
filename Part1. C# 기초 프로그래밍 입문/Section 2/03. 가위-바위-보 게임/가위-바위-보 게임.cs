namespace App
{
    public enum RockPaperScissors
    {
        Rock,
        Paper,
        Scissors
    }

    public enum Result
    {
        Win,
        Lose,
        Draw
    }

    class RockPaperScissorsAI
    {
        static Random rand = new Random();
        static public RockPaperScissors Get()
        {
            int SelectRandValue = rand.Next(0, 3);
            return (RockPaperScissors)Enum.GetValues(typeof(RockPaperScissors)).GetValue(SelectRandValue); 
        }

        static void PrintLog(Result result)
        {
            if (result == Result.Win)
                Console.WriteLine("승리했습니다.");
            else if (result == Result.Lose)
                Console.WriteLine("패배했습니다.");
            else if (result == Result.Draw)
                Console.WriteLine("무승부입니다.");
        }

        static public void Play(RockPaperScissors userSelect, RockPaperScissors computerSelect)
        {
            if(userSelect == RockPaperScissors.Rock)
            {
                switch (computerSelect)
                {
                    case RockPaperScissors.Rock:
                        PrintLog(Result.Draw);
                        break;
                    case RockPaperScissors.Paper:
                        PrintLog(Result.Lose);
                        break;
                    case RockPaperScissors.Scissors:
                        PrintLog(Result.Win);
                        break;
                }
            }
            else if(userSelect == RockPaperScissors.Paper)
            {
                switch (computerSelect)
                {
                    case RockPaperScissors.Rock:
                        PrintLog(Result.Win);
                        break;
                    case RockPaperScissors.Paper:
                        PrintLog(Result.Draw);
                        break;
                    case RockPaperScissors.Scissors:
                        PrintLog(Result.Lose);
                        break;
                }
            }
            else if(userSelect== RockPaperScissors.Scissors)
            {
                switch (computerSelect)
                {
                    case RockPaperScissors.Rock:
                        PrintLog(Result.Lose);
                        break;
                    case RockPaperScissors.Paper:
                        PrintLog(Result.Win);
                        break;
                    case RockPaperScissors.Scissors:
                        PrintLog(Result.Draw);
                        break;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int userSelectNum = Convert.ToInt32(Console.ReadLine());
            RockPaperScissors userSelect = (RockPaperScissors)Enum.GetValues(typeof(RockPaperScissors)).GetValue(userSelectNum);
            Console.WriteLine($"유저의 선택은 {userSelect} 입니다.");

            RockPaperScissors AISelect = RockPaperScissorsAI.Get();
            Console.WriteLine($"컴퓨터의 선택은 {AISelect} 입니다.");

            RockPaperScissorsAI.Play(userSelect, AISelect);
        }
    }
}
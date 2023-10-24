namespace Event
{
    public class InputManager
    {
        public delegate void OnInputKey();
        public event OnInputKey Input;

        static public void ActionA()
        {
            Console.WriteLine("A가 눌렸습니다.");
        }


        public void Update()
        {
            if (Console.KeyAvailable == false)
                return;

            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.A)
            {
                Input();
                //모두에게 알린다
                //여기에 로직을 작성하면 로직의 의존성이 강해지므로 
                //Delegate 문법을 사용하여 함수를 넣어주는 방식이 좋다.
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            InputManager _manager = new InputManager();
            _manager.Input += InputManager.ActionA;
            while (true)
            {
                _manager.Update();
            }
        }
    }
}
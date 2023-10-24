namespace Delegate
{
    // delegate (대리자)

    internal class Program
    {

        //delegate
        //하나의 형식으로 판단, 함수 자체를 인자로 넘겨주는 형식
        //반환:int , 입력:void
        delegate int Onclicked(); 

        static void ButtonPressed(Onclicked clickFunction/*함수 자체를 인자로 넘겨준다 */)
        {
            clickFunction();
            // 버튼이 눌러졌을 때 발생하는 로직
        }
        //하지만 현실적으로 이런식으로는 사용하긴 어렵다
        //많은 함수 사용에 있어 새롭게 로직을 추가하기 보다는 기존 라이브러리에서
        //제공하는 형태로 사용하는 경우가 많다. 
        //버튼이 눌러졌을 때, 호출하고 싶은 함수 자체를 넘겨주어 해당 함수를 실행하는 방식 선택
        //이러한 방식을 콜백 방식이라고 한다. C++의 함수포인터와 느낌이 비슷하다.

        static int TestDelegate()
        {
            Console.WriteLine("Hello delegate");
            return 0;
        }

        static int TestDelegate2()
        {
            Console.WriteLine("Hello delegate2");
            return 0;
        }

        static void Main(string[] args)
        {

            ButtonPressed(TestDelegate);

            // 함수 체이닝도 가능하다.
            Onclicked onclicked = new Onclicked(TestDelegate);
            onclicked += TestDelegate2;
            ButtonPressed(onclicked);

        }

    }
}
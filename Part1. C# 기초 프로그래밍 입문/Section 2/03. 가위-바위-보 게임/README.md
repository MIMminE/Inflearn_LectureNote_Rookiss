# Section 2-3 가위-바위-보 게임

---

## **분기문을 이용한 간단한 게임**

---

> 사용자가 숫자 0 ~ 2 까지 중 하나를 입력하면 컴퓨터와 가위바위보 게임을 할 수 있는 프로그램 코드를 작성한다.  
> 0(Rock) 1(Paper) 2(Scissors)로 처리되며 컴퓨터는 랜덤으로 선택하여 게임의 결과를 화면에 출력한다.  

> 강의와 동일한 코드가 아닌 객체지향 설계 연습을 위한 코드로 작성했음

### **열거형** 

```C#
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
```

> 열거형을 사용하여 가위, 바위, 보에 대한 의미 전달과 게임 승패에 따른 출력 로직을 구분지었다.  
> (사실 이런 작은 규모로 할 때는 굳이 필요하지 않을수도 있지만 연습이니깐..ㅎ)

### **RockPaperScissorAI 클래스**

```C#
class RockPaperScissorsAI
{
    static Random rand = new Random();
    // 컴퓨터가 랜덤으로 가위,바위,보 중 하나를 선택하도록 하기 위한 멤버변수\
    
    static public RockPaperScissors Get(){}
    // 컴퓨터가 랜덤으로 자신이 낼 것을 선택하여 반환해주는 메소드
    
    static void PrintLog(Result result){}
    // 게임 결과에 따른 출력을 위한 메소드
    
    static public void play(RockPaperScissors userSelect, RockPaperScissors computerSelect){}
    // 유저와 컴퓨터의 선택에 따른 게임 결과를 확인하기 위한 메소드
}
```

> 따로 인스턴스를 만들어서 진행하지 않아도 될것으로 보여 static 정적 한정자를 사용한 변수와 메소드를 작성했다.

#### **Get()**

```C#
static public RockPaperScissors Get()
{
    int SelectRandValue = rand.Next(0, 3);
    return (RockPaperScissors)Enum.GetValues(typeof(RockPaperScissors)).GetValue(SelectRandValue); 
}
```

> 열거형 타입을 Array 타입으로 변환한 이후 인덱스 방식으로 값을 뽑아오는 방식으로 구현했다.  
> Enum.GetValues의 인자로 넘겨줄 때는 typeof(enum type) 방식으로 넘겨줘야한다.

**PrintLog()**

```C#
static void PrintLog(Result result)
{
    if (result == Result.Win)
        Console.WriteLine("승리했습니다.");
    else if (result == Result.Lose)
        Console.WriteLine("패배했습니다.");
    else if (result == Result.Draw)
        Console.WriteLine("무승부입니다.");
}
```

> 열거형 타입을 사용하여 조금 더 가독성을 올리기 위해 노력했다. 

**Play**

```C#
static public void play(RockPaperScissors userSelect, RockPaperScissors computerSelect)
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
```

> 유저의 선택과 컴퓨터의 선택에 따른 승패를 나누고 관련 로그 출력을 해주는 부분이다.   
> 유저의 선택에 따른 결과를 switch 문과 열거형을 이용하여 각 결과에 대한 로직을 분기시켜주고 있다.

### **Main**

```C#
static void Main(string[] args)
{
    int userSelectNum = Convert.ToInt32(Console.ReadLine());
    RockPaperScissors userSelect = (RockPaperScissors)Enum.GetValues(typeof(RockPaperScissors)).GetValue(userSelectNum);
    Console.WriteLine($"유저의 선택은 {userSelect} 입니다.");

    RockPaperScissors AISelect = RockPaperScissorsAI.Get();
    Console.WriteLine($"컴퓨터의 선택은 {AISelect} 입니다.");

    RockPaperScissorsAI.Play(userSelect, AISelect);
}
```

> 인프런 Rookiss 강사님 로드맵 'C#과 유니티로 만드는 MMORPG 게임 개발 시리즈'에 대한 학습을 진행하면서 작성한 개인 기록용 강의노트입니다.
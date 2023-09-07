# Section 2-4 상수와 열거형

---

## **switch 분기문의 한계**

---

이전 수업의 가위바위보 예제에서 switch문을 가져와보자.

(강의 노트에 작성한 코드가 아닌 강사님 예제!)

```C#
//ROCK = 0, PAPER = 1, SCISSORS = 2

int userChoice = 0; //ROCK 선택
int computerChoice = 2; //SCISSORS 선택

switch (userChoice)
{
    case 0:
		Console.WriteLine("당신의 선택은 바위입니다.");
        break;
    case 1:
    	Console.WriteLine("당신의 선택은 보입니다.");
    	break;
    case 2:
    	Console.WriteLine("당신의 선택은 가위입니다.");
        break;
}
```

이렇게 작성된 코드를 보면 0 1 2 각 무슨 의미를 가지고 있는 지 곧바로 파악되지 않는다.

```C#
if(choice == aiChoice)
{
	Console.WriteLine("무승부입니다.");
}
else if (choice == 0 && aiChoice == 2)
{
	Console.WriteLine("승리입니다.");
}
else if (choice == 1 && aiChoice == 0)
{
	Console.WriteLine("승리입니다.");
}
else if (choice == 2 && aiChoice == 1)
{
	Console.WriteLine("승리입니다.");
}
else
{
	Console.WriteLine("패배입니다.");
}
```

각 숫자들의 의미가 한번에 파악되지 않아 굉장히 이해하기 어려운 코드임을 알 수 있다.

> 이러한 방식으로 한 코딩을 하드코딩이라고 한다.   
> 하드코딩은 유지보수와 협업을 굉장히 힘들게 하는 부분이므로, 사용하지 않도록 주의해야한다.  
>   
> 하드코딩을 리팩토링 하는 방법은 각 하드코딩의 값을 변수에 저장하고 그 변수를 사용하는 것이다.

변수에 할당하는 방식으로 하드코딩을 해소하면 아래와 같이 작성할 수 있다.

그런데 이 코드는 오류를 발생시킨다.

```C#
//ROCK = 0, PAPER = 1, SCISSORS = 2
int ROCK = 0;
int PAPER = 1;
int SCISSORS = 2;

int userChoice = ROCK; //ROCK 선택
int computerChoice = SCISSORS; //SCISSORS 선택

switch (userChoice)
{
    case ROCK: // 에러 발생
		Console.WriteLine("당신의 선택은 바위입니다.");
        break;
    case PAPER: // 에러 발생
    	Console.WriteLine("당신의 선택은 보입니다.");
    	break;
    case SCISSORS: // 에러 발생
    	Console.WriteLine("당신의 선택은 가위입니다.");
        break;
}
```

> 오류가 발생한 이유는 switch case 문법의 한계로 인해 발생한 것인데,  
> case 뒤에 올 수 있는 값으로 변할 수 있는 가능성이 있는 변수를 입력할 수 없다는 것이다.  
>   
> 생각해보면 간단한데, switch(value) 구문에서 value가 변수이고 그 변수의 값에 따라 분기를 시키는 문법이다.  
> 만약 case의 값조차 변할 수 있는 변동성이 있다면 컨셉과 맞지 않아버리게 되니 허용하지 않는 모양이다.  
> (단, if else 를 이용하여 위의 문제를 해결할 순 있다)

## **상수**

---

> 상수는 변할 수 없는 수를 의미하는 개념으로, 변수와 반대되는 특성을 가지고 있다.   
> 모든 변수 선언 앞에 const 키워드를 사용하면 상수화되어 이후 값을 변경할 수 없게 된다.

이러한 상수를 사용하게 되면 위에서 발생한 switch 구문의 에러를 해결할 수 있다.

```C#
//ROCK = 0, PAPER = 1, SCISSORS = 2
const int ROCK = 0;
const int PAPER = 1;
const int SCISSORS = 2;

int userChoice = ROCK; //ROCK 선택
int computerChoice = SCISSORS; //SCISSORS 선택

switch (userChoice)
{
    case ROCK: // 에러 발생
		Console.WriteLine("당신의 선택은 바위입니다.");
        break;
    case PAPER: // 에러 발생
    	Console.WriteLine("당신의 선택은 보입니다.");
    	break;
    case SCISSORS: // 에러 발생
    	Console.WriteLine("당신의 선택은 가위입니다.");
        break;
}
```

## **열거형**

---

> 열거형은 상수들의 집합을 표현하는 문법이다.   
> 하나의 그룹에서 사용되는 여러 상수표현을 하나로 묶어 관리함으로써 유지 보수에 이점을 준다.  
>   
> 열거형은 enum 열거타입 이름 { 상수1, 상수2, 상수3 } 방식으로 사용한다.

열거형을 사용하여 위의 코드를 개선해보면 다음과 같이 작성할 수 있다.

```C#
//ROCK = 0, PAPER = 1, SCISSORS = 2
const int ROCK = 0;
const int PAPER = 1;
const int SCISSORS = 2;

enum Choice
{
	Rock = 1,
    Paper = 1,
    Scissors = 2
}

int userChoice = Choice.Rock; //ROCK 선택
int computerChoice = Choice.Scissors; //SCISSORS 선택

switch (userChoice)
{
    case Choice.Rock: // 에러 발생
		Console.WriteLine("당신의 선택은 바위입니다.");
        break;
    case Choice.Paper: // 에러 발생
    	Console.WriteLine("당신의 선택은 보입니다.");
    	break;
    case Choice.Scissors: // 에러 발생
    	Console.WriteLine("당신의 선택은 가위입니다.");
        break;
}
```

> 인프런 Rookiss 강사님 로드맵 'C#과 유니티로 만드는 MMORPG 게임 개발 시리즈'에 대한 학습을 진행하면서 작성한 개인 기록용 강의노트입니다.

# Section 2-2 switch

---

## **Switch 분기문**

---

Section 2.1에서 if 구문을 사용하여 구현한 코드를 살펴보면

```C#
int choice = 0;

if (choice == 0)
    Console.WriteLine("가위입니다");
else if (choice == 1)
    Console.WriteLine("바위입니다");
else if (choice == 2)
    Console.WriteLine("보입니다");
```

choice == 0 이라는 조건식이 반복되고 있음을 확인할 수 있다.

이렇게 어떤 변수에 따라 분기를 결정하는 방식일 때 간편하게 사용할 수 있는 분기 문법이 switch이다.

### **Switch 사용법**

```C#
switch(value){
	case "a":
    	//Code
        break;
        
   	case "b":
    	//Code
        break;
        
    default:
        //Code
        break;
}
```

> switch 문법은 value의 값에 따라 직관적으로 분기가 가능하다. (value값이 될 수 있는 것은 문자와 숫자)  
> break; 를 만나게 되면 switch문을 빠져나가게 된다.  
> default: 은 if else 문의 else와 같은 역할로 적절한 케이스가 없다면 default 영역의 코드가 실행된다

### **switch 사용 이유**

> switch는 if else의 축소판 같은 것으로 볼 수 있다.  
> swtich로 구현된 모든 코드는 if else로 구현이 가능하지만 그 반대는 성립되지 않는다.  
> if else의 조건 자율성이 더 높아 응용 범위가 높다.  
> 하지만 가독성과 사용성이 좋아 switch를 사용할 수 있는 형식이라면 일반적으로 선호된다.

## **삼항연산자**

---

어떤 숫자가 2의 배수인지 아닌지를 확인하기 위해 if 문법, switch 문법을 사용하여 아래처럼 작성할 수 있다.

```C#
int number = 25;
bool isPair;

if(number % 2 == 0)
	isPair = true;
else
	isPair = false;
```

```C#
int number = 25;
bood isPair;

switch(number % 2)
{
    case 0:
        isPair = true;
        break;
    case 1:
        isPair = false;
        break;
    default:
        break;
}
```

삼항연산자를 사용하면 간단한 조건식에 대한 결과를 저장하는 분기문을 간편하게 작성할 수 있다.

```C#
bool isPair = ((number % 2) == 0 ? true ; false);
```

> 인프런 Rookiss 강사님 로드맵 'C#과 유니티로 만드는 MMORPG 게임 개발 시리즈'에 대한 학습을 진행하면서 작성한 개인 기록용 강의노트입니다.
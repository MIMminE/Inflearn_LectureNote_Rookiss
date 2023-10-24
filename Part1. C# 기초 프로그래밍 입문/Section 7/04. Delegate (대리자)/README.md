# Section 7.4 Delegate


다른 객체나 함수에 작업을 위임하는 데 사용된다. 주로 객체 지향 프로그래밍 언어에서 볼 수 있다.

**Delegate를 사용하면 이벤트 처리, 콜백 메커니즘, 비동기 프로그래밍 등에서 유용하다.**

예로, UI에서 버튼을 클릭하면 하위 메뉴가 출력되는 것처럼 **[ 버튼 클릭 ]** 이라는 동작이 발생하면 **[ 메뉴 출력 ]** 이라는 기능이 콜백되어 실행된다. **(C++의 함수포인터와 유사하다)**

사용을 위해 먼저 사용할 delegate 타입을 선언해주어야 한다. 

기본적으로 함수를 인자로 받으며 입력으로 들어올 함수가 어떤 형태**(반환 타입이나 인자 타입)**인지에 맞춰 선언해주어야 한다. **선언 이후에는 데이터 타입처럼 사용할 수 있다.**

```csharp
delegate int Onclicked(); 
//반환 타입이 int이면서 인자로 넘겨주는 값이 없는 함수를 인자로 주는 형식

static void ButtonPressed(Onclicked clickFunction)
{
    clickFunction(); 
		//delegate 선언할 때, 인자를 받지 않았으므로 그것에 맞춰줘야 한다.
}
```


💡 **delegate의 사용 이점**

함수를 인자로 받아 해당 함수를 대신하여 실행하는 역할을 하고 있다. 위의 경우처럼 하나의 함수만을 받아 대신 실행하는 경우를 보면 그 장점이 전혀 보이지 않겠지만, 여러개의 함수를 사용하고 또 그 함수들이 사용자 정의 함수가 아닌 라이브러리에서 제공되는 함수의 경우에는 이야기가 다르다.

일반적으로 라이브러리 함수들은 수정 불가능한 형태로 제공된다. **이러한 함수를 수정하는 것보다 그 함수들의 기능을 상황에 맞춰 실행시켜주는 것이 delegate의 이점 중 하나이다.**

또 다른 이점으로 관리적인 측면에서 용이하게 사용될 수 있다는 것이다.

```csharp
static void ButtonPressed()
{
		// 게임 캐릭터의 공격에 관련된 기능 구현
}
```

이런 식으로 버튼이 눌렸을 때 동작을 구현하게 되면 버튼 로직 + 공격 로직이 합쳐져서 구현이 되는 현상이 발생하게 된다. 이는 두 개의 로직이 합쳐서 관리되므로 객체 지향 프로그래밍 이념에도 그렇게 좋은 상황은 아니게 된다. 이를 Delegate를 사용하게 되면 아래와 같이 작성할 수 있게 된다.

```csharp
static void ButtonPressed(OnCliked attack)
{
		attack();
}
```

</aside>

**Delegate의 선언과 사용은 함수를 인자로 넣어주는 방식으로 사용된다.**

```csharp
static int TestDelegate()
{
    Console.WriteLine("Hello delegate");
    return 0;
}

static void Main(string[] args)
{
    ButtonPressed(TestDelegate);
}
```

**객체로 생성하여 함수 체이닝도 가능하다. (핸들러에 이벤트를 추가하는 방식과 같다)**

```csharp
Onclicked onclicked = new **Onclicked**(TestDelegate);
onclicked += TestDelegate2;
ButtonPressed(onclicked);
```
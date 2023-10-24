# Section 7.5 Event

## Event

Delegate를 랩핑하여 사용하도록 하는 기능이다.

**아래는 Delegate만을 사용하여 A를 누르는 동작이 발생했을 때 콘솔에 출력하는 코드이다.**

```csharp
delegate void OnInputKey();
OnInputKey _inputkey = new OnInputKey(ActionA);

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
        _inputkey();
        //모두에게 알린다
        //여기에 로직을 작성하면 로직의 의존성이 강해지므로 
        //Delegate 문법을 사용하여 함수를 넣어주는 방식이 좋다.
    }
}
```

```csharp
static void Main(string[] args)
{
    InputManager _manager = new InputManager();

    while (true)
    {
        _manager.Update();
    }
}
```

- 입력을 담당하는 매니저 객체는 A 키가 눌렸을 때 동작하는 기능을 수행하는 Delegate를 지니고 있다.
- 매니저 객체를 생성하여 Delegate 동작을 호출하는 Update 메소드를 호출하는 것으로 원하는 동작을 수행할 수 있다.

**이러한 방식은 문제는 다음과 같다.**

- **의존성이 강해진다.**
    
    매니저 객체의 동작은 매니저 객체의 내부 구현에 의존하게 되며, 이는 객체 간의 결합도를 증가시켜 코드 변경이 어렵게 된다.
    
- **보안 문제가 발생한다.**
    
    매니저 객체를 생성하면 Delegate를 통해 등록된 내부 함수에 자유롭게 접근할 수 있으므로 보안이 취약하다.
    

이러한 문제를 해결하기 위해 Event 문법이 사용된다.

```csharp
public delegate void OnInputKey();
public event OnInputKey Input;
```

Delegate를 생성하여 함수를 인자로 넣어주는 방식이 아닌 `event` 키워드를 붙여 객체만을 멤버로 가지게 해둔다. **이때 해당 멤버는 외부에서 사용이 가능해야하므로 `public`으로 생성해야 하며 Delegate역시 같은 한정자가 동일해야 한다.**

**이렇게 작성하면 클래스 내부에서 Delegate에 함수 등록을 직접하지 않게 된다.**

함수를 등록하는 동작은 해당 클래스를 선언하여 사용하는 곳에서 직접하게 된다.

```csharp
static void Main(string[] args)
{
    **InputManager** _manager = new InputManager();
    _manager.Input += InputManager.ActionA;
    while (true)
    {
        _manager.Update();
    }
}
```


💡 **Observer Pattern**

```csharp
_manager.Input += InputManager.ActionA;
```

해당 코드처럼 핸들러에 함수 또는 객체를 등록(구독)하여 특정 이벤트가 발생할 때, 등록한 함수 또는 객체를 실행하는 방식을 **Observer Pattern**이라고 한다.

여기서는 함수에 대한 동작을 구독하고 실행하는 구현을 했지만, 객체 수준에서도 자주 사용되는 디자인 패턴이다.


**결과적으로 Delegate는 등록한 함수를 직접 실행할 수 있어 보호수준이 떨어지지만,**

**Event는 등록한 함수를 직접 실행할 수 없다는 점이 보호수준이 높은 이유이다.**

```csharp
public OnInputKey delegateInput = ActionA;
public event OnInputKey eventInput;
// InputManager 클래스의 코드이다.

InputManager _manager = new InputManager();
_manager.eventInput += InputManager.ActionA;
// 여기까지 실행하게 되면 Delegate만을 이용한 함수등록 버젼과
// Event를 이용한 함수등록 버젼 모두가 같은 함수를 등록한 상태가 된다.

_manager.delegateInput();
_manager.eventInput();
// 객체의 각 멤버변수를 직접 실행하게 되면 Delegate를 사용한 버젼은 실행되지만
// Event를 이용한 버젼은 실행되지 않음을 확인할 수 있다.
```
# Section 1.9 < SpinLock >

## SpinLock


컴퓨터 프로그래밍에서 사용되는 동기화 기법 중 하나이다. 

여러 스레드 또는 프로세스 간의 동시 접근으로부터 공유 리소스를 보호하는 데 사용된다. (보호된 리소스는 같은 순간에 하나의 스레드만이 사용할 수 있다)

다른 스레드에 의해 이미 락이 걸려있는 경우, 해당 락이 해제되어 자신이 얻을 수 있는 상태인지를 확인하는 **루프(스핀)을 지속적으로 돈다.**

다른 동기화 메커니즘에 비해 오버헤드가 적지만, 스핀이 오래 지속되면 **CPU 리소스를 소비하므로 락을 짧게 유지하는 경우하는 경우에 효과적인 방법**이다.

## SpinLock의 구현


```csharp
class SpinLock
{
    volatile bool _locked = false;
    public void Acquire()
    {
        while (_locked)
        {
					// 잠금이 풀리기를 기다린다.
        }
        _locked = true;
    }

    public void Release()
    {
        _locked = false;
    }
}
```

`SpinLock`클래스를 선언하여 간단하게 스핀락을 구현한 코드이다. 

Acquire과 Release는 락 개념에서 관습적으로 사용되므로 기억하자.

```csharp
static int _num = 0;
static SpinLock _lock = new SpinLock();
//해당 클래스에서 공유하여 사용하는 SpinLock 인스턴스

static void Thread_1()
{
    for (int i = 0; i < 100000; i++)
    {
        _lock.Acquire(); **//스핀락 소유권 얻기**
        _num++;
        _lock.Release(); **//스핀락 소유권 돌려놓기**
    }
}

static void Thread_2()
{
    for (int i = 0; i < 100000; i++)
    {
        _lock.Acquire(); **//스핀락 소유권 얻기**
        _num--;
        _lock.Release(); **//스핀락 소유권 돌려놓기**
    }
}

static void Main(string[] args)
{
    Task t1 = new Task(Thread_1);
    Task t2 = new Task(Thread_2);

    t1.Start();
    t2.Start();

    Task.WaitAll(t1, t2);

    Console.WriteLine(_num);
}
```

언뜻 보면 문제가 없어보이지만 실행을 시켜보면 정상적으로 작동을 하지 않음을 알 수 있다.

### 실패 원인 분석

```csharp
public void Acquire()
{
    while (_locked)
    {
			// 잠금이 풀리기를 기다린다.
    }
    _locked = true;
}
```

스핀락을 얻는 해당 부분을 보면 스핀락 인스턴스 락이 풀리기를 기다리고 있다가 풀리는 것을 확인한 이후에 락을 걸고 있다. 원자성을 갖추고 있지 않다는 것을 의미한다. 

이러한 상황이 오면 스레드가 수 많은 횟수를 반복하다보면 순간적으로 같이 스핀락을 얻는 순간이 오게 되어 비정상적인 결과를 초래할 수 있다. 

**Lock 관련 기법을 구현할 때는 원자성에 대한 점을 신경쓰며 작업해야 한다.**

### 원자성 확보 위한 코드 수정

결국 스레드가 스핀락을 얻는 코드 부분이 원자적으로 동작해야 하는 것이며, 이전 강의에서 사용한 기법들을 이용하여 구현이 가능하다..

```cpp
volatile int _locked = 0;
public void Acquire()
{
    while (true)
    {
        int original = Interlocked.Exchange(ref _locked, 1); 
        //original의 값이 0이면 잠그기에 성공한 것
        if (original == 0)
            break;
    }
}
```

`Interlocked.Exchange` 함수는 첫 번째 인자로 준 변수의 값을 두 번째 인자값으로 원자적으로 변경하라는 것을 의미한다. 반환값으로 첫 번째 인자의 변경되기 이전의 값이 반환된다. 

- 만약 **`_locked`** 변수의 값이 0이었다면, 이전 값 **`original`**은 0이 된다. 이것은 해당 스레드가 락을 성공적으로 획득한 것을 의미한다.
- 만약 **`_locked`** 변수의 값이 이미 1이었다면, **`original`** 값은 1이 된다. 이것은 다른 스레드가 이미 락을 획득했으므로 현재 스레드는 락을 획득하지 못했음을 의미한다.


💡 **경합하는 자원과 경합하지 않는 자원**

경합하는 자원, 즉 공유자원은 원자성이 보장되지 않은 상황에서는 멋대로 읽거나 사용하면 안된다. 위의 코드에서 _locked 변수는 공유자원이므로 원자성을 고려해주어야 한다는 의미이다. 

original 변수는 지역변수, 여러 스레드에서 공유하지 않고 자기 자신들만 사용하는 변수이므로 원자성을 보장하지 않는 코드를 사용해도 문제가 없다.

**(클래스의 멤버 변수는 힙 영역에 저장되고, 멤버 변수는 스택 영역에 저장됨을 기억하자)**


`Interlocked.Exchange` 함수를 사용하여 구현하는 것도 가능하지만, 직관적이지 못하다는 점이 있다.

변수의 값을 무조건적으로 변경한 다음, 변경 이전 값을 확인하는 방식인데 이번 실습에서는 큰 문제가 없게 작동했지만 찝찝한 면이 있다. 

조금 더 명확하게 ‘**변수의 값이 어떤 값이면 변경하라’** 와 같은 조건을 걸어준다면 더 깔끔해진다.

`Interlocked.CompareExchange` 함수는 변수의 값을 변경하기에 앞서 해당 변수가 특정 값을 가졌는지를 확인하는 조건을 걸어줄 수 있다.

```cpp
while (true)
{
    int original = Interlocked.CompareExchange(ref _locked, 1, 0);
		// 세 번째 인자와 값을 비교하여 두 번째 인자로 변경
    if (original == 0)
        break;
}
```

이러한 동작을 하는 함수들을 **CAS(Compare And Swap)**이라고 한다.

💡 **C++ 에서의 CompareExchange**

CompareExchange 함수의 입력 인자값들의 이름을 보면 `(location, value, comparand)` 이다. `value`와 `comparand`부분에 그냥 값을 입력하기 보다는 변수로 치환하여 넣는 것이 유지 보수 측면에서 이점이 있다. 

C++에서는 각각 `dseired`와 `expected`라는 이름으로 인자를 받고 있다. 직관적인 의미를 지닌 해당 이름들을 변수 이름으로 하여 하는 것도 추천하는 바이다.

```cpp
int desired = 1;
int expected = 0;

if (Interlocked.CompareExchange(ref _locked, desired, expected) == expected)
		break;
```

```
인프런 Rookiss 강사님 로드맵 'C#과 유니티로 만드는 MMORPG 게임 개발 시리즈'에 대한 학습을 진행하면서 작성한 개인 기록용 강의노트입니다.
```

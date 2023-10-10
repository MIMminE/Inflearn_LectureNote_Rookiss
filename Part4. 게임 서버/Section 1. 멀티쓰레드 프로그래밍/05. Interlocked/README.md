# Section 1.5 Interlocked
## 경합 조건 (RACE CONDITION)

컴퓨터 프로그램이나 시스템에서 여러 프로세스나 스레드가 공유 자원에 동시에 접근하려고 할 때 발생할 수 있는 문제이다.

공유된 자원에 대해 동시에 변경하려고 하면 예측 불가능한 결과가 발생할 수 있으며, 무결성 문제의 원인이 된다.

아래의 코드로  실습을 진행하여 결과를 확인해보자.

```c#
static int number = 0;

static void Thread_1()
{
    for (int i = 0; i < 100000; i++)
            number++;
}

static void Thread_2()
{
    for (int i = 0; i < 100000; i++)
            number--;
}

static void Main(string[] args)
{
    Task t1 = new Task(Thread_1);
    Task t2 = new Task(Thread_2);

    t1.Start();
    t2.Start();
    
    Task.WaitAll(t1, t2);
    Console.WriteLine(number);
}
```

전역으로 사용되는 `number` 변수에 접근하여 동작하는 두 개의 함수를 Task에 할당하여 병렬로 처리하고 있다. 

같은 횟수만큼 더해주고 빼주고 있으므로 0이라는 결과를 예상할 수 있지만, 실제 결과는 매 실행마다 예측 불가능한 다른 값이 된다.


💡 **식당 예시로 보는 경합 조건 문제**  
한 테이블에서 음료를 주문했을 때, 주문을 확인한 직원 세 명이 각자 해당 음료를 가져다 주는 상황

결과적으로 정확한 작업이 수행되지 않았다. 

각 직원들을 스레드라 보고 정확한 작업이 수행되지 않은 상황의 원인을 **경합 조건** 문제라 볼 수 있다.



위의 코드에서 올바른 값이 나오지 않는 이유를 확인해보기 위해 `number++`부분의 어셈블리어 코드를 확인해보면 아래와 유사하게 나온다.

```nasm
mov  ecx,dword ptr [ address ]
inc  ecx
mov  dword ptr [ address.ecx ]
```

분석해보면 값을 저장하고 있던 메모리의 값을 임시적으로 저장할 공간으로 가져와 값을 더하여 가져왔던 곳으로 다시 보내는 방식으로 동작한다.

즉, 실제 동작은 세 단계로 나누어서 작동하고 있음을 알 수 있다. (실제 코드는 한 줄이지만 컴퓨터의 처리 단계가 이처럼 변경될 수 있다)

위와 같은 상황에서 두 스레드는 메모리에 동시에 접근하여 같은 값에 대한 연산을 수행하고 업데이트하는데, 이 과정에서 연산의 순서가 꼬이게 되면서 의도치 않는 값을 저장하게 되는 것이 문제의 원인이다.

## 원자성(Atomicity)

어떠한 작업이 하나의 여러 작업으로 분리되지 않고 완전하게 실행되거나 아예 실행되지 않는 상태를 나타낸다.

이는 데이터베이스에서도 중요한 개념으로 취급되며 멀티스레드 환경에서도 공유된 자원에 대한 작업의 원시성은 무결성 유지에 있어 중요하다.

위의 문제에서 세 개로 분리된 어셈블리어 동작을 하나의 원자성의 특성을 갖게 하면 문제가 해결된다. 

```csharp
static void Thread_1()
{
    for (int i = 0; i < 100000; i++)
        Interlocked.Increment(ref number);
}

static void Thread_2()
{
    for (int i = 0; i < 100000; i++)
        Interlocked.Decrement(ref number);
}
```

`Interlocked` 클래스의 함수들은 특정 동작을 원자성을 보장하는 방식으로 실행하는 메소드들이 있다. 

메소드들은 보면 매개변수롤 ref 타입으로 받아오고 있는데, 이는 변수의 값을 직접 조작하여 원자성 연산을 가능케하기 위함이다. 

중간 과정에서 참조가 아닌 복사로 값을 이동하는 방식을 사용한다면 복사하여 옮기는 동안 다른 곳에서 해당 자원에 대한 변경이 발생하는 경우가 생길 수 있기 때문에 ref 와 같은 참조 타입으로 매개변수를 받는 것이다.

원자성 연산은 어떤 자원에 대한 독점을 해야 하기에 동시에 그 자원에 접근하려고 하는 스레드가 있다면 해당 스레드는 이전 작업이 끝나기까지 대기해야 한다. 그러므로 원자성 보장을 하지 않는 동작에 비해 성능이 떨어질 수 밖에 없으므로 사용에 주의해야 한다. (모든 동작에 원자성을 추가하는 것은 좋은 방법은 아니다)


💡 **원자성이 적용된 식당**

한 테이블에서 음료를 주문했을 때, 주문을 확인한 직원 세 명이 음료를 가져다 주기 위해 음료를 챙기려 한다.

가장 먼저 도착한 직원이 음료를 챙겼고 나머지 직원들은 해당 직원이 음료를 가져다주는 동작을 전부 끝마치기 전에는 해당 동작을 수행할 수 없다.  
 (하지만 해당 행동은 한번만 하면 하는 것이기에 첫 번째 직원의 서빙이 끝나면 다른 스레드들이 다시 할 필요는 없다)


## 실습 코드

```csharp
internal class Program
{
    static int number = 0;

    static void Thread_1()
    {
        for (int i = 0; i < 100000; i++)
            Interlocked.Increment(ref number);
    }

    static void Thread_2()
    {
        for (int i = 0; i < 100000; i++)
            Interlocked.Decrement(ref number);
    }

    static void Main(string[] args)
    {
        Task t1 = new Task(Thread_1);
        Task t2 = new Task(Thread_2);

        t1.Start();
        t2.Start();

        Task.WaitAll(t1, t2);
        Console.WriteLine(number);
    }
}
```



```
인프런 Rookiss 강사님 로드맵 'C#과 유니티로 만드는 MMORPG 게임 개발 시리즈'에 대한 학습을 진행하면서 작성한 개인 기록용 강의노트입니다.
```

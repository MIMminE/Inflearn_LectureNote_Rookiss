# Section 1.6 Lock 기초

이전 시간에 배운 Interlocked 클래스의 단점은 단순한 정수 작업에만 활용할 수 있다는 것이다.

## 임계영역


여러 스레드가 공유된 메모리에 대해 접근하고 수정하는 동작을 수행하는 코드 영역을 의미한다. 

멀티스레드 환경에서 메모리에 대한 읽는 작업은 문제가 되지 않지만 데이터를 쓰는 작업을 하는 코드는 문제가 될 수 있다.

→ 이러한 문제를 해결하기 위해 사용했던 기법 중 하나가 이전 시간의 Interlocked 클래스

이외에 여러가지 임계영역 문제 해결을 위한 기법 중 모니터(Monitor)가 있다.

### Monitor

병렬 프로그래밍에서 임계영역 관리를 위한 동기화 메커니즘 중 하나이다.

프로그램의 일부분을 잠금(Lock)으로 묶어 다른 스레드가 해당 영역에 접근을 하지 못하게 하는 개념이다. 

```csharp
static int number = 0;
static object _obj  = new object();

static void Thread_1()
{
    for (int i = 0; i < 100000; i++)
    {
        Monitor.Enter(_obj); //잠그고

        number++;

        Monitor.Exit(_obj); //풀어준다
    }
}

static void Thread_2()
{
    for (int i = 0; i < 100000; i++)
    {
        Monitor.Enter(_obj);

        number--;

        Monitor.Exit(_obj);
    }
};
```

모니터 클래스의 Enter ↔ Exit 쌍을 통해 특정 코드 영역에 대한 Lock를 걸고 풀어줄 수 있다. 

이렇듯 여러 스레드가 공유 자원에 동시에 접근하여 사용하려는 것을 제어하기 위한 원칙을 상호 배제(Mutual Exclusion)이라 한다.

💡 상호 배제를 구현하기 위한 메커니즘은 운영체제와 프로그래밍 언어에서 각각에 다른 이름으로 불리기도 한다. 다음은 몇 가지 메커니즘이다.

1. **Mutex (뮤텍스)**
    
    C/C++ 프로그래밍에서 사용되는 상호 배제 메커니즘
    
    Lock 또는 Critical Section 으로 불리기도 한다.
    
2. **Semaphore (세마포어)**
    
    C/C++ 와 운영체제에서 사용되는 동기화 도구, 상호 배제와 스레드 통신에 사용된다.
    
3. **Monitor (모니터)**
    
    Java, Python 등의 언어에서 사용되는 상호 배제 메커니즘 및 추상화

### Monitor의 문제

만약 모니터를 Enter만 하고 Exit를 해주지 못한 상황이 발생하게 되면 다른 스레드들이 무한 대기하는 상황에 빠지게 된다. 이러한 상황을 DeadLock (데드락)이라 한다.

```csharp
static void Thread_1()
{
    for (int i = 0; i < 100000; i++)
    {
        Monitor.Enter(_obj); //잠그고

			  //코드 , 해당 영역에서 예외 발생

        Monitor.Exit(_obj); //예외 발생으로 인해 실행되지 못함
    }
}
```

이와 같은 상황을 피하기 위해서 try-finally 구문을 이용할 수 있기는 하지만 번거로운 부분이 있어 **lock** 키워드를 사용하여 해결한다.

### lock 키워드

내부적으로 모니터를 사용하여 구현된 상호 배제 메커니즘으로 에외 상황이 발생하여 모니터를 Exit 하지 못하여 발생하는 문제를 간편하게 예방할 수 있다.

```csharp
static void Thread_1()
{
    for (int i = 0; i < 100000; i++)
    {
        lock (_obj)
        {
            number++;
        }
    }
}
```

사용하기에도 간편하여 많이 사용되는 기법이다.


```
인프런 Rookiss 강사님 로드맵 'C#과 유니티로 만드는 MMORPG 게임 개발 시리즈'에 대한 학습을 진행하면서 작성한 개인 기록용 강의노트입니다.
```

# Section 1.1 쓰레드 

## Thread


- 쓰레드는 컴퓨터 프로세스 내에서 실행되는 독립적인 실행 흐름이다.
- 프로레스 내부에서 메모리 및 자원을 공유하며 병렬적으로 작업을 수행한다.
- 일반적인 코드를 실행시키면 싱글 쓰레드로 동작하는 것이다.

### 쓰레드의 사용

```csharp
class Program
{
    static void MainThread()
    {
        Console.WriteLine("Hello Thread!");
    }

    static void Main(string[] args)
    {
        Thread t = new Thread(MainThread);
        t.Start();

        Console.WriteLine("Hello World!");
    }
}
```

- Thread 타입 인스턴스를 생성하여 쓰레드를 사용할 수 있다.
- 생성자 인터페이스는 여러 종류가 있지만 쓰레드에서 사용할 함수를 직접 넣어줄 수 있다. (이때, 람다함수를 사용하기도 한다)
- 모든 쓰레드는 병렬로 실행되기 때문에 위 코드와 같은 경우에는 “Hello World!” 와 “Hello Thread!” 중 어떤 것이 먼저 실행되는지는 스케줄링에 따라 다르지만 일반적으로는 메인 쓰레드가 먼저 실행된다.
- 만약 쓰레드의 동작 순서를 제어하고 싶다면 Join 메소드를 사용하여 아래와 같이 조절할 수 있다.

```csharp
  Thread t = new Thread(MainThread);
  t.Start();
	t.Join(); // Join를 사용하면 다른 쓰레드들이 해당 쓰레드의 실행을 기다린 후 실행된다
```

<aside>
💡 쓰레드에서 실행될 함수가 무한 루프라면 어떻게 될까?

```csharp
static void MainThread()
{
    while (true)
    {
        Console.WriteLine("Hello Thread!");
    }
}
```

이렇게 코드를 수정한 후 실행시키게 되면 메인 함수(프로그램)가 종료되더라도 해당 **쓰레드는 종료되지 않고 계속 문자열을 출력**한다.

이는, C#에서는 쓰레드가 생성될 때 기본적으로 ‘`ForegroundThread`’로 생성된다. 포그라운드 스레드는 해당 스레드의 작업이 완료되기 전까지는 프로그램이 종료되지 않으며, 반대로 ‘`BackgroundThread`’는 실행 중인 프로그램이 종료되면 스레드의 작업도 중지된다. 

스레드의 `IsBackground`속성을 변경해주면 스레드의 수명을 조절할 수 있다.

```csharp
t.IsBackground = true; //기본값은 false(포그라운드 스레드)
t.Start();
```

</aside>

## ThreadPool

- 멀티스레딩 작업을 보다 효율적으로 처리하기 위한 메커니즘
- 일반적으로 사용되는 스레드를 미리 생성하여 관리하고, 작업을 이용할 수 있는 스레드에 할당하는 역할
- 스레드 생성 및 종료 비용을 줄이고, 병렬 처리하기 편리하기 해준다.

### 쓰레드풀의 사용

```csharp
ThreadPool.QueueUserWorkItem(MainThread); 
//스레드풀을 사용하는 인터페이스는 굉장히 다양하다.
```

- 쓰레드풀은 기본적으로 백그라운드 스레드로 동작하므로 메인 함수의 종료와 함께 중지된다.
- 일반 쓰레드를 사용하면 개수의 제한이 없지만 쓰레드풀은 일정 개수의 제한을 두어 관리할 수 있다. (쓰레드의 개수가 많아진다고 성능이 무조건적으로 느는 것은 아니다. CPU 코어가 각 쓰레드를 옮겨가는 시간적인 손해가 증가하기 때문이다)


인프런 Rookiss 강사님 로드맵 'C#과 유니티로 만드는 MMORPG 게임 개발 시리즈'에 대한 학습을 진행하면서 작성한 개인 기록용 강의노트입니다.

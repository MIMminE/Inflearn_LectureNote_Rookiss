# Section 1.13 ReaderWriterLock 구현 연습
## ReaderWriterLock 구현

**ReaderLock** 과 **WriteLock**를 구분지어 각 스레드에 설정하고 해제하는 기능을 구현하는 것이 핵심이다. 

여러가지 방법이 있겠지만 여기서는 하나의 **32비트 플래그와 플래그 마스크 기법**을 이용한 비트 연산으로 스레드를 구분지어 Lock를 구현한다.

```csharp
class Lock
{
    const int EMPTY_FLAG = 0x00000000;
    const int WRITE_MASK = 0x7FFF0000;
    const int READ_MASK = 0x0000FFFF;
		
		int _flag = EMPTY_FLAG;
}
```

먼저, 플래그와 플래그 마스크를 작성한다. 플래그의 1~16비트까지는 write 락을 획득한 스레드 번호를 저장할 것이다. 일반적으로 쓰레드 번호는 양수 표현이여야 하므로 가장 왼쪽의 부호비트는 사용되지 않는다. 때문에 `WRITE_MASK`의 가장 왼쪽 비트가 빠진 **0X7FFF0000**이 되는것이다.

**플래그 마스크와 & 연산을 하게 되면 해당 마스크에 해당하는 값만 남고 그 이외의 부분은 모두 0으로 처리된다.** 

### Lock 정책 수립

락을 구현할 때 어떤 정책을 사용할 것인지에 대한 결정도 해야한다. 예를 들어 락을 얻기 위해 어떤 종류의 락 기법을 사용할 것인지, 재귀적 락을 허용할 것인지 등이 있다. 

여기서 구현할 락은 간단한 구현을 위해 재귀적 락은 허용하지 않으며 **스핀락을 기반으로 구현하지만 5,000번의 스핀 후에는 잠시 휴식하는 방식**으로 락을 얻기 위한 시도를 하는 것으로 결정한다. **(이는 C#에서 제공하는 SpinLock이 가지고 있는 정책과 유사하다)**

💡 **재귀적 락**

한 스레드에서 락을 여러번 거는 것을 말한다. 예를 들어, 쓰레드에서 락을 얻어 실행해야 하는 작업 내부에서 또 다른 락을 얻어야만 하는 기능을 수행할 때에 락 내부에서 락을 한번 더 걸어 잠그게 된다. 이러한 것을 재귀적 락이라 한다.


### WriteLcok 획득과 해제

다른 스레드들이 ReaderLock과 WriteLock를 모두 획득하지 않은 상태일 때, 경합하여 소유권을 얻을 수 있어야 한다. **또한, 누군가가 WriterLock를 획득한 상태라면 ReaderLock와 WriteLock 모두 획득할 수 없는 상태가 된다.**

```csharp
public void WriteLock()
{
    int ThreadId = (Thread.CurrentThread.ManagedThreadId << 16) & WRITE_MASK; 

    while (true)
    {
        for(int i = 0; i < MAX_SPIN_COUNT; i++)
        {
            /*if (_flag == EMPTY_FLAG)
                _flag = ThreadId; 
			// 이러한 방식은 원자성을 보장하지 못하므로 멀티스레드 환경에서는 적합하지 못한다.*/

            if (Interlocked.CompareExchange(ref _flag, ThreadId, EMPTY_FLAG) == EMPTY_FLAG)
                return;
            // 시도를 해서 성공하면 return
        }
        Thread.Yield();
    }
}
```

WriterLock를 얻기 위해 Lock의 상태를 기록하는 플래그를 확인하여 아무도 사용하고 있지 않다면**(EMPTY_FLAG 상태)** 자신의 스레드 값을 플래그의 write 비트 부분에 기록한다. **즉, write 비트 부분이 비어있지 않다면 누군가가 WriteLock를 얻어 사용중이라는 말이 된다.**

일반 변수 연산을 하게 되면 원자성을 보장하지 못하므로 `Interlocked` 계열의 함수로 수행한다.

```csharp
Interlocked.CompareExchange(ref _flag, ThreadId, EMPTY_FLAG)
```

`_flag` 와 `EMPTY_FLAG` 값을 비교하여 같다면 `ThreadId` 값으로 `_flag`를 업데이트하고, 업데이트 이전 값을 반환하는 기능을 원자적으로 수행하고 있다. 

메소드의 반환 값은 _flag의 업데이트 이전 값이므로 해당 값을 비교하여 **이전 값이 비어있는 값이라면 아무도 사용중이지 않고 있다는 것을 의미**하므로 락을 획득할 수 있음을 나타낸다.

락을 해제하는 것은 플래그를 초기화시켜주면 된다. 

```csharp
public void WriteUnlock()
{
	    Interlocked.Exchange(ref _flag, EMPTY_FLAG);
}
```

### ReaderLcok 획득과 해제

다른 스레드가 write락을 획득한 상태가 아닐 때만 락을 획득할 수 있다.

```csharp
public void ReadLock()
{
    //아무도 WriteLock를 획득하고 있지 않으면 ReadCount를 1올린다.
    while (true)
    {
        for (int i = 0; i<= MAX_SPIN_COUNT; i++)
        {
            int expected = _flag & READ_MASK;
            if (Interlocked.CompareExchange(ref _flag, expected + 1, expected) == expected)
                return;
        }

        Thread.Yield();
    }
}
```

ReaderLock 같은 경우는 여러 스레드에서 동시에 접근하여도 상관없기에 허용한다. 그렇기 때문에 Reader 비트 부분에 다른 값이 있더라도 Writer 비트 부분만 비어있다면 락을 획득하는 것을 허용한다. 

**ReaderLock를 나타내는 비트는 락을 획득한 스레드의 개수를 의미하므로 이전의 ReaderLock 개수에서 1를 더한 값으로 원자적으로 변경해주면 된다.**

락을 해제할 때는 단순하게 현재 ReaderLock를 얻은 스레드의 개수를 의미하는 값에 대해 1만큼 낮춰주면 된다. 이때도 반드시 원자성을 고려해야 한다.

```csharp
public void ReadUnlock()
{
    Interlocked.Decrement(ref _flag);   
}
```
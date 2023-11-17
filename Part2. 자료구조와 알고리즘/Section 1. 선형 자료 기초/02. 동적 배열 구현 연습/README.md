# Section 1-2 동적 배열 구현 연습

💡 **동적 배열과 연결 리스트의 이름**

동적 배열이라는 자료구조를 `C#`에서는 `List`라는 이름으로 사용하고 있다. 하지만 `Cpp`에서는 `Vector`라 불리는 컨테이너가 동적 배열로 이용되고 있다. 

마찬가지로 `C#`에서는 연결 리스트를 `LinkedList`로 사용하고 있지만 `Cpp`에서는 `List`라는 이름의 컨테이너로 사용되고 있다.



우리가 구현하고자 하는 25 X 25 타일의 맵은 중간에 삭제되거나 추가되는 타일이 발생하지는 않는다. 그렇기 때문에 연결 리스트 또는 동적 배열은 그렇게 좋은 선택지는 아니게 된다. 

동적 배열 구현에 앞서 프로그램 메인 부분에서 Board 클래스의 인스턴스를 생성하고 init 메소드를 사용하여 객체를 사용할 준비를 한다. 

```csharp
Board _board = new Board();
_board.init();
```

여기서 인스턴스를 생성하고 사용함에 init 메소드를 추가적으로 구현하여 사용하는 이유는 다음과 같다.

1. **복잡한 초기화 로직을 사용할 때는 여러 단계를 거치기도 하는데 그러한 경우에 유용하다.**
2. **생성자는 주로 멤버 변수의 초기화를 담당하고 init 메소드는 복잡한 로직 수행 및 계산을 한다.**
3. **인스턴스에 여러가지 동작 방식이 있을 때 각기 다른 init 메소드를 구현하여 사용할 수 있다.**

## 동적 배열 구현


```csharp
class MyList<T>
{
		const int DEFAULT_SIZE = 1;
		T[] _data = new T[DEFAULT_SIZE];
		
		public int Count; // 실제로 사용중인 데이터 개수
		public int Capacity { get { return _data.Length; }} // 예약된 공간 개수
		// Capacity는 실제로 할당되어 있는 크기
}
```

동적 배열은 가지고 있는 **배열의 크기가 부족할 때 원래 가지고 있던 크기보다 큰 새로운 배열을 할당하는 방식**으로 동작한다. 이때 지금보다 얼마나 크게 설정할 것인지는 동적 배열 할당 정책에 따라 달라진다. 일반적으로는 **1.5 ~ 2배크기**를 할당한다. 

이때 현재 배열이 최대로 사용할 수 있는 공간을 의미하는 변수로 `Capacity`를 사용하고 실제 데이터가 들어가있는 크기를 `Count`라고 하여 관리한다.

```csharp
public void Add(T item)
{
    // 1. 할당된 공간이 충분히 남아 있는지 확인한다.
    if (Count >= Capacity)
    {
        // 2. 남아있지 않다면 모든 데이터를 가지고 더 큰 공간으로 이동한다.
        T[] newArray = new T[Count * 2]; // 2를 곱하는 것은 동적 배열의 정책적인 부분이다.
        for (int i = 0; i < Count; i++)
            newArray[i] = _data[i];
        _data = newArray;
    }
    // 3. 남은 공간에 데이터를 넣어준다. 
    _data[Count] = item;
    Count++;
}
```

```csharp
public T this[int index]
{
    get { return _data[index]; }
    set { _data[index] = value;}
}
```

인덱서라고 하는 문법이다. 이는 `array[1`] 같은 형식으로 인스턴스의 어떤 멤버변수에게 접근하기 위해 사용되는 문법이다.

```csharp
public void RemoveAt(int index)
{
    for (int i = index; i < Count - 1; i++)
        _data[i] = _data[i + 1];
    _data[Count-1] = default(T); // T 타입의 초기값으로 변경
    Count--;
}
```

동적 배열은 삭제하고자 하는 위치의 값을 지운다음 그 다음으로 위치한 값들을 한칸씩 앞으로 당겨주어야 하기 때문에 위와 같은 방식으로 삭제를 진행해야 한다.
# Section 1-3 연결 리스트 구현 연습
## LinkedListNode


연결 리스트는 배열과는 다르게 각 원소가 값을 가지고 있는 것이 아닌 노드라고 불리는 구조물을 가지고 있다. 노드 구조물은 내부에 자신의 값과 다른 노드의 주소를 기억하고 있는 공간을 가지고 있는데 그 주소는 자신 다음의 노드의 주소를 의미한다. 

C#의 LinkedList는 기본적으로 양방향으로 이동이 가능한 양방향 연결 리스트이다. 즉 각 노드는 자신의 앞과 뒤에 해당하는 노드의 위치를 가지고 있어야 하므로 결과적으로 `[ 자신의 값, 앞 노드의 주소, 뒤 노드의 주소 ]` 를 가지게 된다.

```csharp
// 노드는 자신의 값, 앞 노드의 주소, 뒤 노드의 주소를 갖고 있는다.
class MyLinkedNode<T>
{
    public T Value;
    public MyLinkedNode<T>? Prev;
    public MyLinkedNode<T>? Next;
}
```

```csharp
// 연결리스트는 가장 앞에 있는 노드의 주소, 가장 뒤에 있는 노드의 주소와 
// 전체 노드 개수를 갖고 있는다.
class MyLinkedList<T>
{
	   public MyLinkedNode<T>? Head = null;
	   public MyLinkedNode<T>? Tail = null;
	   public int Count = 0;
}
```

일반적인 배열과 달리 데이터 콜렉션 내부에 모든 데이터들을 가지고 있지 않는다. 연결 리스트 타입의 데이터 구조를 구현할 때의 특징으로 이러한 현상 때문에 인덱스를 가지고 접근하는 것이 어렵다는 것이다. 

💡 **Collection 과 Container**

두 용어 모두 프로그래밍에서 자료를 저장하고 관리하는 데 사용된다. 구체적으로 보면 약간의 차이가 있기는 하지만 일반적으로 같은 의미로 사용되어 혼용된다. 

하지만 각기 프로그래밍 언어에서 주로 사용되는 용어는 따로 있으며 자바와 C#에서는 `Collection`이라는 표현으로 사용되고 C++에서는 `Container`라는 용어로 사용된다.


### 연결 리스트 추가와 삭제

```csharp
public MyLinkedNode<T> AddLast(T value) 
{
	   MyLinkedNode<T> newNode = new MyLinkedNode<T>() { Value = value };
	
	   // 만약 가지고 있는 노드가 없다면, 입력으로 들어오는 노드는 Head가 된다.
	   if (Head == null) Head = newNode;
	
	   // 가지고 있는 방이 있었다면 새로 들어오는 노드가 Tail이 된다.
	   if (Tail != null)
	   {
	       Tail.Next = newNode;
	       newNode.Prev = Tail;
	   }
	
	   // 새로 추가된 방을 마지막 방으로 지정한다.
	   Tail = newNode;
	   Count++;
	   return newNode;
}
```

```csharp
// 입력으로 들어오는 노드는 반드시 해당 연결 리스트에 속하다는 가정이 필요하다.
public void Remove(MyLinkedNode<T> node)
{
	    if(node == Head)
	    {
	        Head = node.Next;
	        Head.Prev = null;
	        Count--;
	        return;
	    }
	
	    if(node == Tail)
	    {
	        Tail = node.Prev;
	        Tail.Next = null;
	        Count--;
	        return;
	    }
	
	    node.Next.Prev = node.Prev;
	    node.Prev.Next = node.Next;
	    Count--;
}
```
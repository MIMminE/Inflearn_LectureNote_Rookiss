using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section_1.src
{
	class MyList<T>
	{
		const int DEFAULTSize = 1;
		T[] _data = new T[DEFAULTSize];

		public int Count; // 실제로 사용중인 데이터 개수
		public int Capacity { get { return _data.Length; } } // 예약된 공간 개수
															 // Capacity는 실제로 할당되어 있는 크기

		public void Add(T item)
		{
			// 1. 할당된 공간이 충분히 남아 있는지 확인한다.
			if (Count >= Capacity)
			{
				// 2. 남아있지 않다면 모든 데이터를 가지고 더 큰 공간으로 이동한다.
				T[] newArray = new T[Count * 2];
				// 2를 곱하는 것은 동적 배열의 정책적인 부분이다.
				for (int i = 0; i < Count; i++)
					newArray[i] = _data[i];
				_data = newArray;
			}
			// 3. 남은 공간에 데이터를 넣어준다. 
			_data[Count] = item;
			Count++;
		}

		public T this[int index]
		{
			get { return _data[index]; }
			set { _data[index] = value; }
		}

		public void RemoveAt(int index)
		{
			for (int i = index; i < Count - 1; i++)
				_data[i] = _data[i + 1];
			_data[Count - 1] = default(T); // T 타입의 초기값으로 변경
			Count--;
		}
	}

	class MyLinkedNode<T>
	{
		public T Value;
		public MyLinkedNode<T>? Prev;
		public MyLinkedNode<T>? Next;
	}

	class MyLinkedList<T>
	{
		public MyLinkedNode<T>? Head = null;
		public MyLinkedNode<T>? Tail = null;
		public int Count = 0;


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

		// 입력으로 들어오는 노드는 반드시 해당 연결 리스트에 속하다는 가정이 필요하다.
		public void Remove(MyLinkedNode<T> node)
		{
			if (node == Head)
			{
				Head = node.Next;
				Head.Prev = null;
				Count--;
				return;
			}

			if (node == Tail)
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
	}
}

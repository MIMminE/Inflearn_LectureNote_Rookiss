using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section_5
{
	class Knight : IComparable<Knight>
	{
		public int id {  get; set; }

		public int CompareTo(Knight other)
		{
			if (id == other.id) return 0;
			return id > other.id ? 1 : -1; 
			// 부등호를 변경하거나 리턴 값을 바꿔주는 것으로 기준을 바꿀수 있다.
		}
	}


	// 어떤 타입이든 넣을 수 있는 제너릭 타입 선언 , IComparable 인터페이스를 가진 클래스만 받는다.
	public class PriorityQueue<T> where T : IComparable<T>
	{
		List<T> _heap = new List<T>();

		public void Push(T data)
		{
			// 힙의 맨 끝에 새로운 데이터를 삽입한다.
			_heap.Add(data);

			int now = _heap.Count - 1;
			// 도장깨기 시작
			while (now > 0)
			{
				// 힙 트리의 특징인 구조를 수식으로 파악가능 하다는 점 이용 
				int next = (now - 1) / 2;
				if (_heap[now].CompareTo(_heap[next]) < 0)
					break;

				// 두 값교체
				T tmp = _heap[now];
				_heap[now] = _heap[next];
				_heap[next] = tmp;

				now = next;
			}
		}

		public T Pop()
		{
			// 반환할 데이터를 따로 저장
			T ret = _heap[0];

			// 마지막 데이터를 루트로 이동한다.
			_heap[0] = _heap[_heap.Count - 1];
			_heap.RemoveAt(_heap.Count - 1);

			int now = 0;
			while (now < _heap.Count - 1)
			{
				int left = 2 * now + 1;
				int right = 2 * now + 2;

				int next = now;
				// 왼쪽값이 현재값보다 크면, 왼쪽으로 이동
				if (left <= _heap.Count - 1 && _heap[next].CompareTo(_heap[left]) < 0)
					next = left;
				// 오른쪽값이 현재값(왼쪽 이동 포함)보다 크면, 오른쪽으로 이동
				if (right <= _heap.Count - 1 && _heap[next].CompareTo(_heap[right]) < 0)
					next = right;

				// 왼쪽/오른쪽 모두 현재값보다 작으면 종료
				if (next == now)
					break;

				// 두 값을 교체한다.
				T tmp = _heap[now];
				_heap[now] = _heap[next];
				_heap[next] = tmp;

				now = next;
			}

			return ret;
		}

		public int Count()
		{
			return _heap.Count;
		}
	}
}

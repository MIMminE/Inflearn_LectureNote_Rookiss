using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section_4
{
    // 가장 큰 값을 Pop 한다는 것에서 힙 트리의 개념과 유사하다는 것을 알 수 있다.
    // 정확하게 보면 Binary Heap tree이다.
    class PriorityQueue
    {
        List<int> _heap = new List<int>();

        public void Push(int data)
        {
            // 힙의 맨 끝에 새로운 데이터를 삽입한다.
            _heap.Add(data);

            int now = _heap.Count - 1;
            // 도장깨기 시작
            while(now > 0)
            {
                // 힙 트리의 특징인 구조를 수식으로 파악가능 하다는 점 이용 
                int next = (now - 1) / 2;
                if (_heap[now] < _heap[next])
                    break;

                // 두 값교체
                int tmp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = tmp;

                now = next;
            }
        }

        public int Pop()
        {
            // 반환할 데이터를 따로 저장
            int ret = _heap[0];

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
                if (left <= _heap.Count - 1 && _heap[next] < _heap[left])
                    next = left;
                // 오른쪽값이 현재값(왼쪽 이동 포함)보다 크면, 오른쪽으로 이동
                if (right <= _heap.Count - 1 && _heap[next] < _heap[right])
                    next = right;

                // 왼쪽/오른쪽 모두 현재값보다 작으면 종료
                if (next == now)
                    break;

                // 두 값을 교체한다.
                int tmp = _heap[now];
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

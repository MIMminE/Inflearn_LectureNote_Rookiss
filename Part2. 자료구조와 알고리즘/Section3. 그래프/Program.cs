namespace Section3
{
	// 스택 : LIFO(Last In First Out)
	// 큐 : FIFO(First In First Out)

	class Program
	{
		static void Main(string[] args)
		{
			#region 스택과 큐
			/*
			Stack<int> stack = new Stack<int>();

			stack.Push(101);
			stack.Push(102);
			stack.Push(103);

			int a = stack.Pop();
			int b = stack.Peek();		
		
			Queue<int> queue = new Queue<int>();

			queue.Enqueue(101);
			queue.Enqueue(102);
			queue.Enqueue(103);

			int c = queue.Dequeue();
			int d = queue.Dequeue();
			int e = queue.Peek();
			*/

			/*  기존의 linkedList 등의 자료형을 사용하면 충분히 가능한 기능들을 왜 사용할까?
			 *  추상적으로 사용하기 좋기 때문이다. (예: 스택 구조로 만들게요, 큐 구조로 만들게요)
			 *  실제로 Stack 구현에 있어 List 자료형은 좋은 선택이다. 시간 복잡도의 기준으로 생각해보자.
			 *  반대로 Queue 구현에 있어 List 자료형은 최악의 선택이다. 보통 순환 버퍼라는 것을 이용하여 구현되는 편이다.
			 *  
			 *  실제 게임에서의 응용
			 *  UI 환경에서 팝업창이 여러 개 뜰때, 마지막에 뜬 창이 먼저 꺼져야 한다. (스택 구조)
			 *  네트워크 패킷을 처리할 때 수많은 유저들의 처리를 먼저 온 사람의 패킷 먼저 처리한다. (큐 구조)
			 */
			#endregion
			Vertax v = new Vertax();
			List<Vertax> list_v = v.CreateGraph();
			foreach(var e in list_v)
			{
                Console.WriteLine(e);
            }
		}
	}
}
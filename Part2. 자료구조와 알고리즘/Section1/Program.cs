using System.Collections.Generic;

namespace Section1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			MyList<int> list = new MyList<int>();	
			list.Add(1);
			list.Add(2);
			list.Add(3);

			MyLinkedList<int> myLinkedList = new MyLinkedList<int>();
			myLinkedList.AddLast(1);
			myLinkedList.AddLast(2);
			myLinkedList.AddLast(3);
		}
	}
}
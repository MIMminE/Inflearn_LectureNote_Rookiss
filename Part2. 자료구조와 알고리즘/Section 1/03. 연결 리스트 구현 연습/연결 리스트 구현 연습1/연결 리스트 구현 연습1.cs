using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace MyApp
{
    /* 양방향 연결리스트 구현
     * 연결리스트를 구성하는 각 노드를 의미하는 클래스 필요
     * 연결리스트 자체를 나타내는 클래스 필요
     *  
     */
    
    class MyLinkedList<T>
    {
        public int _nodeCount;
        public MyLinkedListNode<T>? _firstNode = null;
        private MyLinkedListNode<T>? _lastNode = null;

        public MyLinkedListNode<T> AddFirst(T item)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>();
            newNode.item = item;

            if (_nodeCount <= 0)
            {
                _firstNode = newNode;
                _lastNode = newNode;
            }
            else if (_nodeCount == 1)
            {
                _firstNode._next = newNode;
                _lastNode = newNode;
                _lastNode._prev = _firstNode;
            }
            else if (_nodeCount > 1)
            {
                _lastNode._next = newNode;
                newNode._prev = _lastNode;
                _lastNode = newNode;
            }

            _nodeCount++;
            return newNode;
        }
        public void RemoveAt(MyLinkedListNode<T> node)
        {
            MyLinkedListNode<T> targetNode = _firstNode;
            while (true)
            {
                if (targetNode == node)
                {
                    targetNode._next._prev = targetNode._prev;
                    targetNode._prev._next = targetNode._next;
                    break;
                }
                if (targetNode._next == null){
                    break;
                }
                targetNode = targetNode._next;
            }

            _nodeCount--;
        }
    }

    class MyLinkedListNode<T>
    {
        private T _item; // nullable, 널을 허용하는 변수 선언방법
        public T item
        {
            get { return _item; }
            set { _item = value;  }
        }

        public MyLinkedListNode<T>? _prev = null;
        public MyLinkedListNode<T>? _next = null;

    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            LinkedListNode<int> node =  list.AddFirst(1);

            MyLinkedList<int> myList = new MyLinkedList<int>();
            MyLinkedListNode<int> myNode1 =  myList.AddFirst(10);
            MyLinkedListNode<int> myNode2 = myList.AddFirst(20);
            MyLinkedListNode<int> myNode3 = myList.AddFirst(30);

            myList.RemoveAt(myNode2);

            Console.WriteLine(myList._firstNode._next.item);
        }
    } 
}
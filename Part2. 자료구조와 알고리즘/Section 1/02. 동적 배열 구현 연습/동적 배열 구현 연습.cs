using System;
using System.Buffers;
using System.ComponentModel;

namespace MyApp 
{
    /*
     * 동적 배열 구현해보기!
     * 
     * 메소드 Add      : 배열의 마지막에 데이터 추가하기. 단, 배열이 가득찼을 경우 배열을 2배 공간을 확보하여 재할당한 후 추가하기.
     * 메소드 RemoveAt : 배열의 인덱스를 입력으로 받아 해당 인덱스의 데이터를 삭제하기.
     */
    class Program
    { 
        class Mylist<T>
        {
            const int DEFAULT_SIZE = 1;
            private int _count = 0;
            private int _capacity = DEFAULT_SIZE; 
            private T[] mylist = new T[DEFAULT_SIZE];

            public void Add (T item)
            {
                if(_count >= _capacity) // 배열에 할당된 크기보다 데이터가 같거나 많으면
                {
                    T[] new_list = new T[_capacity *= 2]; // 배열의 크기를 2배로 늘려 새로운 배열을 할당한다.

                    for (int i = 0; i < mylist.Length; i++)  // 기존 배열의 데이터들을 그래도 옮긴다.
                        new_list[i] = mylist[i];
                    mylist = new_list;
                }
                mylist[_count] = item;
                _count++;
            }

            public T this[int index]
            {
                get { return mylist[index]; }
                set { mylist[index] = value; }
            }


            public void RemoveAt(int index)
            {
                for (int i = index; i < _count -1; i++) 
                    mylist[i] = mylist[i + 1];

                mylist[_count-1] = default(T);
                _count--;
            }
        }


        static void Main(string[] args)
        {
            List<int> list = new List<int>(); 
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Mylist<int> mylist = new Mylist<int>();
            mylist.Add(1);
            mylist.Add(2);
            mylist.Add(3);
            mylist.Add(4);
            mylist.Add(5);

            mylist.RemoveAt(2);

            Console.WriteLine(mylist[2]);
        }
    }
}
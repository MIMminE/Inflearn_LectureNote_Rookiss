using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace MyApp
{
    // 동적 배열 구현 연습
    class MyArr<T>
    {
        const int DEFAULT_SIZE = 1;
        int count = 0;
        int capacity = DEFAULT_SIZE;

        private T[] _arr;    

        public MyArr()
        {
            _arr = new T[DEFAULT_SIZE];
        }

        public void Add(T item)
        {
            if (count >= capacity)
            {
                capacity *= 2;
                T[] newArr = new T[capacity];
                CarryArr(newArr, _arr);
                _arr = newArr;
            }
            _arr[count] = item;
            count++;
        }

        public void RemoveAt(int index)
        {
            for(int i = index; i < _arr.Length - 1; i++)
                _arr[i] = _arr[i + 1];
            _arr[_arr.Length - 1] = default(T);
            count--;
        }

        public void CarryArr(T[] desArr, T[] souArr)
        {
            for (int i = 0; i < souArr.Length; i++)
                desArr[i] = souArr[i];
        }

        public T this[int index]
        {
            get { return _arr[index]; } 
        }
    }
    enum ItemType
    {
        None,
        Consum,
        Equip,
        Jewel
    }
    class DropTable<T>
    {
        const int DEFAULT_SIZE = 1;
        private int count = 0;
        private int capacity = DEFAULT_SIZE;
        private T[] _arr;

        public void Add(T item)
        {
            if(capacity <= count)
            {
                capacity *= 2;
                T[] newArr = new T[capacity];

                for(int i = 0; i < _arr.Length; i++)
                    newArr[i] = _arr[i];
                _arr = newArr;
                _arr[count] = item;
            }
            else
                _arr[count] = item; 
            
            count++;
        }

        public T this[int index]
        {
            get { return _arr[index]; }
        }

        public DropTable() { _arr = new T[DEFAULT_SIZE]; }
    }
    class Monster
    {
        static private int MonsterID = 0;

        private int _number;

        private DropTable<ItemType> _dropTable;
        public DropTable<ItemType> dropTable
        {
            set { _dropTable = value; }
            get { return _dropTable; }  
        }

        public Monster()
        {
            MonsterID += 1;
            _number = MonsterID; 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DropTable<ItemType> table = new DropTable<ItemType>();

            ItemType item1 = ItemType.Consum;
            ItemType item2 = ItemType.Equip;
            ItemType item3 = ItemType.Jewel;

            table.Add(item1);
            table.Add(item2);
            table.Add(item3);

            Monster monster1 = new Monster();
            monster1.dropTable = table;

            Monster monster2 = new Monster();

            MyArr<Monster> myArr = new MyArr<Monster>();    
            myArr.Add(monster1);
            myArr.Add(monster2);
            myArr.Add(monster1);
            myArr.Add(monster1);

            myArr.RemoveAt(0);
            Console.WriteLine(myArr[1].dropTable[2]);
        }
    } 
}
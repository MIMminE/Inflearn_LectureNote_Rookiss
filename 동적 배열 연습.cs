using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Array
{
    class MyDynamicArray<T>
    {
        const int INIT_SIZE = 1;
        private int dynamic_size = INIT_SIZE;
        private int count = 0;
        private T[] _arr = new T[INIT_SIZE];

        public void Add(T item)
        {
            if (count < dynamic_size)
                _arr[count] = item;
            else
            {
                dynamic_size *= 2;
                T[] new_arr = new T[dynamic_size];

                for (int i = 0; i < _arr.Length; i++)
                    new_arr[i] = _arr[i];
                _arr = new_arr;
                _arr[count] = item;
            }
            count++;   
        }

        public void Insert(int index, T item)
        {
            if (count >= dynamic_size)
            {
                dynamic_size *= 2;
                T[] new_arr = new T[dynamic_size];

                for (int i = 0; i < _arr.Length; i++)
                    new_arr[i] = _arr[i];
                _arr = new_arr;
            }

            for (int i = count; i > index; i--)
            {
                _arr[i] = _arr[i - 1];
            }
            _arr[index] = item;
            count++;
        }

        public void RemoveAt(int index)
        {
            for(int i = index; i < count - 1; i++)
                _arr[i] = _arr[i + 1];
            _arr[count - 1] = default(T);
            count--;

        }

        public T this[int index]
        {
            get { return _arr[index]; }
        } 
    }
}

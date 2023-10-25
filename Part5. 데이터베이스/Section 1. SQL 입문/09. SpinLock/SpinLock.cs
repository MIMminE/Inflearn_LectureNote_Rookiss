using System.Threading;
using System;

namespace SpinLock
{
    class SpinLock
    {
        volatile int _locked = 0;
        public void Acquire()
        {
            while (true)
            {
                //int original = Interlocked.Exchange(ref _locked, 1);
                //original 값이 0이면 잠그기에 성공한 것
                //if (original == 0)
                //    break;
                int desired = 1;
                int expected = 0;

                if (Interlocked.CompareExchange(ref _locked, desired, expected) == expected)
                    break;
            }   
        }

        public void Release()
        {
            _locked = 0;
        }
    }
    class Program
    {
        static int _num = 0;
        static SpinLock _lock = new SpinLock();
        //해당 클래스에서 공유하여 사용하는 SpinLock 인스턴스

        static void Thread_1()
        {
            for (int i = 0; i < 100000; i++)
            {
                _lock.Acquire(); //스핀락 소유권 얻기
                _num++;
                _lock.Release(); //스핀락 소유권 돌려놓기
            }
        }

        static void Thread_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                _lock.Acquire(); //스핀락 소유권 얻기
                _num--;
                _lock.Release(); //스핀락 소유권 돌려놓기
            }
        }

        static void Main(string[] args)
        {
            Task t1 = new Task(Thread_1);
            Task t2 = new Task(Thread_2);

            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);

            Console.WriteLine(_num);
        }
    }
}
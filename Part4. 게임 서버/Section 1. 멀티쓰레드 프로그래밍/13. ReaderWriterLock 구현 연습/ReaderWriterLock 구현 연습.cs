using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore
{
    class Lock
    {
        const int EMPTY_FLAG = 0x00000000;
        const int WRITE_MASK = 0x7FFF0000;
        const int READ_MASK = 0x0000FFFF;
        const int MAX_SPIN_COUNT = 5000;

        // 1비트 : 사용하지 않는 비트
        // 2~16비트 : write 쓰레드 아이디 비트
        // 17 ~ 32 : read 쓰레드 카운트 비트
        // 플래그를 사용하여 락을 관리하는 이유는 재귀적 락을 허용할 경우 어떤 락이 현재 write를 잡고 있는지를 알아야 하므로
        // 쓰레드 정보를 보관하는 공간을 마련해둔 것이다.
        // 재귀적 락을 허용한다는 것은 write 락을 잡은 상태에서 다시 한번 read 락 또는 write 락을 다시한번 잡거나 하는 것을 허용한다는 것이다.
        // 단 read -> write 순으로 락을 잡는 것은 허용하지 않는다.
        int _flag = EMPTY_FLAG;

        int _writeCount = 0; 
        // 재귀적 락을 관리하기 위한 변수, writeCount를 본다는 것은 이미 상호배타적으로 write락을 잡고 있다는 것이 되므로 싱글 스레드처럼 사용 가능하다.


        // 아무도 Write or Read를 획득하고 있을 않을 때, 경합해서 소유권을 얻는다.
        public void WriteLock()
        {
            int lockThreadId = (_flag & WRITE_MASK) >> 16;
            if (Thread.CurrentThread.ManagedThreadId == lockThreadId)
            {
                _writeCount++;
                return;
            }

            int ThreadId = (Thread.CurrentThread.ManagedThreadId << 16) & WRITE_MASK; 

            while (true)
            {
                for(int i = 0; i < MAX_SPIN_COUNT; i++)
                {
                    /*if (_flag == EMPTY_FLAG)
                        _flag = ThreadId; // 이러한 방식은 원자성을 보장하지 못하므로 멀티스레드 환경에서는 적합하지 못한다.*/

                    if (Interlocked.CompareExchange(ref _flag, ThreadId, EMPTY_FLAG) == EMPTY_FLAG)
                    {
                        _writeCount = 1;
                        return;
                    }
                    // 시도를 해서 성공하면 return
                }

                Thread.Yield();
            }
        }
        
        public void WriteUnlock()
        {
            _writeCount--;
            if (_writeCount == 0)
                Interlocked.Exchange(ref _flag, EMPTY_FLAG);
            
        }

        public void ReadLock()
        {
            //아무도 WriteLock를 획득하고 있지 않으면 ReadCount를 1올린다.
            while (true)
            {
                for (int i = 0; i<= MAX_SPIN_COUNT; i++)
                {
                    int expected = _flag & READ_MASK;
                    if (Interlocked.CompareExchange(ref _flag, expected + 1, expected) == expected)
                        return;
                }

                Thread.Yield();
            }
        }

        public void ReadUnlock()
        {
            Interlocked.Decrement(ref _flag);   
        }
    }
}

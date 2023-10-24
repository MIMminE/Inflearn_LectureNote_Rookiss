namespace ExampleDelegate
{
    /*
     * 목표 : Delegate를 이용하여 정렬 함수 구현해보기
     * 날짜 : 2023. 10. 24
     * 배열을 입력으로 주고, Delegate를 이용한 정렬 기준을 입력하여 수행되는 구조 만들어보기
     */

    internal class Program
    {
        delegate void SortType(List<int> list);


        static void SortAscending(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] > list[j])
                    {
                        int tmp = list[j];
                        list[j] = list[i];
                        list[i] = tmp;
                    }
                }
            }
        }

        static void SortDescending(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] < list[j])
                    {
                        int tmp = list[j];
                        list[j] = list[i];
                        list[i] = tmp;
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(5);
            list.Add(3);
            list.Add(7);
            list.Add(9);
            list.Add(6);
            list.Add(1);

            SortType deleFuction = SortAscending;
            //delegate에 정렬의 기본 동작(오름차순 정렬) 설정

            foreach (int e in list)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("_________________");

            //deleFuction -= SortAscending;
            //deleFuction += SortDescending;
            //내림차순으로 변경하고 싶을 때 주석을 풀어주면 된다.

            deleFuction(list);

            foreach (int e in list)
            {
                Console.WriteLine(e);
            }
        }
    }
}
namespace Dynamic_Array
{
    // 동적 배열 구현하기!
   
    class Program
    {
        static void Main(string[] args)
        {
            MyDynamicArray<int> myArray = new MyDynamicArray<int>();

            for (int i = 1; i <= 10; i++)
                myArray.Add(i);

            myArray.Insert(7, 11);
            myArray.RemoveAt(7);

            Console.WriteLine(myArray[9]);
        }




        List<int> myList = new List<int>();
    }
}
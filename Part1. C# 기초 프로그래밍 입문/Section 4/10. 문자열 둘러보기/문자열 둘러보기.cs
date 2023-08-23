using System;

namespace MyApp
{
    class program
    {
        static void Main(string[] args)
        {
            string name = "Harry Potter";

            // 1. 찾기
            bool found = name.Contains("Harry");
            int index = name.IndexOf("Ha");

            // 2. 변형
            name = name + " Junior";
            string lowerCassName = name.ToLower();
            string upperCaseNmae = name.ToUpper();
            string newNmae = name.Replace('r', 'l');

            // 3. 분할
            string[] names = name.Split(new char[] { ' ' });
            string substringName = name.Substring(5);

        }
    }
}
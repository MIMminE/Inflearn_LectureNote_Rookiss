using System;
using System.Buffers;
using System.ComponentModel;
using System.Runtime.ExceptionServices;

namespace MyApp
{
    class Program
    {
        static int GetHighestScore(int[] scores)
        {
            int highestScore = 0;

            foreach (int score in scores)
            {
                if (score > highestScore)
                {
                    highestScore = score;
                }
            }

            return highestScore;
        }

        static int GetAverageScore(int[] scores)
        {
            int totalScore = 0;
            foreach (int score in scores) 
            {   
                totalScore += score;
            }

            return totalScore/scores.Length;
        }

        static int GetIndesOf(int[] scores, int value)
        {
            for (int i = 0; i < scores.Length; i++){
                if (value == scores[i])
                    return i;
            }
            return -1;
        }
        static void Sort(int[] scores)
        {
            for (int i = 0; i < scores.Length - 1; i++)
            {
                for (int j = i + 1; j < scores.Length; j++)
                {
                    if (scores[j] < scores[i])
                    {
                        int tmp = scores[j];
                        scores[j] = scores[i];
                        scores[i] = tmp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int[] scores = new int[5] { 10, 20, 40, 20, 50 };
            Console.WriteLine(GetHighestScore(scores));
            Console.WriteLine(GetAverageScore(scores));
            Console.WriteLine(GetIndesOf(scores, 3));
            Console.WriteLine();
            Sort(scores);

            foreach (int score in scores)
            {
                Console.WriteLine(score);
            }

        }
    }
}
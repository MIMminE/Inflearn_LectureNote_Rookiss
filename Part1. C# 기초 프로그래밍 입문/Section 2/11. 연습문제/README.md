# Section 2-11 연습문제

---

## **연습문제 풀이** 

---

### **구구단 출력**

**문제** : 구구단 2 ~ 9단을 콘솔 창에 출력한다.

```C#
public static void ProblemOne()
{
    for (int i = 2; i < 10; i++)
    {
        for (int j =1; j < 10; j++)
        {
            Console.WriteLine($"{i} * {j} = {i * j}");
        }
    }
}
```

### **별 찍기**

**문제** : 다섯 줄의 별(\*)을 찍는다. 단, 첫 줄에는 한개, 둘째 줄에는 두개 식으로 다섯번째 줄까지 출력한다.

```C#
public static void ProblemTwo()
{
    for (int i = 1; i < 6; i++)
    {
        for (int j = 1; j <= i; j++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
    }
}
```

### **팩토리얼 구하기**

**문제** : 인자로 주어진 숫자에 대한 팩토리얼 값을 구한다.

```C#
public static int ProblemThree(int n, bool OnRecursion = false)
{
    int ret = 1;
    switch (OnRecursion)
    {
        case true:
            if (n == 1) return 1;
            return n * ProblemThree(n - 1, true);

        case false:
            for (int i = 1; i <= n; i++)
                ret *= i;
            break;
    }

    return ret;
}
```

> 인프런 Rookiss 강사님 로드맵 'C#과 유니티로 만드는 MMORPG 게임 개발 시리즈'에 대한 학습을 진행하면서 작성한 개인 기록용 강의노트입니다.
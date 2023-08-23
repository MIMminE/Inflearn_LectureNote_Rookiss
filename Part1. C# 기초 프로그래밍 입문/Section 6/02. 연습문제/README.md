# Section 6-2 연습문제

> 배열을 사용한 간단한 연습문제 풀이
---
### 입력받은 배열에서 가장 큰 수 Return
```C#
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
```
### 입력받은 배열 값들의 평균 Return
```C#
static int GetAverageScore(int[] scores)
{
    int totalScore = 0;
    foreach (int score in scores) 
    {   
        totalScore += score;
    }

    return totalScore/scores.Length;
}
```

### 입력받은 배열에서 입력받은 value 값을 찾아 해당 인덱스 Return
```C#
static int GetIndesOf(int[] scores, int value)
{
    for (int i = 0; i < scores.Length; i++){
        if (value == scores[i])
            return i;
    }
    return -1;
}
```


### 입력받은 배열 정렬
```C#
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
```
- 배열은 참조 타입으로 작동하므로 입력받은 배열의 형태를 바꿔주게될 경우 실제 값도 변경된다.
- 따로 Return를 해주지 않아도 실제값의 변화로 원하는 결과를 얻을 수 있다.
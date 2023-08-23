# Section 6-3 다차원 배열

> 1차원의 배열로 표현하기 어려운 데이터 구조를 표현하기 위한 다차원 배열
---

### 다차원 배열의 선언과 사용
```C#
int[,] arr1 = new int[2, 3];
arr1[0, 0] = 1;
arr1[0, 1] = 2;
arr1[0, 2] = 3;
arr1[1, 0] = 4;
arr1[1, 1] = 5;
arr1[1, 2] = 6;
```
- 2차원 공간은 2, 1차원 공간이 3의 크기를 가진다.
- 1차원 배열과 같이 사용하는 방법은 다양하다.


```C#
int[,] arr2 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
int[,] arr3 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
int[,] arr4 = { { 1, 2, 3 }, { 4, 5, 6 } };
```
### 다차원 배열에서의 Length
```c#
for (int y = 0; y < tiles.GetLength(1); y++)
{
    for (int x = 0; x < tiles.GetLength(0); x++)
    {
        if (tiles[y, x] == 1)
            Console.ForegroundColor = ConsoleColor.Green;
        else
            Console.ForegroundColor = ConsoleColor.Red;
    }
}
```
- 배열에 할당되어 있는 크기를 나타내는 속성인 Length는 배열의 전체 크기이기에 다차원 배열에서는 사용하기에 적합하지 않다. (전체 배열의 크기가 Return 된다)
- GetLength 메소드를 통해 각 차원의 전체 길이를 받아서 사용한다.



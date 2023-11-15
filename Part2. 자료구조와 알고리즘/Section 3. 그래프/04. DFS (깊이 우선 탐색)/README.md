# Section 3-4 DFS (깊이 우선 탐색)
## 깊이 우선 탐색 구현
### 리스트 배열을 이용한 그래프의 DFS

```csharp
bool[] visited = new bool[6];
public void DFS_toList(int now) // 시작 정점
{
    Console.WriteLine(now);
    visited[now] = true;

    foreach (int next in adjacent1[now])
    {
        if (!visited[next])
        DFS_toList(next);
        // 재귀 함수를 이용한다.
    }
}
```

- 인자로 받은 `now`는 탐색의 시작 정점이며 바로 방문한다. (해당 코드에서 방문은 콘솔창에 출력하고 있지만 필요에 따라 여러 방식으로 활용이 가능하다)
- 방문했다는 기록을 남기기 위한 `visited 배열`의 값을 `true`로 변경시킨다. 이렇게 하면 **해당 인덱스에 해당하는 정점은 재방문하지 않게된다.**
- `now`와 연결된 정점들을 하나씩 확인해서, 방문하지 않은 정점을 방문한다.

함수 내에서 자기 자신을 호출하는 재귀함수 방식을 사용하고 있는데, **if 조건으로 방문하지 않은 정점이 있을 때만 호출하도록 설계해야 한다**. 그렇지 않으면 재귀함수를 끝없이 호출하는 구조가 될 것이다.

### 행렬(2차원 배열)을 이용한 그래프의 DFS

```csharp
bool[] visited = new bool[6];
public void DFS_toArray(int now)
{
    Console.WriteLine(now);
    visited[now] = true;

    for(int next = 0; next < adjacent2.GetLength(0); next++)
    {
        if (adjacent2[now, next] == 0) continue; 
        // 2차원 배열은 임의 접근이 가능하므로
        // 연결되지 않은 정점에 대한 탐색은 생략하도록 로직 설계가 가능하다.
        if (!visited[next])
            DFS_toArray(next);
    }
}
```

로직 구조는 크게 달라지지 않는다. 2차원 배열을 이용한 그래프는 인덱스를 이용하여 **특정 정점끼리의 연결 여부를 곧바로 알 수 있기**에 그 점을 이용하여 연결되어 있지 않은 정점에 대한 연산을 스킵할 수 있다.

### 끊어진 그래프 정점에 대한 방문

모든 정점이 연결된 상태의 그래프라면 위에서 작성한 로직만으로도 모든 정점에 대한 탐색이 가능하다. 하지만 중간에 연결이 끊어져 있는 형태의 그래프라면 탐색이 안되는 구간이 발생하게 된다. 끊어진 그래프는 일반적으로 사용되는 데이터 구조는 아니지만 특정 분야에서는 유용하게 사용되기도 한다.

```csharp
public void SearchAll()
{
    for (int i = 0; i < adjacent1.Length - 1; i++)
    {
        if (!visited[i])
            DFS_toList(i);	  
    }
}
```
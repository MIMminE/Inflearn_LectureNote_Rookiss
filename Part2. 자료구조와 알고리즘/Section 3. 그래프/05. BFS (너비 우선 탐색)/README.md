# Section 3-5 BFS (너비 우선 탐색)
## 너비 우선 탐색 구현

너비 우선 탐색은 ‘예약’에 대한 개념을 이용하면 어렵지 않게 구현이 가능하다. 

1. 출발 정점은 바로 방문하고 연결되어 있는 정점들에 대해 방문 예약을 건다. 여기서 예약이라는 것은 곧 방문할 것이라는 신호이다.
2. 가장 오래된 예약된 정점을 방문하고 방문한 정점을 기준으로 연결된 정점들에 대해 방문 예약을 건다.
3. 2번을 반복한다.

### 리스트 배열으로 표현된 그래프 탐색

```csharp
static public List<int>[] adjacent1 = new List<int>[6]
{
	new List<int>() { 1, 3 },
	new List<int>() { 0, 2, 3 },
	new List<int>() { 1 },
	new List<int>() { 0, 1, 4 },
	new List<int>() { 3, 5 },
	new List<int>() { 4 }
};

bool[] found = new bool[6];
public void BFS(int start)
{
    Queue<int> q = new Queue<int>();
    q.Enqueue(start);
    found[start] = true;

	while (q.Count > 0)
	{
		int now = q.Dequeue();
		Console.WriteLine(now);
	
		foreach(int next in adjacent1[now])
		{
			if (!found[next])
			{
				q.Enqueue(next);
				found[next] = true;
			}
		}
	}
}
```

### 행렬로 표현된 그래프 탐색

```csharp
static public int[,] adjacent2 = new int[6,6]
{
	{ 0, 1, 0, 1, 0, 0 },
    { 1, 0, 1, 1, 0, 0 },
    { 0, 1, 0, 0, 0, 0 },
    { 1, 1, 0, 1, 0, 0 },
    { 0, 0, 0, 1, 0, 1 },
    { 0, 0, 0, 0, 1, 0 }
};

bool[] found = new bool[6];
public void BFS_toArray(int start)
{
    Queue<int> q = new Queue<int>();
    q.Enqueue(start);
    found[start] = true;

    while(q.Count > 0)
    {
        int now = q.Dequeue();
        Console.WriteLine(now);

        for (int next = 0; next < adjacent2.GetLength(0); next++)
        {
            if (adjacent2[now, next] == 0) continue;
			if (found[next]) continue;
            q.Enqueue(next);
            found[next] = true;
		}
    }
}
```

너비 우선 탐색은 주로 **최단 경로 관련된 기능에 활용되는 편**이다.
# Section 3-7 다익스트라 최단 경로 알고리즘
## Dijkstra 최단 경로 구현

`BFS`는 그래픵 모든 정점의 거리가 같을 경우에만 사용이 가능한 방법이다. 만약 간선에 가중치가 포함되어 있는 경우에는 다른 방법으로 구현해야하는데, 그 중 `Dijkstra 알고리즘`을 이용할 수 있다.

```csharp
// 가중치가 있는 그래프
static public int[,] adjacent = new int[6, 6]
{
	{ -1, 15, -1, 35, -1, -1 },
	{ 15, -1, 05, 10, -1, -1 },
	{ -1, 05, -1, -1, -1, -1 },
	{ 35, 10, -1, -1, 05, -1 },
	{ -1, -1, -1, 05, -1, 05 },
	{ -1, -1, -1, -1, 05, -1 }
};
```

`Dijkstra`는 `BFS`와 **유사한 구조를 가지고 있지만 예약을 했다고 무조건 바로 방문하지 않는다.** 자신에게 올 수 있는 모든 예약을 받은 이후에 모든 예약 중 가장 좋은 값을 가진 예약을 통해 방문하는 시스템이다. 최단 경로를 구하는 로직이므로 여기서 **가장 좋은 값이라 함은 거리가 짧은 값**을 의미한다.

```csharp
static public void SearchDijkstra(int start)
{
	bool[] visited = new bool[6];
	int[] distance = new int[6];
	int[] parent = new int[6];
	Array.Fill<int>(distance, Int32.MaxValue);

	distance[start] = 0;
	parent[start] = start;
	// Dijkstra 방식은 distance를 확인하여 예약 여부를 확인한다.
}
```

- **visited 배열**
    
    **방문 여부**를 나타낸다. 방문을 했다는 것은 해당 정점에 대한 최단 거리 연산을 끝마쳤다는 것을 의미한다. 즉 해당 배열의 값이 true이면 해당 정점은 다시 예약하지 않는다.
    

- **distance 배열**
    
    각 **정점까지의 최단거리**를 기록하는 배열이다. 로직이 수행되면서 각 배열의 값은 변화하게 된다. 해당 배열에는 매우 큰 값(로직 자체가 최소값을 구해야하므로)으로 초기화시켜준다. 또한, `distance`는 예약을 한 시점에서 값을 변화시키며 방문을 한 순간부터는 변화하지 않는다. **(distance가 초기값 그대로라는 의미는 해당 정점으로 현재까지는 아무도 예약을 하지 않았다는 의미이다)**
    

- **parent 배열**
    
    여러 예약 중에 가장 좋은 값을 가지고 오는 예약자를 의미한다. 즉, **방문을 할 때 어느 정점에서 오고 있는지를 의미**하며 출발지점에서는 자기 자신을 가리키게 된다.
    

```csharp
while (true)
{
	// 제일 좋은 예약자를 찾는다. 

	// 가장 가까운 후보를 저장하는 거리와 정점을 기록할 변수들
	int closest = Int32.MaxValue;
	int now = -1;
	for (int i = 0; i < 6; i++)
	{
		// 이미 방문 정점은 스킵
		if (visited[i]) continue;
		// 아직 예약된 적이 없거나, 기존 후보보다 멀리 있으면 스킵
		if (distance[i] == Int32.MaxValue || distance[i] >= closest) continue;
		// 정보 갱신, 여태 발견한 후보 중 가장 좋은 후보라는 의미
		closest = distance[i];
		now = i;

		/* 여러 정보 중 어떤 기준에 부합한 가장 좋은 정보를 탐색하는 방식으로 
		* 자주 사용되는 방식이다. for문이 끝나게 되면 가장 좋은 값만 
		* closet과 now에 저장된다.
		*/
	}
	
	// 다음 후보가 없거나 연결된 간선이 없다는 의미
	if (now == -1)
		break;
	
	visited[now] = true;
	
	// 방문한 정점과 인접한 정점들을 조사하여
	// 상황에 따라 발견한 최단거리를 갱신한다.
	for (int next = 0; next < 6; next++)
	{
		// 정점이 연겯되어 있지 않다면 스킵
		if (adjacent[now, next] == -1) 
			continue;
		// 이미 방문한 정점이면 스킵
		if (visited[next]) continue;

		// 새로 조사된 정점의 최단거리 계산
		int nextDistance = distance[now] + adjacent[now, next];

		// 계산된 해당 정점으로의 최단거리가 기존의 거리보다 작으면 업데이트 진행
		if (nextDistance < distance[next])
		{
			distance[next] = nextDistance;
			parent[next] = now;
		}
	}
}
```

가장 가까운 예약자를 찾는 로직을 보면 모든 정점을 보고 있음을 볼 수 있다. 이는 정점이 많아질수록 부하를 크게 일으키며, 일반적으로는 `**우선순위 큐**`를 사용하여 구현하여 효율성을 높인다.
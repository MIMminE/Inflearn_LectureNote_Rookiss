# Section 3-6 BFS를 이용한 길찾기 구현
## BFS 최단거리 구현


```csharp
void BFS_practice()
{
	bool[,] found = new bool[_board.Size, _board.Size];
	Pos[,] parent = new Pos[_board.Size, _board.Size];
	int[] deltaY = new int[4] { -1, 1, 0, 0 };
	int[] deltaX = new int[4] { 0, 0, -1, 1 };
	
	Queue<Pos> q = new Queue<Pos>();
	q.Enqueue(new Pos(PosY, PosX));
	found[PosY, PosX] = true;
	parent[PosY, PosX] = new Pos(PosY, PosX);
	
	while (q.Count > 0 )
	{
		Pos now = q.Dequeue();
		int nowY = now.Y;
		int nowX = now.X;
	
		for ( int i = 0; i < 4; i++)
		{
			int nextY = nowY + deltaY[i];
			int nextX = nowX + deltaX[i];
			// 배열의 유효범위를 초과하는 연산을 막기 위하여 사용된 조건식
			if (nextY < 0 || nextY >= _board.Size || nextX < 0 || nextX >= _board.Size) continue;
			// 간선으로 연결이 되었는지(이동이 가능한지아닌지)
			if (_board.Tile[nextY, nextX] != Board.TileType.Wall)
			{
				// 이전에 이미 방문한 곳인지 아닌지)
				if (found[nextY, nextX]) continue;
				q.Enqueue(new Pos(nextY, nextX));
				found[nextY, nextX] = true;
				parent[nextY, nextX] = new Pos(nowY, nowX);
			}
		}
	}

	// 해당 부분에 추가 코드 작성 필요
}
```

기존에 사용하던 타일 맵에 적용하기 위해서는 각 좌표의 상하좌우 이동 가능 여부에 대한 정보를 마치 그래프처럼 사용해주어야 한다. (이부분이 매우 어렵다) 

```csharp
int[] deltaY = new int[4] { -1, 1, 0, 0 };
int[] deltaX = new int[4] { 0, 0, -1, 1 };
```

Y좌표와 X좌표의 상하좌우 이동에 대한 좌표변화를 위와 같이 관리하면 길게 코드를 작성하지 않아도 간편하게 각 정점의 상하좌우가 이동가능한 곳인지 아닌지에 대한 판단이 가능하다.

그외에는 1차원이던 그래프 BFS를 2차원에 적용하는 부분은 **2차원 배열을 하나의 클래스나 구조체로 매핑하는 방법으로도 가능해보인다.** 

위의 코드는 **탐색만을 진행할 뿐 실제 경로를 이동시켜주고 있지는 않다.** 아래코드를 추가적으로 포함시켜야만 최단거리를 실제 리스트에 저장하여 해당 좌표값을 이동하여 최단거리 이동을 할 수 있다.

```csharp
int parentY = _board.DesY;
int parentX = _board.DesX;
while(parentY != parent[parentY, parentX].Y || parentX != parent[parentY, parentX].X )
{
    _movePath.Add(new int[2] { parentY, parentX });
	// 부모의 위치가 아닌 자기 자신의 위치를 넣어주고 있음에 주의하자.
    parentY = parent[parentY, parentX].Y;
    parentX = parent[parentY, parentX].X;
}
_movePath.Add(new int[2] { parent[parentY, parentX].Y, parent[parentY, parentX].X });
_movePath.Reverse();
// 리스트를 역으로 넣어주었으므로 역전을 해주어야 출발지가 정상적으로 셋팅된다.
```
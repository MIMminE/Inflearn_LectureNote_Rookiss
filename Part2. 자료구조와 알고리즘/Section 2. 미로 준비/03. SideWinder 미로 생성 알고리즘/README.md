# Section 2-3 SideWinder 미로 생성 알고리즘
## SideWinder 미로

Binary Tree미로와 유사한 방식으로 랜덤한 미로를 생성하는 알고리즘이다. 차이점이라면 우측으로 길을 뚫는 횟수에 비례하여 아래로 뚫는 로직이 수행될 때 자신 위치에서 아래로 뚫는 것이 아닌 이전에 우측으로 연속적으로 뚫어온 위치 중 랜덤하게 아래로 뚫게 된다. 

```csharp
for (int y = 1; y < size; y += 2)
{
	int rightCount = 0;
	for (int x = 1; x < size; x += 2){
		int randValue = rand.Next(0, 2);
		if (randValue == 0)
		{
			int xValue = rand.Next(0, rightCount + 1);
			_tile[y + 1, x - xValue * 2] = TileType.Empty;
		
			rightCount = 0;
		}
		else
		{
			_tile[y, x + 1] = TileType.Empty;
			rightCount++;
		}
	}	
}
```

`rightCount` 를 변수를 이용하여 우측으로 길을 뚫은 횟수를 이용해주면 쉽게 변형이 가능하다.
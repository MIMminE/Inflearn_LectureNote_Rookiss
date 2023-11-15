# Section 2-4 플레이어 이동

## 객체지향 로직의 책임


프로그램 상에서 어떤 동작에 대한 책임은 해당 동작의 메인이 되는 객체가 가지고 있는 것이 설계적으로 옳다. 예를 들어 맵에서 캐릭터의 이동이라는 동작은 맵이라는 공간에서 캐릭터가 이동하는 개념이므로 캐릭터가 이동 로직에 대한 책임을 가지고 있는 것이 되어야 하고 관련 로직들도 캐릭터 클래스에서 작성되어야 한다.

이때, 캐릭터는 맵에 대한 정보를 필요로 하기 때문에 객체의 생성과 초기화 단계에서 맵에 대한 정보를 넣어주어야 한다.

```csharp
class Player
{
    public int PosY { get; private set; } 
    public int PosX { get; private set; }
		// 내부에서는 변경 가능, 외부에서는 변경 불가능

    private Board _board;

		public void Initialize(int posY, int posX, int destY, int destX, Board board)
		{
		    PosY = posY;
		    PosX = posX;
		    _board = board;
		}
}
```

### 루프 속에서 Tick를 기준으로 한 로직 제어

```csharp
while (true)
{
		// 입력

		// 로직

		// 렌더링
}
```

위와 같은 방식이 일반적인 게임 클라이언트 설계이다. 저 루프를 게임루프라고도 부르며 렌더링이 1초에 몇번씩 실행되냐에 따라 프레임 값이 결정되며 프레임이 30FPS(초당 프레임 시간) 이하로 떨어지게 되면 버벅이는 현상이 발생할 수 있다고 본다. 

이를 기반으로 본다면 렌더링은 최소 1초에 30번 이상 실행되어야 하고 많아지면 그래픽에 대한 표현력이 우수해진다. 하지만 입력과 로직 부분까지 그렇게 실행되는 것은 좋은 방법이 아닐 수 있다. 오히려 일정 시간을 두고 실행되어야 하는 로직들이 더 많고 너무 잦은 로직 실행은 프로그램을 무겁게 만들기 때문이다. 

이러한 상황을 제어하기 위해 프레임 관리를 하며 여러 방식이 있지만 여기서는 `System.Environment.TickCount`라는 현재 시스템의 밀리세컨드 단위로 표현된 시간을 이용한다. 

```csharp
int currentTick = System.Environment.TickCount;
if (currentTick - lastTick < WAIT_TICK)
    continue;
int deltaTick = currentTick - lastTick;
lastTick = currentTick;

player.Update(deltaTick);
```

반환 타입은 int이므로 1초에 해당하는 값은 10,000이 된다. 프로그램이 시작된 후 경과된 전체 시간을 반환하는 점을 이용하여 몇 초 간격으로 로직을 제어할 수 있다. 

```csharp
const int MOVE_TICK = 100; // 0.1초
int sum_tick = 0; // Update 문에서만 사용될 변수들이므로 해당 위치에 선언

public void Update(int deltaTick)
{
    sum_tick += deltaTick; // 입력으로 들어온 경과시간을 누적하여 일정 수치에 도달하면 로직 수행
    if(sum_tick >= MOVE_TICK) 
    {
        sum_tick = 0; // 누적시간을 다시 초기화하여 다음 로직 수행시간까지 대기
        RandMove();
    }
}
```

`deltaTick`은 이전 로직 실행 후 경과한 시간이 되고 내부적으로 위 코드와 같이 사용하여 제어한다.

### 플레이어 이동

일정 시간마다 플레이어 좌표를 이동시켜주는 RandMove 메소드를 실행하도록 설정하였다. 플레이어 이동에 있어서 주의할 점은 벽에 해당하는 좌표로는 이동이 불가능하므로 Board의 좌표 정보를 읽어와 판단을 하며 이동로직을 수행해야 한다.

```csharp
private void RandMove()
{
    int randValue = rand.Next(0, 4);
    switch(randValue)
    {
        case 0: //상
            if (_board.Tile[PosY - 1, PosX] == Board.TileType.Empty)
                PosY -= 1;
            break;
        case 1: //하
            if (_board.Tile[PosY + 1, PosX] == Board.TileType.Empty)
                PosY += 1;
            break;
        case 2: //좌
            if (_board.Tile[PosY, PosX - 1] == Board.TileType.Empty)
                PosX -= 1;
            break;
        case 3: //우
            if (_board.Tile[PosY, PosX + 1] == Board.TileType.Empty)
                PosX += 1;
            break;
    }
}
```
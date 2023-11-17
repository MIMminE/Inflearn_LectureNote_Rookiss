# Section 0 환경설정
## 프레임 관리

게임 클라이언트는 기본적으로 `입력 → 로직 → 렌더링`의 순서로 프로세스가 설계되어 있다. 

- 입력 : 사용자의 키보드와 마우스 등에 의한 입력 감지
- 로직 : 입력된 키에 대한 이벤트 처리 및 로직 수행
- 렌더링 : 수행된 기능들이 반영된 세상을 렌더링(DirextX, OpenGL 등의 라이브러리)

만약 로컬 게임이 아닌 서버가 결합되어 있는 게임이라면 로직 수행 부분을 서버가 담당하고 통신이 오가며 렌더링을 클라이언트가 해주는 방식을 대체로 사용한다.

```csharp
while(true)
{
	// 입력

	// 로직

	// 렌더링
}
```

무한으로 돌면서 현재 게임 세계 상태를 렌더링 해주는 것인데, 프레임이란 **1초에 몇 번 렌더링이 되냐를 의미**한다. 보통 FPS게임에서는 60프레임 정도를 기준으로 삼고 30프레임 밑으로 떨어지면 크게 문제가 생긴다는 것으로 본다.

```csharp
const int WAIT_TICK = 1000 / 30; 
// 1/30초에 한번 렌더링 되도록 하기 위한 값, 하드코딩을 피하기 위한 상수설정
int lastTick = 0;
while(true)
{
		#region 프레임 관리 
			int currentTick = System.Environment.TickCount;
												//시스템 시간을 기준으로 하며, 밀리 초 단위이다.
			if (currentTick - lastTick < WAIT_TICK)
			    continue;
			lastTick = currentTick;
		#endregion
}
```

### 콘솔에 좌표 그리기

```csharp
int lastTick = 0;

const int WAIT_TICK = 1000 / 30;
const char CIRCLE = '\u25cf'; // 원에 해당하는 코드
ConsoleColor DEFAULT_COLOR = Console.ForegroundColor;
Console.CursorVisible = false;
while (true)
{
    #region 프레임 관리 

    Console.SetCursorPosition(0, 0);
    Console.ForegroundColor = ConsoleColor.Green;
    for (int i = 0; i < 25; i++)
    {
        for (int j = 0; j < 25; j++)
        {
            Console.Write(CIRCLE);
        }
        Console.WriteLine();
    }
    Console.ForegroundColor = DEFAULT_COLOR;
}
```
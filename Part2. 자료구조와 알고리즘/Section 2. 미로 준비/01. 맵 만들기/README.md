# Section 2-1 맵 만들기
## Board 클래스 구현

`Board 클래스`의 주 기능은 맵을 구성하는 타일을 생성하고 콘솔 창에 렌더링을 하는 것이다. 각 기능은 `init 메소드`와 `Render 메소드`를 통해 구현한다.

```csharp

class Board
{
		// 맵의 벽과 길을 판단할 수 있는 직관적인 enum 타입 선언
    public enum TileType
    {
        Empty,
        Wall
    }

    // 2차원 배열로 사용
    private TileType[,] _tile;
    public int _size;

    public void init(int size)
    {
        _tile = new TileType[size, size];
        _size = size;

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                if (x == 0 || y == 0 || x == _size - 1 || y == _size - 1)
                {
                    _tile[y, x] = TileType.Wall;
                    continue;
                }
                _tile[y, x] = TileType.Empty;
            }
        }
		}
}
```

```csharp
// 해당 메소드를 프레임마다 실행하여 렌더링을 진행한다.
public void Render()
{       
	    const char CIRCLE = '\u25cf';
	    ConsoleColor DEFAULT_COLOR = Console.ForegroundColor;
	    Console.CursorVisible = false;
	
	    Console.SetCursorPosition(0, 0);
	
	    for (int i = 0; i < _size; i++)
	    {
	        for (int j = 0; j < _size; j++)
	        {
	            GetTileColor(_tile[i, j]);
	            Console.Write(CIRCLE);
	        }
	        Console.WriteLine();
	    }
	    Console.ForegroundColor = DEFAULT_COLOR;
}

// 콘솔 창에서의 색상 표현을 위한 기능
public void GetTileColor(TileType tileType)
{
	    if (tileType == TileType.Empty) Console.ForegroundColor = ConsoleColor.Green;
	    else Console.ForegroundColor = ConsoleColor.Red;
}
```

```csharp
static void Main(string[] args)
 {
	     Board _board = new Board();
	     _board.init(25);
	
	     int lastTick = 0;
	     while (true)
	     {
	         #region 프레임 관리 
	         int currentTick = System.Environment.TickCount;
	         if (currentTick - lastTick < WAIT_TICK)
	             continue;
	         lastTick = currentTick;
	         #endregion
					
	         _board.Render();
	     }
 }
```

결과적으로 보면 프레임 관리에 로직에 의하여 1/30초 단위로 한번씩 Render 메소드가 실행된다. 중간에 **_board의 타일을 변화시켜주는 로직이 실행된다면 지속적으로 콘솔에 출력되는 모습에 변화가 있을 것이다.** 이런 방식이 일반적인 클라이언트 프로그램의 렌더링 과정이다.
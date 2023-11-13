using System.Drawing;

namespace DataStructure
{
    class Board
    {
        public enum TileType
        {
            Empty,
            Wall,
            Dest,
			Player
		}

        // 2차원 배열로 사용
        public TileType[,] Tile {  get; private set; }
        public int Size { get; private set; }
        private Player _player;
        Random rand = new Random();

        public int DesY { get; private set; }
        public int DesX { get; private set; }
        public void SetDestYX(int y, int x) {  DesY = y; DesX = x; Tile[y, x] = TileType.Dest; }

        #region Tile 초기화 로직
        public void Init(int size, Player player)
        {
            Tile = new TileType[size, size];
            Size = size;
            _player = player;

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (x == 0 || y == 0 || x == Size - 1 || y == Size - 1)
                    {
                        Tile[y, x] = TileType.Wall;
                        continue;
                    }
                    Tile[y, x] = TileType.Empty;
                }
            }
        }

        public void InitBinaryTree(int size, Player player)
        {
            Tile = new TileType[size, size];
            Size = size;
            _player = player;

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (x % 2 == 0 | y % 2 == 0)
                    {
                        Tile[y, x] = TileType.Wall;
                        continue;
                    }
                    
                    if (x == DesX && y == DesY)
                    {
						Tile[y, x] = TileType.Dest;
                        continue;
					}
                    Tile[y, x] = TileType.Empty;
                }
            }

            for (int y = 1; y < size; y += 2)
            {
                for (int x = 1; x < size; x += 2)
                {
					if (x == DesX && y == DesY)
					{
						Tile[y, x] = TileType.Dest;
						continue;
					}

					if (x == size - 2 && y == size - 2)
                        continue;

                    if( x == size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }
                    if (y == size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
		

					int randValue = rand.Next(0, 2);
                    if (randValue == 0)
                        Tile[y + 1, x] = TileType.Empty;
                    else
                        Tile[y, x + 1] = TileType.Empty;
                }
            }
        }

        public void InitSidWinder(int size, Player player)
        {
            Tile = new TileType[size, size];
            Size = size;
            _player = player;

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
					if (x % 2 == 0 | y % 2 == 0)
                    {
                        Tile[y, x] = TileType.Wall;
                        continue;
                    }
                    Tile[y, x] = TileType.Empty;
                }
            }
            for (int y = 1; y < size; y += 2)
            {
                int rightCount = 0;
                for (int x = 1; x < size; x += 2)
                {
                    if (x == size - 2 && y == size - 2)
                        continue;

                    if (x == size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }
                    if (y == size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    int randValue = rand.Next(0, 2);
                    if (randValue == 0)
                    {
                        int xValue = rand.Next(0, rightCount + 1);
                        Tile[y + 1, x - xValue * 2] = TileType.Empty;

                        rightCount = 0;
                    }
                    else
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        rightCount++;
                    }
                        
                }
            }

        }
        #endregion

        #region Render 로직
        public void Render()
        {       
            const char CIRCLE = '\u25cf';
            ConsoleColor DEFAULT_COLOR = Console.ForegroundColor;
            Console.CursorVisible = false;

            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {

                    if(y == _player.PosY && x == _player.PosX)
                        GetTileColor(TileType.Player);
                    else
                        GetTileColor(Tile[y, x]);
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = DEFAULT_COLOR;
        }
        public void GetTileColor(TileType tileType)
        {
            if (tileType == TileType.Empty) Console.ForegroundColor = ConsoleColor.Green;
            else if (tileType == TileType.Player) Console.ForegroundColor = ConsoleColor.Blue;
			else if (tileType == TileType.Dest) Console.ForegroundColor = ConsoleColor.Yellow;
			else Console.ForegroundColor = ConsoleColor.Red;
        }
        #endregion

    }
}

namespace DataStructure
{
    class Player
    {
        public int PosY { get; private set; }
        public int PosX { get; private set; }
        private Board _board;
        Random rand = new Random();

        public void Initialize(int posY, int posX, int destY, int destX, Board board)
        {
            PosY = posY;
            PosX = posX;
            _board = board;
        }

        const int MOVE_TICK = 100; // 0.1초
        int sum_tick = 0; // Update 문에서만 사용될 변수들이므로 해당 위치에 선언
        public void Update(int deltaTick)
        {
            sum_tick += deltaTick;
            if(sum_tick >= MOVE_TICK)
            {
                sum_tick = 0;
                RandMove();
            }
        }

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
    }
}

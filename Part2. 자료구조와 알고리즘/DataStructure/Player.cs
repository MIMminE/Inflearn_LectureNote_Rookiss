﻿namespace DataStructure
{
    class Player
    {
        public enum Dir
        {
            Up = 0,
            Left = 1,
			Down = 2,
			Right = 3
        }
       
        public int PosY { get; private set; }
        public int PosX { get; private set; }
        private Board _board;
        private int _dir = (int)Dir.Up;
        private List<int[]> _movePath = new List<int[]>();

		Random rand = new Random();

        public void Initialize(int posY, int posX, int destY, int destX, Board board)
        {
            PosY = posY;
            PosX = posX;
            _board = board;
            _board.SetDestYX(destY, destX);

            int[] frontY = new int[4] { -1, 0, 1, 0 };
			int[] frontX = new int[4] { 0, -1, 0, 1 };
            // 목적지에 도착했는지 확인
			while (PosY != board.DesY || PosX != board.DesX)
            {
				// 1. 현재 바라보는 방향을 기준으로 오른쪽으로 갈 수 있는지 확인.
				if (_board.Tile[PosY + frontY[(_dir - 1 + 4) % 4], PosX + frontX[(_dir - 1 + 4) % 4]] != Board.TileType.Wall) 
                {
                    // 오른족 방향으로 90도 회전, 앞으로 전진
                    _dir = (_dir - 1 + 4) % 4;
                    PosY = PosY + frontY[_dir];
                    PosX = PosX + frontX[_dir];
                    _movePath.Add(new int[2] { PosY, PosX });
				}
                // 2. 현재 바라보는 방향으로 앞으로 갈 수 있는지 확인.
                else if (_board.Tile[PosY + frontY[_dir], PosX + frontX[_dir]] != Board.TileType.Wall)
                {
					PosY = PosY + frontY[_dir];
					PosX = PosX + frontX[_dir];
					_movePath.Add(new int[2] { PosY, PosX });
				}
                else
                {
					// 왼쪽 방향 90도 회전
					_dir = (_dir + 1 + 4) % 4;
				}

            }
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
        int Move_count = 0;
        private void RandMove()
        {
            if(_movePath.Count > Move_count)
            {
				PosY = _movePath[Move_count][0];
				PosX = _movePath[Move_count][1];
				Move_count++;
			}
			/*
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
            }*/
		}
    }
}

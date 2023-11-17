using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Section_5;

namespace Section_2.src
{
	public class Player
	{
		public enum Dir
		{
			Up = 0,
			Left = 1,
			Down = 2,
			Right = 3
		}
		class Pos
		{
			public Pos(int y, int x) { Y = y; X = x; }
			public int Y;
			public int X;
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
			//RightHand();

			AStart();
		}
		#region 플레이어 이동 로직 (우수법, BFS, A*)
		
		struct PQNode : IComparable<PQNode>
		{
			public int G;
			public int H;
			public int Y;
			public int X;

			public int CompareTo(PQNode other)
			{
				if (G + H == other.G + other.H)
					return 0;
				return G + H < other.G + H ? 1 : -1;
			}
		}

		void AStart()
		{
			// F = G + H
			// G = 시작점에서 해당 좌표까지 이동하는데 드는 비용 (경로에 따라 달라짐)
			// H = 목적지에서 얼마나 가까운지에 대한 값 (어떤 방식으로 계산할지는 사용자 결정)

			// 방문 여부를 확인하는 closed 리스트 
			bool[,] closed = new bool[_board.Size, _board.Size];

			// 경로 예약 여부를 확인하는 open 리스트, 초기값은 매우 큰값(F값을 이용하여 예약)
			int[,] open = new int[_board.Size, _board.Size];
			for (int y = 0; y < _board.Size; y++)
				for (int x =0; x < _board.Size; x++)
					open[y, x] = Int32.MaxValue;

			// open 리스트에서 가장 좋은 정보를 뽑아오기 위한 우선순위 큐
			PriorityQueue<PQNode> pq = new PriorityQueue<PQNode>();

			// 시작 좌표이므로 이동 경로 비용 0
			open[PosY, PosX] = 0 + Heuristic(PosY, PosX, _board.DesY, _board.DesX);
			pq.Push(new PQNode() { G = 0, H = Heuristic(PosY, PosX, _board.DesY, _board.DesX), Y = PosY, X = PosX});	

			while (true)
			{
				// 제일 좋은 후보 탐색, 우선순위 큐를 사용하면 편리하다.
			}
		}
		
		// 휴리스틱 정책에 따른 함수 정의
		int Heuristic(int PosY,int PosX,int DesY, int DesX)
		{
			return Math.Abs(DesY - PosY) + Math.Abs(DesX - PosX);
		}
		
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

			while (q.Count > 0)
			{
				Pos now = q.Dequeue();
				int nowY = now.Y;
				int nowX = now.X;

				for (int i = 0; i < 4; i++)
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


			int parentY = _board.DesY;
			int parentX = _board.DesX;
			while (parentY != parent[parentY, parentX].Y || parentX != parent[parentY, parentX].X)
			{
				_movePath.Add(new int[2] { parentY, parentX });
				parentY = parent[parentY, parentX].Y;
				parentX = parent[parentY, parentX].X;
			}
			_movePath.Add(new int[2] { parent[parentY, parentX].Y, parent[parentY, parentX].X });
			_movePath.Reverse();

		}
		void BFS()
		{
			int[] deltaY = new int[] { -1, 0, 1, 0 };
			int[] deltaX = new int[] { 0, -1, 0, 1 };


			bool[,] found = new bool[_board.Size, _board.Size];
			Pos[,] parent = new Pos[_board.Size, _board.Size];

			Queue<Pos> q = new Queue<Pos>();
			q.Enqueue(new Pos(PosY, PosX));
			found[PosY, PosX] = true;
			parent[PosY, PosX] = new Pos(PosY, PosX);

			while (q.Count > 0)
			{
				Pos pos = q.Dequeue();
				int nowY = pos.Y;
				int nowX = pos.X;

				for (int i = 0; i < 4; i++)
				{
					int nextY = nowY + deltaY[i];
					int nextX = nowX + deltaX[i];
					if (nextX < 0 || nextX >= _board.Size || nextY < 0 || nextY >= _board.Size)
						continue;
					if (_board.Tile[nextY, nextX] == Board.TileType.Wall)
						continue;
					if (found[nextY, nextX])
						continue;

					q.Enqueue(new Pos(nextY, nextX));
					found[nextY, nextX] = true;
					parent[nextY, nextX] = new Pos(nowY, nowX);
				}
			}

			int y = _board.DesY;
			int x = _board.DesX;
			while (parent[y, x].Y != y || parent[y, x].X != x)
			{
				_movePath.Add(new int[] { y, x });
				Pos pos = parent[y, x];
				y = pos.Y;
				x = pos.X;
			}
			_movePath.Add(new int[] { y, x });
			_movePath.Reverse();
		}
		void RightHand()
		{

			int[] frontY = new int[4] { -1, 0, 1, 0 };
			int[] frontX = new int[4] { 0, -1, 0, 1 };
			// 목적지에 도착했는지 확인
			while (PosY != _board.DesY || PosX != _board.DesX)
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

		#endregion
		const int MOVE_TICK = 100; // 0.1초
		int sum_tick = 0; // Update 문에서만 사용될 변수들이므로 해당 위치에 선언
		public void Update(int deltaTick)
		{
			sum_tick += deltaTick;
			if (sum_tick >= MOVE_TICK)
			{
				sum_tick = 0;
				RandMove();
			}
		}
		int Move_count = 0;
		private void RandMove()
		{
			if (_movePath.Count > Move_count)
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

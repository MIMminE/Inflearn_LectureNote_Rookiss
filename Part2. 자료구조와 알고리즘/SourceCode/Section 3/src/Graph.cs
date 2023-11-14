using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section_3.src
{
	class Vertax
	{
		public List<Vertax> edges = new List<Vertax>();
		public List<Vertax> CreateGraph()
		{
			List<Vertax> v = new List<Vertax>(6)
			{
				new Vertax(),
				new Vertax(),
				new Vertax(),
				new Vertax(),
				new Vertax(),
				new Vertax()
			};

			v[0].edges.Add(v[1]);
			v[0].edges.Add(v[3]);

			v[1].edges.Add(v[0]);
			v[1].edges.Add(v[2]);
			v[1].edges.Add(v[3]);

			v[3].edges.Add(v[4]);

			v[5].edges.Add(v[4]);

			return v;
		}
	}

	class Edge
	{
		public int _destVertax;
		public int _weight;
		public Edge(int destVertax, int weight)
		{
			_destVertax = destVertax;
			_weight = weight;
		}
	}

	class GraphTest
	{
		#region 그래프 이론
		static public List<int>[] adj1 = new List<int>[6]
		{
			new List<int> { 1, 3 },
			new List<int> { 0, 2, 3 },
			new List<int> { },
			new List<int> { 4 },
			new List<int> { },
			new List<int> { 4 }
		};

		static public List<Edge>[] adj2 = new List<Edge>[6]
		{
			new List<Edge> { new Edge(1, 15), new Edge(3, 35) },
			new List<Edge> { new Edge(0, 15), new Edge(2, 5), new Edge(3, 10) },
			new List<Edge> { },
			new List<Edge> { new Edge(4, 5) },
			new List<Edge> { },
			new List<Edge> { new Edge(4, 5) },
		};

		static public int[,] adj3 = new int[6, 6]{
			{ 0, 1, 0, 1, 0, 0 },
			{ 1, 0, 1, 1, 0, 0 },
			{ 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 1, 0 },
			{ 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 1, 0 }
		};

		static public int[,] adj4 = new int[6, 6]{
			{ -1, 15, -1, 35, -1, -1 },
			{ 15, -1, 05, 10, -1, -1 },
			{ -1, -1, -1, -1, -1, -1 },
			{ -1, -1, -1, -1, 05, -1 },
			{ -1, -1, -1, -1, -1, -1 },
			{ -1, -1, -1, -1, 05, -1 }
		};
		#endregion

		#region 그래프 생성 실습 

		static public List<int>[] adjacent1 = new List<int>[6]
		{
			new List<int>() { 1, 3 },
			new List<int>() { 0, 2, 3 },
			new List<int>() { 1 },
			new List<int>() { 0, 1, 4 },
			new List<int>() { 3, 5 },
			new List<int>() { 4 }
		};

		static public int[,] adjacent2 = new int[6, 6]
		{
			{ 0, 1, 0, 1, 0, 0 },
			{ 1, 0, 1, 1, 0, 0 },
			{ 0, 1, 0, 0, 0, 0 },
			{ 1, 1, 0, 0, 1, 0 },
			{ 0, 0, 0, 1, 0, 1 },
			{ 0, 0, 0, 0, 1, 0 }
		};

		#endregion

		#region 깊이 우선 탐색(DFS)
		// 1) 우선 now부터 방문하고
		// 2) now와 연결된 정점들을 하나씩 확인해서, 방문하지 않은 정점을 방문한다.
		bool[] visited = new bool[6];
		public void DFS_toList(int now) // 시작 정점
		{
			Console.WriteLine(now);
			visited[now] = true;

			foreach (int next in adjacent1[now])
			{
				if (!visited[next])
					DFS_toList(next);
			}
		}

		public void DFS_toArray(int now)
		{
			Console.WriteLine(now);
			visited[now] = true;

			for (int next = 0; next < adjacent2.GetLength(0); next++)
			{
				if (adjacent2[now, next] == 0) continue;
				if (!visited[next])
					DFS_toArray(next);
			}
		}

		public void SearchAll()
		{
			for (int i = 0; i < adjacent1.Length - 1; i++)
			{
				if (!visited[i])
				{
					DFS_toList(i);
				}
			}
		}
		#endregion

		#region 너비 우선 탐색 (BFS)
		bool[] found = new bool[6];
		public void BFS_toList(int start)
		{
			Queue<int> q = new Queue<int>();
			q.Enqueue(start);
			found[start] = true;

			while (q.Count > 0)
			{
				int now = q.Dequeue();
				Console.WriteLine(now);

				foreach (int next in adjacent1[now])
				{
					if (!found[next])
					{
						q.Enqueue(next);
						found[next] = true;
					}
				}
			}
		}

		public void BFS_toArray(int start)
		{
			Queue<int> q = new Queue<int>();
			q.Enqueue(start);
			found[start] = true;

			while (q.Count > 0)
			{
				int now = q.Dequeue();
				Console.WriteLine(now);

				for (int next = 0; next < adjacent2.GetLength(0); next++)
				{
					if (adjacent2[now, next] == 0) continue;
					if (found[next]) continue;
					q.Enqueue(next);
					found[next] = true;
				}
			}
		}
		#endregion

		#region 코딩 테스트 문제 DFS 알고리즘 예제

		static public int[,] Sample = new int[,]
		{
			{ 1, 0, 1, 1, 1 },
			{ 1, 0, 1, 0, 1 },
			{ 1, 0, 1, 1, 1 },
			{ 1, 1, 1, 0, 1 },
			{ 0, 0, 0, 0, 1 }
		};


		public node[,] MapConvert(int[,] map)
		{
			int mapLengthY = map.GetLength(0);
			int mapLengthX = map.GetLength(1);

			node[,] nodeArray = new node[mapLengthY, mapLengthX];
			int num = 0;
			for (int i = 0; i < mapLengthY; i++)
			{
				for (int j = 0; j < mapLengthX; j++)
				{
					num++;
					nodeArray[i, j] = new node() { id = num, x = j, y = i, IsValid = IsValid(map, i, j), distance = 0, perent = 0 };
				}
			}
			return nodeArray;
		}
		public int[] IsValid(int[,] map, int posY, int posX)
		{
			int[] isValid = { 0, 0, 0, 0 };
			int[,] moveDelta = new int[4, 2]
			{
				{ -1, 0 },
				{ +1, 0 },
				{ 0, -1 },
				{ 0, +1 }
			};

			bool[] useIndex = new bool[4] { true, true, true, true }; // 상 하 좌 우
			if (posY == 0) useIndex[0] = false;
			if (posY == map.GetLength(0) - 1) useIndex[1] = false;
			if (posX == 0) useIndex[2] = false;
			if (posX == map.GetLength(1) - 1) useIndex[3] = false;

			for (int i = 0; i < 4; i++)
			{
				if (useIndex[i])
					if (map[posY + moveDelta[i, 0], posX + moveDelta[i, 1]] == 1) isValid[i] = 1;
			}

			return isValid;
		}


		public void Solution(int[,] maps)
		{
			int startX = 0;
			int startY = 0;
			node[,] map = MapConvert(maps);
			bool[,] found = new bool[map.GetLength(0), map.GetLength(1)];

			Queue<node> q = new Queue<node>();
			q.Enqueue(map[startY, startX]);
			found[startY, startX] = true;

			int nowY = startY;
			int nowX = startX;
			while (q.Count > 0)
			{
				node now = q.Dequeue();
				nowY = now.y;
				nowX = now.x;
				if (now.IsValid[0] == 1)
				{
					if (found[nowY - 1, nowX] == false)
					{
						map[nowY - 1, nowX].distance = map[nowY, nowX].distance + 1;
						q.Enqueue(map[nowY - 1, nowX]);
						found[nowY - 1, nowX] = true;
					}
				}
				if (now.IsValid[1] == 1)
				{
					if (found[nowY + 1, nowX] == false)
					{
						map[nowY + 1, nowX].distance = map[nowY, nowX].distance + 1;
						q.Enqueue(map[nowY + 1, nowX]);
						found[nowY + 1, nowX] = true;
					}
				}
				if (now.IsValid[2] == 1)
				{
					if (found[nowY, nowX - 1] == false)
					{
						map[nowY, nowX - 1].distance = map[nowY, nowX].distance + 1;
						q.Enqueue(map[nowY, nowX - 1]);
						found[nowY, nowX - 1] = true;
					}
				}
				if (now.IsValid[3] == 1)
				{
					if (found[nowY, nowX + 1] == false)
					{
						map[nowY, nowX + 1].distance = map[nowY, nowX].distance + 1;
						q.Enqueue(map[nowY, nowX + 1]);
						found[nowY, nowX + 1] = true;
					}
				}
			}


			Console.WriteLine(map[4, 4].distance);
		}
		#endregion



	}

	struct node
	{
		public int id;
		public int x;
		public int y;
		public int[] IsValid;
		public int distance;
		public int perent;
	}
}

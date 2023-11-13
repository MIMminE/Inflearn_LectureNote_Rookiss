using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section3
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

		static public int[,] adjacent2 = new int[6,6]
		{
		    { 0, 1, 0, 1, 0, 0 },
            { 1, 0, 1, 1, 0, 0 },
            { 0, 1, 0, 0, 0, 0 },
            { 1, 1, 0, 1, 0, 0 },
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

			for(int next = 0; next < adjacent2.GetLength(0); next++)
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

        bool[] found = new bool[6];
        public void BFS(int start)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            found[start] = true;

            while(q.Count > 0)
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
    }
}

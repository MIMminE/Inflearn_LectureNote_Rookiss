using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section_3.src
{
	class Dijkstra
	{
		//Dijkstra 알고리즘은 간선에 가중치가 포함되어 있다.
		static public int[,] adjacent = new int[6, 6]
		{
			{ -1, 15, -1, 35, -1, -1 },
			{ 15, -1, 05, 10, -1, -1 },
			{ -1, 05, -1, -1, -1, -1 },
			{ 35, 10, -1, -1, 05, -1 },
			{ -1, -1, -1, 05, -1, 05 },
			{ -1, -1, -1, -1, 05, -1 }
		};
		static public void SearchDijkstra(int start)
		{
			bool[] visited = new bool[6];
			int[] distance = new int[6];
			int[] parent = new int[6];
			Array.Fill<int>(distance, Int32.MaxValue);

			distance[start] = 0;
			parent[start] = start;
			// Dijkstra 방식은 distance를 확인하여 예약 여부를 확인한다.

			while (true)
			{
				// 제일 좋은 후보를 찾는다. (가장 가까운 후보)

				// 가장 가까운 후보를 저장하는 거리와 정점을 기록할 변수들
				int closest = Int32.MaxValue;
				int now = -1;
				for (int i = 0; i < 6; i++)
				{
					// 이미 방문 정점은 스킵
					if (visited[i]) continue;
					// 아직 예약된 적이 없거나, 기존 후보보다 멀리 있으면 스킵
					if (distance[i] == Int32.MaxValue || distance[i] >= closest) continue;
					// 정보 갱신, 여태 발견한 후보 중 가장 좋은 후보라는 의미
					closest = distance[i];
					now = i;
		
					/* 여러 정보 중 어떤 기준에 부합한 가장 좋은 정보를 탐색하는 방식으로 
					 * 자주 사용되는 방식이다. for문이 끝나게 되면 가장 좋은 값만 
					 * closet과 now에 저장된다.
					 */
				}

				// 다음 후보가 없거나 연결된 간선이 없다는 의미
				if (now == -1)
					break;

				visited[now] = true;

				// 방문한 정점과 인접한 정점들을 조사하여
				// 상황에 따라 발견한 최단거리를 갱신한다.
				for (int next = 0; next < 6; next++)
				{
					// 정점이 연겯되어 있지 않다면 스킵
					if (adjacent[now, next] == -1) 
						continue;
					// 이미 방문한 정점이면 스킵
					if (visited[next]) continue;

					// 새로 조사된 정점의 최단거리 계산
					int nextDistance = distance[now] + adjacent[now, next];

					// 계산된 해당 정점으로의 최단거리가 기존의 거리보다 작으면 업데이트 진행
					if (nextDistance < distance[next])
					{
						distance[next] = nextDistance;
						parent[next] = now;
					}
				}
			}
		}
	}
}

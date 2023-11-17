using Section_3.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Section_3.src
{
	class TreeNode<T>
	{
		public T Value { get; set; }
		public List<TreeNode<T>> ChildList { get; set; } = new List<TreeNode<T>>();
		// 아래 방향으로만 진행되는 트리의 구조상 부모의 메모리 주소를 저장하지 않는다.
	}

	class TreeTest
	{
		static public TreeNode<String> CreateTreeNode()
		{
			TreeNode<String> root = new TreeNode<String>()
			{
				Value = "R1 개발실",
				ChildList = 
				{
					new TreeNode<String>() { Value = "디자인팀",
						ChildList =
						{
							new TreeNode<String>() {Value="전투"},
							new TreeNode<String>() {Value="경제"},
							new TreeNode<String>() {Value="스토리"}
						}
					},
					new TreeNode<String>() { Value = "프로그래밍팀",
						ChildList =
						{
							new TreeNode<String>() {Value="서버"},
							new TreeNode<String>() {Value="클라"},
							new TreeNode<String>() {Value="엔진"}
						}
					},
					new TreeNode<String>() { Value = "아트팀",
						ChildList =
						{
							new TreeNode<String>() {Value="배경"},
							new TreeNode<String>() {Value="캐릭터"},
						}
					}
				}
			};
			return root; 
		}

		// 서브트리의 개념이 있어 재귀함수를 사용하면 쉽게 구현이 가능하다.
		static public void PrintTree(TreeNode<String> root)
		{
            Console.WriteLine(root.Value);
			
			foreach (var child in root.ChildList)
			{
				PrintTree(child);
			}
        }
		
		// 트리의 높이를 반환하는 기능 구현, 재귀함수를 사용하면 편리하다.
		static public int GetHeight(TreeNode<String> root)
		{
			int height = 0;
			foreach(var child in root.ChildList)
			{
				int newHeight = GetHeight(child) + 1;
				height = Math.Max(height, newHeight);
			}

			return height;
		}
	}
}

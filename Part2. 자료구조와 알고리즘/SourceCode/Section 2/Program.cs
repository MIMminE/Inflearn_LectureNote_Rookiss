using Section_2.src;

namespace Section_2
{
	class Program
	{
		const int WAIT_TICK = 1000 / 30;
		static void Main(string[] args)
		{
			Board _board = new Board();
			Player player = new Player();
			_board.InitSidWinder(25, player);
			player.Initialize(1, 1, _board.Size - 2, _board.Size - 2, _board);

			int lastTick = 0;
			while (true)
			{
				#region 프레임 관리 
				int currentTick = System.Environment.TickCount;
				if (currentTick - lastTick < WAIT_TICK)
					continue;
				int deltaTick = currentTick - lastTick;
				lastTick = currentTick;
				#endregion

				// 로직
				player.Update(deltaTick);

				// 렌더링
				_board.Render();
			}
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore
{
	// 클라이언트의 요청이 Accept 되면 둘 사이에 하나의 Session이 생성되어 데이터 통신이 가능해진다. 
	class Session
	{
		Socket _socket;
		int _disconnect = 0;
		
		public void init(Socket socket)
		{
			_socket = socket;

			SocketAsyncEventArgs revArgs = new SocketAsyncEventArgs();
			revArgs.Completed += new EventHandler<SocketAsyncEventArgs>(OnReceiveCompleted);
			revArgs.SetBuffer(new byte[1024], 0, 1024); // 경우에 따라 크게 만들어놓고 쪼개서 사용하기도 함
			// 비동기 Receive 작업에서 사용되는 버퍼 셋팅

			RegisterReceive(revArgs);
		}

		void RegisterReceive(SocketAsyncEventArgs revArgs)
		{
			bool pending = _socket.ReceiveAsync(revArgs);
			if (pending == false) OnReceiveCompleted(null, revArgs);
		}

		void OnReceiveCompleted(object sender, SocketAsyncEventArgs revArgs)
		{
			// 연결이 끊기거나 하는 경우에 0바이트를 수신받기도 한다.
			if (revArgs.BytesTransferred > 0 && revArgs.SocketError == SocketError.Success)
			{
				try
				{
					string receData = Encoding.UTF8.GetString(revArgs.Buffer, revArgs.Offset, revArgs.BytesTransferred);
					Console.WriteLine($"[From Client] : {receData}");
					RegisterReceive(revArgs);
				} catch (Exception e)
				{
                    Console.WriteLine($"OnReceiveCompleted Failed : {e}");
                }
			}
			else
			{
				Disconnect();
			}
		}

		public void Disconnect()
		{
			if (Interlocked.Exchange(ref _disconnect, 1) == 1) return;
			_socket.Shutdown(SocketShutdown.Both);
			_socket.Close();
		}
	}
}

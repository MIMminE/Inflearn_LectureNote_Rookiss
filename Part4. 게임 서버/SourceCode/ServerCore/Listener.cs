using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore
{
    class Listener
    {
        Socket _listenSocket;
        Action<Socket> _onAcceptHandler; // 매개변수로 받을 함수의 매개변수를 Socket으로 받게다는 의미

        public void init(IPEndPoint endPoint, Action<Socket> onAcceptHandler)
        {
            // 문지기 생성
            _listenSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            

            // 문지기 교육
            _listenSocket.Bind(endPoint);
            // 영업시작, 최대 대기수 10명
            _listenSocket.Listen(10);

            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.Completed += new EventHandler<SocketAsyncEventArgs>(OnAcceptCompleted);
            //비동기 작업이 완료되면 호출되는 메소드 등록
            RegisterAccept(args);
        }

        void RegisterAccept(SocketAsyncEventArgs args)
        {
            args.AcceptSocket = null; // 이전의 소켓을 지우고 진행

            bool pending = _listenSocket.AcceptAsync(args); 
            if (pending == false) OnAcceptCompleted(null, args); // 우연찮게 통신 시도하자마자 바로 허가된 상황
        }

        void OnAcceptCompleted(object sender, SocketAsyncEventArgs args)
        {
            if (args.SocketError == SocketError.Success)
            {
                _onAcceptHandler.Invoke(args.AcceptSocket);
            }
            else
                Console.WriteLine(args.SocketError.ToString());

            RegisterAccept(args); // 다음 사용자를 위해 재등록
        }

    }
}

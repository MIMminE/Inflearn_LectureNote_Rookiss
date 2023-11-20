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
            _onAcceptHandler += onAcceptHandler; // 핸들러 덮어쓰기가 아닌 핸들러에 추가 핸들러 등록하는 것

            // 문지기 교육
            _listenSocket.Bind(endPoint);
            // 영업시작, 최대 대기수 10명
            _listenSocket.Listen(10);

            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.Completed += new EventHandler<SocketAsyncEventArgs>(OnAcceptCompleted);
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


        public Socket Accept()
        {
            _listenSocket.AcceptAsync();

            //요청하는 부분과 실제 처리되는 부분을 분리해야한다.
            return _listenSocket.Accept(); //blocking 계열 함수는 최대한 피해야 한다. 
        }
    }
}

using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerCore
{
    class Program
    {
        static void OnAcceptHandler(Socket clientSocket)
        {
            try
            {
                // 받는다.
                byte[] recvBuff = new byte[1024];
                int receByte = clientSocket.Receive(recvBuff);
                // 몇 Byte를 받았는지 반환해준다.
                string receData = Encoding.UTF8.GetString(recvBuff, 0, receByte);
                Console.WriteLine($"From Client : {receData}");
                // Socket 통신은 기본적으로 Byte 단위이므로 인코딩 과정이 필요하다. 

                // 보낸다.
                byte[] sendBuffer = Encoding.UTF8.GetBytes("Welcome to MMO Server");
                clientSocket.Send(sendBuffer);

                // 쫒아낸다.
                clientSocket.Shutdown(SocketShutdown.Both); // 양측 데이터 전송 중단할 것을 의미
                clientSocket.Close(); // 실제 연결 끊음을 의미
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
        static void Main(string[] args)
        {
            // DNS
            string host = Dns.GetHostName();
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);

            Listener lintener = new Listener();
            // 문지기

            lintener.init(endPoint, OnAcceptHandler); // 앤드포인트와 소켓이 준비가 되면 이 함수를 실행시켜주라는 의미
            Console.WriteLine("Listening...");

            while (true)
            {
                ;  
            }
        }
    }
}